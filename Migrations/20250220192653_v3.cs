using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EdufyAPI.Migrations
{
    /// <inheritdoc />
    public partial class v3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "73846490-9b22-42df-bfc8-65c5c50c5521", null, "Admin", "ADMIN" },
                    { "93607ce4-f8bd-4288-b334-21e9d823ba3e", null, "User", "USER" },
                    { "e64af17d-1fc2-415b-a6c5-a9b676be4d95", null, "SuperAdmin", "SUPERADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "73846490-9b22-42df-bfc8-65c5c50c5521");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "93607ce4-f8bd-4288-b334-21e9d823ba3e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e64af17d-1fc2-415b-a6c5-a9b676be4d95");

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
    }
}
