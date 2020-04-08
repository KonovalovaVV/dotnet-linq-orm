using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DataAccess.Models;

namespace DataAccess.ModelConfigurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name).IsRequired().HasMaxLength(64);
            builder.Property(p => p.Type).IsRequired();
            builder.HasOne(p => p.ParentCategory).WithMany().HasForeignKey(p => p.ParentCategoryId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
