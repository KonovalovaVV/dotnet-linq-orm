using Microsoft.EntityFrameworkCore;
using MoneyManager.AppSettings;
using MoneyManager.ModelConfigurations;
using MoneyManager.Models;

namespace MoneyManager
{
    public class MoneyManagerContext: DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Asset> Assets { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Category> Categories { get; set; }

        public MoneyManagerContext()
        {
            Database.EnsureDeleted();   
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(AppSettingsProvider.GetInstance().Settings.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new AssetConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new TransactionConfiguration());

            modelBuilder.Seed();
        }
    }
}
