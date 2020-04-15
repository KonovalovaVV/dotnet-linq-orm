using DataAccess.ModelGenerator;
using DataAccess.Models;
using Infrastructure;
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
                Color = ColorHelper.GetColor("4345AA"),
                Name = "Transport",
                Id = Guid.Parse("4C4A99E9-3F0D-450F-9180-E786F0CBAFA7"),
                Type = CategoryType.Expense
            };
            categories.Add(transport);
            Category taxi = new Category
            {
                Color = ColorHelper.DefaultColor,
                Name = "Taxi",
                Id = Guid.Parse("1CA32810-BA58-4D47-9E94-492472C75BDD"),
                Type = CategoryType.Expense,
                ParentCategoryId = transport.Id
            };
            categories.Add(taxi);
            Category bus = new Category
            {
                Color = ColorHelper.DefaultColor,
                Name = "Bus",
                Id = Guid.Parse("D06A9F94-D766-45AD-BC57-DC48CC719BA7"),
                Type = CategoryType.Expense,
                ParentCategoryId = transport.Id
            };
            categories.Add(bus);
            Category food = new Category
            {
                Color = ColorHelper.DefaultColor,
                Name = "Food",
                Id = Guid.Parse("56F896AA-A12D-4E20-8775-C0E57D01F54C"),
                Type = CategoryType.Expense
            };
            categories.Add(food);
            Category sweetFood = new Category
            {
                Color = ColorHelper.DefaultColor,
                Name = "Sweet",
                Id = Guid.Parse("9DF955DD-9F5E-4A4B-8AC4-9D33A7AEA7B5"),
                Type = CategoryType.Expense,
                ParentCategoryId = food.Id
            };
            categories.Add(sweetFood);
            Category chocolate = new Category
            {
                Color = ColorHelper.DefaultColor,
                Name = "Sweet",
                Id = Guid.Parse("4CC2EADF-A102-4D76-931B-63A2B09A5617"),
                Type = CategoryType.Expense,
                ParentCategoryId = sweetFood.Id
            };
            categories.Add(chocolate);
            Category dairy = new Category
            {
                Color = ColorHelper.DefaultColor,
                Name = "Dairy products",
                Id = Guid.Parse("371FFC12-C8FE-421E-82CD-0F2D532B4F70"),
                Type = CategoryType.Expense,
                ParentCategoryId = food.Id
            };
            categories.Add(dairy);
            Category milk = new Category
            {
                Color = ColorHelper.DefaultColor,
                Name = "Milk",
                Id = Guid.Parse("6F2E8917-055A-4E08-A4D5-B279FB12CC20"),
                Type = CategoryType.Expense,
                ParentCategoryId = dairy.Id
            };
            categories.Add(milk);
            Category cheese = new Category
            {
                Color = ColorHelper.DefaultColor,
                Name = "Cheese",
                Id = Guid.Parse("1E884FBA-2FDA-40AA-8AA2-0E47331C8A31"),
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
