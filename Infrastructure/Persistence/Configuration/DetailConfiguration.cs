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
    public class DetailConfiguration : IEntityTypeConfiguration<Detail>
    {
        public void Configure(EntityTypeBuilder<Detail> builder)
        {
            Faker faker = new("tr");

            builder.HasData(new Detail
            {
                Id = 1,
                Title = faker.Lorem.Sentence(1),
                Description=faker.Lorem.Sentences(3," "),
                CategoryId=1,
                CreatedDate = DateTime.Now,
                IsDeleted=false,
            });
            builder.HasData(new Detail
            {
                Id = 2,
                Title = faker.Lorem.Sentence(1),
                Description = faker.Lorem.Sentences(3, " "),
                CategoryId = 3,
                CreatedDate = DateTime.Now,
                IsDeleted = false,
            });
            builder.HasData(new Detail
            {
                Id = 3,
                Title = faker.Lorem.Sentence(1),
                Description = faker.Lorem.Sentences(3, " "),
                CategoryId = 4,
                CreatedDate = DateTime.Now,
                IsDeleted = false,
            });
        }
    }
}
