using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public class Asset
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public ICollection<Transaction> Transactions { get; set; }
    }
}
