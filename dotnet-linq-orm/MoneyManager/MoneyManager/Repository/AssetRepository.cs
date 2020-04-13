using DataAccess.DtoModels;
using DataAccess.Mappers;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Repository
{
    public class AssetRepository : BaseRepository<Asset>
    {
        public AssetRepository(MoneyManagerContext context) : base(context) { }

        public new AssetDto Get(Guid assetId)
        {
            var asset = base.Get(assetId);
            return AssetMapper.MapToAssetDto(asset);
        }

        public void Create(AssetDto assetDto, UserDto userDto)
        {
            Create(AssetMapper.MapToAsset(assetDto, userDto));
        }

        // Write a query to get the asset list for the selected user (userId) 
        // ordered by the asset’s name.
        // Each record of the output model should include Asset.Id, Asset.Name and Balance.
        public IEnumerable<AssetDto> GetUsersAssets(Guid userId)
        {
            var assets = MoneyManagerContext.Assets
                .Where(a => a.UserId == userId)
                .OrderBy(a => a.Name);
            return AssetMapper.MapToAssetDto(assets);
        }
    }
}
