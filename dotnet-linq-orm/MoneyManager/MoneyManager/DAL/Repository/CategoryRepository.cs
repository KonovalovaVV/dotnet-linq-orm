using Microsoft.EntityFrameworkCore;
using MoneyManager.Models;
using System;
using System.Collections.Generic;

namespace MoneyManager.DAL.Repository
{
    public class CategoryRepository : IRepository<Category>
    {
        private readonly MoneyManagerContext _moneyManagerContext;

        public CategoryRepository(MoneyManagerContext context)
        {
            _moneyManagerContext = context;
        }

        public IEnumerable<Category> GetAll()
        {
            return _moneyManagerContext.Categories;
        }

        public Category Get(Guid id)
        {
            return _moneyManagerContext.Categories.Find(id);
        }

        public void Create(Category category)
        {
            _moneyManagerContext.Categories.Add(category);
        }

        public void Update(Category category)
        {
            _moneyManagerContext.Entry(category).State = EntityState.Modified;
        }

        public void Delete(Guid id)
        {
            Category category = _moneyManagerContext.Categories.Find(id);
            if (category != null)
                _moneyManagerContext.Categories.Remove(category);
        }
    }
}
