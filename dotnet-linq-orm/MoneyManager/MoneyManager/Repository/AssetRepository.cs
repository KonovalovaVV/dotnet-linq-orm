using MoneyManager.Models;

namespace MoneyManager.Repository
{
    public class AssetRepository : BaseRepository<Asset>
    {
        private readonly MoneyManagerContext _moneyManagerContext;

        public AssetRepository(MoneyManagerContext context) : base(context, context.Assets)
        {
            _moneyManagerContext = context;
        }
    }
}
