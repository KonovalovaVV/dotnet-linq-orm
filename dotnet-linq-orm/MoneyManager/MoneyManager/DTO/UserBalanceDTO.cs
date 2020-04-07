using System;

namespace MoneyManager.DTO
{
    public class UserBalanceDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public decimal Balance { get; set; }
    }
}
