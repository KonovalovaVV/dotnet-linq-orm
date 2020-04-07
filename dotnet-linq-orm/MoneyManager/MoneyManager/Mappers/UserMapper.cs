using MoneyManager.DTO;
using MoneyManager.Models;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;

namespace MoneyManager.Mappers
{
    public class UserMapper
    {
        public static UserDTO MapUserDTO(User user)
        {
            return new UserDTO
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email
            };
        }

        public static IEnumerable<UserDTO> MapUserDTO(IEnumerable<User> users)
        {
            return users.Select(x => MapUserDTO(x));
        }

        public static UserBalanceDTO MapUserBalanceDTO(User user, decimal balance)
        {
            return new UserBalanceDTO
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Balance = balance
            };
        }
    }
}
