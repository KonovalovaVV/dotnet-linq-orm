using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace DataAccess.Repository
{
    public class BaseRepository<T> where T : class
    {
        protected readonly MoneyManagerContext MoneyManagerContext;
        private readonly DbSet<T> _entities;

        public BaseRepository(MoneyManagerContext moneyManagerContext)
        {
            MoneyManagerContext = moneyManagerContext;
            _entities = MoneyManagerContext.Set<T>();
        }

        protected IEnumerable<T> GetAll()
        {
            return _entities;
        }

        protected T Get(Guid id)
        {
            return _entities.Find(id);
        }

        public void Create(T entity)
        {
            _entities.Add(entity);
        }

        public void Update(T entity)
        {
            MoneyManagerContext.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(Guid id)
        {
            T entity = _entities.Find(id);
            if (entity != null)
                _entities.Remove(entity);
        }
    }
}
