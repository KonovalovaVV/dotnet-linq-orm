using MoneyManager.Models;
using System;

namespace MoneyManager.ModelGenerator
{
    public static class UserGenerator
    {
        public static User GenerateUser()
        {
            return new User
            {
                Id = Guid.NewGuid(),
                Name = StringGenerator.RandomString(),
                Email = StringGenerator.RandomString(),
                Hash = StringGenerator.RandomString(),
                Salt = StringGenerator.RandomString()
            };
        }
    }
}
