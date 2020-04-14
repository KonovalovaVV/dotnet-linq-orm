using DataAccess.DtoModels;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Mappers
{
    public class TransactionMapper
    {
        public static TransactionWithParentCategoryDto MapToTransactionWithParentCategoryDto(Transaction transaction)
        {
            return new TransactionWithParentCategoryDto
            {
                AssetName = transaction.Asset.Name,
                CategoryName = transaction.Category.Name,
                Date = transaction.Date,
                Comment = transaction.Comment,
                ParentCategoryName = transaction.Category.ParentCategory?.Name
            };
        }

        public static TransactionDto MapToTransactionDto(Transaction transaction)
        {
            return new TransactionDto
            {
                Amount = transaction.Amount,
                AssetId = transaction.AssetId,
                CategoryId = transaction.CategoryId,
                Date = transaction.Date,
                Comment = transaction.Comment
            };
        }

        public static IEnumerable<TransactionWithParentCategoryDto> MapToTransactionWithParentCategoryDto(IEnumerable<Transaction> transactions)
        {
            return transactions.Select(MapToTransactionWithParentCategoryDto);
        }

        public static Transaction MapToTransaction(TransactionDto transactionDto)
        {
            return new Transaction
            {
                Id = Guid.NewGuid(),
                Date = transactionDto.Date,
                Amount = transactionDto.Amount,
                Comment = transactionDto.Comment,
                AssetId = transactionDto.AssetId,
                CategoryId = transactionDto.CategoryId
            };
        }
    }
}
