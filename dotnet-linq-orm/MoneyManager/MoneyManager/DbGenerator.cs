using DataAccess.ModelGenerator;
using DataAccess.Models;
using System;
using System.Collections.Generic;

namespace DataAccess
{
    public class DbGenerator
    {
        private const int UserAmount = 5;
        private const int AssetAmount = 20;
        private const int CategoryAmount = 10;
        private const int TransactionAmount = 100;

        public User[] Users = new User[UserAmount];
        public Asset[] Assets = new Asset[AssetAmount];
        public Category[] Categories = new Category[CategoryAmount];
        public Transaction[] Transactions = new Transaction[TransactionAmount];

        public DbGenerator()
        {
            GenerateUsers();
            GenerateAssets();
            GenerateCategories();
            GenerateTransactions();
        }

        public static List<Category> GetDefaultCategories()
        {
            List<Category> categories = new List<Category>();
            Category transport = new Category
            {
                Color = Convert.ToInt32("233D4D", 16),
                Name = "Transport",
                Id = Guid.NewGuid(),
                Type = CategoryType.Expense
            };
            categories.Add(transport);
            Category taxi = new Category
            {
                Color = Convert.ToInt32("233D4D", 16),
                Name = "Taxi",
                Id = Guid.NewGuid(),
                Type = CategoryType.Expense,
                ParentCategoryId = transport.Id
            };
            categories.Add(taxi);
            Category bus = new Category
            {
                Color = Convert.ToInt32("233D4D", 16),
                Name = "Bus",
                Id = Guid.NewGuid(),
                Type = CategoryType.Expense,
                ParentCategoryId = transport.Id
            };
            categories.Add(bus);
            Category food = new Category
            {
                Color = Convert.ToInt32("254B4D", 16),
                Name = "Food",
                Id = Guid.NewGuid(),
                Type = CategoryType.Expense
            };
            categories.Add(food);
            Category sweetFood = new Category
            {
                Color = Convert.ToInt32("233D4D", 16),
                Name = "Sweet",
                Id = Guid.NewGuid(),
                Type = CategoryType.Expense,
                ParentCategoryId = food.Id
            };
            categories.Add(sweetFood);
            Category chocolate = new Category
            {
                Color = Convert.ToInt32("233D4D", 16),
                Name = "Sweet",
                Id = Guid.NewGuid(),
                Type = CategoryType.Expense,
                ParentCategoryId = sweetFood.Id
            };
            categories.Add(chocolate);
            Category dairy = new Category
            {
                Color = Convert.ToInt32("233D4D", 16),
                Name = "Dairy products",
                Id = Guid.NewGuid(),
                Type = CategoryType.Expense,
                ParentCategoryId = food.Id
            };
            categories.Add(dairy);
            Category milk = new Category
            {
                Color = Convert.ToInt32("233D4D", 16),
                Name = "Milk",
                Id = Guid.NewGuid(),
                Type = CategoryType.Expense,
                ParentCategoryId = dairy.Id
            };
            categories.Add(milk);
            Category cheese = new Category
            {
                Color = Convert.ToInt32("233D4D", 16),
                Name = "Cheese",
                Id = Guid.NewGuid(),
                Type = CategoryType.Expense,
                ParentCategoryId = dairy.Id
            };
            categories.Add(cheese);
            return categories;
        }

        private void GenerateUsers()
        {
            for(int i = 0; i < UserAmount; i++)
            {
                Users[i] = UserGenerator.GenerateUser();
            }
        }

        private void GenerateAssets()
        {
            for (int i = 0; i < AssetAmount; i++)
            {
                Assets[i] = AssetGenerator.GenerateAsset(Users[i % UserAmount]);
            }
        }

        private void GenerateCategories()
        {
            for (int i = 0; i < CategoryAmount/2; i++)
            {
                Categories[i] = CategoryGenerator.GenerateCategory();
            }

            for (int i = CategoryAmount / 2; i < CategoryAmount; i++)
            {
                Categories[i] = CategoryGenerator.GenerateCategory(Categories[i % CategoryAmount/2]);
            }
        }

        private void GenerateTransactions()
        {
            for(int i = 0; i < TransactionAmount; i++)
            {
                Transactions[i] = TransactionGenerator
                    .GenerateTransaction(Assets[i % AssetAmount], Categories[i % CategoryAmount]);
            }
        }
    }
}
