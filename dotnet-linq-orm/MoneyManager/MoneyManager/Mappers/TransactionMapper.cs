using DataAccess.DtoModels;
using DataAccess.Models;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Mappers
{
    public class TransactionMapper
    {
        public static TransactionDto MapToTransactionDto (Transaction transaction)
        {
            string parentCategoryName = null;
            if(transaction.Category.ParentCategory != null)
            {
                parentCategoryName = transaction.Category.ParentCategory.Name;
            }
            return new TransactionDto
            {
                AssetName = transaction.Asset.Name,
                CategoryName = transaction.Category.Name,
                Date = transaction.Date,
                Comment = transaction.Comment,
                ParentCategoryName = parentCategoryName
            };
        }

        public static IEnumerable<TransactionDto> MapToTransactionDto(IEnumerable<Transaction> transactions)
        {
            return transactions.Select(x => MapToTransactionDto(x));
        }
    }
}
