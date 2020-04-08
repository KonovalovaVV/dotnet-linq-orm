using DataAccess.DtoModels;
using DataAccess.Mappers;
using DataAccess.Models;
using System;

namespace DataAccess.Repository
{
    public class TransactionRepository : BaseRepository<Transaction>
    {
        private readonly MoneyManagerContext _moneyManagerContext;

        public TransactionRepository(MoneyManagerContext context): base(context)
        {
            _moneyManagerContext = context;
        }

        public new TransactionDto Get(Guid transactionId)
        {
            var transaction = base.Get(transactionId);
            return TransactionMapper.MapToTransactionDto(transaction);
        }
    }
}
