using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EdufyAPI.Migrations
{
    /// <inheritdoc />
    public partial class RenameTitleInQuiz : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "InternalTitle",
                table: "Quizzes",
                newName: "Title");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Quizzes",
                newName: "InternalTitle");
        }
    }
}
