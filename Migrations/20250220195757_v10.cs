using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EdufyAPI.Migrations
{
    /// <inheritdoc />
    public partial class v10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "1ec40b0b-3c82-4096-adb1-d0499fb33402", null, "Admin", "ADMIN" },
                    { "4f9c1556-67c5-4f93-8e07-e68da79d954e", null, "User", "USER" },
                    { "af243fd6-29fb-451f-bd65-55cce3f07886", null, "SuperAdmin", "SUPERADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1ec40b0b-3c82-4096-adb1-d0499fb33402");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4f9c1556-67c5-4f93-8e07-e68da79d954e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "af243fd6-29fb-451f-bd65-55cce3f07886");

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
    }
}
