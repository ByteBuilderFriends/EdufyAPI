using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EdufyAPI.Migrations
{
    /// <inheritdoc />
    public partial class v8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4bcca914-f42a-49b1-9057-2e72f5a79408");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "700dd39c-484b-4456-b589-bceba144f465");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e9ce2295-29d1-4976-99ac-8d5279e62d6b");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6efdbf3c-7e88-47ef-880e-9b1ae60661aa", null, "User", "USER" },
                    { "8a6e1278-5eed-456a-be02-18857caf3080", null, "Admin", "ADMIN" },
                    { "f1848124-1773-4279-a5ae-2cfdedea05f5", null, "SuperAdmin", "SUPERADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6efdbf3c-7e88-47ef-880e-9b1ae60661aa");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8a6e1278-5eed-456a-be02-18857caf3080");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f1848124-1773-4279-a5ae-2cfdedea05f5");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4bcca914-f42a-49b1-9057-2e72f5a79408", null, "User", "USER" },
                    { "700dd39c-484b-4456-b589-bceba144f465", null, "Admin", "ADMIN" },
                    { "e9ce2295-29d1-4976-99ac-8d5279e62d6b", null, "SuperAdmin", "SUPERADMIN" }
                });
        }
    }
}
