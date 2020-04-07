using MoneyManager.DTO;
using MoneyManager.Models;

namespace MoneyManager.Mappers
{
    public class TransactionMapper
    {
        public static TransactionDTO MapTransactionDTO
            (Transaction transaction, string assetName, string categoryName, string parentCategoryName)
        {
            return new TransactionDTO
            {
                AssetName = assetName,
                CategoryName = categoryName,
                ParentCategoryName = parentCategoryName,
                Date = transaction.Date,
                Comment = transaction.Comment
            };
        }
    }
}
