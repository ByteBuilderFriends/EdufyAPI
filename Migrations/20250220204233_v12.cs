using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EdufyAPI.Migrations
{
    /// <inheritdoc />
    public partial class v12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "5648e524-f459-485b-833f-e074920a8a7e", null, "SuperAdmin", "SUPERADMIN" },
                    { "db313d72-aea3-40da-9bbf-bb1d96db30cf", null, "Admin", "ADMIN" },
                    { "e5397d2a-5107-4c48-b700-b81ba667e88a", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5648e524-f459-485b-833f-e074920a8a7e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "db313d72-aea3-40da-9bbf-bb1d96db30cf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e5397d2a-5107-4c48-b700-b81ba667e88a");

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
    }
}
