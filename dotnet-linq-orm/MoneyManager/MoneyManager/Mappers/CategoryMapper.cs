using DataAccess.DtoModels;
using DataAccess.Models;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Mappers
{
    public class CategoryMapper
    {
        public static CategoryDto MapToCategoryDto(Category category)
        {
            return new CategoryDto
            {
                Id = category.Id,
                Name = category.Name,
                Amount = category.Transactions
                    .Select(t => t.Amount)
                    .Sum()
            };
        }

        public static IEnumerable<CategoryDto> MapToAssetDto(IEnumerable<Category> categories)
        {
            return categories.Select(x => MapToCategoryDto(x));
        }
    }
}

