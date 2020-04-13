using DataAccess.DtoModels;
using DataAccess.Mappers;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public void Create(TransactionDto transactionDto)
        {
            Create(TransactionMapper.MapToTransaction(transactionDto));
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
                .Where(t => t.Date >= startDate && t.Date <= endDate && t.Asset.UserId == userId)
                .OrderBy(T => T.Date)
                .ToList();

            var transactionMonthReports = new List<TransactionMonthReport>();
            
            foreach (var group in transactions.GroupBy(t => new { t.Date.Month, t.Date.Year }))
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
                    Month = group.Key.Month,
                    Year = group.Key.Year
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
            List<CategoryWithAmount> categories = GetUsersCategories(userId);
            Dictionary<Category, int> CategoryGroups = new Dictionary<Category, int>();
            foreach (var category in MoneyManagerContext.Categories.Where(c => c.Type == categoryType))
            {
                CategoryGroups.Add(category, 0);
            }
            GroupByParentCategories(ref CategoryGroups);
            GetAmounts(CategoryGroups, ref categories);
            return categories;
        }

        private void GroupByParentCategories(ref Dictionary<Category, int> CategoryGroups)
        {
            List<Category> categoryGroup = new List<Category>();
            int groupNumber = 1;
            foreach (var item in CategoryGroups.ToArray())
            {
                var currentItem = item;
                if (item.Value == 0)
                {
                    while (currentItem.Key.ParentCategory != null && currentItem.Value == 0)
                    {
                        categoryGroup.Add(currentItem.Key);
                        currentItem = new KeyValuePair<Category, int>(currentItem.Key.ParentCategory, 0);
                    }
                    if (currentItem.Key.ParentCategory == null && currentItem.Value == 0)
                    {
                        CategoryGroups[currentItem.Key] = -groupNumber++;
                        foreach (var c in categoryGroup)
                        {
                            CategoryGroups[c] = groupNumber;
                        }
                    }
                    if (currentItem.Value != 0)
                    {
                        foreach (var c in categoryGroup)
                        {
                            CategoryGroups[c] = currentItem.Value;
                        }
                    }
                }
            }
        }

        private void GetAmounts(Dictionary<Category, int> CategoryGroups, ref List<CategoryWithAmount> categories)
        {
            foreach (var item in CategoryGroups)
            {
                if (item.Value < 0)
                {
                    if (!categories.Contains(CategoryMapper.MapToCategoryWithAmount(item.Key)))
                    {
                        if (item.Key.Transactions != null)
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
        }

        public List<CategoryWithAmount> GetUsersCategories(Guid userId)
        {
            return MoneyManagerContext.Transactions
                .Where(t => t.Asset.UserId == userId)
                .GroupBy(t => t.Category.Name)
                .Select(tg => new CategoryWithAmount
                {
                    Name = tg.Key,
                    Amount = tg.Sum(t => t.Amount)
                })
                .ToList();
        }
    }
}