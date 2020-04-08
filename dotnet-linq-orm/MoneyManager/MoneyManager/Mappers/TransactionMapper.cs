using DataAccess.DtoModels;
using DataAccess.Models;

namespace DataAccess.Mappers
{
    public class TransactionMapper
    {
        public static TransactionDto MapToTransactionDto (Transaction transaction)
        {
            return new TransactionDto
            {
                AssetName = transaction.Asset.Name,
                CategoryName = transaction.Category.Name,
                ParentCategoryName = transaction.Category.ParentCategory.Name,
                Date = transaction.Date,
                Comment = transaction.Comment
            };
        }
    }
}
