using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EdufyAPI.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "051cd7ad-6f8e-481d-a25b-1728562bc54c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "13d95390-de57-4a20-8365-9d2c9605cf71");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2fa149bd-c452-4a9a-a801-98082e6a1e5e");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { "051cd7ad-6f8e-481d-a25b-1728562bc54c", null, "SuperAdmin", "SUPERADMIN" },
                    { "13d95390-de57-4a20-8365-9d2c9605cf71", null, "Admin", "ADMIN" },
                    { "2fa149bd-c452-4a9a-a801-98082e6a1e5e", null, "User", "USER" }
                });
        }
    }
}
