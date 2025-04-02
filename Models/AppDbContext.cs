﻿using EdufyAPI.Models.Roles;
using EdufyAPI.RoleSeeding;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EdufyAPI.Models
{
    // You can Change DbContext to your desired name
    public partial class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        override protected void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            #region Roles Seed
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = "1", // Static GUID or hardcoded value
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole
                {
                    Id = "2",
                    Name = "Instructor",
                    NormalizedName = "INSTRUCTOR"
                },
                new IdentityRole
                {
                    Id = "3",
                    Name = "Student",
                    NormalizedName = "STUDENT"
                }
            );
            #endregion



            #region Relationships

            // Restrict delete behavior to avoid accidental deletion of related entities
            // Helps in avoiding orphaned records in the database
            // Helps in preventing cascading delete, to prevent cycles or multiple cascade paths
            foreach (var foreignKey in modelBuilder.Model.GetEntityTypes()
            .SelectMany(e => e.GetForeignKeys()))
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }

            modelBuilder.Entity<Enrollment>(entity =>
            {
                entity.HasKey(sc => new { sc.StudentId, sc.CourseId });

                entity.HasOne(sc => sc.Student)
                      .WithMany(s => s.Enrollments)
                      .HasForeignKey(sc => sc.StudentId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(sc => sc.Course)
                      .WithMany(c => c.Enrollments)
                      .HasForeignKey(sc => sc.CourseId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // Define the FK relationship between Progress and Enrollment
            modelBuilder.Entity<Progress>()
                .HasOne(p => p.Enrollment)
                .WithOne(e => e.Progress)
                .HasForeignKey<Progress>(p => new { p.StudentId, p.CourseId })
                .OnDelete(DeleteBehavior.Restrict); // Avoid cascading delete


            //// Define the FK relationship between StudentAnswer and QuizAttempt
            //modelBuilder.Entity<StudentAnswer>()
            //    .HasOne(sa => sa.QuizResult)
            //    .WithMany(qa => qa.StudentAnswers)
            //    .HasForeignKey(sa => sa.QuizResultId)
            //    .OnDelete(DeleteBehavior.Restrict); // Avoid cascading delete

            //// Define the FK relationship between QuizAttempt and StudentAnswer
            //modelBuilder.Entity<QuizAttemp>()
            //    .HasMany(qa => qa.StudentAnswers)
            //    .WithOne(sa => sa.QuizResult)
            //    .HasForeignKey(sa => sa.QuizResultId)
            //    .OnDelete(DeleteBehavior.Restrict); // Avoid cascading delete

            #endregion

            IdentitySeeding.Seed(modelBuilder); // Apply role and user seeding
            CourseSeeding.Seed(modelBuilder); // Seed Courses
            EnrollmentSeeding.Seed(modelBuilder); // Seed Enrollments
            ProgressSeeding.Seed(modelBuilder); // Seed Progresses
            LessonSeeding.Seed(modelBuilder); // Seed Lessons
            QuizSeeding.Seed(modelBuilder); // Seed Quizzes
            QuestionSeeding.Seed(modelBuilder); // Seed Questions
            AnswerSeeding.Seed(modelBuilder); // Seed Answers
            QuizAttempSeeding.Seed(modelBuilder); // Seed Quiz Attempts
            StudentAnswerSeeding.Seed(modelBuilder); // Seed Student Answers

        }
    }
}
