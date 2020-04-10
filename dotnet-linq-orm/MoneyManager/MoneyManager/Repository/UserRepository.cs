using DataAccess.DtoModels;
using DataAccess.Mappers;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;  

namespace DataAccess.Repository
{
    public class UserRepository : BaseRepository<User>
    {
        public UserRepository(MoneyManagerContext context) : base(context) { }

        public new UserDto Get(Guid userId)
        {
            var user = base.Get(userId);
            return UserMapper.MapToUserDto(user);
        }

        // Write a request to get the user by email.
        public User GetUserByEmail(string email)
        {
            return MoneyManagerContext.Users.FirstOrDefault(u => u.Email == email);
        }

        // Write a query to get the user list sorted by the user’s name.
        // Each record of the output model should include
        // User.Id, User.Name and User.Email.
        public IEnumerable<UserDto> GetAllUsersOrderByName()
        {
            return UserMapper.MapToUserDto(MoneyManagerContext.Users.OrderBy(u => u.Name));
        }

        // Write a query to return the current balance for the selected user(parameter userId).
        // Each record of the output model should include User.Id, User.Email, User.Name, and Balance.
        public UserBalanceDto GetCurrentBalance(Guid userId)
        {
            return UserMapper.MapToUserBalanceDto(base.Get(userId));
        }
    }
}
