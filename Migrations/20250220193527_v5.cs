using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EdufyAPI.Migrations
{
    /// <inheritdoc />
    public partial class v5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "4627a144-27b1-4ea5-87b5-dc8d6257b6bb", null, "Admin", "ADMIN" },
                    { "5bebf02a-dea5-4cdd-893b-f701ffec4112", null, "User", "USER" },
                    { "6e56decb-a000-42af-a71c-6842e176142e", null, "SuperAdmin", "SUPERADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4627a144-27b1-4ea5-87b5-dc8d6257b6bb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5bebf02a-dea5-4cdd-893b-f701ffec4112");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6e56decb-a000-42af-a71c-6842e176142e");

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
    }
}
