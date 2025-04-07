using EdufyAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EdufyAPI.RoleSeeding
{
    public class ProgressSeeding
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            var student1Id = "626b8c7f-f4d4-4467-bb37-570f1aa6fd77";
            var student2Id = "e452e625-327a-4bf2-9540-3db6577ab68f";

            var course1Id = "1c700ea4-ac54-487f-80e4-25c7b348b9e0";
            var course2Id = "2d7df053-81d5-4bb8-994d-76619c341c46";

            var fixedDate = new DateTime(2025, 4, 7, 0, 0, 0, DateTimeKind.Utc);

            modelBuilder.Entity<Progress>().HasData(
                new Progress
                {
                    Id = "PROG-1001",
                    CourseId = course1Id,
                    StudentId = student1Id,
                    TotalLessonsCompleted = 5,
                    LastUpdated = fixedDate
                },
                new Progress
                {
                    Id = "PROG-1002",
                    CourseId = course1Id,
                    StudentId = student2Id,
                    TotalLessonsCompleted = 7,
                    LastUpdated = fixedDate
                },
                new Progress
                {
                    Id = "PROG-1003",
                    CourseId = course2Id,
                    StudentId = student1Id,
                    TotalLessonsCompleted = 10,
                    LastUpdated = fixedDate
                },
                new Progress
                {
                    Id = "PROG-1004",
                    CourseId = course2Id,
                    StudentId = student2Id,
                    TotalLessonsCompleted = 12,
                    LastUpdated = fixedDate
                }
            );
        }
    }
}
