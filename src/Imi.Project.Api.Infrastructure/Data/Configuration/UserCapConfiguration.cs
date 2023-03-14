using Imi.Project.Api.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace Imi.Project.Api.Infrastructure.Data.Configuration
{
    public class UserCapConfiguration
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            // Add many to many relations
            modelBuilder.Entity<User>()
                .HasMany(x => x.LikedCaps)
                .WithMany(x => x.LikedByUsers)
                .UsingEntity(x => x.ToTable("CapsLikedByUsers")
                    .HasData(
                        new[]
                        {
                            new { LikedByUsersId = "188f90e8-9f40-4d59-92c9-5954a332e571", LikedCapsId = Guid.Parse("a6a70eb4-39ab-4e1f-94b5-380b282f7003") },
                            new { LikedByUsersId = "188f90e8-9f40-4d59-92c9-5954a332e571", LikedCapsId = Guid.Parse("e87e2d97-0715-48f0-b5c2-26b3abbada28") },
                            new { LikedByUsersId = "188f90e8-9f40-4d59-92c9-5954a332e571", LikedCapsId = Guid.Parse("48d407e3-f47c-4ad6-bbdf-b14347cbc095") },
                            new { LikedByUsersId = "188f90e8-9f40-4d59-92c9-5954a332e571", LikedCapsId = Guid.Parse("74443ec9-a663-48f0-bb6f-79def81ffd39") },
                            new { LikedByUsersId = "188f90e8-9f40-4d59-92c9-5954a332e571", LikedCapsId = Guid.Parse("a0cb17a8-91cc-4579-be4c-bf590c9c1f23") },
                        }
                    ));

            modelBuilder.Entity<User>()
                .HasMany(x => x.CapsCollection)
                .WithMany(x => x.Users)
                .UsingEntity(x => x.ToTable("CapsOwnedByUsers"));
        }
    }
}