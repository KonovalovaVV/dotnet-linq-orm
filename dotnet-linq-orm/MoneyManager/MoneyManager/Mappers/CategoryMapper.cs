﻿using DataAccess.DtoModels;
using DataAccess.Models;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Mappers
{
    public class CategoryMapper
    {
        public static CategoryWithAmount MapToCategoryWithAmount(Category category)
        {
            decimal amount = category.Transactions == null ? 0 : category.Transactions
                    .Select(t => t.Amount)
                    .Sum();
            return new CategoryWithAmount
            {
                Name = category.Name,
                Amount = amount
            };
        }

        public static CategoryDto MapToCategoryDto(Category category)
        {
            return new CategoryDto
            {
                Name = category.Name,
                Id = category.Id,
                Type = category.Type,
                ParentCategoryId = category.ParentCategoryId
            };
        }

        public static IEnumerable<CategoryWithAmount> MapToCategoryWithAmount(IEnumerable<Category> categories)
        {
            return categories.Select(MapToCategoryWithAmount);
        }

        public static IEnumerable<CategoryDto> MapToCategoryDto(IEnumerable<Category> categories)
        {
            return categories.Select(MapToCategoryDto);
        }

        public static Category MapToCategory(CategoryDto categoryDto)
        {
            return new Category
            {
                Id = categoryDto.Id,
                Name = categoryDto.Name,
                ParentCategoryId = categoryDto.ParentCategoryId,
                Type = categoryDto.Type
            };
        }
    }
}

