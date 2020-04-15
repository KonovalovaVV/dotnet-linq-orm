using Microsoft.EntityFrameworkCore;
using DataAccess.Models;

namespace DataAccess
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(DbGenerator.GetDefaultCategories());
        }
    }
}
