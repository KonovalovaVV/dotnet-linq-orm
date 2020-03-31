﻿using MoneyManager.Models;
using System;

namespace MoneyManager.ModelGenerator
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
    }
}
