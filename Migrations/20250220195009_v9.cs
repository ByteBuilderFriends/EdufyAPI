using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EdufyAPI.Migrations
{
    /// <inheritdoc />
    public partial class v9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "228b55ee-48cf-400c-a33b-0e73a75b0639", null, "SuperAdmin", "SUPERADMIN" },
                    { "610d7559-2eac-4971-96d5-8255f0771ebb", null, "Admin", "ADMIN" },
                    { "c0e202f4-b0a6-4828-a3ed-83469974e35c", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "228b55ee-48cf-400c-a33b-0e73a75b0639");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "610d7559-2eac-4971-96d5-8255f0771ebb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c0e202f4-b0a6-4828-a3ed-83469974e35c");

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
    }
}
