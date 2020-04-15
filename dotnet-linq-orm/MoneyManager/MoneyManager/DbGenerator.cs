using DataAccess.ModelGenerator;
using DataAccess.Models;

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

        public static Category[] GetDefaultCategories()
        {
            Category[] categories = new Category[CategoryAmount];
            for (int i = 0; i < CategoryAmount / 2; i++)
            {
                categories[i] = CategoryGenerator.GenerateCategory();
            }

            for (int i = CategoryAmount / 2; i < CategoryAmount; i++)
            {
                categories[i] = CategoryGenerator.GenerateCategory(categories[i % CategoryAmount / 2]);
            }
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
