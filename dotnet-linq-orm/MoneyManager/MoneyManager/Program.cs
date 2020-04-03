using MoneyManager.Models;
using System;
using MoneyManager.DAL.UnitOfWork;
using MoneyManager.ModelGenerator;

namespace MoneyManager
{
    class Program
    {
        static void Main(string[] args)
        {
            EFUnitOfWork efUnit = new EFUnitOfWork(new MoneyManagerContext());
            User bob = new User
            {
                Id = Guid.NewGuid(),
                Name = "Bob",
                Email = "bob@gmail.com",
                Hash = "456",
                Salt = "765"
            };
            Asset asset = new Asset
            {
                Id = Guid.NewGuid(),
                Name = "Bob's asset",
                UserId = bob.Id
            };
            Category incomeCategory = new Category
            {
                Id = Guid.NewGuid(),
                Name = "Transport",
                Type = CategoryType.Income
            };
            Category expenceCategory = new Category
            {
                Id = Guid.NewGuid(),
                Name = "Transport",
                Type = CategoryType.Expense
            };
            efUnit.Users.Create(bob);
            efUnit.Assets.Create(asset);
            efUnit.Categories.Create(expenceCategory);
            efUnit.Categories.Create(incomeCategory);
            Transaction[] bobsTransactions = new Transaction[8];
            for (int i = 0; i < 4; i++)
            {
                bobsTransactions[i] = TransactionGenerator.GenerateTransaction(asset, incomeCategory);
                bobsTransactions[i].Comment = "bob is best";
                efUnit.Transactions.Create(bobsTransactions[i]);
            }
            for (int i = 4; i < 8; i++)
            {
                bobsTransactions[i] = TransactionGenerator.GenerateTransaction(asset, expenceCategory);
                bobsTransactions[i].Comment = "bob...";
                efUnit.Transactions.Create(bobsTransactions[i]);
            }
            efUnit.Save();
            Console.WriteLine("Saved successfully.");

            Console.WriteLine("Get user by email(sara@gmail.com): ");
            Console.WriteLine(efUnit.query.GetUserByEmail("sara@gmail.com").Name);

            Console.WriteLine("All users ordered by name: ");
            var users = efUnit.query.GetAllUsersOrderByName();
            foreach (var user in users)
            {
                Console.WriteLine(user.Name);
            }
            
            Console.WriteLine("Bob's assets ordered by name: ");
            var assets = efUnit.query.GetUsersAssetsOrderByName(bob.Id);
            foreach (var a in assets)
            {
                Console.WriteLine(a.Name);
            }

            Console.WriteLine("Bob's transactions: ");
            var transactions = efUnit.query.GetUsersTransactions(bob.Id);
            foreach (var t in transactions)
            {
                Console.WriteLine("Id: {0} Amount: {1}", t.Id, t.Amount);
            }

            Console.WriteLine("Bob's total value: ");
            Console.WriteLine(efUnit.query.GetTotalValue(bob.Id, DateTime.MinValue, DateTime.Now));

            Console.WriteLine("Bob's current balance: ");
            Console.WriteLine(efUnit.query.GetCurrentBalance(bob.Id));

            Console.WriteLine("Deleting all bob's transactions for this month: ");
            efUnit.query.DeleteAllUsersTransactionsForMonth(bob.Id);
            efUnit.Save();
            if (efUnit.query.GetUsersTransactions(bob.Id).Count == 0)
            {
                Console.WriteLine("Deleted successfully");
            }
        }
    }
}
