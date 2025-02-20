using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EdufyAPI.Migrations
{
    /// <inheritdoc />
    public partial class v11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "9f34a749-1f24-4900-934c-8a1169e783f4", null, "Admin", "ADMIN" },
                    { "af3e27b6-c7a9-485f-ace4-9cf2f09e2665", null, "SuperAdmin", "SUPERADMIN" },
                    { "f7037243-7026-4e32-afcb-0da06b7c0100", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9f34a749-1f24-4900-934c-8a1169e783f4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "af3e27b6-c7a9-485f-ace4-9cf2f09e2665");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f7037243-7026-4e32-afcb-0da06b7c0100");

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
    }
}
