using MoneyManager.Models;
using System;
using MoneyManager.ModelGenerator;
using MoneyManager;
using MoneyManager.UnitOfWork;

namespace Client
{
    public class Program
    {
        static void Main(string[] args)
        {
            UnitOfWork efUnit = new UnitOfWork(new MoneyManagerContext());

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

            Console.WriteLine("Deleting all bob's transactions for this month: ");
            efUnit.Transactions.DeleteAllTransactionsForMonth(bob.Id);

            Console.WriteLine("Get user by email(sara@gmail.com): ");
            Console.WriteLine(efUnit.Users.GetUserByEmail("sara@gmail.com").Name);

            Console.WriteLine("All users ordered by name: ");
            var users = efUnit.Users.GetAllUsersOrderByName();
            foreach (var user in users)
            {
                Console.WriteLine(user.Name);
            }

            Console.WriteLine("Bob's assets ordered by name: ");
            var assets = efUnit.Users.GetUsersAssetsOrderByName(bob.Id);
            foreach (var a in assets)
            {
                Console.WriteLine(a.Name);
            }

            Console.WriteLine("Bob's current balance: ");
            Console.WriteLine(efUnit.Users.GetCurrentBalance(bob.Id).Balance);

            efUnit.Save();
        }
    }
}
