using EdufyAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EdufyAPI.RoleSeeding
{
    public static class EnrollmentSeeding
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            // Replace with actual seeded Student IDs from RoleSeeding
            var student1Id = "626b8c7f-f4d4-4467-bb37-570f1aa6fd77";
            var student2Id = "e452e625-327a-4bf2-9540-3db6577ab68f";

            // Replace with actual seeded Course IDs from CourseSeeding
            var course1Id = "1c700ea4-ac54-487f-80e4-25c7b348b9e0";
            var course2Id = "2d7df053-81d5-4bb8-994d-76619c341c46";

            var enrollments = new List<Enrollment>
            {
                new Enrollment
                {
                    StudentId = student1Id,
                    CourseId = course1Id
                },
                new Enrollment
                {
                    StudentId = student1Id,
                    CourseId = course2Id
                },
                new Enrollment
                {
                    StudentId = student2Id,
                    CourseId = course1Id
                },
                new Enrollment
                {
                    StudentId = student2Id,
                    CourseId = course2Id
                }
            };

            modelBuilder.Entity<Enrollment>().HasData(enrollments);
        }
    }
}
