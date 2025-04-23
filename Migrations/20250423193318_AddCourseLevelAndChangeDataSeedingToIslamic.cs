using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EdufyAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddCourseLevelAndChangeDataSeedingToIslamic : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Progresses",
                keyColumn: "Id",
                keyValue: "PROG-1001");

            migrationBuilder.DeleteData(
                table: "Progresses",
                keyColumn: "Id",
                keyValue: "PROG-1002");

            migrationBuilder.DeleteData(
                table: "Progresses",
                keyColumn: "Id",
                keyValue: "PROG-1003");

            migrationBuilder.DeleteData(
                table: "Progresses",
                keyColumn: "Id",
                keyValue: "PROG-1004");

            migrationBuilder.AddColumn<int>(
                name: "Level",
                table: "Courses",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: "1c700ea4-ac54-487f-80e4-25c7b348b9e0",
                columns: new[] { "Description", "Level", "ThumbnailUrl", "Title" },
                values: new object[] { "Start your journey of memorizing the Holy Quran with effective techniques and guidance from experienced teachers.", 1, "quran_memorization_thumbnail.jpg", "Quran Memorization for Beginners" });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: "2d7df053-81d5-4bb8-994d-76619c341c46",
                columns: new[] { "Category", "Description", "Level", "ThumbnailUrl", "Title" },
                values: new object[] { 9, "Explore the advanced rulings related to acts of worship including prayer, fasting, and zakat based on classical jurisprudence.", 3, "fiqh_advanced_thumbnail.jpg", "Fiqh of Worship: Advanced Concepts" });

            migrationBuilder.UpdateData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: "LESSON-1001",
                columns: new[] { "Content", "ExternalVideoUrl", "Title" },
                values: new object[] { "This lesson discusses the virtues of memorizing the Quran and how it strengthens one’s connection with Allah.", "https://example.com/quran-intro", "Why Memorize the Quran?" });

            migrationBuilder.UpdateData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: "LESSON-1002",
                columns: new[] { "Content", "ExternalVideoUrl", "Title" },
                values: new object[] { "Learn how to build an effective daily schedule for memorization and review.", "https://example.com/hifz-routine", "Daily Routine for Hifz" });

            migrationBuilder.UpdateData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: "LESSON-1003",
                columns: new[] { "Content", "ExternalVideoUrl", "Title" },
                values: new object[] { "This lesson explores the advanced rulings on prerequisites of prayer such as purity, timing, and facing the Qibla.", "https://example.com/fiqh-salah", "The Conditions of Salah" });

            migrationBuilder.UpdateData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: "LESSON-1004",
                columns: new[] { "Content", "ExternalVideoUrl", "Title" },
                values: new object[] { "Understand the technical conditions, types of zakat, and modern-day applications.", "https://example.com/zakat-rulings", "Zakat: Detailed Rulings" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Level",
                table: "Courses");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: "1c700ea4-ac54-487f-80e4-25c7b348b9e0",
                columns: new[] { "Description", "ThumbnailUrl", "Title" },
                values: new object[] { "Learn the basics of C# programming, including syntax, OOP concepts, and best practices.", "csharp_course_thumbnail.jpg", "Introduction to C#" });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: "2d7df053-81d5-4bb8-994d-76619c341c46",
                columns: new[] { "Category", "Description", "ThumbnailUrl", "Title" },
                values: new object[] { 16, "Deep dive into .NET framework, dependency injection, middleware, and microservices.", "dotnet_course_thumbnail.jpg", "Advanced .NET Development" });

            migrationBuilder.UpdateData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: "LESSON-1001",
                columns: new[] { "Content", "ExternalVideoUrl", "Title" },
                values: new object[] { "This is the introduction to programming, covering the basics of coding.", "https://example.com/intro-video", "Introduction to Programming" });

            migrationBuilder.UpdateData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: "LESSON-1002",
                columns: new[] { "Content", "ExternalVideoUrl", "Title" },
                values: new object[] { "This lesson explains variables, constants, and different data types in programming.", "https://example.com/variables-video", "Variables and Data Types" });

            migrationBuilder.UpdateData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: "LESSON-1003",
                columns: new[] { "Content", "ExternalVideoUrl", "Title" },
                values: new object[] { "This lesson dives deep into sorting algorithms and their applications.", "https://example.com/algorithms-video", "Advanced Algorithms" });

            migrationBuilder.UpdateData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: "LESSON-1004",
                columns: new[] { "Content", "ExternalVideoUrl", "Title" },
                values: new object[] { "Learn about trees, graphs, and their applications in computer science.", "https://example.com/data-structures-video", "Data Structures: Trees and Graphs" });

            migrationBuilder.InsertData(
                table: "Progresses",
                columns: new[] { "Id", "CompletedProgress", "CourseId", "LastUpdated", "StudentId", "TotalLessonsCompleted" },
                values: new object[,]
                {
                    { "PROG-1001", false, "1c700ea4-ac54-487f-80e4-25c7b348b9e0", new DateTime(2025, 4, 7, 0, 0, 0, 0, DateTimeKind.Utc), "626b8c7f-f4d4-4467-bb37-570f1aa6fd77", 5 },
                    { "PROG-1002", false, "1c700ea4-ac54-487f-80e4-25c7b348b9e0", new DateTime(2025, 4, 7, 0, 0, 0, 0, DateTimeKind.Utc), "e452e625-327a-4bf2-9540-3db6577ab68f", 7 },
                    { "PROG-1003", false, "2d7df053-81d5-4bb8-994d-76619c341c46", new DateTime(2025, 4, 7, 0, 0, 0, 0, DateTimeKind.Utc), "626b8c7f-f4d4-4467-bb37-570f1aa6fd77", 10 },
                    { "PROG-1004", false, "2d7df053-81d5-4bb8-994d-76619c341c46", new DateTime(2025, 4, 7, 0, 0, 0, 0, DateTimeKind.Utc), "e452e625-327a-4bf2-9540-3db6577ab68f", 12 }
                });
        }
    }
}
