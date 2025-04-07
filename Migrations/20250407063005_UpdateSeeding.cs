using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EdufyAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Options",
                columns: new[] { "Id", "IsCorrect", "OptionText", "QuestionId" },
                values: new object[,]
                {
                    { "OPTION-5", false, "Berlin", "QUESTION-2" },
                    { "OPTION-6", false, "Madrid", "QUESTION-2" },
                    { "OPTION-7", true, "Paris", "QUESTION-2" },
                    { "OPTION-8", false, "Rome", "QUESTION-2" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: "OPTION-5");

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: "OPTION-6");

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: "OPTION-7");

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "Id",
                keyValue: "OPTION-8");
        }
    }
}
