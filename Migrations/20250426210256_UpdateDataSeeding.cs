using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EdufyAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDataSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: "1c700ea4-ac54-487f-80e4-25c7b348b9e0",
                column: "Category",
                value: 16);

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: "2d7df053-81d5-4bb8-994d-76619c341c46",
                column: "Category",
                value: 4);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: "1c700ea4-ac54-487f-80e4-25c7b348b9e0",
                column: "Category",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: "2d7df053-81d5-4bb8-994d-76619c341c46",
                column: "Category",
                value: 9);
        }
    }
}
