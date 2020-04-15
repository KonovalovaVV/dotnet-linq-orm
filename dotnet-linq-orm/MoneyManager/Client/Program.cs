using DataAccess.Models;
using System;
using DataAccess.UnitOfWork;
using DataAccess.DtoModels;

namespace Client
{
    public class Program
    {
        static void Main(string[] args)
        {
            UnitOfWork efUnit = new UnitOfWork();

            UserDto bob = new UserDto
            {
                Id = Guid.NewGuid(),
                Name = "Bob",
                Email = "bob@gmail.com",
            };
            AssetDto asset = new AssetDto
            {
                Id = Guid.NewGuid(),
                Name = "Bob's asset",
                UserId = bob.Id
            };
            CategoryDto incomeCategory = new CategoryDto
            {
                Id = Guid.NewGuid(),
                Name = "Bob's job",
                Type = CategoryType.Income,
                Color = Convert.ToInt32("233D4D", 16)
            };
            CategoryDto incomeSubCategory = new CategoryDto
            {
                Id = Guid.NewGuid(),
                Name = "Bob's secret job",
                Type = CategoryType.Income,
                Color = incomeCategory.Color,
                ParentCategoryId = incomeCategory.Id
            };
            CategoryDto expenseCategory = new CategoryDto
            {
                Id = Guid.NewGuid(),
                Color = Convert.ToInt32("233D4D", 16),
                Name = "Sport",
                Type = CategoryType.Expense
            };
            efUnit.Users.Create(bob);
            efUnit.Assets.Create(asset);
            efUnit.Categories.Create(expenseCategory);
            efUnit.Categories.Create(incomeCategory);
            efUnit.Categories.Create(incomeSubCategory);

            TransactionDto[] bobsTransactions = new TransactionDto[8];
            for (int i = 0; i < 4; i++)
            {
                bobsTransactions[i] = new TransactionDto
                {
                    CategoryId = incomeCategory.Id,
                    AssetId = asset.Id,
                    Amount = (decimal)new Random().NextDouble(),    
                    Date = DateTime.Now,
                    Comment = "bob is best"
                };
                efUnit.Transactions.Create(bobsTransactions[i]);
            }
            for (int i = 4; i < 8; i++)
            {
                bobsTransactions[i] = new TransactionDto
                {
                    CategoryId = incomeCategory.Id,
                    AssetId = asset.Id,
                    Amount = (decimal)new Random().NextDouble(),
                    Date = DateTime.Now,
                    Comment = "bob..."
                };
                efUnit.Transactions.Create(bobsTransactions[i]);
            }
            efUnit.Save();
            Console.WriteLine("Saved successfully.");

            Console.WriteLine("All bob's transactions: ");
            foreach (var tr in efUnit.Transactions.GetUsersTransactions(bob.Id))
            {
                Console.WriteLine(tr.Comment);
            }

            Console.WriteLine("Deleting all bob's transactions for this month: ");
            efUnit.Transactions.DeleteAllTransactionsForMonth(bob.Id);

            Console.WriteLine("Get user by email(bob@gmail.com): ");
            Console.WriteLine(efUnit.Users.GetUserByEmail("bob@gmail.com").Name);

            Console.WriteLine("All users ordered by name: ");
            var users = efUnit.Users.GetAllUsersOrderByName();
            foreach (var user in users)
            {
                Console.WriteLine(user.Name);
            }

            Console.WriteLine("Bob's assets ordered by name: ");
            var assets = efUnit.Assets.GetUsersAssets(bob.Id);
            foreach (var a in assets)
            {
                Console.WriteLine(a.Name);
            }

            Console.WriteLine("Bob's current balance: ");
            Console.WriteLine(efUnit.Users.GetCurrentBalance(bob.Id).Balance);

            Console.WriteLine("Transactions month report: ");
            var transactions = efUnit.Transactions
                .GetTransactionMonthReports(bob.Id, DateTime.MinValue, DateTime.MaxValue);
            foreach(var t in transactions)
            {
                Console.WriteLine("Expence: {0}; income: {1}; for {2}.{3}", t.TotalExpense, t.TotalIncome, t.Month, t.Year);
            }

            Console.WriteLine("Get total amount of incomes: ");
            var result = efUnit.Transactions.GetTotalAmountOfType(bob.Id, CategoryType.Income);
            foreach(var r in result)
            {
                Console.WriteLine("Name: {0}, Amount: {1}", r.Name, r.Amount);
            }
            efUnit.Save();
        }
    }
}
