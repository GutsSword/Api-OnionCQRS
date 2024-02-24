using Bogus;
using Hepsi.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Configuration
{
    public class BrandConfiguration : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(256);

            Faker faker = new("tr");
            builder.HasData(new Brand
            {
                Id = 1,
                Name = faker.Commerce.Department(),
                CreatedDate = DateTime.Now,
                IsDeleted = false,
            });
            builder.HasData(new Brand
            {

                Id = 2,
                Name = faker.Commerce.Department(),
                CreatedDate = DateTime.Now,
                IsDeleted = false,
            });
            builder.HasData(new Brand
            {

                Id = 3,
                Name = faker.Commerce.Department(),
                CreatedDate = DateTime.Now,
                IsDeleted = true,
            });
        }
    }
}
