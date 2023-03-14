using Imi.Project.Api.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace Imi.Project.Api.Infrastructure.Data.Seeding
{
    public static class FittingsSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Fitting>()
                .HasMany(x => x.Caps)
                .WithOne(x => x.Fitting)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);

            // Seed fittings
            modelBuilder.Entity<Fitting>().HasData(
            new Fitting()
            {
                Id = Guid.Parse("b3105e3b-4a55-486d-abaf-f96b014736b0"),
                Name = "Snapback"
            },
            new Fitting()
            {
                Id = Guid.Parse("74f6e159-3c96-457a-a7e7-3a58e9640f07"),
                Name = "Fitted"
            },
            new Fitting()
            {
                Id = Guid.Parse("625c000d-934b-4a48-a5da-2390021eaa65"),
                Name = "Trucker"
            },
            new Fitting()
            {
                Id = Guid.Parse("697af9aa-8ca3-4b35-9e7f-145c245cac55"),
                Name = "Dad Cap"
            },
            new Fitting()
            {
                Id = Guid.Parse("362f8832-1186-4b41-be31-76099e11d288"),
                Name = "Stretchfit"
            },
            new Fitting()
            {
                Id = Guid.Parse("033449e3-d71c-4182-a62c-f725d2fe27f5"),
                Name = "5-Panel"
            },
            new Fitting()
            {
                Id = Guid.Parse("f96b8562-adf5-4bec-945f-a9f9e53e320a"),
                Name = "Adjustable"
            });
        }
    }
}