using Bogus;
using Hepsi.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            Faker faker = new("tr");

            builder.HasData(new Product
            {
                Id=1,           
                Title = faker.Commerce.ProductName(),
                Description = faker.Commerce.ProductDescription(),
                BrandId = 1,
                Discount = faker.Random.Decimal(0,10),
                Price = faker.Finance.Amount(10,1000),
                CreatedDate=DateTime.Now,
                IsDeleted=false,
            });

            builder.HasData(new Product
            {
                Id = 2,
                Title = faker.Commerce.ProductName(),
                Description = faker.Commerce.ProductDescription(),
                BrandId = 3,
                Discount = faker.Random.Decimal(0, 10),
                Price = faker.Finance.Amount(10, 1000),
                CreatedDate = DateTime.Now,
                IsDeleted = false,
            });
        }
    }
}
