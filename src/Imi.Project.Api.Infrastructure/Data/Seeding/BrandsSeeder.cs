using Imi.Project.Api.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace Imi.Project.Api.Infrastructure.Data.Seeding
{
    public static class BrandsSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brand>()
                .HasMany(x => x.Caps)
                .WithOne(x => x.Brand)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);

            // Seed Brands
            modelBuilder.Entity<Brand>().HasData(
            new Brand()
            {
                Id = Guid.Parse("34495ce8-cb32-4fc6-be6e-f01ec9516c84"),
                Name = "Mitchel & Ness"
            },
            new Brand()
            {
                Id = Guid.Parse("411e97b5-24ac-4f77-9401-ed8e95cc91a0"),
                Name = "New Era"
            },
            new Brand()
            {
                Id = Guid.Parse("e77b07b6-27c3-4df6-bbab-10d10cb5a22f"),
                Name = "Nike"
            },
            new Brand()
            {
                Id = Guid.Parse("f3f00bed-635e-4d5a-9e4d-e8b076a90632"),
                Name = "Bearded Man"
            },
            new Brand()
            {
                Id = Guid.Parse("c116b76c-b60e-4c0b-9615-f015cb0eb64d"),
                Name = "Burton"
            },
            new Brand()
            {
                Id = Guid.Parse("6710ae13-5c89-460a-aadb-c58f9d207288"),
                Name = "Goorin Bros."
            },
            new Brand()
            {
                Id = Guid.Parse("d4148156-f492-4290-9325-f7936ebdaf83"),
                Name = "47 Brand"
            },
            new Brand()
            {
                Id = Guid.Parse("bcc6ea98-2f4b-47a6-ab2f-b1e156589a8e"),
                Name = "Brixton"
            },
            new Brand()
            {
                Id = Guid.Parse("bc5ec2ac-5fe2-447d-be60-cd0b85539a61"),
                Name = "Capslab"
            });
        }
    }
}