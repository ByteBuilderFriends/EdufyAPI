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
                     Id = "LESSON-1001",
                     CourseId = course1Id, // Quran Memorization for Beginners
                     Title = "Why Memorize the Quran?",
                     Content = "This lesson discusses the virtues of memorizing the Quran and how it strengthens one’s connection with Allah.",
                     ExternalVideoUrl = "https://example.com/quran-intro"
                 },
                 new Lesson
                 {
                     Id = "LESSON-1002",
                     CourseId = course1Id,
                     Title = "Daily Routine for Hifz",
                     Content = "Learn how to build an effective daily schedule for memorization and review.",
                     ExternalVideoUrl = "https://example.com/hifz-routine"
                 },
                 new Lesson
                 {
                     Id = "LESSON-1003",
                     CourseId = course2Id, // Fiqh of Worship: Advanced Concepts
                     Title = "The Conditions of Salah",
                     Content = "This lesson explores the advanced rulings on prerequisites of prayer such as purity, timing, and facing the Qibla.",
                     ExternalVideoUrl = "https://example.com/fiqh-salah"
                 },
                 new Lesson
                 {
                     Id = "LESSON-1004",
                     CourseId = course2Id,
                     Title = "Zakat: Detailed Rulings",
                     Content = "Understand the technical conditions, types of zakat, and modern-day applications.",
                     ExternalVideoUrl = "https://example.com/zakat-rulings"
                 }
            );

        }
    }
}
