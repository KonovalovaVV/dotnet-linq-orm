using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoneyManager.Models;

namespace MoneyManager.ModelConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name).IsRequired().HasMaxLength(64);
            builder.Property(p => p.Email).IsRequired().HasMaxLength(64);
            builder.Property(p => p.Hash).IsRequired().HasMaxLength(1024);
            builder.Property(p => p.Salt).IsRequired().HasMaxLength(1024);
        }
    }
}
