using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public class Category
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public CategoryType Type { get; set; }
        public Guid? ParentCategoryId { get; set; }
        public int Color { get; set; }
        public Category ParentCategory  { get; set; }
        public ICollection<Transaction> Transactions { get; set; }
    }
}
