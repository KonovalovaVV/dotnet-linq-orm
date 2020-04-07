using MoneyManager.Models;

namespace MoneyManager.Repository
{
    public class CategoryRepository : BaseRepository<Category>
    {
        private readonly MoneyManagerContext _moneyManagerContext;

        public CategoryRepository(MoneyManagerContext context): base(context, context.Categories)
        {
            _moneyManagerContext = context;
        }
    }
}
