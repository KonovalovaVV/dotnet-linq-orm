using Microsoft.EntityFrameworkCore;
using MoneyManager.Models;
using System;
using System.Collections.Generic;

namespace MoneyManager.DAL.Repository
{
    public class TransactionRepository : IRepository<Transaction>
    {
        private readonly MoneyManagerContext _moneyManagerContext;

        public TransactionRepository(MoneyManagerContext context)
        {
            _moneyManagerContext = context;
        }

        public IEnumerable<Transaction> GetAll()
        {
            return _moneyManagerContext.Transactions;
        }

        public Transaction Get(Guid id)
        {
            return _moneyManagerContext.Transactions.Find(id);
        }

        public void Create(Transaction transaction)
        {
            _moneyManagerContext.Transactions.Add(transaction);
        }

        public void Update(Transaction transaction)
        {
            _moneyManagerContext.Entry(transaction).State = EntityState.Modified;
        }

        public void Delete(Guid id)
        {
            Transaction transaction = _moneyManagerContext.Transactions.Find(id);
            if (transaction != null)
                _moneyManagerContext.Transactions.Remove(transaction);
        }
    }
}
