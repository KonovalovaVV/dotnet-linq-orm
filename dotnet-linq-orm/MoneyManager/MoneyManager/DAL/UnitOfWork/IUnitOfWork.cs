using MoneyManager.DAL.Repository;
using System;

namespace MoneyManager.DAL.UnitOfWork
{
    public interface IUnitOfWork: IDisposable
    {
        UserRepository Users { get; }
        AssetRepository Assets { get; }
        CategoryRepository Categories { get; }
        TransactionRepository Transactions { get; }

        void Save();

    }
}
