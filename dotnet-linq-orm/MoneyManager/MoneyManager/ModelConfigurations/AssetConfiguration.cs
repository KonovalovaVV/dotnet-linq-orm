using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DataAccess.Models;

namespace DataAccess.ModelConfigurations
{
    public class AssetConfiguration : IEntityTypeConfiguration<Asset>
    {
        public void Configure(EntityTypeBuilder<Asset> builder)
        {
            builder.HasKey(p => p.Id);
            builder
                .Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(64);
        }
    }
}
