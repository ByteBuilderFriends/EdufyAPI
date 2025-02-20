using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EdufyAPI.Migrations
{
    /// <inheritdoc />
    public partial class v4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "0eb47b92-286c-433a-8272-0cc50c0f8ae2", null, "SuperAdmin", "SUPERADMIN" },
                    { "731a6836-1487-474d-ad14-7dba4cf9789b", null, "User", "USER" },
                    { "b963c601-f255-4101-a46a-4ddbe0efb1ca", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0eb47b92-286c-433a-8272-0cc50c0f8ae2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "731a6836-1487-474d-ad14-7dba4cf9789b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b963c601-f255-4101-a46a-4ddbe0efb1ca");

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
    }
}
