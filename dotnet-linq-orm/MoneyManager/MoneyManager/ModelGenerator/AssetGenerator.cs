using MoneyManager.Models;
using System;

namespace MoneyManager.ModelGenerator
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
