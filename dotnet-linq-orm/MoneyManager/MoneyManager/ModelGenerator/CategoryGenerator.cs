using DataAccess.Models;
using System;

namespace DataAccess.ModelGenerator
{
    public static class CategoryGenerator
    {
        public static Category GenerateCategory(Category parentCategory)
        {
            Category category = GenerateCategory();
            category.ParentCategoryId = parentCategory.Id;
            return category;
        }

        public static Category GenerateCategory()
        {
            return new Category
            {
                Id = Guid.NewGuid(),
                Name = StringGenerator.RandomString(),
                Type = (CategoryType)new Random().Next(1, 3)
            };
        }
    }
}
