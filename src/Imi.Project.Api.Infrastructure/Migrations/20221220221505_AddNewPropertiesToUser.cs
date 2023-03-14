using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Imi.Project.Api.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddNewPropertiesToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RefreshToken",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RefreshTokenExpiryTime",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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
                columns: new[] { "PasswordHash", "RefreshToken", "RefreshTokenExpiryTime", "SecurityStamp" },
                values: new object[] { "AQAAAAEAACcQAAAAECk/Ly8hLiTywZAiY7AVL6CCfH+5wcDDkh18AuZqrZPhmsT7/RuXIDwMj2AJk0XKGA==", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A3BF5EF0E681074089066686658DF064" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9bf21dbb-6cf5-4190-bacc-4e0d3c6d752a",
                columns: new[] { "PasswordHash", "RefreshToken", "RefreshTokenExpiryTime", "SecurityStamp" },
                values: new object[] { "AQAAAAEAACcQAAAAEN5OAVeTz/aORZW757mSgrfABDd1vt201xyeBBxXBrpFj68u/mHkgmSGDq9X/TnWlg==", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "3B44820509AEB64C96BCEC89868F3640" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cc3d3a4c-cb1a-4d58-81e8-dec08925923f",
                columns: new[] { "PasswordHash", "RefreshToken", "RefreshTokenExpiryTime", "SecurityStamp" },
                values: new object[] { "AQAAAAEAACcQAAAAEKkqu4S+DjZ6Hqb2PMk2Eiik6rN/F6IoUQk9nvCQcCz3OIQYSKX/Vrq0oRqmVIVFWQ==", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "F805CF1798C92844BA710CDBEAA61B1F" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RefreshToken",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RefreshTokenExpiryTime",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000001",
                column: "ConcurrencyStamp",
                value: "a4eafa25-1fbf-4644-b7c6-25f168939fb2");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "188f90e8-9f40-4d59-92c9-5954a332e571",
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AQAAAAEAACcQAAAAECgbzd8+/nUePEXM5AcUsoyYsSCRXTPT7j3NmH+VyKxxIwxZqJABe84ovozdJX2Kcg==", "F63CBF464D25564EB58F896474DF4850" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9bf21dbb-6cf5-4190-bacc-4e0d3c6d752a",
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AQAAAAEAACcQAAAAEBV2yMexKltw7CfQwS+UJxn8UXUlXzrHqEKS6U4GyrJfcxoCzC+FDlth8yUs/+EZnA==", "A8687B743982044B94AFA1343E208DDD" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cc3d3a4c-cb1a-4d58-81e8-dec08925923f",
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AQAAAAEAACcQAAAAEJpWfOIL2osBqxU2Z/PqM6jsEiVkgwvEti0GhTE8Ey9/hSsTigNGxNmNp3TI22rI/g==", "55CFDDF5B2142648A9EA3B5E06D1996E" });
        }
    }
}
