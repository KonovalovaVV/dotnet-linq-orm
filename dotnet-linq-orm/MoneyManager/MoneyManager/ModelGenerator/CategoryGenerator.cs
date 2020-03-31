
using MoneyManager.Models;
using System;

namespace MoneyManager.ModelGenerator
{
    public static class CategoryGenerator
    {
        public static Category GenerateCategory(Category parentCategory)
        {
            return new Category
            {
                Id = Guid.NewGuid(),
                Name = StringGenerator.RandomString(),
                Type = new Random().Next(0, 2),
                ParentId = parentCategory.Id,
            };
        }

        public static Category GenerateCategory()
        {
            return new Category
            {
                Id = Guid.NewGuid(),
                Name = StringGenerator.RandomString(),
                Type = new Random().Next(0, 2),
            };
        }
    }
}
