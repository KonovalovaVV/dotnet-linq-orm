using MoneyManager.ModelGenerator;
using MoneyManager.Models;

namespace MoneyManager
{
    public class DbGenerator
    {
        private const int UserAmount = 5;
        private const int AssetAmount = 20;
        private const int CategoryAmount = 10;
        private const int TransactionAmount = 100;

        public User[] DefaultUsers = new User[UserAmount];
        public Asset[] DefaultAssets = new Asset[AssetAmount];
        public Category[] DefaultCategories = new Category[CategoryAmount];
        public Transaction[] DefaultTransactions = new Transaction[TransactionAmount];

        public DbGenerator()
        {
            GenerateUsers();
            GenerateAssets();
            GenerateCategories();
            GenerateTransactions();
        }

        private void GenerateUsers()
        {
            for(int i = 0; i < UserAmount; i++)
            {
                DefaultUsers[i] = UserGenerator.GenerateUser();
            }
        }

        private void GenerateAssets()
        {
            for (int i = 0; i < AssetAmount; i++)
            {
                DefaultAssets[i] = AssetGenerator.GenerateAsset(DefaultUsers[i % UserAmount]);
            }
        }

        private void GenerateCategories()
        {
            for (int i = 0; i < CategoryAmount/2; i++)
            {
                DefaultCategories[i] = CategoryGenerator.GenerateCategory();
            }

            for (int i = CategoryAmount / 2; i < CategoryAmount; i++)
            {
                DefaultCategories[i] = CategoryGenerator.GenerateCategory(DefaultCategories[i % CategoryAmount/2]);
            }
        }

        private void GenerateTransactions()
        {
            for(int i = 0; i < TransactionAmount; i++)
            {
                DefaultTransactions[i] = TransactionGenerator
                    .GenerateTransaction(DefaultAssets[i % AssetAmount], DefaultCategories[i % CategoryAmount]);
            }
        }
    }
}
