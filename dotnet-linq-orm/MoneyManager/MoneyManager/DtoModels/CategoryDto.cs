using System;

namespace DataAccess.DtoModels
{
    public class CategoryDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
    }
}
