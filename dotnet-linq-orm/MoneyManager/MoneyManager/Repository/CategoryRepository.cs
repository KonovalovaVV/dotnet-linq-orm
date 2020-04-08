using DataAccess.DtoModels;
using DataAccess.Mappers;
using DataAccess.Models;
using System;

namespace DataAccess.Repository
{
    public class CategoryRepository : BaseRepository<Category>
    {
        public CategoryRepository(MoneyManagerContext context) : base(context) { }

        public new CategoryDto Get(Guid categoryId)
        {
            var category = base.Get(categoryId);
            return CategoryMapper.MapToCategoryDto(category);
        }
    }
}
