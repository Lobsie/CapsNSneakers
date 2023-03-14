using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Imi.Project.Api.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NewInitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Firstname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lastname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HasApprovedTermsAndConditions = table.Column<bool>(type: "bit", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fittings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fittings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Caps",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Material = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Colorway = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrandId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FittingId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Caps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Caps_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Caps_Fittings_FittingId",
                        column: x => x.FittingId,
                        principalTable: "Fittings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "CapsLikedByUsers",
                columns: table => new
                {
                    LikedByUsersId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LikedCapsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CapsLikedByUsers", x => new { x.LikedByUsersId, x.LikedCapsId });
                    table.ForeignKey(
                        name: "FK_CapsLikedByUsers_AspNetUsers_LikedByUsersId",
                        column: x => x.LikedByUsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CapsLikedByUsers_Caps_LikedCapsId",
                        column: x => x.LikedCapsId,
                        principalTable: "Caps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CapsOwnedByUsers",
                columns: table => new
                {
                    CapsCollectionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsersId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CapsOwnedByUsers", x => new { x.CapsCollectionId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_CapsOwnedByUsers_AspNetUsers_UsersId",
                        column: x => x.UsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CapsOwnedByUsers_Caps_CapsCollectionId",
                        column: x => x.CapsCollectionId,
                        principalTable: "Caps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "00000000-0000-0000-0000-000000000001", "a4eafa25-1fbf-4644-b7c6-25f168939fb2", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateOfBirth", "Email", "EmailConfirmed", "Firstname", "HasApprovedTermsAndConditions", "Lastname", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "188f90e8-9f40-4d59-92c9-5954a332e571", 0, "4c9b30a8-f2bb-4c97-80d9-47b9cc66cab3", new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "user@imi.be", true, "Imi", true, "User", false, null, "USER@IMI.BE", "IMIUSER", "AQAAAAEAACcQAAAAECgbzd8+/nUePEXM5AcUsoyYsSCRXTPT7j3NmH+VyKxxIwxZqJABe84ovozdJX2Kcg==", "0470000001", true, "F63CBF464D25564EB58F896474DF4850", false, "ImiUser" },
                    { "9bf21dbb-6cf5-4190-bacc-4e0d3c6d752a", 0, "61ad8388-02a4-4fdd-af2d-21a2224473c3", new DateTime(1990, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "refuser@imi.be", true, "Imi", false, "Refuser", false, null, "REFUSER@IMI.BE", "IMIREFUSER", "AQAAAAEAACcQAAAAEBV2yMexKltw7CfQwS+UJxn8UXUlXzrHqEKS6U4GyrJfcxoCzC+FDlth8yUs/+EZnA==", "0470000002", true, "A8687B743982044B94AFA1343E208DDD", false, "ImiRefuser" },
                    { "cc3d3a4c-cb1a-4d58-81e8-dec08925923f", 0, "41e08eef-a668-468e-8172-d9bafbe369f2", new DateTime(1990, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@imi.be", true, "Imi", null, "Admin", false, null, "ADMIN@IMI.BE", "IMIADMIN", "AQAAAAEAACcQAAAAEJpWfOIL2osBqxU2Z/PqM6jsEiVkgwvEti0GhTE8Ey9/hSsTigNGxNmNp3TI22rI/g==", "0470000003", true, "55CFDDF5B2142648A9EA3B5E06D1996E", false, "ImiAdmin" }
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("34495ce8-cb32-4fc6-be6e-f01ec9516c84"), "Mitchel & Ness" },
                    { new Guid("411e97b5-24ac-4f77-9401-ed8e95cc91a0"), "New Era" },
                    { new Guid("6710ae13-5c89-460a-aadb-c58f9d207288"), "Goorin Bros." },
                    { new Guid("bc5ec2ac-5fe2-447d-be60-cd0b85539a61"), "Capslab" },
                    { new Guid("bcc6ea98-2f4b-47a6-ab2f-b1e156589a8e"), "Brixton" },
                    { new Guid("c116b76c-b60e-4c0b-9615-f015cb0eb64d"), "Burton" },
                    { new Guid("d4148156-f492-4290-9325-f7936ebdaf83"), "47 Brand" },
                    { new Guid("e77b07b6-27c3-4df6-bbab-10d10cb5a22f"), "Nike" },
                    { new Guid("f3f00bed-635e-4d5a-9e4d-e8b076a90632"), "Bearded Man" }
                });

            migrationBuilder.InsertData(
                table: "Fittings",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("033449e3-d71c-4182-a62c-f725d2fe27f5"), "5-Panel" },
                    { new Guid("362f8832-1186-4b41-be31-76099e11d288"), "Stretchfit" },
                    { new Guid("625c000d-934b-4a48-a5da-2390021eaa65"), "Trucker" },
                    { new Guid("697af9aa-8ca3-4b35-9e7f-145c245cac55"), "Dad Cap" },
                    { new Guid("74f6e159-3c96-457a-a7e7-3a58e9640f07"), "Fitted" },
                    { new Guid("b3105e3b-4a55-486d-abaf-f96b014736b0"), "Snapback" },
                    { new Guid("f96b8562-adf5-4bec-945f-a9f9e53e320a"), "Adjustable" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "UserId" },
                values: new object[,]
                {
                    { 1, "hasApproved", "True", "188f90e8-9f40-4d59-92c9-5954a332e571" },
                    { 2, "hasApproved", "False", "9bf21dbb-6cf5-4190-bacc-4e0d3c6d752a" },
                    { 3, "hasApproved", "", "cc3d3a4c-cb1a-4d58-81e8-dec08925923f" },
                    { 12, "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier", "188f90e8-9f40-4d59-92c9-5954a332e571", "188f90e8-9f40-4d59-92c9-5954a332e571" },
                    { 13, "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier", "9bf21dbb-6cf5-4190-bacc-4e0d3c6d752a", "9bf21dbb-6cf5-4190-bacc-4e0d3c6d752a" },
                    { 14, "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier", "cc3d3a4c-cb1a-4d58-81e8-dec08925923f", "cc3d3a4c-cb1a-4d58-81e8-dec08925923f" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "00000000-0000-0000-0000-000000000001", "cc3d3a4c-cb1a-4d58-81e8-dec08925923f" });

            migrationBuilder.InsertData(
                table: "Caps",
                columns: new[] { "Id", "BrandId", "Colorway", "FittingId", "Material", "Name" },
                values: new object[,]
                {
                    { new Guid("48d407e3-f47c-4ad6-bbdf-b14347cbc095"), new Guid("f3f00bed-635e-4d5a-9e4d-e8b076a90632"), "Beige", new Guid("697af9aa-8ca3-4b35-9e7f-145c245cac55"), "100% Cotton", "Dark Side Of The Beard Ripped" },
                    { new Guid("67f39956-6fd9-486f-a84e-e6195533e906"), new Guid("411e97b5-24ac-4f77-9401-ed8e95cc91a0"), "Black", new Guid("f96b8562-adf5-4bec-945f-a9f9e53e320a"), "100% Cotton", "Caps Exclusive Roses A-Frame" },
                    { new Guid("74443ec9-a663-48f0-bb6f-79def81ffd39"), new Guid("34495ce8-cb32-4fc6-be6e-f01ec9516c84"), "Off white/Black", new Guid("b3105e3b-4a55-486d-abaf-f96b014736b0"), "100% Polyester", "Seattle Supersonics 50th" },
                    { new Guid("789dbb4e-fc85-42aa-8887-96ae9d07acd5"), new Guid("411e97b5-24ac-4f77-9401-ed8e95cc91a0"), "Green/Pink", new Guid("033449e3-d71c-4182-a62c-f725d2fe27f5"), "100% Polyester", "Polartec Camper" },
                    { new Guid("893b881f-f606-421c-931d-08d9d4b3ebff"), new Guid("34495ce8-cb32-4fc6-be6e-f01ec9516c84"), "Black/Gold", new Guid("625c000d-934b-4a48-a5da-2390021eaa65"), "60% Cotton, 40% Polyester", "Own Brand Box Logo" },
                    { new Guid("a0cb17a8-91cc-4579-be4c-bf590c9c1f23"), new Guid("34495ce8-cb32-4fc6-be6e-f01ec9516c84"), "Black", new Guid("b3105e3b-4a55-486d-abaf-f96b014736b0"), "100% Polyester", "Chicago Bulls The Finals" },
                    { new Guid("a6a70eb4-39ab-4e1f-94b5-380b282f7003"), new Guid("34495ce8-cb32-4fc6-be6e-f01ec9516c84"), "Black", new Guid("b3105e3b-4a55-486d-abaf-f96b014736b0"), "80% Acrylic, 20% Wool", "Blank Black" },
                    { new Guid("ac6c9cab-aada-469b-8b6c-7e48bc4b4dac"), new Guid("34495ce8-cb32-4fc6-be6e-f01ec9516c84"), "Stone/Forest", new Guid("f96b8562-adf5-4bec-945f-a9f9e53e320a"), "63% Polyester, 34% Cotton, 3% P.U. Spandex", "Brooklyn Nets" },
                    { new Guid("ce181b1e-9c17-4442-82fd-a126e82d8efe"), new Guid("34495ce8-cb32-4fc6-be6e-f01ec9516c84"), "Navy/Yellow", new Guid("74f6e159-3c96-457a-a7e7-3a58e9640f07"), "100% Polyester", "Denver Nuggets Coast2coast" },
                    { new Guid("e87e2d97-0715-48f0-b5c2-26b3abbada28"), new Guid("f3f00bed-635e-4d5a-9e4d-e8b076a90632"), "Beige", new Guid("625c000d-934b-4a48-a5da-2390021eaa65"), "100% Polyester", "Cap Man" }
                });

            migrationBuilder.InsertData(
                table: "CapsLikedByUsers",
                columns: new[] { "LikedByUsersId", "LikedCapsId" },
                values: new object[,]
                {
                    { "188f90e8-9f40-4d59-92c9-5954a332e571", new Guid("48d407e3-f47c-4ad6-bbdf-b14347cbc095") },
                    { "188f90e8-9f40-4d59-92c9-5954a332e571", new Guid("74443ec9-a663-48f0-bb6f-79def81ffd39") },
                    { "188f90e8-9f40-4d59-92c9-5954a332e571", new Guid("a0cb17a8-91cc-4579-be4c-bf590c9c1f23") },
                    { "188f90e8-9f40-4d59-92c9-5954a332e571", new Guid("a6a70eb4-39ab-4e1f-94b5-380b282f7003") },
                    { "188f90e8-9f40-4d59-92c9-5954a332e571", new Guid("e87e2d97-0715-48f0-b5c2-26b3abbada28") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Caps_BrandId",
                table: "Caps",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Caps_FittingId",
                table: "Caps",
                column: "FittingId");

            migrationBuilder.CreateIndex(
                name: "IX_CapsLikedByUsers_LikedCapsId",
                table: "CapsLikedByUsers",
                column: "LikedCapsId");

            migrationBuilder.CreateIndex(
                name: "IX_CapsOwnedByUsers_UsersId",
                table: "CapsOwnedByUsers",
                column: "UsersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CapsLikedByUsers");

            migrationBuilder.DropTable(
                name: "CapsOwnedByUsers");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Caps");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Fittings");
        }
    }
}
