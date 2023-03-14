using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Imi.Project.Api.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddRolesToUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000001",
                column: "ConcurrencyStamp",
                value: "a7867b17-a779-465a-9792-4caef2557d19");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "00000000-0000-0000-0000-000000000002", "dacd925b-f26f-4e4c-86ed-ef8a61fedc4c", "User", "USER" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "188f90e8-9f40-4d59-92c9-5954a332e571",
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AQAAAAEAACcQAAAAEKJIRwbGsuhCW3NgaHikA7pLRliAaI3TwF1Qz863rW/oXOJQMRWsnuFyWxD+3mDHrQ==", "F0842FD914AD234795CB7066909B895A" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9bf21dbb-6cf5-4190-bacc-4e0d3c6d752a",
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AQAAAAEAACcQAAAAEOY0L0XKi2hzeamUwX23LNUzrcazpVPGMLKAL1dAm4Fu7FI4UlH4SwCtNDNWtAyVGA==", "1B936E2EB7674B4F919670913B9397F9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cc3d3a4c-cb1a-4d58-81e8-dec08925923f",
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AQAAAAEAACcQAAAAEGXegeAft9WdeOuJAu1ef9GUoSERVWrmfqph7tHsMhYBBw9LTpS9VNOq7Q+iC9Zjdw==", "A2F3AD1C6B0EB84AAB61610FE09154CA" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "00000000-0000-0000-0000-000000000002", "188f90e8-9f40-4d59-92c9-5954a332e571" },
                    { "00000000-0000-0000-0000-000000000002", "9bf21dbb-6cf5-4190-bacc-4e0d3c6d752a" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "00000000-0000-0000-0000-000000000002", "188f90e8-9f40-4d59-92c9-5954a332e571" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "00000000-0000-0000-0000-000000000002", "9bf21dbb-6cf5-4190-bacc-4e0d3c6d752a" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000002");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000001",
                column: "ConcurrencyStamp",
                value: "e83fc6c9-319b-42ea-ae65-a13a08095f52");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "188f90e8-9f40-4d59-92c9-5954a332e571",
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AQAAAAEAACcQAAAAECk/Ly8hLiTywZAiY7AVL6CCfH+5wcDDkh18AuZqrZPhmsT7/RuXIDwMj2AJk0XKGA==", "A3BF5EF0E681074089066686658DF064" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9bf21dbb-6cf5-4190-bacc-4e0d3c6d752a",
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AQAAAAEAACcQAAAAEN5OAVeTz/aORZW757mSgrfABDd1vt201xyeBBxXBrpFj68u/mHkgmSGDq9X/TnWlg==", "3B44820509AEB64C96BCEC89868F3640" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cc3d3a4c-cb1a-4d58-81e8-dec08925923f",
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AQAAAAEAACcQAAAAEKkqu4S+DjZ6Hqb2PMk2Eiik6rN/F6IoUQk9nvCQcCz3OIQYSKX/Vrq0oRqmVIVFWQ==", "F805CF1798C92844BA710CDBEAA61B1F" });
        }
    }
}
