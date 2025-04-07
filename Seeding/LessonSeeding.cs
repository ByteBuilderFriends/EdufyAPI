using EdufyAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EdufyAPI.RoleSeeding
{
    public class LessonSeeding
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            var course1Id = "1c700ea4-ac54-487f-80e4-25c7b348b9e0";
            var course2Id = "2d7df053-81d5-4bb8-994d-76619c341c46";

            modelBuilder.Entity<Lesson>().HasData(
                new Lesson
                {
                    Id = "LESSON-1001", // Stronger ID
                    CourseId = course1Id,
                    Title = "Introduction to Programming",
                    Content = "This is the introduction to programming, covering the basics of coding.",
                    ExternalVideoUrl = "https://example.com/intro-video"
                },
                new Lesson
                {
                    Id = "LESSON-1002", // Stronger ID
                    CourseId = course1Id,
                    Title = "Variables and Data Types",
                    Content = "This lesson explains variables, constants, and different data types in programming.",
                    ExternalVideoUrl = "https://example.com/variables-video"
                },
                new Lesson
                {
                    Id = "LESSON-1003", // Stronger ID
                    CourseId = course2Id,
                    Title = "Advanced Algorithms",
                    Content = "This lesson dives deep into sorting algorithms and their applications.",
                    ExternalVideoUrl = "https://example.com/algorithms-video"
                },
                new Lesson
                {
                    Id = "LESSON-1004", // Stronger ID
                    CourseId = course2Id,
                    Title = "Data Structures: Trees and Graphs",
                    Content = "Learn about trees, graphs, and their applications in computer science.",
                    ExternalVideoUrl = "https://example.com/data-structures-video"
                }
            );
        }
    }
}
