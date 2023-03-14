﻿// <auto-generated />
using System;
using Imi.Project.Api.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Imi.Project.Api.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230110135849_AddRolesToUsers")]
    partial class AddRolesToUsers
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CapUser", b =>
                {
                    b.Property<string>("LikedByUsersId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<Guid>("LikedCapsId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LikedByUsersId", "LikedCapsId");

                    b.HasIndex("LikedCapsId");

                    b.ToTable("CapsLikedByUsers", (string)null);

                    b.HasData(
                        new
                        {
                            LikedByUsersId = "188f90e8-9f40-4d59-92c9-5954a332e571",
                            LikedCapsId = new Guid("a6a70eb4-39ab-4e1f-94b5-380b282f7003")
                        },
                        new
                        {
                            LikedByUsersId = "188f90e8-9f40-4d59-92c9-5954a332e571",
                            LikedCapsId = new Guid("e87e2d97-0715-48f0-b5c2-26b3abbada28")
                        },
                        new
                        {
                            LikedByUsersId = "188f90e8-9f40-4d59-92c9-5954a332e571",
                            LikedCapsId = new Guid("48d407e3-f47c-4ad6-bbdf-b14347cbc095")
                        },
                        new
                        {
                            LikedByUsersId = "188f90e8-9f40-4d59-92c9-5954a332e571",
                            LikedCapsId = new Guid("74443ec9-a663-48f0-bb6f-79def81ffd39")
                        },
                        new
                        {
                            LikedByUsersId = "188f90e8-9f40-4d59-92c9-5954a332e571",
                            LikedCapsId = new Guid("a0cb17a8-91cc-4579-be4c-bf590c9c1f23")
                        });
                });

            modelBuilder.Entity("CapUser1", b =>
                {
                    b.Property<Guid>("CapsCollectionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UsersId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("CapsCollectionId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("CapsOwnedByUsers", (string)null);
                });

            modelBuilder.Entity("Imi.Project.Api.Core.Entities.Brand", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Brands");

                    b.HasData(
                        new
                        {
                            Id = new Guid("34495ce8-cb32-4fc6-be6e-f01ec9516c84"),
                            Name = "Mitchel & Ness"
                        },
                        new
                        {
                            Id = new Guid("411e97b5-24ac-4f77-9401-ed8e95cc91a0"),
                            Name = "New Era"
                        },
                        new
                        {
                            Id = new Guid("e77b07b6-27c3-4df6-bbab-10d10cb5a22f"),
                            Name = "Nike"
                        },
                        new
                        {
                            Id = new Guid("f3f00bed-635e-4d5a-9e4d-e8b076a90632"),
                            Name = "Bearded Man"
                        },
                        new
                        {
                            Id = new Guid("c116b76c-b60e-4c0b-9615-f015cb0eb64d"),
                            Name = "Burton"
                        },
                        new
                        {
                            Id = new Guid("6710ae13-5c89-460a-aadb-c58f9d207288"),
                            Name = "Goorin Bros."
                        },
                        new
                        {
                            Id = new Guid("d4148156-f492-4290-9325-f7936ebdaf83"),
                            Name = "47 Brand"
                        },
                        new
                        {
                            Id = new Guid("bcc6ea98-2f4b-47a6-ab2f-b1e156589a8e"),
                            Name = "Brixton"
                        },
                        new
                        {
                            Id = new Guid("bc5ec2ac-5fe2-447d-be60-cd0b85539a61"),
                            Name = "Capslab"
                        });
                });

            modelBuilder.Entity("Imi.Project.Api.Core.Entities.Cap", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("BrandId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Colorway")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("FittingId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Material")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.HasIndex("FittingId");

                    b.ToTable("Caps");

                    b.HasData(
                        new
                        {
                            Id = new Guid("a6a70eb4-39ab-4e1f-94b5-380b282f7003"),
                            BrandId = new Guid("34495ce8-cb32-4fc6-be6e-f01ec9516c84"),
                            Colorway = "Black",
                            FittingId = new Guid("b3105e3b-4a55-486d-abaf-f96b014736b0"),
                            Material = "80% Acrylic, 20% Wool",
                            Name = "Blank Black"
                        },
                        new
                        {
                            Id = new Guid("74443ec9-a663-48f0-bb6f-79def81ffd39"),
                            BrandId = new Guid("34495ce8-cb32-4fc6-be6e-f01ec9516c84"),
                            Colorway = "Off white/Black",
                            FittingId = new Guid("b3105e3b-4a55-486d-abaf-f96b014736b0"),
                            Material = "100% Polyester",
                            Name = "Seattle Supersonics 50th"
                        },
                        new
                        {
                            Id = new Guid("a0cb17a8-91cc-4579-be4c-bf590c9c1f23"),
                            BrandId = new Guid("34495ce8-cb32-4fc6-be6e-f01ec9516c84"),
                            Colorway = "Black",
                            FittingId = new Guid("b3105e3b-4a55-486d-abaf-f96b014736b0"),
                            Material = "100% Polyester",
                            Name = "Chicago Bulls The Finals"
                        },
                        new
                        {
                            Id = new Guid("893b881f-f606-421c-931d-08d9d4b3ebff"),
                            BrandId = new Guid("34495ce8-cb32-4fc6-be6e-f01ec9516c84"),
                            Colorway = "Black/Gold",
                            FittingId = new Guid("625c000d-934b-4a48-a5da-2390021eaa65"),
                            Material = "60% Cotton, 40% Polyester",
                            Name = "Own Brand Box Logo"
                        },
                        new
                        {
                            Id = new Guid("ac6c9cab-aada-469b-8b6c-7e48bc4b4dac"),
                            BrandId = new Guid("34495ce8-cb32-4fc6-be6e-f01ec9516c84"),
                            Colorway = "Stone/Forest",
                            FittingId = new Guid("f96b8562-adf5-4bec-945f-a9f9e53e320a"),
                            Material = "63% Polyester, 34% Cotton, 3% P.U. Spandex",
                            Name = "Brooklyn Nets"
                        },
                        new
                        {
                            Id = new Guid("ce181b1e-9c17-4442-82fd-a126e82d8efe"),
                            BrandId = new Guid("34495ce8-cb32-4fc6-be6e-f01ec9516c84"),
                            Colorway = "Navy/Yellow",
                            FittingId = new Guid("74f6e159-3c96-457a-a7e7-3a58e9640f07"),
                            Material = "100% Polyester",
                            Name = "Denver Nuggets Coast2coast"
                        },
                        new
                        {
                            Id = new Guid("789dbb4e-fc85-42aa-8887-96ae9d07acd5"),
                            BrandId = new Guid("411e97b5-24ac-4f77-9401-ed8e95cc91a0"),
                            Colorway = "Green/Pink",
                            FittingId = new Guid("033449e3-d71c-4182-a62c-f725d2fe27f5"),
                            Material = "100% Polyester",
                            Name = "Polartec Camper"
                        },
                        new
                        {
                            Id = new Guid("67f39956-6fd9-486f-a84e-e6195533e906"),
                            BrandId = new Guid("411e97b5-24ac-4f77-9401-ed8e95cc91a0"),
                            Colorway = "Black",
                            FittingId = new Guid("f96b8562-adf5-4bec-945f-a9f9e53e320a"),
                            Material = "100% Cotton",
                            Name = "Caps Exclusive Roses A-Frame"
                        },
                        new
                        {
                            Id = new Guid("e87e2d97-0715-48f0-b5c2-26b3abbada28"),
                            BrandId = new Guid("f3f00bed-635e-4d5a-9e4d-e8b076a90632"),
                            Colorway = "Beige",
                            FittingId = new Guid("625c000d-934b-4a48-a5da-2390021eaa65"),
                            Material = "100% Polyester",
                            Name = "Cap Man"
                        },
                        new
                        {
                            Id = new Guid("48d407e3-f47c-4ad6-bbdf-b14347cbc095"),
                            BrandId = new Guid("f3f00bed-635e-4d5a-9e4d-e8b076a90632"),
                            Colorway = "Beige",
                            FittingId = new Guid("697af9aa-8ca3-4b35-9e7f-145c245cac55"),
                            Material = "100% Cotton",
                            Name = "Dark Side Of The Beard Ripped"
                        });
                });

            modelBuilder.Entity("Imi.Project.Api.Core.Entities.Fitting", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Fittings");

                    b.HasData(
                        new
                        {
                            Id = new Guid("b3105e3b-4a55-486d-abaf-f96b014736b0"),
                            Name = "Snapback"
                        },
                        new
                        {
                            Id = new Guid("74f6e159-3c96-457a-a7e7-3a58e9640f07"),
                            Name = "Fitted"
                        },
                        new
                        {
                            Id = new Guid("625c000d-934b-4a48-a5da-2390021eaa65"),
                            Name = "Trucker"
                        },
                        new
                        {
                            Id = new Guid("697af9aa-8ca3-4b35-9e7f-145c245cac55"),
                            Name = "Dad Cap"
                        },
                        new
                        {
                            Id = new Guid("362f8832-1186-4b41-be31-76099e11d288"),
                            Name = "Stretchfit"
                        },
                        new
                        {
                            Id = new Guid("033449e3-d71c-4182-a62c-f725d2fe27f5"),
                            Name = "5-Panel"
                        },
                        new
                        {
                            Id = new Guid("f96b8562-adf5-4bec-945f-a9f9e53e320a"),
                            Name = "Adjustable"
                        });
                });

            modelBuilder.Entity("Imi.Project.Api.Core.Entities.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("Firstname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("HasApprovedTermsAndConditions")
                        .HasColumnType("bit");

                    b.Property<string>("Lastname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RefreshTokenExpiryTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "188f90e8-9f40-4d59-92c9-5954a332e571",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "4c9b30a8-f2bb-4c97-80d9-47b9cc66cab3",
                            DateOfBirth = new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "user@imi.be",
                            EmailConfirmed = true,
                            Firstname = "Imi",
                            HasApprovedTermsAndConditions = true,
                            Lastname = "User",
                            LockoutEnabled = false,
                            NormalizedEmail = "USER@IMI.BE",
                            NormalizedUserName = "IMIUSER",
                            PasswordHash = "AQAAAAEAACcQAAAAEKJIRwbGsuhCW3NgaHikA7pLRliAaI3TwF1Qz863rW/oXOJQMRWsnuFyWxD+3mDHrQ==",
                            PhoneNumber = "0470000001",
                            PhoneNumberConfirmed = true,
                            RefreshTokenExpiryTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            SecurityStamp = "F0842FD914AD234795CB7066909B895A",
                            TwoFactorEnabled = false,
                            UserName = "ImiUser"
                        },
                        new
                        {
                            Id = "9bf21dbb-6cf5-4190-bacc-4e0d3c6d752a",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "61ad8388-02a4-4fdd-af2d-21a2224473c3",
                            DateOfBirth = new DateTime(1990, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "refuser@imi.be",
                            EmailConfirmed = true,
                            Firstname = "Imi",
                            HasApprovedTermsAndConditions = false,
                            Lastname = "Refuser",
                            LockoutEnabled = false,
                            NormalizedEmail = "REFUSER@IMI.BE",
                            NormalizedUserName = "IMIREFUSER",
                            PasswordHash = "AQAAAAEAACcQAAAAEOY0L0XKi2hzeamUwX23LNUzrcazpVPGMLKAL1dAm4Fu7FI4UlH4SwCtNDNWtAyVGA==",
                            PhoneNumber = "0470000002",
                            PhoneNumberConfirmed = true,
                            RefreshTokenExpiryTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            SecurityStamp = "1B936E2EB7674B4F919670913B9397F9",
                            TwoFactorEnabled = false,
                            UserName = "ImiRefuser"
                        },
                        new
                        {
                            Id = "cc3d3a4c-cb1a-4d58-81e8-dec08925923f",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "41e08eef-a668-468e-8172-d9bafbe369f2",
                            DateOfBirth = new DateTime(1990, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "admin@imi.be",
                            EmailConfirmed = true,
                            Firstname = "Imi",
                            Lastname = "Admin",
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMIN@IMI.BE",
                            NormalizedUserName = "IMIADMIN",
                            PasswordHash = "AQAAAAEAACcQAAAAEGXegeAft9WdeOuJAu1ef9GUoSERVWrmfqph7tHsMhYBBw9LTpS9VNOq7Q+iC9Zjdw==",
                            PhoneNumber = "0470000003",
                            PhoneNumberConfirmed = true,
                            RefreshTokenExpiryTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            SecurityStamp = "A2F3AD1C6B0EB84AAB61610FE09154CA",
                            TwoFactorEnabled = false,
                            UserName = "ImiAdmin"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "00000000-0000-0000-0000-000000000001",
                            ConcurrencyStamp = "a7867b17-a779-465a-9792-4caef2557d19",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "00000000-0000-0000-0000-000000000002",
                            ConcurrencyStamp = "dacd925b-f26f-4e4c-86ed-ef8a61fedc4c",
                            Name = "User",
                            NormalizedName = "USER"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ClaimType = "hasApproved",
                            ClaimValue = "True",
                            UserId = "188f90e8-9f40-4d59-92c9-5954a332e571"
                        },
                        new
                        {
                            Id = 2,
                            ClaimType = "hasApproved",
                            ClaimValue = "False",
                            UserId = "9bf21dbb-6cf5-4190-bacc-4e0d3c6d752a"
                        },
                        new
                        {
                            Id = 3,
                            ClaimType = "hasApproved",
                            ClaimValue = "",
                            UserId = "cc3d3a4c-cb1a-4d58-81e8-dec08925923f"
                        },
                        new
                        {
                            Id = 12,
                            ClaimType = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier",
                            ClaimValue = "188f90e8-9f40-4d59-92c9-5954a332e571",
                            UserId = "188f90e8-9f40-4d59-92c9-5954a332e571"
                        },
                        new
                        {
                            Id = 13,
                            ClaimType = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier",
                            ClaimValue = "9bf21dbb-6cf5-4190-bacc-4e0d3c6d752a",
                            UserId = "9bf21dbb-6cf5-4190-bacc-4e0d3c6d752a"
                        },
                        new
                        {
                            Id = 14,
                            ClaimType = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier",
                            ClaimValue = "cc3d3a4c-cb1a-4d58-81e8-dec08925923f",
                            UserId = "cc3d3a4c-cb1a-4d58-81e8-dec08925923f"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = "cc3d3a4c-cb1a-4d58-81e8-dec08925923f",
                            RoleId = "00000000-0000-0000-0000-000000000001"
                        },
                        new
                        {
                            UserId = "188f90e8-9f40-4d59-92c9-5954a332e571",
                            RoleId = "00000000-0000-0000-0000-000000000002"
                        },
                        new
                        {
                            UserId = "9bf21dbb-6cf5-4190-bacc-4e0d3c6d752a",
                            RoleId = "00000000-0000-0000-0000-000000000002"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("CapUser", b =>
                {
                    b.HasOne("Imi.Project.Api.Core.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("LikedByUsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Imi.Project.Api.Core.Entities.Cap", null)
                        .WithMany()
                        .HasForeignKey("LikedCapsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CapUser1", b =>
                {
                    b.HasOne("Imi.Project.Api.Core.Entities.Cap", null)
                        .WithMany()
                        .HasForeignKey("CapsCollectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Imi.Project.Api.Core.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Imi.Project.Api.Core.Entities.Cap", b =>
                {
                    b.HasOne("Imi.Project.Api.Core.Entities.Brand", "Brand")
                        .WithMany("Caps")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Imi.Project.Api.Core.Entities.Fitting", "Fitting")
                        .WithMany("Caps")
                        .HasForeignKey("FittingId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Brand");

                    b.Navigation("Fitting");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Imi.Project.Api.Core.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Imi.Project.Api.Core.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Imi.Project.Api.Core.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Imi.Project.Api.Core.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Imi.Project.Api.Core.Entities.Brand", b =>
                {
                    b.Navigation("Caps");
                });

            modelBuilder.Entity("Imi.Project.Api.Core.Entities.Fitting", b =>
                {
                    b.Navigation("Caps");
                });
#pragma warning restore 612, 618
        }
    }
}
