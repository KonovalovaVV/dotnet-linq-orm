using DataAccess.DtoModels;
using DataAccess.Mappers;
using DataAccess.Models;
using System;

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
    }
}
