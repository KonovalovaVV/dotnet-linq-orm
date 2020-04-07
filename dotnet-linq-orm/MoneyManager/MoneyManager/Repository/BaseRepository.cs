using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace MoneyManager.Repository
{
    public class BaseRepository<T> where T : class
    {
        private readonly MoneyManagerContext _moneyManagerContext;
        private readonly DbSet<T> _entities;

        public BaseRepository(MoneyManagerContext moneyManagerContext, DbSet<T> entities)
        {
            _moneyManagerContext = moneyManagerContext;
            _entities = entities;
        }

        public IEnumerable<T> GetAll()
        {
            return _entities;
        }

        public T Get(Guid id)
        {
            return _entities.Find(id);
        }

        public void Create(T entity)
        {
            _entities.Add(entity);
        }

        public void Update(T entity)
        {
            _moneyManagerContext.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(Guid id)
        {
            T entity = _entities.Find(id);
            if (entity != null)
                _entities.Remove(entity);
        }
    }
}
