using EdufyAPI.Models.Roles;
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
            modelBuilder.Entity<Enrollment>(entity =>
                {
                    entity.HasKey(sc => new { sc.StudentId, sc.CourseId });

                    entity.HasOne(sc => sc.Student)
                          .WithMany(s => s.StudentCourses)
                          .HasForeignKey(sc => sc.StudentId)
                          .OnDelete(DeleteBehavior.Restrict);

                    entity.HasOne(sc => sc.Course)
                          .WithMany(c => c.StudentCourses)
                          .HasForeignKey(sc => sc.CourseId)
                          .OnDelete(DeleteBehavior.Restrict);
                });

            #endregion
        }
    }
}
