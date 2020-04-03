using Microsoft.EntityFrameworkCore;
using MoneyManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MoneyManager.DAL.Repository
{
    public class UserRepository : IRepository<User>
    {
        private readonly MoneyManagerContext _moneyManagerContext;

        public UserRepository(MoneyManagerContext context)
        {
            _moneyManagerContext = context;
        }

        public IEnumerable<User> GetAll()
        {
            return _moneyManagerContext.Users;
        }

        public User Get(Guid id)
        {
            return _moneyManagerContext.Users.Find(id);
        }

        public void Create(User user)
        {
            _moneyManagerContext.Users.Add(user);
        }

        public void Update(User user)
        {
            _moneyManagerContext.Entry(user).State = EntityState.Modified;
        }

        public void Delete(Guid id)
        {
            User user = _moneyManagerContext.Users.Find(id);
            if (user != null)
                _moneyManagerContext.Users.Remove(user);
        }
    }
}
