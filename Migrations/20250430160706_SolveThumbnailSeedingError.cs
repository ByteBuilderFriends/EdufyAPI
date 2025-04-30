using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AskAMuslimAPI.Migrations
{
    /// <inheritdoc />
    public partial class SolveThumbnailSeedingError : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: "tester");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: "a1",
                column: "ThumbnailUrl",
                value: "a1.jpg");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: "a2",
                column: "ThumbnailUrl",
                value: "a2.jpg");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: "a3",
                column: "ThumbnailUrl",
                value: "a3.jpg");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: "a4",
                column: "ThumbnailUrl",
                value: "a4.jpg");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: "f1",
                column: "ThumbnailUrl",
                value: "f1.jpg");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: "f2",
                column: "ThumbnailUrl",
                value: "f2.jpg");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: "f3",
                column: "ThumbnailUrl",
                value: "f3.jpg");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: "f4",
                column: "ThumbnailUrl",
                value: "f4.jpg");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: "fa1",
                column: "ThumbnailUrl",
                value: "fa1.jpg");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: "fa2",
                column: "ThumbnailUrl",
                value: "fa2.jpg");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: "fa3",
                column: "ThumbnailUrl",
                value: "fa3.jpg");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: "fa4",
                column: "ThumbnailUrl",
                value: "fa4.jpg");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: "h1",
                column: "ThumbnailUrl",
                value: "h1.jpg");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: "h2",
                column: "ThumbnailUrl",
                value: "h2.jpg");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: "h3",
                column: "ThumbnailUrl",
                value: "h3.jpg");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: "h4",
                column: "ThumbnailUrl",
                value: "h4.jpg");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: "q1",
                column: "ThumbnailUrl",
                value: "q1.jpg");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: "q2",
                column: "ThumbnailUrl",
                value: "q2.jpg");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: "q3",
                column: "ThumbnailUrl",
                value: "q3.jpg");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: "q4",
                column: "ThumbnailUrl",
                value: "q4.jpg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: "a1",
                column: "ThumbnailUrl",
                value: "https://ask-a-muslim.runasp.net/uploads/course-thumbnails/a1.jpg");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: "a2",
                column: "ThumbnailUrl",
                value: "https://ask-a-muslim.runasp.net/uploads/course-thumbnails/a2.jpg");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: "a3",
                column: "ThumbnailUrl",
                value: "https://ask-a-muslim.runasp.net/uploads/course-thumbnails/a3.jpg");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: "a4",
                column: "ThumbnailUrl",
                value: "https://ask-a-muslim.runasp.net/uploads/course-thumbnails/a4.jpg");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: "f1",
                column: "ThumbnailUrl",
                value: "https://ask-a-muslim.runasp.net/uploads/course-thumbnails/f1.jpg");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: "f2",
                column: "ThumbnailUrl",
                value: "https://ask-a-muslim.runasp.net/uploads/course-thumbnails/f2.jpg");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: "f3",
                column: "ThumbnailUrl",
                value: "https://ask-a-muslim.runasp.net/uploads/course-thumbnails/f3.jpg");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: "f4",
                column: "ThumbnailUrl",
                value: "https://ask-a-muslim.runasp.net/uploads/course-thumbnails/f4.jpg");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: "fa1",
                column: "ThumbnailUrl",
                value: "https://ask-a-muslim.runasp.net/uploads/course-thumbnails/fa1.jpg");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: "fa2",
                column: "ThumbnailUrl",
                value: "https://ask-a-muslim.runasp.net/uploads/course-thumbnails/fa2.jpg");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: "fa3",
                column: "ThumbnailUrl",
                value: "https://ask-a-muslim.runasp.net/uploads/course-thumbnails/fa3.jpg");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: "fa4",
                column: "ThumbnailUrl",
                value: "https://ask-a-muslim.runasp.net/uploads/course-thumbnails/fa4.jpg");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: "h1",
                column: "ThumbnailUrl",
                value: "https://ask-a-muslim.runasp.net/uploads/course-thumbnails/h1.jpg");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: "h2",
                column: "ThumbnailUrl",
                value: "https://ask-a-muslim.runasp.net/uploads/course-thumbnails/h2.jpg");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: "h3",
                column: "ThumbnailUrl",
                value: "https://ask-a-muslim.runasp.net/uploads/course-thumbnails/h3.jpg");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: "h4",
                column: "ThumbnailUrl",
                value: "https://ask-a-muslim.runasp.net/uploads/course-thumbnails/h4.jpg");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: "q1",
                column: "ThumbnailUrl",
                value: "https://ask-a-muslim.runasp.net/uploads/course-thumbnails/q1.jpg");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: "q2",
                column: "ThumbnailUrl",
                value: "https://ask-a-muslim.runasp.net/uploads/course-thumbnails/q2.jpg");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: "q3",
                column: "ThumbnailUrl",
                value: "https://ask-a-muslim.runasp.net/uploads/course-thumbnails/q3.jpg");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: "q4",
                column: "ThumbnailUrl",
                value: "https://ask-a-muslim.runasp.net/uploads/course-thumbnails/q4.jpg");

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Category", "Description", "InstructorId", "Level", "ThumbnailUrl", "Title" },
                values: new object[] { "tester", 16, "tester", "2c179b2d-1d3b-42a3-8d6f-d2fd86b73c29", 1, "myPhoto.jpeg", "tester" });
        }
    }
}
