using DataAccess.DtoModels;
using DataAccess.Mappers;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace DataAccess.Repository
{
    public class TransactionRepository : BaseRepository<Transaction>
    {
        public TransactionRepository(MoneyManagerContext context) : base(context) { }

        public new TransactionWithParentCategoryDto Get(Guid transactionId)
        {
            var transaction = base.Get(transactionId);
            return TransactionMapper.MapToTransactionWithParentCategoryDto(transaction);
        }

        // Write a command to delete all user's (parameter userId) transactions in the current month.
        public void DeleteAllTransactionsForMonth(Guid userId)
        {
            var endDate = DateTime.Now;
            var startDate = endDate.Date.AddMonths(-1);
            var transactions = MoneyManagerContext.Transactions
                .Where(t => t.Date >= startDate && t.Date <= endDate && t.Asset.UserId == userId);
            MoneyManagerContext.Transactions.RemoveRange(transactions);
        }

        // Write a query to return the transaction list for the selected user (userId) 
        // ordered descending by Transaction.Date, then ordered ascending by Asset.Name
        // and then ordered ascending by Category.Name.
        // Each record of the output model should include Asset.Name, Category.Name 
        // (transaction subcategory), Category.ParentName (transaction parent category), 
        // Transaction.Amount, Transaction.Date and Transaction.Comment.
        public List<TransactionWithParentCategoryDto> GetUsersTransactions(Guid userId)
        {
            var transactions = MoneyManagerContext.Transactions
                .Where(t => t.Asset.UserId == userId)
                .OrderByDescending(t => t.Date)
                .ThenBy(t => t.Asset.Name)
                .ThenBy(t => t.Category.Name);

            return TransactionMapper.MapToTransactionWithParentCategoryDto(transactions).ToList();
        }

        //  Write a query to return the total value of income and expenses 
        // for the selected period (parameters userId, startDate, endDate) 
        // ordered by Transaction.Date and grouped by month.
        // Each record of the output model should include total Income and Expenses, Month and Year.
        public List<TransactionMonthReport> GetTransactionMonthReports(Guid userId, DateTime startDate, DateTime endDate)
        {
            List<Transaction> transactions = MoneyManagerContext.Transactions
                .Where(t => t.Date >= startDate && t.Date <= endDate && t.Asset.UserId == userId).ToList();
            List<TransactionMonthReport> transactionMonthReports = new List<TransactionMonthReport>();
            foreach (var group in transactions.GroupBy(t => t.Date.Month))
            {
                transactionMonthReports.Add(new TransactionMonthReport
                {
                    TotalExpense = group
                    .Where(t => t.Category.Type == CategoryType.Expense)
                    .Select(t => t.Amount)
                    .Sum(),
                    TotalIncome = group
                    .Where(t => t.Category.Type == CategoryType.Income)
                    .Select(t => t.Amount)
                    .Sum(),
                    Month = group.Key,
                    Year = group
                    .Select(t => t.Date.Year)
                    .FirstOrDefault()
                });
            }
            return transactionMonthReports;
        }

        // Write a query to return the total amount 
        // of all parent categories for the selected type of operation(Income or Expenses). 
        // The result should include only categories that have transactions in the current month.
        // Input parameters in this query are UserId and OperationType(category type). 
        // Each record of the output model should include Category.Name and Amount.
        // In addition, you should order results descending by Transaction.Amount 
        // and then ordered them by Category.Name.
        public List<CategoryWithAmount> GetTotalAmountOfType(Guid userId, CategoryType categoryType)
        {
            List<CategoryWithAmount> categories = new List<CategoryWithAmount>();
            Dictionary<Category, int> DSU = new Dictionary<Category, int>();
            foreach(var category in MoneyManagerContext.Categories.Where(c=>c.Type == categoryType))
            {
                DSU.Add(category, 0);
            }
            KeyValuePair<Category, int> currentItem;
            List<Category> way = new List<Category>();
            int colors = 1;
            foreach(KeyValuePair<Category,int> item in DSU.ToArray())
            {
                currentItem = item;
                if(item.Value == 0)
                {
                    while (currentItem.Key.ParentCategory != null && currentItem.Value == 0)
                    {
                        way.Add(currentItem.Key);
                        currentItem = new KeyValuePair<Category, int>(currentItem.Key.ParentCategory, 0); 
                    }
                    if (currentItem.Key.ParentCategory == null && currentItem.Value == 0)
                    {
                        DSU[currentItem.Key] = -colors++;
                        foreach(var c in way)
                        {
                            DSU[c] = colors;
                        }
                    }
                    if (currentItem.Value != 0)
                    {
                        foreach (var c in way)
                        {
                            DSU[c] = currentItem.Value;
                        }
                    }
                }
            }
            foreach(var item in DSU)
            {
                if (item.Value < 0)
                {
                    if (!categories.Contains(CategoryMapper.MapToCategoryWithAmount(item.Key)))
                    {
                        if(item.Key.Transactions != null)
                        categories.Add(new CategoryWithAmount
                        {
                            Name = item.Key.Name,
                            Amount = item.Key.Transactions
                            .Select(t => t.Amount)
                            .Sum()
                        });
                        else
                        {
                            categories.Add(new CategoryWithAmount
                            {
                                Name = item.Key.Name,
                                Amount = 0
                            });
                        }
                    }
                    else
                    {
                        categories.Find(c => c.Name == item.Key.Name).Amount +=
                            item.Key.Transactions
                            .Select(t => t.Amount)
                            .Sum();
                    }
                }
                else
                {
                    if (categories.Contains(CategoryMapper.MapToCategoryWithAmount(item.Key.ParentCategory)))                     
                    {
                        if (item.Key.Transactions != null)
                        {
                            categories.Find(c => c.Name == item.Key.ParentCategory.Name).Amount +=
                                item.Key.Transactions
                                .Select(t => t.Amount)
                                .Sum();
                        }
                    }
                    else
                    {
                        if (item.Key.Transactions != null)
                        {
                            categories.Add(new CategoryWithAmount
                            {
                                Name = item.Key.ParentCategory.Name,
                                Amount = item.Key.Transactions
                            .Select(t => t.Amount)
                            .Sum()
                            });
                        }
                    }
                }
            }
            return categories;
        }
    }
}
