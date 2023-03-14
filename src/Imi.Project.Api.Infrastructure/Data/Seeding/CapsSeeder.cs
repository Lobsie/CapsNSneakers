using Imi.Project.Api.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace Imi.Project.Api.Infrastructure.Data.Seeding
{
    public static class CapsSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cap>().HasData(
            new Cap()
            {
                Id = Guid.Parse("a6a70eb4-39ab-4e1f-94b5-380b282f7003"),
                Name = "Blank Black",
                Material = "80% Acrylic, 20% Wool",
                Colorway = "Black",
                BrandId = Guid.Parse("34495ce8-cb32-4fc6-be6e-f01ec9516c84"),
                FittingId = Guid.Parse("b3105e3b-4a55-486d-abaf-f96b014736b0")
            },
            new Cap()
            {
                Id = Guid.Parse("74443ec9-a663-48f0-bb6f-79def81ffd39"),
                Name = "Seattle Supersonics 50th",
                Material = "100% Polyester",
                Colorway = "Off white/Black",
                BrandId = Guid.Parse("34495ce8-cb32-4fc6-be6e-f01ec9516c84"),
                FittingId = Guid.Parse("b3105e3b-4a55-486d-abaf-f96b014736b0")
            },
            new Cap()
            {
                Id = Guid.Parse("a0cb17a8-91cc-4579-be4c-bf590c9c1f23"),
                Name = "Chicago Bulls The Finals",
                Material = "100% Polyester",
                Colorway = "Black",
                BrandId = Guid.Parse("34495ce8-cb32-4fc6-be6e-f01ec9516c84"),
                FittingId = Guid.Parse("b3105e3b-4a55-486d-abaf-f96b014736b0")
            },
            new Cap()
            {
                Id = Guid.Parse("893b881f-f606-421c-931d-08d9d4b3ebff"),
                Name = "Own Brand Box Logo",
                Material = "60% Cotton, 40% Polyester",
                Colorway = "Black/Gold",
                BrandId = Guid.Parse("34495ce8-cb32-4fc6-be6e-f01ec9516c84"),
                FittingId = Guid.Parse("625c000d-934b-4a48-a5da-2390021eaa65")
            },
            new Cap()
            {
                Id = Guid.Parse("ac6c9cab-aada-469b-8b6c-7e48bc4b4dac"),
                Name = "Brooklyn Nets",
                Material = "63% Polyester, 34% Cotton, 3% P.U. Spandex",
                Colorway = "Stone/Forest",
                BrandId = Guid.Parse("34495ce8-cb32-4fc6-be6e-f01ec9516c84"),
                FittingId = Guid.Parse("f96b8562-adf5-4bec-945f-a9f9e53e320a")
            },
            new Cap()
            {
                Id = Guid.Parse("ce181b1e-9c17-4442-82fd-a126e82d8efe"),
                Name = "Denver Nuggets Coast2coast",
                Material = "100% Polyester",
                Colorway = "Navy/Yellow",
                BrandId = Guid.Parse("34495ce8-cb32-4fc6-be6e-f01ec9516c84"),
                FittingId = Guid.Parse("74f6e159-3c96-457a-a7e7-3a58e9640f07")
            },
            new Cap()
            {
                Id = Guid.Parse("789dbb4e-fc85-42aa-8887-96ae9d07acd5"),
                Name = "Polartec Camper",
                Material = "100% Polyester",
                Colorway = "Green/Pink",
                BrandId = Guid.Parse("411e97b5-24ac-4f77-9401-ed8e95cc91a0"),
                FittingId = Guid.Parse("033449e3-d71c-4182-a62c-f725d2fe27f5")
            },
            new Cap()
            {
                Id = Guid.Parse("67f39956-6fd9-486f-a84e-e6195533e906"),
                Name = "Caps Exclusive Roses A-Frame",
                Material = "100% Cotton",
                Colorway = "Black",
                BrandId = Guid.Parse("411e97b5-24ac-4f77-9401-ed8e95cc91a0"),
                FittingId = Guid.Parse("f96b8562-adf5-4bec-945f-a9f9e53e320a")
            },
            new Cap()
            {
                Id = Guid.Parse("e87e2d97-0715-48f0-b5c2-26b3abbada28"),
                Name = "Cap Man",
                Material = "100% Polyester",
                Colorway = "Beige",
                BrandId = Guid.Parse("f3f00bed-635e-4d5a-9e4d-e8b076a90632"),
                FittingId = Guid.Parse("625c000d-934b-4a48-a5da-2390021eaa65")
            },
            new Cap()
            {
                Id = Guid.Parse("48d407e3-f47c-4ad6-bbdf-b14347cbc095"),
                Name = "Dark Side Of The Beard Ripped",
                Material = "100% Cotton",
                Colorway = "Beige",
                BrandId = Guid.Parse("f3f00bed-635e-4d5a-9e4d-e8b076a90632"),
                FittingId = Guid.Parse("697af9aa-8ca3-4b35-9e7f-145c245cac55")
            });
        }
    }
}