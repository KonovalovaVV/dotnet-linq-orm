using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Hash { get; set; }
        public string Salt { get; set; }
        public ICollection<Asset> Assets { get; set; }
    }
}
