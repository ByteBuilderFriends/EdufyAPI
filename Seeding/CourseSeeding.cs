using AskAMuslimAPI.Enums;
using EdufyAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EdufyAPI.RoleSeeding
{
    public class CourseSeeding
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            // Fetching existing instructor IDs from RoleSeeding
            var aam = "626b8c7f-f4d4-4467-bb37-570f1aa6fd66";
            var mujahidHussain = "9a5c21b2-2d92-4d0f-bad3-47d4bbd4e611";
            var muftiMenk = "2c179b2d-1d3b-42a3-8d6f-d2fd86b73c29";
            var assimAlhakeem = "d1234567-89ab-4cde-8f01-23456789abcd";
            var muhammadSalah = "f2345678-90ab-4def-9f12-34567890bcde";
            var ibnUthaymeen = "a3456789-01bc-4fgh-9g23-45678901cdef";
            var ibnFarooq = "b4567890-12cd-5ghi-0h34-56789012def0";

            // Define the courses list
            string directory = "https://ask-a-muslim.runasp.net/uploads/course-thumbnails/";

            var courses = new List<Course>
            {
                #region Quran Courses
                new Course
                {
                    Id = "q1",
                    Title = "Qur'an tafseer by Mufti menk",
                    Description = "Learn to memorize the Quran with effective techniques.",
                    Category = CourseCategory.Quran,
                    Level = CourseLevel.Beginner,
                    ThumbnailUrl = $"{directory}q1.jpg",
                    InstructorId = muftiMenk
                },
                new Course
                {
                    Id = "q2",
                    Title = "Complete Quran Tafseer",
                    Description = "Master the basics of Tajweed for proper Quran recitation.",
                    Category = CourseCategory.Quran,
                    Level = CourseLevel.Beginner,
                    ThumbnailUrl = $"{directory}q2.jpg",
                    InstructorId = mujahidHussain
                },
                new Course
                {
                    Id = "q3",
                    Title = "TAFSEER OF QUR'AN |Sheikh Assim Al Hakeem",
                    Description = "Enhance your recitation skills with proper Makharij and Sifaat.",
                    Category = CourseCategory.Quran,
                    Level = CourseLevel.Intermediate,
                    ThumbnailUrl = $"{directory}q3.jpg",
                    InstructorId = assimAlhakeem
                },
                new Course
                {
                    Id = "q4",
                    Title = "Mufti Menk - Quran Tafseer",
                    Description = "Dive deeper into Quranic understanding and reflection.",
                    Category = CourseCategory.Quran,
                    Level = CourseLevel.Advanced,
                    ThumbnailUrl = $"{directory}q4.jpg",
                    InstructorId = muftiMenk
                },
                #endregion

                #region Hadith Courses
                new Course
                {
                    Id = "h1",
                    Title = "Comprehensive Hadith Course - Mishkat-ul-Masabih",
                    Description = "Welcome to the **Comprehensive Hadith Course - Mishkat-ul-Masabih**...",
                    Category = CourseCategory.Hadith,
                    Level = CourseLevel.Beginner,
                    ThumbnailUrl = $"{directory}h1.jpg",
                    InstructorId = mujahidHussain
                },
                new Course
                {
                    Id = "h2",
                    Title = "Advanced Islamic Diploma Course in Quran and Hadith",
                    Description = "The Free Advanced Diploma Course in Quran and Hadith...",
                    Category = CourseCategory.Hadith,
                    Level = CourseLevel.Advanced,
                    ThumbnailUrl = $"{directory}h2.jpg",
                    InstructorId = mujahidHussain
                },
                new Course
                {
                    Id = "h3",
                    Title = "Hadith - Semester 1 | Shaykh Dr. Muhammad Salah",
                    Description = "An in-depth study of Sahih Bukhari collections.",
                    Category = CourseCategory.Hadith,
                    Level = CourseLevel.Beginner,
                    ThumbnailUrl = $"{directory}h3.jpg",
                    InstructorId = muhammadSalah
                },
                new Course
                {
                    Id = "h4",
                    Title = "Al Nawawi's Forty Hadith",
                    Description = "Study the top authentic Hadith books.",
                    Category = CourseCategory.Hadith,
                    Level = CourseLevel.Intermediate,
                    ThumbnailUrl = $"{directory}h4.jpg",
                    InstructorId = ibnUthaymeen
                },
                #endregion

                #region Aqeedah Courses
                new Course
                {
                    Id = "a1",
                    Title = "principles of belief",
                    Description = "Learn the fundamentals of Islamic beliefs and Aqeedah.",
                    Category = CourseCategory.Aqeeda,
                    Level = CourseLevel.Beginner,
                    ThumbnailUrl = $"{directory}a1.jpg",
                    InstructorId = aam
                },
                new Course
                {
                    Id = "a2",
                    Title = "Aqeedah/Creed",
                    Description = "Explore advanced topics in Islamic beliefs and theology.",
                    Category = CourseCategory.Aqeeda,
                    Level = CourseLevel.Advanced,
                    ThumbnailUrl = $"{directory}a2.jpg",
                    InstructorId = ibnUthaymeen
                },
                new Course
                {
                    Id = "a3",
                    Title = "Islamic Beliefs and Practices",
                    Description = "Study the beliefs of Ahlus Sunnah wal Jama'ah.",
                    Category = CourseCategory.Aqeeda,
                    Level = CourseLevel.Intermediate,
                    ThumbnailUrl = $"{directory}a3.jpg",
                    InstructorId = ibnFarooq
                },
                new Course
                {
                    Id = "a4",
                    Title = "Fundamentals of Aqeedah",
                    Description = "Learn the fundamentals of Islamic beliefs and Aqeedah.",
                    Category = CourseCategory.Aqeeda,
                    Level = CourseLevel.Beginner,
                    ThumbnailUrl = $"{directory}a4.jpg",
                    InstructorId = assimAlhakeem
                },
                #endregion

                #region Fiqh Courses
                new Course
                {
                    Id = "f1",
                    Title = "Fiqh Of Ramadan",
                    Description = "Learn the principles of Islamic law and jurisprudence.",
                    Category = CourseCategory.Fiqh,
                    Level = CourseLevel.Intermediate,
                    ThumbnailUrl = $"{directory}f1.jpg",
                    InstructorId = aam
                },
                new Course
                {
                    Id = "f2",
                    Title = "Fiqh - Semester 1 | Shaykh Assim Al-Hakeem",
                    Description = "Explore advanced topics in Islamic law and jurisprudence.",
                    Category = CourseCategory.Fiqh,
                    Level = CourseLevel.Beginner,
                    ThumbnailUrl = $"{directory}f2.jpg",
                    InstructorId = assimAlhakeem
                },
                new Course
                {
                    Id = "f3",
                    Title = "Islamic Fiqh",
                    Description = "Study the principles of Islamic law and ethics.",
                    Category = CourseCategory.Fiqh,
                    Level = CourseLevel.Intermediate,
                    ThumbnailUrl = $"{directory}f3.jpg",
                    InstructorId = assimAlhakeem
                },
                new Course
                {
                    Id = "f4",
                    Title = "FIQH IN ISLAM based on Sharh al-Umdah",
                    Description = "Learn the principles of Islamic law and jurisprudence.",
                    Category = CourseCategory.Fiqh,
                    Level = CourseLevel.Beginner,
                    ThumbnailUrl = $"{directory}f4.jpg",
                    InstructorId = ibnFarooq
                },
                #endregion

                #region Faith Courses
                new Course
                {
                    Id = "fa1",
                    Title = "Faith in Islam",
                    Description = "Learn the fundamentals of Islamic beliefs and Aqeedah.",
                    Category = CourseCategory.Faith,
                    Level = CourseLevel.Beginner,
                    ThumbnailUrl = $"{directory}fa1.jpg",
                    InstructorId = aam
                },
                new Course
                {
                    Id = "fa2",
                    Title = "The Six Articles of Faith in Islam",
                    Description = "Explore advanced topics in Islamic beliefs and theology.",
                    Category = CourseCategory.Faith,
                    Level = CourseLevel.Advanced,
                    ThumbnailUrl = $"{directory}fa2.jpg",
                    InstructorId = aam
                },
                new Course
                {
                    Id = "fa3",
                    Title = "Islamic Faith",
                    Description = "Study the beliefs of Ahlus Sunnah wal Jama'ah.",
                    Category = CourseCategory.Faith,
                    Level = CourseLevel.Beginner,
                    ThumbnailUrl = $"{directory}fa3.jpg",
                    InstructorId = assimAlhakeem
                },
                new Course
                {
                    Id = "fa4",
                    Title = "Islamic Reminders",
                    Description = "Learn the fundamentals of Islamic beliefs and Aqeedah.",
                    Category = CourseCategory.Faith,
                    Level = CourseLevel.Beginner,
                    ThumbnailUrl = $"{directory}fa4.jpg",
                    InstructorId = ibnFarooq
                }
                #endregion
        };

            // Add the courses to the model builder
            modelBuilder.Entity<Course>().HasData(courses);
        }
    }
}
