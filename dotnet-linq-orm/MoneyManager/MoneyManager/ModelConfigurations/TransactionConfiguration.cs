using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DataAccess.Models;

namespace DataAccess.ModelConfigurations
{
    public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.HasKey(p => p.Id);
            builder
                .Property(p => p.Amount)
                .IsRequired()
                .HasColumnType("decimal(16,3)");
            builder
                .Property(p => p.Date)
                .IsRequired()
                .HasColumnType("datetime2(7)");
            builder
                .Property(p => p.Comment)
                .HasMaxLength(1024);
        }
    }
}
