using Microsoft.EntityFrameworkCore;
using MoneyManager.Models;
using System;
using System.Collections.Generic;

namespace MoneyManager.DAL.Repository
{
    public class AssetRepository : IRepository<Asset>
    {
        private readonly MoneyManagerContext _moneyManagerContext;

        public AssetRepository(MoneyManagerContext context)
        {
            _moneyManagerContext = context;
        }

        public IEnumerable<Asset> GetAll()
        {
            return _moneyManagerContext.Assets;
        }

        public Asset Get(Guid id)
        {
            return _moneyManagerContext.Assets.Find(id);
        }

        public void Create(Asset asset)
        {
            _moneyManagerContext.Assets.Add(asset);
        }

        public void Update(Asset asset)
        {
            _moneyManagerContext.Entry(asset).State = EntityState.Modified;
        }

        public void Delete(Guid id)
        {
            Asset Asset = _moneyManagerContext.Assets.Find(id);
            if (Asset != null)
                _moneyManagerContext.Assets.Remove(Asset);
        }
    }
}
