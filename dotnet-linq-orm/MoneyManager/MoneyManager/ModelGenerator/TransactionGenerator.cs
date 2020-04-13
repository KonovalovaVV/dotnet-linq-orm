using DataAccess.DtoModels;
using DataAccess.Models;
using System;

namespace DataAccess.ModelGenerator
{
    public static class TransactionGenerator
    {
        public static Transaction GenerateTransaction(Asset asset, Category category)
        {
            return new Transaction
            {
                Id = Guid.NewGuid(),
                CategoryId = category.Id,
                AssetId = asset.Id,
                Amount = (decimal)new Random().NextDouble(), 
                Date = DateTime.Now,
            };
        }

        public static TransactionDto GenerateTransactionDto(AssetDto assetDto, CategoryDto categoryDto)
        {
            return new TransactionDto
            {
                CategoryId = categoryDto.Id,
                AssetId = assetDto.Id,
                Amount = (decimal)new Random().NextDouble(),
                Date = DateTime.Now,
                Comment = "blahblah"
            };
        }
    }
}
