using DataAccess.DtoModels;
using DataAccess.Models;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Mappers
{
    public class UserMapper
    {
        public static UserDto MapToUserDto(User user)
        {
            return new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email
            };
        }

        public static IEnumerable<UserDto> MapToUserDto(IEnumerable<User> users)
        {
            return users.Select(x => MapToUserDto(x));
        }

        public static UserBalanceDto MapToUserBalanceDto(User user)
        {
            return new UserBalanceDto
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Balance = user.Assets.Select(a => a.Transactions.Select(t => t.Amount).Sum()).Sum()
            };
        }
    }
}
