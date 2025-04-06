using EdufyAPI.Models.QuizModels;
using EdufyAPI.Models.Roles;
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



            modelBuilder.Entity<Answer>(model =>
            {
                model.HasOne(a => a.Student)
                    .WithMany(s => s.Answers)
                    .HasForeignKey(a => a.StudentId)
                    .OnDelete(DeleteBehavior.Restrict);
                model.HasKey(a => new { a.StudentId, a.QuestionId });
            });

            #endregion

            // Seed the database with initial data
            RolesSeeding.Seed(modelBuilder);
        }
    }
}
