using Bogus;
using Hepsi.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    public class ProductCategoryConfiguration : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            //Create Primary Key 
            builder.HasKey(x => new { x.ProductId, x.CategoryId }); 

            builder.HasOne(x=>x.Product)
                .WithMany(x=>x.ProductCategories)
                .HasForeignKey(x=>x.ProductId).OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Category)
                .WithMany(x => x.ProductCategories)
                .HasForeignKey(x => x.CategoryId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
