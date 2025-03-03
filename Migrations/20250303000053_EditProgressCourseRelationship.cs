using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EdufyAPI.Migrations
{
    /// <inheritdoc />
    public partial class EditProgressCourseRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Progresses_CourseId",
                table: "Progresses");

            migrationBuilder.CreateIndex(
                name: "IX_Progresses_CourseId_StudentId",
                table: "Progresses",
                columns: new[] { "CourseId", "StudentId" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Progresses_Enrollment_CourseId_StudentId",
                table: "Progresses",
                columns: new[] { "CourseId", "StudentId" },
                principalTable: "Enrollment",
                principalColumns: new[] { "StudentId", "CourseId" },
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Progresses_Enrollment_CourseId_StudentId",
                table: "Progresses");

            migrationBuilder.DropIndex(
                name: "IX_Progresses_CourseId_StudentId",
                table: "Progresses");

            migrationBuilder.CreateIndex(
                name: "IX_Progresses_CourseId",
                table: "Progresses",
                column: "CourseId");
        }
    }
}
