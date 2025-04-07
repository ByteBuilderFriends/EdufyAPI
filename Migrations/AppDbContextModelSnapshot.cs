﻿// <auto-generated />
using System;
using EdufyAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EdufyAPI.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.13")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EduConnectAPI.Models.Certificate", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CertificateNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("IssueDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ProgressId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Remarks")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProgressId")
                        .IsUnique();

                    b.ToTable("Certificate");
                });

            modelBuilder.Entity("EdufyAPI.Models.Course", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InstructorId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("NumberOfStudentsEnrolled")
                        .HasColumnType("int");

                    b.Property<string>("ThumbnailUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("InstructorId");

                    b.ToTable("Courses");

                    b.HasData(
                        new
                        {
                            Id = "1c700ea4-ac54-487f-80e4-25c7b348b9e0",
                            Description = "Learn the basics of C# programming, including syntax, OOP concepts, and best practices.",
                            InstructorId = "58ec4bbf-4913-4dc1-96b7-381159ce0878",
                            NumberOfStudentsEnrolled = 0,
                            ThumbnailUrl = "csharp_course_thumbnail.jpg",
                            Title = "Introduction to C#"
                        },
                        new
                        {
                            Id = "2d7df053-81d5-4bb8-994d-76619c341c46",
                            Description = "Deep dive into .NET framework, dependency injection, middleware, and microservices.",
                            InstructorId = "a86582e6-8511-4b78-b548-e17a2eaf0d3e",
                            NumberOfStudentsEnrolled = 0,
                            ThumbnailUrl = "dotnet_course_thumbnail.jpg",
                            Title = "Advanced .NET Development"
                        });
                });

            modelBuilder.Entity("EdufyAPI.Models.Enrollment", b =>
                {
                    b.Property<string>("StudentId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CourseId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("StudentId", "CourseId");

                    b.HasIndex("CourseId");

                    b.ToTable("Enrollment");

                    b.HasData(
                        new
                        {
                            StudentId = "626b8c7f-f4d4-4467-bb37-570f1aa6fd77",
                            CourseId = "1c700ea4-ac54-487f-80e4-25c7b348b9e0"
                        },
                        new
                        {
                            StudentId = "626b8c7f-f4d4-4467-bb37-570f1aa6fd77",
                            CourseId = "2d7df053-81d5-4bb8-994d-76619c341c46"
                        },
                        new
                        {
                            StudentId = "e452e625-327a-4bf2-9540-3db6577ab68f",
                            CourseId = "1c700ea4-ac54-487f-80e4-25c7b348b9e0"
                        },
                        new
                        {
                            StudentId = "e452e625-327a-4bf2-9540-3db6577ab68f",
                            CourseId = "2d7df053-81d5-4bb8-994d-76619c341c46"
                        });
                });

            modelBuilder.Entity("EdufyAPI.Models.Lesson", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CourseId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ExternalVideoUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ThumbnailUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VideoUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.ToTable("Lessons");

                    b.HasData(
                        new
                        {
                            Id = "LESSON-1001",
                            Content = "This is the introduction to programming, covering the basics of coding.",
                            CourseId = "1c700ea4-ac54-487f-80e4-25c7b348b9e0",
                            ExternalVideoUrl = "https://example.com/intro-video",
                            ThumbnailUrl = "",
                            Title = "Introduction to Programming",
                            VideoUrl = ""
                        },
                        new
                        {
                            Id = "LESSON-1002",
                            Content = "This lesson explains variables, constants, and different data types in programming.",
                            CourseId = "1c700ea4-ac54-487f-80e4-25c7b348b9e0",
                            ExternalVideoUrl = "https://example.com/variables-video",
                            ThumbnailUrl = "",
                            Title = "Variables and Data Types",
                            VideoUrl = ""
                        },
                        new
                        {
                            Id = "LESSON-1003",
                            Content = "This lesson dives deep into sorting algorithms and their applications.",
                            CourseId = "2d7df053-81d5-4bb8-994d-76619c341c46",
                            ExternalVideoUrl = "https://example.com/algorithms-video",
                            ThumbnailUrl = "",
                            Title = "Advanced Algorithms",
                            VideoUrl = ""
                        },
                        new
                        {
                            Id = "LESSON-1004",
                            Content = "Learn about trees, graphs, and their applications in computer science.",
                            CourseId = "2d7df053-81d5-4bb8-994d-76619c341c46",
                            ExternalVideoUrl = "https://example.com/data-structures-video",
                            ThumbnailUrl = "",
                            Title = "Data Structures: Trees and Graphs",
                            VideoUrl = ""
                        });
                });

            modelBuilder.Entity("EdufyAPI.Models.Progress", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("CompletedProgress")
                        .HasColumnType("bit");

                    b.Property<string>("CourseId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("LastUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("StudentId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("TotalLessonsCompleted")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("StudentId", "CourseId")
                        .IsUnique();

                    b.ToTable("Progresses");

                    b.HasData(
                        new
                        {
                            Id = "PROG-1001",
                            CompletedProgress = false,
                            CourseId = "1c700ea4-ac54-487f-80e4-25c7b348b9e0",
                            LastUpdated = new DateTime(2025, 4, 7, 0, 12, 7, 564, DateTimeKind.Utc).AddTicks(669),
                            StudentId = "626b8c7f-f4d4-4467-bb37-570f1aa6fd77",
                            TotalLessonsCompleted = 5
                        },
                        new
                        {
                            Id = "PROG-1002",
                            CompletedProgress = false,
                            CourseId = "1c700ea4-ac54-487f-80e4-25c7b348b9e0",
                            LastUpdated = new DateTime(2025, 4, 7, 0, 12, 7, 564, DateTimeKind.Utc).AddTicks(673),
                            StudentId = "e452e625-327a-4bf2-9540-3db6577ab68f",
                            TotalLessonsCompleted = 7
                        },
                        new
                        {
                            Id = "PROG-1003",
                            CompletedProgress = false,
                            CourseId = "2d7df053-81d5-4bb8-994d-76619c341c46",
                            LastUpdated = new DateTime(2025, 4, 7, 0, 12, 7, 564, DateTimeKind.Utc).AddTicks(677),
                            StudentId = "626b8c7f-f4d4-4467-bb37-570f1aa6fd77",
                            TotalLessonsCompleted = 10
                        },
                        new
                        {
                            Id = "PROG-1004",
                            CompletedProgress = false,
                            CourseId = "2d7df053-81d5-4bb8-994d-76619c341c46",
                            LastUpdated = new DateTime(2025, 4, 7, 0, 12, 7, 564, DateTimeKind.Utc).AddTicks(679),
                            StudentId = "e452e625-327a-4bf2-9540-3db6577ab68f",
                            TotalLessonsCompleted = 12
                        });
                });

            modelBuilder.Entity("EdufyAPI.Models.QuizModels.Answer", b =>
                {
                    b.Property<string>("StudentId")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnOrder(1);

                    b.Property<string>("QuestionId")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnOrder(2);

                    b.Property<string>("SelectedOptionId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("StudentId", "QuestionId");

                    b.HasIndex("QuestionId");

                    b.HasIndex("SelectedOptionId");

                    b.ToTable("Answers");
                });

            modelBuilder.Entity("EdufyAPI.Models.QuizModels.Option", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("IsCorrect")
                        .HasColumnType("bit");

                    b.Property<string>("OptionText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("QuestionId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.ToTable("Options");
                });

            modelBuilder.Entity("EdufyAPI.Models.QuizModels.Question", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Marks")
                        .HasColumnType("int");

                    b.Property<string>("QuestionText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("QuizId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("QuizId");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("EdufyAPI.Models.QuizModels.Quiz", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<string>("LessonId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("StudentId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("StudentQuizEvaluation")
                        .HasColumnType("int");

                    b.Property<int>("StudentQuizResult")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TotalMarks")
                        .HasColumnType("int");

                    b.Property<int>("TotalQuestions")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LessonId");

                    b.HasIndex("StudentId");

                    b.ToTable("Quizzes");
                });

            modelBuilder.Entity("EdufyAPI.Models.Roles.AppUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("ProfilePictureUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasDiscriminator().HasValue("AppUser");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "1",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "2",
                            Name = "Instructor",
                            NormalizedName = "INSTRUCTOR"
                        },
                        new
                        {
                            Id = "3",
                            Name = "Student",
                            NormalizedName = "STUDENT"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("EdufyAPI.Models.Roles.Admin", b =>
                {
                    b.HasBaseType("EdufyAPI.Models.Roles.AppUser");

                    b.HasDiscriminator().HasValue("Admin");
                });

            modelBuilder.Entity("EdufyAPI.Models.Roles.Instructor", b =>
                {
                    b.HasBaseType("EdufyAPI.Models.Roles.AppUser");

                    b.HasDiscriminator().HasValue("Instructor");

                    b.HasData(
                        new
                        {
                            Id = "58ec4bbf-4913-4dc1-96b7-381159ce0878",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "aa69aeef-abe7-4014-82d4-5ad653a7cb54",
                            Email = "omar.tarek@example.com",
                            EmailConfirmed = false,
                            FirstName = "Omar",
                            LastName = "Tarek",
                            LockoutEnabled = false,
                            NormalizedEmail = "OMAR.TAREK@EXAMPLE.COM",
                            NormalizedUserName = "OMAR.TAREK",
                            PasswordHash = "AQAAAAIAAYagAAAAECdIBKZfi4z6aOXJzj0QfBmT4rZ4u4MUUuVpAxSvpcJrki2hWz/ZwvW3gtmuI9oREg==",
                            PhoneNumber = "1122334455",
                            PhoneNumberConfirmed = false,
                            ProfilePictureUrl = "",
                            SecurityStamp = "50655cd3-0af4-4549-84f0-57f17d96f1ed",
                            TwoFactorEnabled = false,
                            UserName = "omar.tarek"
                        },
                        new
                        {
                            Id = "a86582e6-8511-4b78-b548-e17a2eaf0d3e",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "25032349-409d-4e98-8a40-f97db7f9f37a",
                            Email = "hana.mostafa@example.com",
                            EmailConfirmed = false,
                            FirstName = "Hana",
                            LastName = "Mostafa",
                            LockoutEnabled = false,
                            NormalizedEmail = "HANA.MOSTAFA@EXAMPLE.COM",
                            NormalizedUserName = "HANA.MOSTAFA",
                            PasswordHash = "AQAAAAIAAYagAAAAEJoiQdm0y5IZpZF3BLXERkWstuy+8EU8jUfOtDnpLcyoqiwq6wIke/LyLQcrmxpFCw==",
                            PhoneNumber = "5566778899",
                            PhoneNumberConfirmed = false,
                            ProfilePictureUrl = "",
                            SecurityStamp = "e14da933-e6c7-44b3-8045-c82cd1c52292",
                            TwoFactorEnabled = false,
                            UserName = "hana.mostafa"
                        });
                });

            modelBuilder.Entity("EdufyAPI.Models.Roles.Student", b =>
                {
                    b.HasBaseType("EdufyAPI.Models.Roles.AppUser");

                    b.HasDiscriminator().HasValue("Student");

                    b.HasData(
                        new
                        {
                            Id = "626b8c7f-f4d4-4467-bb37-570f1aa6fd77",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "f2866e8f-7f5c-4940-a81b-5c9afbe5554a",
                            Email = "ali.mahmoud@example.com",
                            EmailConfirmed = false,
                            FirstName = "Ali",
                            LastName = "Mahmoud",
                            LockoutEnabled = false,
                            NormalizedEmail = "ALI.MAHMOUD@EXAMPLE.COM",
                            NormalizedUserName = "ALI.MAHMOUD",
                            PasswordHash = "AQAAAAIAAYagAAAAENRQGCT+AnEhC2tjkQ0uWCI30AUaBIOIL0JPGJnX279r8+iopdFqJ3w992SeN3J5vQ==",
                            PhoneNumber = "1234567890",
                            PhoneNumberConfirmed = false,
                            ProfilePictureUrl = "",
                            SecurityStamp = "34bed44d-0982-4caf-b2fb-be03f44dc381",
                            TwoFactorEnabled = false,
                            UserName = "ali.mahmoud"
                        },
                        new
                        {
                            Id = "e452e625-327a-4bf2-9540-3db6577ab68f",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "19caa602-33ca-4e29-9dfd-d04f700634e4",
                            Email = "salma.ahmed@example.com",
                            EmailConfirmed = false,
                            FirstName = "Salma",
                            LastName = "Ahmed",
                            LockoutEnabled = false,
                            NormalizedEmail = "SALMA.AHMED@EXAMPLE.COM",
                            NormalizedUserName = "SALMA.AHMED",
                            PasswordHash = "AQAAAAIAAYagAAAAEJkRk/RFb1ZVrpUzqe2Wzx4XJJV3xK97u7+8jCynLmaDJeg+d/Ec3297gFtTQyZsdA==",
                            PhoneNumber = "0987654321",
                            PhoneNumberConfirmed = false,
                            ProfilePictureUrl = "",
                            SecurityStamp = "dcc112b5-8bf7-4949-864d-38aaa190377e",
                            TwoFactorEnabled = false,
                            UserName = "salma.ahmed"
                        });
                });

            modelBuilder.Entity("EduConnectAPI.Models.Certificate", b =>
                {
                    b.HasOne("EdufyAPI.Models.Progress", "Progress")
                        .WithOne("Certificate")
                        .HasForeignKey("EduConnectAPI.Models.Certificate", "ProgressId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Progress");
                });

            modelBuilder.Entity("EdufyAPI.Models.Course", b =>
                {
                    b.HasOne("EdufyAPI.Models.Roles.Instructor", "Instructor")
                        .WithMany("Courses")
                        .HasForeignKey("InstructorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Instructor");
                });

            modelBuilder.Entity("EdufyAPI.Models.Enrollment", b =>
                {
                    b.HasOne("EdufyAPI.Models.Course", "Course")
                        .WithMany("Enrollments")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("EdufyAPI.Models.Roles.Student", "Student")
                        .WithMany("Enrollments")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("EdufyAPI.Models.Lesson", b =>
                {
                    b.HasOne("EdufyAPI.Models.Course", "Course")
                        .WithMany("Lessons")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("EdufyAPI.Models.Progress", b =>
                {
                    b.HasOne("EdufyAPI.Models.Course", "Course")
                        .WithMany("CourseProgress")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("EdufyAPI.Models.Roles.Student", null)
                        .WithMany("Progresses")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("EdufyAPI.Models.Enrollment", "Enrollment")
                        .WithOne("Progress")
                        .HasForeignKey("EdufyAPI.Models.Progress", "StudentId", "CourseId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Enrollment");
                });

            modelBuilder.Entity("EdufyAPI.Models.QuizModels.Answer", b =>
                {
                    b.HasOne("EdufyAPI.Models.QuizModels.Question", "Question")
                        .WithMany()
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("EdufyAPI.Models.QuizModels.Option", "Option")
                        .WithMany()
                        .HasForeignKey("SelectedOptionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("EdufyAPI.Models.Roles.Student", "Student")
                        .WithMany("Answers")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Option");

                    b.Navigation("Question");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("EdufyAPI.Models.QuizModels.Option", b =>
                {
                    b.HasOne("EdufyAPI.Models.QuizModels.Question", "Question")
                        .WithMany("Options")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Question");
                });

            modelBuilder.Entity("EdufyAPI.Models.QuizModels.Question", b =>
                {
                    b.HasOne("EdufyAPI.Models.QuizModels.Quiz", "Quiz")
                        .WithMany("Questions")
                        .HasForeignKey("QuizId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Quiz");
                });

            modelBuilder.Entity("EdufyAPI.Models.QuizModels.Quiz", b =>
                {
                    b.HasOne("EdufyAPI.Models.Lesson", "Lesson")
                        .WithMany()
                        .HasForeignKey("LessonId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("EdufyAPI.Models.Roles.Student", "Student")
                        .WithMany("Quizzes")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Lesson");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("EdufyAPI.Models.Roles.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("EdufyAPI.Models.Roles.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("EdufyAPI.Models.Roles.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("EdufyAPI.Models.Roles.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("EdufyAPI.Models.Course", b =>
                {
                    b.Navigation("CourseProgress");

                    b.Navigation("Enrollments");

                    b.Navigation("Lessons");
                });

            modelBuilder.Entity("EdufyAPI.Models.Enrollment", b =>
                {
                    b.Navigation("Progress")
                        .IsRequired();
                });

            modelBuilder.Entity("EdufyAPI.Models.Progress", b =>
                {
                    b.Navigation("Certificate")
                        .IsRequired();
                });

            modelBuilder.Entity("EdufyAPI.Models.QuizModels.Question", b =>
                {
                    b.Navigation("Options");
                });

            modelBuilder.Entity("EdufyAPI.Models.QuizModels.Quiz", b =>
                {
                    b.Navigation("Questions");
                });

            modelBuilder.Entity("EdufyAPI.Models.Roles.Instructor", b =>
                {
                    b.Navigation("Courses");
                });

            modelBuilder.Entity("EdufyAPI.Models.Roles.Student", b =>
                {
                    b.Navigation("Answers");

                    b.Navigation("Enrollments");

                    b.Navigation("Progresses");

                    b.Navigation("Quizzes");
                });
#pragma warning restore 612, 618
        }
    }
}
