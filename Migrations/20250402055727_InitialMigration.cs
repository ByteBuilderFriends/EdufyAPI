using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EdufyAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    ProfilePictureUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThumbnailUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InstructorId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Courses_AspNetUsers_InstructorId",
                        column: x => x.InstructorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Enrollment",
                columns: table => new
                {
                    StudentId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CourseId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrollment", x => new { x.StudentId, x.CourseId });
                    table.ForeignKey(
                        name: "FK_Enrollment_AspNetUsers_StudentId",
                        column: x => x.StudentId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Enrollment_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Lessons",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThumbnailUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VideoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExternalVideoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CourseId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lessons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lessons_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Progresses",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TotalLessonsCompleted = table.Column<int>(type: "int", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CourseId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StudentId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Progresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Progresses_AspNetUsers_StudentId",
                        column: x => x.StudentId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Progresses_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Progresses_Enrollment_StudentId_CourseId",
                        columns: x => new { x.StudentId, x.CourseId },
                        principalTable: "Enrollment",
                        principalColumns: new[] { "StudentId", "CourseId" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Quizzes",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PassingScore = table.Column<int>(type: "int", nullable: false),
                    TimeLimit = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LessonId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quizzes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Quizzes_Lessons_LessonId",
                        column: x => x.LessonId,
                        principalTable: "Lessons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Certificate",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CertificateNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IssueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProgressId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Certificate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Certificate_Progresses_ProgressId",
                        column: x => x.ProgressId,
                        principalTable: "Progresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Explanation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Points = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    OrderIndex = table.Column<int>(type: "int", nullable: false),
                    Answer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuizId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Questions_Quizzes_QuizId",
                        column: x => x.QuizId,
                        principalTable: "Quizzes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "QuizResults",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Score = table.Column<double>(type: "float", nullable: false),
                    StartedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CompletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProgressId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    QuizId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StudentId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuizResults", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuizResults_AspNetUsers_StudentId",
                        column: x => x.StudentId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_QuizResults_Progresses_ProgressId",
                        column: x => x.ProgressId,
                        principalTable: "Progresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_QuizResults_Quizzes_QuizId",
                        column: x => x.QuizId,
                        principalTable: "Quizzes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Answers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsCorrect = table.Column<bool>(type: "bit", nullable: false),
                    Explanation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderIndex = table.Column<int>(type: "int", nullable: false),
                    QuestionId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Answers_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentAnswer",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SubmittedAnswer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubmittedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsCorrect = table.Column<bool>(type: "bit", nullable: false),
                    SelectedAnswerIds = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuizResultId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    QuestionId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AnswerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentAnswer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentAnswer_Answers_AnswerId",
                        column: x => x.AnswerId,
                        principalTable: "Answers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentAnswer_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentAnswer_QuizResults_QuizResultId",
                        column: x => x.QuizResultId,
                        principalTable: "QuizResults",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1", null, "Admin", "ADMIN" },
                    { "2", null, "Instructor", "INSTRUCTOR" },
                    { "3", null, "Student", "STUDENT" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePictureUrl", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "58ec4bbf-4913-4dc1-96b7-381159ce0878", 0, "1b7795c4-332b-40be-a452-ff1bc9c6a91f", "Instructor", "omar.tarek@example.com", false, "Omar", "Tarek", false, null, "OMAR.TAREK@EXAMPLE.COM", "OMAR.TAREK", "AQAAAAIAAYagAAAAEHfG3kVSDGYlE19W+GpKUzz5SOhN9LinHSy3q/y6Ozl3Xl5vmGpKEtKO7IR3HjPV9w==", "1122334455", false, "", "a6afba5a-0909-4c12-958e-810f60ab37a3", false, "omar.tarek" },
                    { "626b8c7f-f4d4-4467-bb37-570f1aa6fd77", 0, "d7c5d3d7-d959-4c74-89a0-a6de9df0888a", "Student", "ali.mahmoud@example.com", false, "Ali", "Mahmoud", false, null, "ALI.MAHMOUD@EXAMPLE.COM", "ALI.MAHMOUD", "AQAAAAIAAYagAAAAEPFBrUDr9mI9Ha4vir7abB26qAJDjek5hjRafR4ewwl+4Mf+gKTnieAlYnkA7vEQmQ==", "1234567890", false, "", "272f69db-d44c-4ea9-9ef0-56e332d9adb4", false, "ali.mahmoud" },
                    { "a86582e6-8511-4b78-b548-e17a2eaf0d3e", 0, "7527958f-dc1b-42be-9c19-856c8b660dbd", "Instructor", "hana.mostafa@example.com", false, "Hana", "Mostafa", false, null, "HANA.MOSTAFA@EXAMPLE.COM", "HANA.MOSTAFA", "AQAAAAIAAYagAAAAEHxGfFe6Mr7oxyO1gMMyiDObSQgFYTwMYArJhmL5PQARw/l8aWs42hYyq6P+9i/7GA==", "5566778899", false, "", "d4240263-ea88-47bc-aed7-7e66e28063ab", false, "hana.mostafa" },
                    { "e452e625-327a-4bf2-9540-3db6577ab68f", 0, "082576e7-5464-4608-8329-8c7fc8247f0c", "Student", "salma.ahmed@example.com", false, "Salma", "Ahmed", false, null, "SALMA.AHMED@EXAMPLE.COM", "SALMA.AHMED", "AQAAAAIAAYagAAAAEMAjCq9BOGCh12VESDso69qMu1ziu/K9MkVxMqUE93K/9XObh7TOZK2ZtZqJKcJCoQ==", "0987654321", false, "", "04bbf8d3-d318-45cd-ae87-e7f911d18e7b", false, "salma.ahmed" }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Description", "InstructorId", "ThumbnailUrl", "Title" },
                values: new object[,]
                {
                    { "1c700ea4-ac54-487f-80e4-25c7b348b9e0", "Learn the basics of C# programming, including syntax, OOP concepts, and best practices.", "58ec4bbf-4913-4dc1-96b7-381159ce0878", "csharp_course_thumbnail.jpg", "Introduction to C#" },
                    { "2d7df053-81d5-4bb8-994d-76619c341c46", "Deep dive into .NET framework, dependency injection, middleware, and microservices.", "a86582e6-8511-4b78-b548-e17a2eaf0d3e", "dotnet_course_thumbnail.jpg", "Advanced .NET Development" }
                });

            migrationBuilder.InsertData(
                table: "Enrollment",
                columns: new[] { "CourseId", "StudentId" },
                values: new object[,]
                {
                    { "1c700ea4-ac54-487f-80e4-25c7b348b9e0", "626b8c7f-f4d4-4467-bb37-570f1aa6fd77" },
                    { "2d7df053-81d5-4bb8-994d-76619c341c46", "626b8c7f-f4d4-4467-bb37-570f1aa6fd77" },
                    { "1c700ea4-ac54-487f-80e4-25c7b348b9e0", "e452e625-327a-4bf2-9540-3db6577ab68f" },
                    { "2d7df053-81d5-4bb8-994d-76619c341c46", "e452e625-327a-4bf2-9540-3db6577ab68f" }
                });

            migrationBuilder.InsertData(
                table: "Lessons",
                columns: new[] { "Id", "Content", "CourseId", "ExternalVideoUrl", "ThumbnailUrl", "Title", "VideoUrl" },
                values: new object[,]
                {
                    { "LESSON-1001", "This is the introduction to programming, covering the basics of coding.", "1c700ea4-ac54-487f-80e4-25c7b348b9e0", "https://example.com/intro-video", "", "Introduction to Programming", "" },
                    { "LESSON-1002", "This lesson explains variables, constants, and different data types in programming.", "1c700ea4-ac54-487f-80e4-25c7b348b9e0", "https://example.com/variables-video", "", "Variables and Data Types", "" },
                    { "LESSON-1003", "This lesson dives deep into sorting algorithms and their applications.", "2d7df053-81d5-4bb8-994d-76619c341c46", "https://example.com/algorithms-video", "", "Advanced Algorithms", "" },
                    { "LESSON-1004", "Learn about trees, graphs, and their applications in computer science.", "2d7df053-81d5-4bb8-994d-76619c341c46", "https://example.com/data-structures-video", "", "Data Structures: Trees and Graphs", "" }
                });

            migrationBuilder.InsertData(
                table: "Progresses",
                columns: new[] { "Id", "CourseId", "LastUpdated", "StudentId", "TotalLessonsCompleted" },
                values: new object[,]
                {
                    { "PROG-1001", "1c700ea4-ac54-487f-80e4-25c7b348b9e0", new DateTime(2025, 4, 2, 5, 57, 26, 888, DateTimeKind.Utc).AddTicks(4830), "626b8c7f-f4d4-4467-bb37-570f1aa6fd77", 5 },
                    { "PROG-1002", "1c700ea4-ac54-487f-80e4-25c7b348b9e0", new DateTime(2025, 4, 2, 5, 57, 26, 888, DateTimeKind.Utc).AddTicks(4848), "e452e625-327a-4bf2-9540-3db6577ab68f", 7 },
                    { "PROG-1003", "2d7df053-81d5-4bb8-994d-76619c341c46", new DateTime(2025, 4, 2, 5, 57, 26, 888, DateTimeKind.Utc).AddTicks(4853), "626b8c7f-f4d4-4467-bb37-570f1aa6fd77", 10 },
                    { "PROG-1004", "2d7df053-81d5-4bb8-994d-76619c341c46", new DateTime(2025, 4, 2, 5, 57, 26, 888, DateTimeKind.Utc).AddTicks(4856), "e452e625-327a-4bf2-9540-3db6577ab68f", 12 }
                });

            migrationBuilder.InsertData(
                table: "Quizzes",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Description", "IsActive", "IsDeleted", "LessonId", "PassingScore", "TimeLimit", "Title", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { "QUIZ-2001", new DateTime(2025, 4, 2, 5, 57, 26, 888, DateTimeKind.Utc).AddTicks(4980), "System", "This quiz tests your knowledge on basic programming concepts.", true, false, "LESSON-1001", 80, 300, "Introduction to Programming Quiz", null, null },
                    { "QUIZ-2002", new DateTime(2025, 4, 2, 5, 57, 26, 888, DateTimeKind.Utc).AddTicks(4986), "System", "This quiz tests your understanding of variables and data types.", true, false, "LESSON-1002", 70, 300, "Variables and Data Types Quiz", null, null },
                    { "QUIZ-2003", new DateTime(2025, 4, 2, 5, 57, 26, 888, DateTimeKind.Utc).AddTicks(4989), "System", "This quiz evaluates your understanding of complex algorithms.", true, false, "LESSON-1003", 85, 300, "Advanced Algorithms Quiz", null, null }
                });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "Answer", "CreatedAt", "CreatedBy", "Explanation", "OrderIndex", "Points", "QuizId", "Text", "Type", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { "QUESTION-3001", "Paris", new DateTime(2025, 4, 2, 5, 57, 26, 888, DateTimeKind.Utc).AddTicks(5035), "System", "The capital of France is Paris.", 1, 10, "QUIZ-2002", "What is the capital of France?", 1, null, null },
                    { "QUESTION-3002", "4", new DateTime(2025, 4, 2, 5, 57, 26, 888, DateTimeKind.Utc).AddTicks(5050), "System", "2 + 2 equals 4.", 2, 5, "QUIZ-2002", "What is 2 + 2?", 1, null, null },
                    { "QUESTION-3003", "George Orwell", new DateTime(2025, 4, 2, 5, 57, 26, 888, DateTimeKind.Utc).AddTicks(5055), "System", "The author of '1984' is George Orwell.", 1, 10, "QUIZ-2003", "Who is the author of '1984'?", 1, null, null },
                    { "QUESTION-3004", "Pacific Ocean", new DateTime(2025, 4, 2, 5, 57, 26, 888, DateTimeKind.Utc).AddTicks(5058), "System", "The largest ocean on Earth is the Pacific Ocean.", 2, 5, "QUIZ-2003", "What is the largest ocean on Earth?", 1, null, null }
                });

            migrationBuilder.InsertData(
                table: "QuizResults",
                columns: new[] { "Id", "CompletedAt", "CreatedAt", "CreatedBy", "ProgressId", "QuizId", "Score", "StartedAt", "StudentId", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { "QUIZATTEMPT-10001", new DateTime(2025, 4, 2, 5, 57, 26, 888, DateTimeKind.Utc).AddTicks(5207), new DateTime(2025, 4, 2, 5, 57, 26, 888, DateTimeKind.Utc).AddTicks(5200), "System", "PROG-1001", "QUIZ-2001", 85.0, new DateTime(2025, 4, 2, 5, 42, 26, 888, DateTimeKind.Utc).AddTicks(5203), "e452e625-327a-4bf2-9540-3db6577ab68f", null, null },
                    { "QUIZATTEMPT-10002", new DateTime(2025, 4, 2, 5, 57, 26, 888, DateTimeKind.Utc).AddTicks(5212), new DateTime(2025, 4, 2, 5, 57, 26, 888, DateTimeKind.Utc).AddTicks(5211), "System", "PROG-1002", "QUIZ-2002", 60.0, new DateTime(2025, 4, 2, 5, 37, 26, 888, DateTimeKind.Utc).AddTicks(5212), "626b8c7f-f4d4-4467-bb37-570f1aa6fd77", null, null },
                    { "QUIZATTEMPT-10003", new DateTime(2025, 4, 2, 5, 57, 26, 888, DateTimeKind.Utc).AddTicks(5221), new DateTime(2025, 4, 2, 5, 57, 26, 888, DateTimeKind.Utc).AddTicks(5220), "System", "PROG-1001", "QUIZ-2002", 90.0, new DateTime(2025, 4, 2, 5, 47, 26, 888, DateTimeKind.Utc).AddTicks(5220), "e452e625-327a-4bf2-9540-3db6577ab68f", null, null },
                    { "QUIZATTEMPT-10004", new DateTime(2025, 4, 2, 5, 57, 26, 888, DateTimeKind.Utc).AddTicks(5268), new DateTime(2025, 4, 2, 5, 57, 26, 888, DateTimeKind.Utc).AddTicks(5267), "System", "PROG-1002", "QUIZ-2001", 75.0, new DateTime(2025, 4, 2, 5, 32, 26, 888, DateTimeKind.Utc).AddTicks(5267), "626b8c7f-f4d4-4467-bb37-570f1aa6fd77", null, null }
                });

            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Explanation", "IsCorrect", "OrderIndex", "QuestionId", "Text", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { "ANSWER-4001", new DateTime(2025, 4, 2, 5, 57, 26, 888, DateTimeKind.Utc).AddTicks(5099), "System", null, true, 1, "QUESTION-3001", "Option A: Correct answer for question 1", null, null },
                    { "ANSWER-4002", new DateTime(2025, 4, 2, 5, 57, 26, 888, DateTimeKind.Utc).AddTicks(5104), "System", null, false, 2, "QUESTION-3001", "Option B: Incorrect answer for question 1", null, null },
                    { "ANSWER-4003", new DateTime(2025, 4, 2, 5, 57, 26, 888, DateTimeKind.Utc).AddTicks(5108), "System", null, true, 1, "QUESTION-3002", "Option A: Correct answer for question 2", null, null },
                    { "ANSWER-4004", new DateTime(2025, 4, 2, 5, 57, 26, 888, DateTimeKind.Utc).AddTicks(5110), "System", null, false, 2, "QUESTION-3002", "Option B: Incorrect answer for question 2", null, null },
                    { "ANSWER-4005", new DateTime(2025, 4, 2, 5, 57, 26, 888, DateTimeKind.Utc).AddTicks(5113), "System", null, true, 1, "QUESTION-3003", "Option A: Correct answer for question 3", null, null },
                    { "ANSWER-4006", new DateTime(2025, 4, 2, 5, 57, 26, 888, DateTimeKind.Utc).AddTicks(5117), "System", null, false, 2, "QUESTION-3003", "Option B: Incorrect answer for question 3", null, null }
                });

            migrationBuilder.InsertData(
                table: "StudentAnswer",
                columns: new[] { "Id", "AnswerId", "CreatedAt", "CreatedBy", "IsCorrect", "QuestionId", "QuizResultId", "SelectedAnswerIds", "SubmittedAnswer", "SubmittedAt", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { "STUDENTANSWER-7001", "ANSWER-4001", new DateTime(2025, 4, 2, 5, 57, 26, 888, DateTimeKind.Utc).AddTicks(5333), "System", true, "QUESTION-3001", "QUIZATTEMPT-10001", "[]", "Option A: Correct answer for question 1", new DateTime(2025, 4, 2, 5, 57, 26, 888, DateTimeKind.Utc).AddTicks(5335), null, null },
                    { "STUDENTANSWER-7004", "ANSWER-4002", new DateTime(2025, 4, 2, 5, 57, 26, 888, DateTimeKind.Utc).AddTicks(5337), "System", false, "QUESTION-3001", "QUIZATTEMPT-10002", "[]", "Option B: Incorrect answer for question 1", new DateTime(2025, 4, 2, 5, 57, 26, 888, DateTimeKind.Utc).AddTicks(5338), null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Answers_QuestionId",
                table: "Answers",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Certificate_ProgressId",
                table: "Certificate",
                column: "ProgressId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Courses_InstructorId",
                table: "Courses",
                column: "InstructorId");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollment_CourseId",
                table: "Enrollment",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_CourseId",
                table: "Lessons",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Progresses_CourseId",
                table: "Progresses",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Progresses_StudentId_CourseId",
                table: "Progresses",
                columns: new[] { "StudentId", "CourseId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Questions_QuizId",
                table: "Questions",
                column: "QuizId");

            migrationBuilder.CreateIndex(
                name: "IX_QuizResults_ProgressId",
                table: "QuizResults",
                column: "ProgressId");

            migrationBuilder.CreateIndex(
                name: "IX_QuizResults_QuizId",
                table: "QuizResults",
                column: "QuizId");

            migrationBuilder.CreateIndex(
                name: "IX_QuizResults_StudentId",
                table: "QuizResults",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Quizzes_LessonId",
                table: "Quizzes",
                column: "LessonId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentAnswer_AnswerId",
                table: "StudentAnswer",
                column: "AnswerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentAnswer_QuestionId",
                table: "StudentAnswer",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentAnswer_QuizResultId",
                table: "StudentAnswer",
                column: "QuizResultId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Certificate");

            migrationBuilder.DropTable(
                name: "StudentAnswer");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Answers");

            migrationBuilder.DropTable(
                name: "QuizResults");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Progresses");

            migrationBuilder.DropTable(
                name: "Quizzes");

            migrationBuilder.DropTable(
                name: "Enrollment");

            migrationBuilder.DropTable(
                name: "Lessons");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
