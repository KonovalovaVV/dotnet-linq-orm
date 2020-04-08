using DataAccess.Models;
using System;

namespace DataAccess.ModelGenerator
{
    public static class AssetGenerator
    {
        public static Asset GenerateAsset(User user)
        {
            return new Asset
            {
                Id = Guid.NewGuid(),
                Name = StringGenerator.RandomString(),
                UserId = user.Id
            };
        }
    }
}
