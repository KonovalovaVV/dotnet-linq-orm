using DataAccess.DtoModels;
using DataAccess.Mappers;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;  

namespace DataAccess.Repository
{
    public class UserRepository : BaseRepository<User>
    {
        public UserRepository(MoneyManagerContext context) : base(context) { }

        public new UserDto Get(Guid userId)
        {
            var user = base.Get(userId);
            return UserMapper.MapToUserDto(user);
        }

        // Write a request to get the user by email.
        public User GetUserByEmail(string email)
        {
            return MoneyManagerContext.Users.FirstOrDefault(u => u.Email == email);
        }

        // Write a query to get the user list sorted by the user’s name.
        // Each record of the output model should include
        // User.Id, User.Name and User.Email.
        public IEnumerable<UserDto> GetAllUsersOrderByName()
        {
            return UserMapper.MapToUserDto(MoneyManagerContext.Users.OrderBy(u => u.Name));
        }

        // Write a query to return the current balance for the selected user(parameter userId).
        // Each record of the output model should include User.Id, User.Email, User.Name, and Balance.
        public UserBalanceDto GetCurrentBalance(Guid userId)
        {
            return UserMapper.MapToUserBalanceDto(base.Get(userId));
        }

        // Write a query to get the asset list for the selected user (userId) 
        // ordered by the asset’s name.
        // Each record of the output model should include Asset.Id, Asset.Name and Balance.
        public IEnumerable<AssetDto> GetUsersAssetsOrderByName(Guid userId)
        {
            return AssetMapper.MapToAssetDto(base.Get(userId).Assets).OrderBy(a => a.Name);
        }

        // Write a command to delete all user's (parameter userId) transactions in the current month.
        public void DeleteAllTransactionsForMonth(Guid userId)
        {
            foreach (var asset in base.Get(userId).Assets)
            {
                MoneyManagerContext.Transactions.RemoveRange(asset.Transactions);
            }
        }

        // Write a query to return the transaction list for the selected user (userId) 
        // ordered descending by Transaction.Date, then ordered ascending by Asset.Name
        // and then ordered ascending by Category.Name.
        // Each record of the output model should include Asset.Name, Category.Name 
        // (transaction subcategory), Category.ParentName (transaction parent category), 
        // Transaction.Amount, Transaction.Date and Transaction.Comment.
        public List<TransactionDto> GetUsersTransactions(Guid userId)
        {
            List<TransactionDto> transactions = new List<TransactionDto>();
            foreach (var asset in base.Get(userId).Assets)
            {
                transactions.AddRange(TransactionMapper.MapToTransactionDto(asset.Transactions));
            }
            return transactions.OrderByDescending(t => t.Date).ThenBy(t => t.AssetName).ThenBy(t => t.CategoryName).ToList();
        }

        //  Write a query to return the total value of income and expenses 
        // for the selected period (parameters userId, startDate, endDate) 
        // ordered by Transaction.Date and grouped by month.
        // Each record of the output model should include total Income and Expenses, Month and Year.
        public List<TransactionMonthReport> GetTransactionMonthReports(Guid userId, DateTime startDate, DateTime endDate)
        {
            List<Transaction> transactions = new List<Transaction>();
            foreach (var asset in base.Get(userId).Assets)
            {
                transactions.AddRange(asset.Transactions);
            }
            List<TransactionMonthReport> transactionMonthReports = new List<TransactionMonthReport>();
            foreach(var group in transactions.GroupBy(t => t.Date.Month))
            {
                transactionMonthReports.Add(new TransactionMonthReport
                {
                    TotalExpence = group.Where(t => t.Category.Type == CategoryType.Expense).Select(t => t.Amount).Sum(),
                    TotalIncome = group.Where(t => t.Category.Type == CategoryType.Income).Select(t => t.Amount).Sum(),
                    Month = group.Key,
                    Year = group.Select(t => t.Date.Year).FirstOrDefault()
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
        public List<CategoryDto> GetTotalAmountOfType(Guid userId, CategoryType categoryType)
        {
            List<Transaction> transactions = new List<Transaction>();
            foreach (var asset in base.Get(userId).Assets)
            {
                transactions.AddRange(asset.Transactions.Where(t=>t.Category.Type == categoryType));
            }
            List<CategoryDto> categories = new List<CategoryDto>();
            var groupedParentTransactions = transactions
                .Where(t => t.Category.ParentCategory == null).GroupBy(t => t.Category);
            var groupedNotParentTransactions = transactions
                .Where(t => t.Category.ParentCategory != null).GroupBy(t => t.Category);
            foreach(var group in groupedParentTransactions)
            {
                categories.Add(new CategoryDto
                {
                    Amount = group.Select(g => g.Amount).Sum(),
                    Name = group.Key.Name
                });
            }
            foreach(var group in groupedNotParentTransactions)
            {
                categories.Find(c => c.Name == group.Key.ParentCategory.Name).Amount += group.Select(g => g.Amount).Sum();
            }
            return categories;
        }

    }
}
