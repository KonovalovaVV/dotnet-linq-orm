using MoneyManager.ModelGenerator;
using MoneyManager.Models;

namespace MoneyManager
{
    public class DbGenerator
    {
        private const int userAmount = 5;
        private const int assetAmount = 20;
        private const int categoryAmount = 10;
        private const int transactionAmount = 100;

        private static readonly User[] _defaultUsers = new User[userAmount];
        private static readonly Asset[] _defaultAssets = new Asset[assetAmount];
        private static readonly Category[] _defaultCategories = new Category[categoryAmount];
        private static readonly Transaction[] _defaultTransactions = new Transaction[transactionAmount];

        public static User[] GenerateUsers()
        {
            for(int i = 0; i < userAmount; i++)
            {
                _defaultUsers[i] = UserGenerator.GenerateUser();
            }
            return _defaultUsers;
        }

        public static Asset[] GenerateAssets()
        {
            for (int i = 0; i < assetAmount; i++)
            {
                _defaultAssets[i] = AssetGenerator.GenerateAsset(_defaultUsers[i % userAmount]);
            }
            return _defaultAssets;
        }

        public static Category[] GenerateCategories()
        {
            for (int i = 0; i < categoryAmount/2; i++)
            {
                _defaultCategories[i] = CategoryGenerator.GenerateCategory();
            }

            for (int i = categoryAmount / 2; i < categoryAmount; i++)
            {
                _defaultCategories[i] = CategoryGenerator.GenerateCategory(_defaultCategories[i % categoryAmount/2]);
            }
            return _defaultCategories;
        }

        public static Transaction[] GenerateTransactions()
        {
            for(int i = 0; i < transactionAmount; i++)
            {
                _defaultTransactions[i] = TransactionGenerator
                    .GenerateTransaction(_defaultAssets[i % assetAmount], _defaultCategories[i % categoryAmount]);
            }
            return _defaultTransactions;
        }
    }
}
