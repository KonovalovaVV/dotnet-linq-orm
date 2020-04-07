using MoneyManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MoneyManager.Repository
{
    public class TransactionRepository : BaseRepository<Transaction>
    {
        private readonly MoneyManagerContext _moneyManagerContext;

        public TransactionRepository(MoneyManagerContext context): base(context, context.Transactions)
        {
            _moneyManagerContext = context;
        }

        public void DeleteAllTransactionsForMonth(Guid UserId)
        {
            IEnumerable<Guid> ids = _moneyManagerContext.Transactions.Where(t => t.Date.Day == DateTime.Now.Day)
                           .Join(_moneyManagerContext.Assets.Where(a => a.UserId == UserId),
                           t => t.AssetId, a => a.Id,(t, a) => t.Id);
            foreach (Guid id in ids)
            {
                _moneyManagerContext.Transactions.Remove(Get(id));
            }
        }
    }
}
