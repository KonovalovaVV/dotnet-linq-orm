using System;

namespace DataAccess.DtoModels
{
    public class UserBalanceDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public decimal Balance { get; set; }
    }
}
