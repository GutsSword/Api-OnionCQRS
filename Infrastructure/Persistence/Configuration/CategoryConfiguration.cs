using Bogus;
using Hepsi.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(256);

            Faker faker = new("tr");

            builder.HasData(new Category
            {
                Id = 1,
                Name = "Elektrik",
                Priorty = 1,
                ParentID = 0,
                IsDeleted = false,
                CreatedDate = DateTime.Now
            });
            builder.HasData(new Category
            {
                Id = 3,
                Name = "Bilgisayar",
                Priorty = 1,
                ParentID = 1,
                IsDeleted = false,
                CreatedDate = DateTime.Now
            });
            builder.HasData(new Category
            {
                Id = 2,
                Name = "Moda",
                Priorty = 2,
                ParentID = 0,
                IsDeleted = false,
                CreatedDate = DateTime.Now
            });
            builder.HasData(new Category
            {
                Id = 4,
                Name = "Kadın",
                Priorty = 1,
                ParentID = 2,
                IsDeleted = false,
                CreatedDate = DateTime.Now
            });
        }
    }
}
