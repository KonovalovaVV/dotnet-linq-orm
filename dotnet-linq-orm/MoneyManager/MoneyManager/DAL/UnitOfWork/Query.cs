using MoneyManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MoneyManager.DAL.UnitOfWork
{
    public class Query
    {
        private readonly MoneyManagerContext _moneyManagerContext;
        private readonly EFUnitOfWork _efUnit;

        public Query(EFUnitOfWork efUnit, MoneyManagerContext moneyManagerContext)
        {
            _efUnit = efUnit;
            _moneyManagerContext = moneyManagerContext;
        }

        // Write a command to delete all user's (parameter userId) transactions in the current month.
        public void DeleteAllUsersTransactionsForMonth(Guid UserId)
        {
            var transactions = from t in _moneyManagerContext.Transactions
                               join a in _moneyManagerContext.Assets on t.AssetId equals a.Id
                               where a.UserId == UserId && t.Date.Day == DateTime.Now.Day
                               select new { t.Id };
            foreach (var item in transactions)
            {
                _efUnit.Transactions.Delete(item.Id);
            }
        }

        // Write a request to get the user by email.
        public User GetUserByEmail(string email)
        {
            return _moneyManagerContext.Users.Where(u => u.Email == email).First();
        }

        // Write a query to get the user list sorted by the user’s name.
        // Each record of the output model should include
        // User.Id, User.Name and User.Email.
        public IEnumerable<User> GetAllUsersOrderByName()
        {
            return _moneyManagerContext.Users.OrderBy(u => u.Name);
        }

        // Write a query to return the current balance for the selected user(parameter userId).
        // Each record of the output model should include User.Id, User.Email, User.Name, and Balance.
        public decimal GetCurrentBalance(Guid userId)
        {
            User user = _efUnit.Users.Get(userId);
            decimal result = 0;
            foreach (var asset in user.Assets) 
            {
                foreach(var transaction in asset.Transactions)
                {
                    if (_efUnit.Categories.Get(transaction.CategoryId).Type == CategoryType.Income)
                    {
                        result += transaction.Amount;
                    }
                }
            }

            return result;
        }

        // Write a query to get the asset list for the selected user (userId) 
        // ordered by the asset’s name.
        // Each record of the output model should include Asset.Id, Asset.Name and Balance.
        public IEnumerable<Asset> GetUsersAssetsOrderByName(Guid userId)
        {
            return _efUnit.Users.Get(userId).Assets.OrderBy(a => a.Name);
        }

        // Write a query to return the transaction list for the selected user(userId) 
        // ordered descending by Transaction.Date, then ordered ascending by Asset.Name 
        // and then ordered ascending by Category.Name.
        // Each record of the output model should include Asset.Name, 
        // Category.Name (transaction subcategory), 
        // Category.ParentName (transaction parent category),
        // Transaction.Amount, Transaction.Date and Transaction.Comment.
        public List<Transaction> GetUsersTransactions(Guid userId)
        {
            User user = _efUnit.Users.Get(userId);
            List<Transaction> transactions = new List<Transaction>();
            foreach (var asset in user.Assets)
            {
                transactions.AddRange(asset.Transactions);
            }
            transactions.OrderByDescending(t => t.Date).ThenBy(t => _efUnit.Assets.Get(t.AssetId).Name)
                .ThenBy(t => _efUnit.Categories.Get(t.CategoryId).Name);
            return transactions;
        }

        // Write a query to return the total value of income and expenses 
        // for the selected period(parameters userId, startDate, endDate) 
        // ordered by Transaction.Date and grouped by month.
        // Each record of the output model should include total Income and Expenses, Month and Year.
        public decimal GetTotalValue(Guid userId, DateTime startDate, DateTime endDate)
        {
            List<Transaction> transactions = GetUsersTransactions(userId)
                                            .Where(t => t.Date > startDate && t.Date < endDate).ToList();
            return transactions.Sum(t => t.Amount);
        }

        // Write a query to return the total amount of all parent categories 
        // for the selected type of operation(Income or Expenses).
        // The result should include only categories that have transactions in the current month.
        // Input parameters in this query are UserId and OperationType(category type). 
        // Each record of the output model should include Category.Name and Amount.
        // In addition, you should order results descending by Transaction.Amount 
        // and then ordered them by Category.Name.
        public int GetParentCategoryAmount(Guid userId, CategoryType type)
        {
            User user = _efUnit.Users.Get(userId);
            var currentMonthTransactions = GetUsersTransactions(userId).Where(t => t.Date.Month == DateTime.Now.Month);
            var currentMonthCategoriesId = currentMonthTransactions.Select(t => t.CategoryId);
            List<Category> categories = new List<Category>();
            foreach(var categoryId in currentMonthCategoriesId)
            {
                categories.Add(_efUnit.Categories.Get(categoryId));
            }
            return categories.Distinct().Count(c => c.ParentCategoryId != null);
        }
    }
}
