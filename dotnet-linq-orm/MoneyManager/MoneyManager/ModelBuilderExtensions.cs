using Microsoft.EntityFrameworkCore;
using DataAccess.Models;

namespace DataAccess
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            DbGenerator dbGenerator = new DbGenerator();
            modelBuilder.Entity<User>().HasData(dbGenerator.DefaultUsers);
            modelBuilder.Entity<Asset>().HasData(dbGenerator.DefaultAssets);
            modelBuilder.Entity<Category>().HasData(dbGenerator.DefaultCategories);
            modelBuilder.Entity<Transaction>().HasData(dbGenerator.DefaultTransactions);
        }
    }
}
