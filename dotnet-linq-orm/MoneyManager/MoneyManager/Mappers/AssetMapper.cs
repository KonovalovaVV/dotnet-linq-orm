using MoneyManager.DTO;
using MoneyManager.Models;
using System.Collections.Generic;
using System.Linq;

namespace MoneyManager.Mappers
{
    public class AssetMapper
    {
        public static AssetDTO MapAssetDTO(Asset asset)
        {
            return new AssetDTO
            {
                Id = asset.Id,
                Name = asset.Name,
                Balance =  asset.Transactions.Select(t => t.Amount).Sum()
            };
        }

       public static IEnumerable<AssetDTO> MapAssetDTO(IEnumerable<Asset> assets)
       {
            return assets.Select(x => MapAssetDTO(x));
       }
    }
}
