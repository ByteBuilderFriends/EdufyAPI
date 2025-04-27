using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AskAMuslimAPI.Migrations
{
    /// <inheritdoc />
    public partial class IntialMigration : Migration
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
                    ProfilePictureUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    Category = table.Column<int>(type: "int", nullable: true),
                    Level = table.Column<int>(type: "int", nullable: true),
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
                    CompletedProgress = table.Column<bool>(type: "bit", nullable: false),
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
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalQuestions = table.Column<int>(type: "int", nullable: false),
                    TotalMarks = table.Column<int>(type: "int", nullable: false),
                    StudentQuizEvaluation = table.Column<int>(type: "int", nullable: false),
                    StudentQuizResult = table.Column<int>(type: "int", nullable: false),
                    LessonId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    QuestionText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Marks = table.Column<int>(type: "int", nullable: false),
                    QuizId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                name: "Options",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OptionText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsCorrect = table.Column<bool>(type: "bit", nullable: false),
                    QuestionId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Options", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Options_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Answers",
                columns: table => new
                {
                    StudentId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    QuestionId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SelectedOptionId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answers", x => new { x.StudentId, x.QuestionId });
                    table.ForeignKey(
                        name: "FK_Answers_AspNetUsers_StudentId",
                        column: x => x.StudentId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Answers_Options_SelectedOptionId",
                        column: x => x.SelectedOptionId,
                        principalTable: "Options",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Answers_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
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
                    { "2c179b2d-1d3b-42a3-8d6f-d2fd86b73c29", 0, "fixed-concurrency-stamp-4", "Instructor", "mufti.menk@example.com", false, "Mufti", "Menk", false, null, "MUFTI.MENK@EXAMPLE.COM", "MUFTI.MENK", "AQAAAAIAAYagAAAAEKhfABcexVBa2CPOgHa7LU7h2tgaGe2VQbOMGe9uCcuVEb8tAwxqru9YHFTtJK3glw==", "0987654321", false, "", "fixed-security-stamp-4", false, "mufti.menk" },
                    { "626b8c7f-f4d4-4467-bb37-570f1aa6fd66", 0, "fixed-concurrency-stamp-1", "Instructor", "aam@example.com", false, "AskAMuslim", "Academy", false, null, "AAM@EXAMPLE.COM", "AAM", "AQAAAAIAAYagAAAAEKsmLRBJp6I5tKPy0WDNs07ql09VZX8z4DGjbn3fzmT2LbzkPQnDg7czDSEiGsR3PA==", "1234567890", false, "", "fixed-security-stamp-1", false, "aam" },
                    { "626b8c7f-f4d4-4467-bb37-570f1aa6fd77", 0, "fixed-concurrency-stamp-1", "Student", "ali.mahmoud@example.com", false, "Ali", "Mahmoud", false, null, "ALI.MAHMOUD@EXAMPLE.COM", "ALI.MAHMOUD", "AQAAAAIAAYagAAAAEKsmLRBJp6I5tKPy0WDNs07ql09VZX8z4DGjbn3fzmT2LbzkPQnDg7czDSEiGsR3PA==", "1234567890", false, "", "fixed-security-stamp-1", false, "ali.mahmoud" },
                    { "7d3f2475-7a1b-4f85-92eb-0faab6aa8d4f", 0, "fixed-concurrency-stamp-2", "Instructor", "marwan.mohamed@example.com", false, "Marwan", "Mohamed", false, null, "MARWAN.MOHAMED@EXAMPLE.COM", "MARWAN.MOHAMED", "AQAAAAIAAYagAAAAEKhfABcexVBa2CPOgHa7LU7h2tgaGe2VQbOMGe9uCcuVEb8tAwxqru9YHFTtJK3glw==", "0987654321", false, "", "fixed-security-stamp-2", false, "marwan.mohamed" },
                    { "9a5c21b2-2d92-4d0f-bad3-47d4bbd4e611", 0, "fixed-concurrency-stamp-3", "Instructor", "mujahid.hussain@example.com", false, "Mujahid", "Hussain", false, null, "MUJAHID.HUSSAIN@EXAMPLE.COM", "MUJAHID.HUSSAIN", "AQAAAAIAAYagAAAAEKhfABcexVBa2CPOgHa7LU7h2tgaGe2VQbOMGe9uCcuVEb8tAwxqru9YHFTtJK3glw==", "0987654321", false, "", "fixed-security-stamp-3", false, "mujahid.hussain" },
                    { "a3456789-01bc-4fgh-9g23-45678901cdef", 0, "fixed-concurrency-stamp-7", "Instructor", "ibn.uthaymeen@example.com", false, "Ibn", "Uthaymeen", false, null, "IBN.UTHAYMEEN@EXAMPLE.COM", "IBN.UTHAYMEEN", "AQAAAAIAAYagAAAAEDh4wGZKpAbvIJKliK8GLUUSUrfz1D7ySMf9IFXGwG3o8fR9cA7ek/5yk8QbMv9iyA==", "0223344556", false, "", "fixed-security-stamp-7", false, "ibn.uthaymeen" },
                    { "b4567890-12cd-5ghi-0h34-56789012def0", 0, "fixed-concurrency-stamp-8", "Instructor", "ibn.farooq@example.com", false, "Ibn", "Farooq", false, null, "IBN.FAROOQ@EXAMPLE.COM", "IBN.FAROOQ", "AQAAAAIAAYagAAAAEDy4zHzmVDpQm3uvHQclPBfiD/NvWb8IlA6tbjdzGp5B0V5RBoTxAjB4vKnV8qvG8w==", "0334455667", false, "", "fixed-security-stamp-8", false, "ibn.farooq" },
                    { "d1234567-89ab-4cde-8f01-23456789abcd", 0, "fixed-concurrency-stamp-5", "Instructor", "assim.alhakeem@example.com", false, "Assim", "AlHakeem", false, null, "ASSIM.ALHAKEEM@EXAMPLE.COM", "ASSIM.ALHAKEEM", "AQAAAAIAAYagAAAAEB1wXcGz8Hbl5otx+fN7ygtlzHv2NfqeUqlg3RW0dP4gWbTY6wHT0t8xKzJKzZfyDQ==", "0123456789", false, "", "fixed-security-stamp-5", false, "assim.alhakeem" },
                    { "e452e625-327a-4bf2-9540-3db6577ab68f", 0, "fixed-concurrency-stamp-2", "Student", "salma.ahmed@example.com", false, "Salma", "Ahmed", false, null, "SALMA.AHMED@EXAMPLE.COM", "SALMA.AHMED", "AQAAAAIAAYagAAAAEKhfABcexVBa2CPOgHa7LU7h2tgaGe2VQbOMGe9uCcuVEb8tAwxqru9YHFTtJK3glw==", "0987654321", false, "", "fixed-security-stamp-2", false, "salma.ahmed" },
                    { "f2345678-90ab-4def-9f12-34567890bcde", 0, "fixed-concurrency-stamp-6", "Instructor", "muhammad.salah@example.com", false, "Muhammad", "Salah", false, null, "MUHAMMAD.SALAH@EXAMPLE.COM", "MUHAMMAD.SALAH", "AQAAAAIAAYagAAAAEC9oZk+QkS2u4GNHbAh9uPuBjNQfHdjkk5IvP8xCmUNz5cIY3ZoIXF1xv8bZf9nqBA==", "0112233445", false, "", "fixed-security-stamp-6", false, "muhammad.salah" }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Category", "Description", "InstructorId", "Level", "ThumbnailUrl", "Title" },
                values: new object[,]
                {
                    { "a1", 4, "Learn the fundamentals of Islamic beliefs and Aqeedah.", "626b8c7f-f4d4-4467-bb37-570f1aa6fd66", 1, "aqeedah_basics_thumbnail.jpg", "principles of belief" },
                    { "a2", 4, "Explore advanced topics in Islamic beliefs and theology.", "a3456789-01bc-4fgh-9g23-45678901cdef", 3, "advanced_aqeedah_thumbnail.jpg", "Aqeedah/Creed" },
                    { "a3", 4, "Study the beliefs of Ahlus Sunnah wal Jama'ah.", "b4567890-12cd-5ghi-0h34-56789012def0", 2, "ahlus_sunnah_thumbnail.jpg", "Islamic Beliefs and Practices" },
                    { "a4", 4, "Learn the fundamentals of Islamic beliefs and Aqeedah.", "d1234567-89ab-4cde-8f01-23456789abcd", 1, "aqeedah_basics_thumbnail.jpg", "Fundamentals of Aqeedah" },
                    { "f1", 3, "Learn the principles of Islamic law and jurisprudence.", "626b8c7f-f4d4-4467-bb37-570f1aa6fd66", 2, "fiqh_basics_thumbnail.jpg", "Fiqh Of Ramadan" },
                    { "f2", 3, "Explore advanced topics in Islamic law and jurisprudence.", "d1234567-89ab-4cde-8f01-23456789abcd", 1, "advanced_fiqh_thumbnail.jpg", "Fiqh - Semester 1 | Shaykh Assim Al-Hakeem" },
                    { "f3", 3, "Study the principles of Islamic law and ethics.", "d1234567-89ab-4cde-8f01-23456789abcd", 2, "fiqh_ethics_thumbnail.jpg", "Islamic Fiqh" },
                    { "f4", 3, "Learn the principles of Islamic law and jurisprudence.", "b4567890-12cd-5ghi-0h34-56789012def0", 1, "fiqh_basics_thumbnail.jpg", "FIQH IN ISLAM based on Sharh al-Umdah" },
                    { "fa1", 17, "Learn the fundamentals of Islamic beliefs and Aqeedah.", "626b8c7f-f4d4-4467-bb37-570f1aa6fd66", 1, "faith_basics_thumbnail.jpg", "Faith in Islam" },
                    { "fa2", 17, "Explore advanced topics in Islamic beliefs and theology.", "626b8c7f-f4d4-4467-bb37-570f1aa6fd66", 3, "advanced_faith_thumbnail.jpg", "The Six Articles of Faith in Islam" },
                    { "fa3", 17, "Study the beliefs of Ahlus Sunnah wal Jama'ah.", "d1234567-89ab-4cde-8f01-23456789abcd", 1, "ahlus_sunnah_thumbnail.jpg", "Islamic Faith" },
                    { "fa4", 17, "Learn the fundamentals of Islamic beliefs and Aqeedah.", "b4567890-12cd-5ghi-0h34-56789012def0", 1, "faith_basics_thumbnail.jpg", "Islamic Reminders" },
                    { "h1", 2, "Welcome to the **Comprehensive Hadith Course - Mishkat-ul-Masabih**. This playlist provides a thorough exploration of Hadith from the Mishkat-ul-Masabih collection. Each lesson offers detailed explanations and context for the sayings of the Prophet Muhammad (peace be upon him), aiming to enhance your understanding of these important teachings. Covering a broad range of topics, the course is structured to guide you through the Hadith in a systematic way, suitable for learners at various levels. The content includes scholarly insights and reflections to help you connect with and apply the Prophet’s teachings in everyday life. We invite you to join us in this study to deepen your knowledge and practice of Islam.\r\n", "9a5c21b2-2d92-4d0f-bad3-47d4bbd4e611", 1, "hadith_intro_thumbnail.jpg", "Comprehensive Hadith Course - Mishkat-ul-Masabih" },
                    { "h2", 2, "The Free Advanced Diploma Course in Quran and Hadith will in-sha-Allah benefit both Muslims who aspire to study the Quran and Hadith in depth, and scholars seeking to revise key aspects of the Aalim course (Dars-i Nizami). It follows mainstream Islamic teachings, avoiding promotion of any modern sect, and aims to educate based on earlier Islamic scholars' teachings. The course focuses on Tafseer and Hadees, with Tafseer explanations referencing renowned scholars like Tabari, Bawdawi, Ibn Kaseer, Qurtabi, and Razi. The explanations of Hadith will follow the interpretations provided by Hadith scholars, with particular emphasis on the authentication of the Ahadith. When Fiqh matters arise, perspectives from the main Sunni schools—Hanafi, Maliki, Shafie, and Hanbali—are usually provided.", "9a5c21b2-2d92-4d0f-bad3-47d4bbd4e611", 3, "hadith_manners_thumbnail.jpg", "Advanced Islamic Diploma Course in Quran and Hadith" },
                    { "h3", 2, "An in-depth study of Sahih Bukhari collections.", "f2345678-90ab-4def-9f12-34567890bcde", 1, "sahih_bukhari_thumbnail.jpg", "Hadith - Semester 1 | Shaykh Dr. Muhammad Salah" },
                    { "h4", 2, "Study the top authentic Hadith books.", "a3456789-01bc-4fgh-9g23-45678901cdef", 2, "authentic_hadith_thumbnail.jpg", "Al Nawawi's Forty Hadith" },
                    { "q1", 16, "Learn to memorize the Quran with effective techniques.", "2c179b2d-1d3b-42a3-8d6f-d2fd86b73c29", 1, "quran_memorization_thumbnail.jpg", "Qur'an tafseer by Mufti menk" },
                    { "q2", 16, "Master the basics of Tajweed for proper Quran recitation.", "9a5c21b2-2d92-4d0f-bad3-47d4bbd4e611", 1, "tajweed_thumbnail.jpg", "Complete Quran Tafseer" },
                    { "q3", 16, "Enhance your recitation skills with proper Makharij and Sifaat.", "d1234567-89ab-4cde-8f01-23456789abcd", 2, "quran_recitation_thumbnail.jpg", "TAFSEER OF QUR'AN |Sheikh Assim Al Hakeem" },
                    { "q4", 16, "Dive deeper into Quranic understanding and reflection.", "2c179b2d-1d3b-42a3-8d6f-d2fd86b73c29", 3, "advanced_quran_studies_thumbnail.jpg", "Mufti Menk - Quran Tafseer" }
                });

            migrationBuilder.InsertData(
                table: "Enrollment",
                columns: new[] { "CourseId", "StudentId" },
                values: new object[,]
                {
                    { "q1", "626b8c7f-f4d4-4467-bb37-570f1aa6fd77" },
                    { "q2", "626b8c7f-f4d4-4467-bb37-570f1aa6fd77" },
                    { "q1", "e452e625-327a-4bf2-9540-3db6577ab68f" },
                    { "q2", "e452e625-327a-4bf2-9540-3db6577ab68f" }
                });

            migrationBuilder.InsertData(
                table: "Lessons",
                columns: new[] { "Id", "Content", "CourseId", "ExternalVideoUrl", "ThumbnailUrl", "Title", "VideoUrl" },
                values: new object[,]
                {
                    { "l1a1", "This lesson covers the importance of understanding the fundamentals of Aqeedah.", "a1", "https://youtu.be/mKF693FWc6A?si=IUg8K_Hcn82pCy1E", "", "Principles of Belief: The Basis of rationale and proof", "" },
                    { "l1a2", "This lesson emphasizes the importance of understanding the attributes of Allah.", "a2", "https://youtu.be/Ioy35ni7NXs?si=k6vVjInPQ6pkr1Rq", "", "02 - Seeking a cure using specific Names of Allaah to treat a particular illness - Shaikh Uthaymeen", "" },
                    { "l1a3", "This lesson covers the importance of understanding the Day of Judgment.", "a3", "https://youtu.be/5bdrB9Gu_Y0?si=KVtWr4RArQJa6J_P", "", "1 Explanation of the Islāmic Belief : Introduction", "" },
                    { "l1a4", "This lesson emphasizes the importance of understanding the concept of Shirk.", "a4", "https://youtu.be/2R0lqMBWzGE?si=EOCu9y3MtHRTbbys", "", "The three Fundamental Principles (Thalaathat-ul-usool) Part 1 - Assim al hakeem", "" },
                    { "l1f1", "This lesson covers the importance of understanding the rules of prayer.", "f1", "https://youtu.be/TRq7E0gCe_w?si=AyJJpa4xsNBfuY65", "", "What Is Fasting? | Fiqh Of Ramadan", "" },
                    { "l1f2", "This lesson emphasizes the importance of understanding the rules of Zakat.", "f2", "https://youtu.be/V0tOuxRXgW8?si=KI0a2sRjiOdmWtJq", "", "Fiqh - Semester 1 - Introduction", "" },
                    { "l1f3", "This lesson covers the importance of understanding the rules of transactions.", "f3", "https://www.youtube.com/live/SNaabBT5hTw?si=Wi5SRFQdZHd7PF4f", "", "Islamic Fiqh 13 - Assim al hakeem", "" },
                    { "l1f4", "This lesson emphasizes the importance of understanding the rules of family matters.", "f4", "https://youtu.be/2DVTYk1jVE4?si=wv0RdDQM0Sjtz8N_", "", "Sharh 'Umdah al-Fiqh 1 [Introduction-Ibn Qudamah]", "" },
                    { "l1fa1", "This lesson covers the importance of understanding the concept of faith.", "fa1", "https://youtu.be/pyUySSuyHNw?si=wKhwmoS9s5HidZyy", "", "Faith Part 1", "" },
                    { "l1fa2", "This lesson emphasizes the importance of understanding the concept of Tawheed.", "fa2", "https://youtu.be/foNaMDvYLPo?si=bkTPg4JXrV5_vsHp", "", "What Are the Six Articles of Faith in Islam? | Pillars of Iman", "" },
                    { "l1fa3", "This lesson covers the importance of understanding the concept of Iman.", "fa3", "https://youtu.be/VlQKUOIB8fM?si=QGIqI2wlEpALJd85", "", "The Islamic faith # 1", "" },
                    { "l1fa4", "This lesson emphasizes the importance of understanding the concept of Nifaq.", "fa4", "https://youtu.be/Z76LIk2fr6U?si=RsmZtJ0pSOn6fhR_", "", "THIS SHOULD MAKE YOU CRY | Islamic Reminder", "" },
                    { "l1h1", "This lesson covers the importance of seeking knowledge and its impact on personal growth.", "h1", "https://youtu.be/ZrrVbZhTqXk?si=4aoP0Y9tBPNfik8g", "", "Principles of Hadith - 1", "" },
                    { "l1h2", "This lesson emphasizes the importance of acting upon knowledge.", "h2", "https://youtu.be/x82aep1XRvw?si=nk5JJtk7I7K-o36t", "", "Hadith 1", "" },
                    { "l1h3", "This lesson covers the importance of humility in seeking knowledge.", "h3", "https://youtu.be/mWbG69wdO-Q?si=fXwrVbVi92JOdTHU", "", "Hadith - Semester 1 - Introduction", "" },
                    { "l1h4", "This lesson emphasizes the importance of gratitude in seeking knowledge.", "h4", "https://youtu.be/rcsJ_RorUSs?si=CxqJPcqTNR198eIm", "", "01-Explanation of the first hadith of intention for Ibn Uthaymeen", "" },
                    { "l1q1", "This lesson discusses the virtues of memorizing the Quran and how it strengthens one’s connection with Allah.", "q1", "https://youtu.be/2qds-xNU4Xc?si=JOYbgc9mNGNWAosV", "", "Quran Tafseer 1?", "" },
                    { "l1q2", "This lesson emphasizes the importance of consistency and setting realistic goals.", "q2", "https://youtu.be/d6hLVtnDSWQ?si=M2HFkEO5_XDg65GY", "", "Principles of Tafseer - 1", "" },
                    { "l1q3", "This lesson covers the importance of seeking knowledge from reliable sources.", "q3", "https://youtu.be/-qQNhf8tank?si=OKHub6BfIC0OVV2z", "", "TAFSEER OF QUR'AN Ep 02 Sheikh Assim Al Hakeem", "" },
                    { "l1q4", "This lesson emphasizes the importance of reflecting on the meanings of the verses.", "q4", "https://youtu.be/ZN9lzkWGA_E?si=KstXa-RsPxGSFgUZ", "", "Mufti Menk - Quran Tafseer Day1", "" },
                    { "l2a1", "This lesson discusses the significance of Tawheed and its implications in daily life.", "a1", "https://youtu.be/urwR3bgRqB0?si=tUvMXeyr5WLdSXyG", "", "Principles of Belief: MENTAL EVIDENCE IN ISLAM", "" },
                    { "l2a2", "This lesson discusses the significance of belief in the Prophets and Messengers.", "a2", "https://youtu.be/wmnK6ZnXj7I?si=ugldutKHd0S1_Emf", "", "03 - What does Al-‘Uboodiyyah (servitude: Oneness of Allah in worship) comprise of? Sh. Al-Uthaymeen\r\n", "" },
                    { "l2a3", "This lesson discusses the significance of belief in Angels.", "a3", "https://youtu.be/5fCEQBaHI28?si=Mi1VYzS8gq9ccNqx", "", "2 Explanation of the Islāmic Belief:Praise of Allah", "" },
                    { "l2a4", "This lesson discusses the significance of belief in Divine Decree.", "a4", "https://youtu.be/1Rj5EtLGnKU?si=q595x4yKEz0sIMVj", "", "The three Fundamental Principles (Thalaathat-ul-usool) Part 2 - Assim al hakeem", "" },
                    { "l2f1", "This lesson discusses the significance of understanding the rules of fasting.", "f1", "https://youtu.be/aDK3sTkrOZE?si=sfQgMyI1tJWYZe3h", "", "Do I Have to Make the Intention to Fast? | Fiqh of Ramadan", "" },
                    { "l2f2", "This lesson discusses the significance of understanding the rules of Hajj.", "f2", "https://youtu.be/Zxl94-DFGx4?si=Zd31VXLlRis6eMWF", "", "Fiqh - Semester 1 - Lecture 1", "" },
                    { "l2f3", "This lesson discusses the significance of understanding the rules of contracts.", "f3", "https://www.youtube.com/live/opr8cfX6lSM?si=OdbdSheKXTXfi_qp", "", "Islamic Fiqh 14 - Assim al hakeem", "" },
                    { "l2f4", "This lesson discusses the significance of understanding the rules of inheritance.", "f4", "https://youtu.be/PJrknK2MZck?si=EF4dkX9mXtJefR4w", "", "Sharh 'Umdah al-Fiqh 2", "" },
                    { "l2fa1", "This lesson discusses the significance of understanding the pillars of faith.", "fa1", "https://youtu.be/rLgfs2eBu3Y?si=Kpko5UiGDAIR9vZq", "", "Faith Part 2", "" },
                    { "l2fa2", "This lesson discusses the significance of understanding the concept of Shirk.", "fa2", "https://youtu.be/eKnIJqe8gc8?si=c6BpfWHl_Uv2g_K4", "", "The Oneness of Allah in Islam: Tawheed and Monotheism", "" },
                    { "l2fa3", "This lesson discusses the significance of understanding the concept of Kufr.", "fa3", "https://youtu.be/GKY3ycmTXZA?si=RQYWL0BpGa8WbOWN", "", "The Islamic Faith # 2", "" },
                    { "l2fa4", "This lesson discusses the significance of understanding the concept of Iman.", "fa4", "https://youtu.be/uioedvBAZb4?si=CjnPuUvnVSyJ1X41", "", "Message to those who sell out their Deen", "" },
                    { "l2h1", "This lesson discusses the significance of sincerity in seeking knowledge.", "h1", "https://youtu.be/iQxLrk9y2pU?si=Kxi-qEFzjvvbZWCR", "", "Principles of Hadith - 2", "" },
                    { "l2h2", "This lesson discusses the significance of sharing knowledge with others.", "h2", "https://youtu.be/w6ps627J2SA?si=tIMVfO7eaICOb7aB", "", "Hadith 2", "" },
                    { "l2h3", "This lesson discusses the significance of patience in the pursuit of knowledge.", "h3", "https://youtu.be/pJgBEUO_cu0?si=gKdL_UgVbzvt9TIN", "", "Hadith - Semester 1 - Lecture 1 | Shaykh Dr. Muhammad Salah", "" },
                    { "l2h4", "This lesson discusses the significance of perseverance in the face of challenges.", "h4", "https://youtu.be/yB0IK5iF5sI?si=9BPv146lsh6p-uLF", "", "03-Explanation of the third Hadith ''Islam is built upon five'' by Ibn Uthaymeen", "" },
                    { "l2q1", "This lesson provides practical tips and techniques for starting the memorization journey.", "q1", "https://youtu.be/jRYb9NfNDZA?si=B3jkn9O3J6yZ9iN7", "", "Quran Tafseer 2", "" },
                    { "l2q2", "This lesson discusses the significance of understanding the context and background of the verses.", "q2", "https://youtu.be/FY7yZhNw-XA?si=K7SElOuXowXvAmus", "", "Principles of Tafseer - 2", "" },
                    { "l2q3", "This lesson discusses the significance of understanding the Arabic language.", "q3", "https://youtu.be/1qh0G5uFVlw?si=4i_Y7J53XBOpyBVC", "", "TAFSEER OF QUR'AN Ep 03 Surah Naba 1 4 Sheikh Assim Al Hakeem", "" },
                    { "l2q4", "This lesson discusses the significance of memorizing and reciting the Quran regularly.", "q4", "https://youtu.be/2XMyXyLs1fc?si=wAAyLxgvWZtKqsQk", "", "Mufti Menk - Quran Tafseer Day2", "" }
                });

            migrationBuilder.InsertData(
                table: "Quizzes",
                columns: new[] { "Id", "Description", "LessonId", "StudentQuizEvaluation", "StudentQuizResult", "Title", "TotalMarks", "TotalQuestions" },
                values: new object[,]
                {
                    { "QUIZ-1", "A quiz to test your math skills.", "l1q1", 0, 0, "Math Quiz", 100, 2 },
                    { "QUIZ-2", "A quiz to test your science knowledge.", "l2q1", 0, 0, "Science Quiz", 100, 10 }
                });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "Marks", "QuestionText", "QuizId" },
                values: new object[,]
                {
                    { "QUESTION-1", 5, "What is 2 + 2?", "QUIZ-1" },
                    { "QUESTION-2", 95, "What is the capital of France?", "QUIZ-1" }
                });

            migrationBuilder.InsertData(
                table: "Options",
                columns: new[] { "Id", "IsCorrect", "OptionText", "QuestionId" },
                values: new object[,]
                {
                    { "OPTION-1", false, "3", "QUESTION-1" },
                    { "OPTION-2", true, "4", "QUESTION-1" },
                    { "OPTION-3", false, "5", "QUESTION-1" },
                    { "OPTION-4", false, "6", "QUESTION-1" },
                    { "OPTION-5", false, "Berlin", "QUESTION-2" },
                    { "OPTION-6", false, "Madrid", "QUESTION-2" },
                    { "OPTION-7", true, "Paris", "QUESTION-2" },
                    { "OPTION-8", false, "Rome", "QUESTION-2" }
                });

            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "QuestionId", "StudentId", "SelectedOptionId" },
                values: new object[,]
                {
                    { "QUESTION-1", "626b8c7f-f4d4-4467-bb37-570f1aa6fd77", "OPTION-2" },
                    { "QUESTION-2", "626b8c7f-f4d4-4467-bb37-570f1aa6fd77", "OPTION-1" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Answers_QuestionId",
                table: "Answers",
                column: "QuestionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Answers_SelectedOptionId",
                table: "Answers",
                column: "SelectedOptionId",
                unique: true);

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
                name: "IX_Options_QuestionId",
                table: "Options",
                column: "QuestionId");

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
                name: "IX_Quizzes_LessonId",
                table: "Quizzes",
                column: "LessonId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Answers");

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
                name: "Options");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Progresses");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Enrollment");

            migrationBuilder.DropTable(
                name: "Quizzes");

            migrationBuilder.DropTable(
                name: "Lessons");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
