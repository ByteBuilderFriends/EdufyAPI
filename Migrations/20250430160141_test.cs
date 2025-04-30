using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AskAMuslimAPI.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Category", "Description", "InstructorId", "Level", "ThumbnailUrl", "Title" },
                values: new object[] { "tester", 16, "tester", "2c179b2d-1d3b-42a3-8d6f-d2fd86b73c29", 1, "myPhoto.jpeg", "tester" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: "tester");
        }
    }
}
