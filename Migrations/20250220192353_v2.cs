using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EdufyAPI.Migrations
{
    /// <inheritdoc />
    public partial class v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "12beac71-7482-4788-80d2-2a24137bc324");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3883e269-ae43-4090-acd6-be6571431f24");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "42d48e0a-26ce-4767-821a-c59945bab704");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4bada260-0db7-4725-93cf-26bd4c37572f", null, "Admin", "ADMIN" },
                    { "6e852b4a-6bdb-40ef-ba5a-c44446ccdb36", null, "User", "USER" },
                    { "8dfb8e8b-8088-43cb-87a7-cb119a6e4c6b", null, "SuperAdmin", "SUPERADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4bada260-0db7-4725-93cf-26bd4c37572f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6e852b4a-6bdb-40ef-ba5a-c44446ccdb36");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8dfb8e8b-8088-43cb-87a7-cb119a6e4c6b");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "12beac71-7482-4788-80d2-2a24137bc324", null, "SuperAdmin", "SUPERADMIN" },
                    { "3883e269-ae43-4090-acd6-be6571431f24", null, "User", "USER" },
                    { "42d48e0a-26ce-4767-821a-c59945bab704", null, "Admin", "ADMIN" }
                });
        }
    }
}
