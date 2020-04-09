using DataAccess.Models;
using System;
using DataAccess.ModelGenerator;
using DataAccess;
using DataAccess.UnitOfWork;
using Microsoft.EntityFrameworkCore;

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
                Name = "Bob's job",
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

            Console.WriteLine("All bob's transactions: ");
            foreach (var tr in efUnit.Users.GetUsersTransactions(bob.Id))
            {
                Console.WriteLine(tr.Comment);
            }

            Console.WriteLine("Deleting all bob's transactions for this month: ");
            efUnit.Users.DeleteAllTransactionsForMonth(bob.Id);

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

            Console.WriteLine("Transactions month report: ");
            var transactions = efUnit.Users.GetTransactionMonthReports(bob.Id, DateTime.MinValue, DateTime.MaxValue);
            foreach(var t in transactions)
            {
                Console.WriteLine("Expence: {0}; income: {1}; month: {2}.", t.TotalExpence, t.TotalIncome, t.Month);
            }

            Console.WriteLine("Get total amount of incomes: ");
            var result = efUnit.Users.GetTotalAmountOfType(bob.Id, CategoryType.Income);
            foreach(var r in result)
            {
                Console.WriteLine("Name: {0}, Amount: {1}", r.Name, r.Amount);
            }
            efUnit.Save();
        }
    }
}
