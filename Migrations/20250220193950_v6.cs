using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EdufyAPI.Migrations
{
    /// <inheritdoc />
    public partial class v6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "3bad26cf-f9ca-4974-bd5c-47d1fa76f650", null, "User", "USER" },
                    { "4e9e2f1f-4753-477c-a319-4fd9acfbedc6", null, "SuperAdmin", "SUPERADMIN" },
                    { "6ac17fbf-8e33-471f-b8c8-e141e0c597c4", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3bad26cf-f9ca-4974-bd5c-47d1fa76f650");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4e9e2f1f-4753-477c-a319-4fd9acfbedc6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6ac17fbf-8e33-471f-b8c8-e141e0c597c4");

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
    }
}
