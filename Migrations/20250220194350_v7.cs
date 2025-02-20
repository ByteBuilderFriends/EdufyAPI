using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EdufyAPI.Migrations
{
    /// <inheritdoc />
    public partial class v7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "4bcca914-f42a-49b1-9057-2e72f5a79408", null, "User", "USER" },
                    { "700dd39c-484b-4456-b589-bceba144f465", null, "Admin", "ADMIN" },
                    { "e9ce2295-29d1-4976-99ac-8d5279e62d6b", null, "SuperAdmin", "SUPERADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { "3bad26cf-f9ca-4974-bd5c-47d1fa76f650", null, "User", "USER" },
                    { "4e9e2f1f-4753-477c-a319-4fd9acfbedc6", null, "SuperAdmin", "SUPERADMIN" },
                    { "6ac17fbf-8e33-471f-b8c8-e141e0c597c4", null, "Admin", "ADMIN" }
                });
        }
    }
}
