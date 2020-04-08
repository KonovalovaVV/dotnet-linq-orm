using DataAccess.Repository;
using System;

namespace DataAccess.UnitOfWork
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
