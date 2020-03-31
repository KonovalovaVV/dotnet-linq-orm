using Microsoft.EntityFrameworkCore;
using MoneyManager.Models;

namespace MoneyManager
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(DbGenerator.GenerateUsers());
            modelBuilder.Entity<Asset>().HasData(DbGenerator.GenerateAssets());
            modelBuilder.Entity<Category>().HasData(DbGenerator.GenerateCategories());
            modelBuilder.Entity<Transaction>().HasData(DbGenerator.GenerateTransactions());
        }
    }
}
