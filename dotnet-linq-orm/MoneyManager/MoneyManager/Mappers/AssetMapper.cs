﻿using DataAccess.DtoModels;
using DataAccess.Models;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Mappers
{
    public class AssetMapper
    {
        public static AssetDto MapToAssetDto(Asset asset)
        {
            return new AssetDto
            {
                Id = asset.Id,
                Name = asset.Name,
                Balance =  asset.Transactions
                    .Select(t => t.Amount)
                    .Sum()
            };
        }

       public static IEnumerable<AssetDto> MapToAssetDto(IEnumerable<Asset> assets)
       {
            return assets.Select(x => MapToAssetDto(x));
       }
    }
}
