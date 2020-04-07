using MoneyManager.DTO;
using MoneyManager.Mappers;
using MoneyManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MoneyManager.Repository
{
    public class UserRepository : BaseRepository<User>
    {
        private readonly MoneyManagerContext _moneyManagerContext;

        public UserRepository(MoneyManagerContext context) : base(context, context.Users)
        {
            _moneyManagerContext = context;
        }

        // Write a request to get the user by email.
        public User GetUserByEmail(string email)
        {
            return _moneyManagerContext.Users.FirstOrDefault(u => u.Email == email);
        }

        // Write a query to get the user list sorted by the user’s name.
        // Each record of the output model should include
        // User.Id, User.Name and User.Email.
        public IEnumerable<UserDTO> GetAllUsersOrderByName()
        {
            return UserMapper.MapUserDTO(_moneyManagerContext.Users.OrderBy(u => u.Name));
        }

        // Write a query to return the current balance for the selected user(parameter userId).
        // Each record of the output model should include User.Id, User.Email, User.Name, and Balance.
        public UserBalanceDTO GetCurrentBalance(Guid userId)
        {
            decimal result = _moneyManagerContext.Transactions
                .Join(_moneyManagerContext.Categories.Where(c => c.Type == CategoryType.Income),
                t => t.CategoryId, c => c.Id, (t, c) => t.Amount).Sum();
            return UserMapper.MapUserBalanceDTO(Get(userId), result);
        }

        // Write a query to get the asset list for the selected user (userId) 
        // ordered by the asset’s name.
        // Each record of the output model should include Asset.Id, Asset.Name and Balance.
        public IEnumerable<AssetDTO> GetUsersAssetsOrderByName(Guid userId)
        {
            return AssetMapper.MapAssetDTO(Get(userId).Assets).OrderBy(a => a.Name);
        }
    }
}
