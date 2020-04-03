﻿using MoneyManager.DAL.Repository;
using System;

namespace MoneyManager.DAL.UnitOfWork
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private readonly MoneyManagerContext _moneyManagerContext;
        private UserRepository userRepository;
        private AssetRepository assetRepository;
        private CategoryRepository categoryRepository;
        private TransactionRepository transactionRepository;
        public Query query;

        public EFUnitOfWork(MoneyManagerContext moneyManagerContext)
        {
            _moneyManagerContext = moneyManagerContext;
            query = new Query(this, _moneyManagerContext);
        }

        public UserRepository Users
        {
            get
            {
                if (userRepository == null)
                    userRepository = new UserRepository(_moneyManagerContext);
                return userRepository;
            }
        }

        public AssetRepository Assets
        {
            get
            {
                if (assetRepository == null)
                    assetRepository = new AssetRepository(_moneyManagerContext);
                return assetRepository;
            }
        }

        public CategoryRepository Categories
        {
            get
            {
                if (categoryRepository == null)
                    categoryRepository = new CategoryRepository(_moneyManagerContext);
                return categoryRepository;
            }
        }

        public TransactionRepository Transactions
        {
            get
            {
                if (transactionRepository == null)
                    transactionRepository = new TransactionRepository(_moneyManagerContext);
                return transactionRepository;
            }
        }

        public void Save()
        {
            _moneyManagerContext.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _moneyManagerContext.Dispose();
                }
                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
