using DataAccess.Models;
using System;

namespace DataAccess.DtoModels
{
    public class CategoryDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public CategoryType Type { get; set; }
        public Guid? ParentCategoryId { get; set; }
        public int Color { get; set; }
    }
}
