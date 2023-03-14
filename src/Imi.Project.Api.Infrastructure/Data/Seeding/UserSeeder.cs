using Imi.Project.Api.Core.Constants;
using Imi.Project.Api.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;

namespace Imi.Project.Api.Infrastructure.Data.Seeding
{
    public static class UserSeeder
    {
        // IMI users
        // Password
        private const string password = "Test123?";

        // Names and Email
        private const string user = "ImiUser";
        private const string userEmail = "user@imi.be";
        private const string refuser = "ImiRefuser";
        private const string refuserEmail = "refuser@imi.be";
        private const string admin = "ImiAdmin";
        private const string adminEmail = "admin@imi.be";

        private static string GenerateSecurityStamp()
        {
            var guid = Guid.NewGuid();
            return String.Concat(Array.ConvertAll(guid.ToByteArray(), b => b.ToString("X2"))).ToUpper();
        }

        public static void Seed(ModelBuilder modelBuilder)
        {
            // Add PasswordHasher
            IPasswordHasher<User> passwordHasher = new PasswordHasher<User>();

            // IMI users
            List<User> users = new()
            {
                new User
                {
                    Id = "188f90e8-9f40-4d59-92c9-5954a332e571",
                    UserName = user,
                    NormalizedUserName = user.ToUpper(),
                    Firstname = "Imi",
                    Lastname = "User",
                    Email = userEmail,
                    NormalizedEmail = userEmail.ToUpper(),
                    EmailConfirmed = true,
                    PhoneNumber = "0470000001",
                    PhoneNumberConfirmed = true,
                    DateOfBirth = new DateTime(1990, 01, 01),
                    HasApprovedTermsAndConditions = true,
                    SecurityStamp = GenerateSecurityStamp(),
                    ConcurrencyStamp = "4c9b30a8-f2bb-4c97-80d9-47b9cc66cab3"
                },
                new User
                {
                    Id = "9bf21dbb-6cf5-4190-bacc-4e0d3c6d752a",
                    UserName = refuser,
                    NormalizedUserName = refuser.ToUpper(),
                    Firstname = "Imi",
                    Lastname = "Refuser",
                    Email = refuserEmail,
                    NormalizedEmail = refuserEmail.ToUpper(),
                    EmailConfirmed = true,
                    PhoneNumber = "0470000002",
                    PhoneNumberConfirmed = true,
                    DateOfBirth = new DateTime(1990, 04, 02),
                    HasApprovedTermsAndConditions = false,
                    SecurityStamp = GenerateSecurityStamp(),
                    ConcurrencyStamp = "61ad8388-02a4-4fdd-af2d-21a2224473c3"
                },
                new User
                {
                    Id = "cc3d3a4c-cb1a-4d58-81e8-dec08925923f",
                    UserName = admin,
                    NormalizedUserName = admin.ToUpper(),
                    Firstname = "Imi",
                    Lastname = "Admin",
                    Email = adminEmail,
                    NormalizedEmail = adminEmail.ToUpper(),
                    EmailConfirmed = true,
                    PhoneNumber = "0470000003",
                    PhoneNumberConfirmed = true,
                    DateOfBirth = new DateTime(1990, 04, 03),
                    SecurityStamp = GenerateSecurityStamp(),
                    ConcurrencyStamp = "41e08eef-a668-468e-8172-d9bafbe369f2"
                }
            };

            // Add password to each user
            foreach (var user in users)
            {
                user.PasswordHash = passwordHasher.HashPassword(user, password);
            }

            // Seed users
            modelBuilder.Entity<User>().HasData(users);

            // Role seeding
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = "00000000-0000-0000-0000-000000000001",
                    Name = CustomRoles.Admin,
                    NormalizedName = CustomRoles.Admin.ToUpper()
                },
                new IdentityRole
                {
                    Id = "00000000-0000-0000-0000-000000000002",
                    Name = CustomRoles.User,
                    NormalizedName = CustomRoles.User.ToUpper(),
                }) ;

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "00000000-0000-0000-0000-000000000001",
                    UserId = "cc3d3a4c-cb1a-4d58-81e8-dec08925923f" // Admin
                },
                new IdentityUserRole<string>
                {
                    RoleId = "00000000-0000-0000-0000-000000000002",
                    UserId = "188f90e8-9f40-4d59-92c9-5954a332e571" // User
                },
                new IdentityUserRole<string>
                {
                    RoleId = "00000000-0000-0000-0000-000000000002",
                    UserId = "9bf21dbb-6cf5-4190-bacc-4e0d3c6d752a" // Refuser
                });

            // Loop through users and add claims
            var userClaims = new List<IdentityUserClaim<string>>();

            for (int i = 0; i < users.Count; i++)
            {
                var user = users[i];

                userClaims.Add(
                    new IdentityUserClaim<string>
                    {
                        Id = i + 1,
                        UserId = user.Id,
                        ClaimType = CustomClaimTypes.HasApproved,
                        ClaimValue = user.HasApprovedTermsAndConditions.ToString()
                    });
            }

            for (int i = 11; i < users.Count + 11; i++)
            {
                var user = users[i - 11];

                userClaims.Add(
                    new IdentityUserClaim<string>
                    {
                        Id = i + 1,
                        UserId = user.Id,
                        ClaimType = ClaimTypes.NameIdentifier,
                        ClaimValue = user.Id
                    });
            }

            // Claims seeding
            modelBuilder.Entity<IdentityUserClaim<string>>().HasData(userClaims);
        }
    }
}