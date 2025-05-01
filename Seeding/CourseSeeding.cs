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
            var zadAcademy = "b4567890-12cd-5ghi-0h34-56789012def1";


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
                    ThumbnailUrl = "q1.jpg",
                    InstructorId = muftiMenk
                },
                new Course
                {
                    Id = "q2",
                    Title = "Complete Quran Tafseer",
                    Description = "Master the basics of Tajweed for proper Quran recitation.",
                    Category = CourseCategory.Quran,
                    Level = CourseLevel.Beginner,
                    ThumbnailUrl = "q2.jpg",
                    InstructorId = mujahidHussain
                },
                new Course
                {
                    Id = "q3",
                    Title = "TAFSEER OF QUR'AN |Sheikh Assim Al Hakeem",
                    Description = "Enhance your recitation skills with proper Makharij and Sifaat.",
                    Category = CourseCategory.Quran,
                    Level = CourseLevel.Intermediate,
                    ThumbnailUrl = "q3.jpg",
                    InstructorId = assimAlhakeem
                },
                new Course
                {
                    Id = "q4",
                    Title = "Mufti Menk - Quran Tafseer",
                    Description = "Dive deeper into Quranic understanding and reflection.",
                    Category = CourseCategory.Quran,
                    Level = CourseLevel.Advanced,
                    ThumbnailUrl = "q4.jpg",
                    InstructorId = muftiMenk
                },
                new Course
                {
                    Id = "q5",
                    Title = "Scientific Miracles In The Quran",
                    Description = "Learn the fundamentals of Quranic Arabic grammar.",
                    Category = CourseCategory.Quran,
                    Level = CourseLevel.Beginner,
                    ThumbnailUrl = "q5.jpg",
                    InstructorId = aam
                },
                new Course
                {
                    Id = "q6",
                    Title = "Muhammad Salah - Tafseer Quran",
                    Description = "Explore the linguistic miracles of the Quran.",
                    Category = CourseCategory.Quran,
                    Level = CourseLevel.Advanced,
                    ThumbnailUrl = "q6.jpg",
                    InstructorId = muhammadSalah
                },
                new Course
                {
                    Id = "q7",
                    Title = "Tafsir - Semester 1 - Zad Academy",
                    Description = "Learn the fundamentals of Quranic Arabic grammar.",
                    Category = CourseCategory.Quran,
                    Level = CourseLevel.Beginner,
                    ThumbnailUrl = "q7.jpg",
                    InstructorId = zadAcademy
                },
                #endregion

                #region Hadith Courses
                new Course
                {
                    Id = "h1",
                    Title = "Comprehensive Hadith Course - Mishkat-ul-Masabih",
                    Description = "Welcome to the Comprehensive Hadith Course - Mishkat-ul-Masabih.",
                    Category = CourseCategory.Hadith,
                    Level = CourseLevel.Beginner,
                    ThumbnailUrl = "h1.jpg",
                    InstructorId = mujahidHussain
                },
                new Course
                {
                    Id = "h2",
                    Title = "Advanced Islamic Diploma Course in Quran and Hadith",
                    Description = "The Free Advanced Diploma Course in Quran and Hadith...",
                    Category = CourseCategory.Hadith,
                    Level = CourseLevel.Advanced,
                    ThumbnailUrl = "h2.jpg",
                    InstructorId = mujahidHussain
                },
                new Course
                {
                    Id = "h3",
                    Title = "Hadith - Semester 1 | Shaykh Dr. Muhammad Salah",
                    Description = "An in-depth study of Sahih Bukhari collections.",
                    Category = CourseCategory.Hadith,
                    Level = CourseLevel.Beginner,
                    ThumbnailUrl = "h3.jpg",
                    InstructorId = muhammadSalah
                },
                new Course
                {
                    Id = "h4",
                    Title = "Al Nawawi's Forty Hadith",
                    Description = "Study the top authentic Hadith books.",
                    Category = CourseCategory.Hadith,
                    Level = CourseLevel.Intermediate,
                    ThumbnailUrl = "h4.jpg",
                    InstructorId = ibnUthaymeen
                },
                new Course
                {
                    Id = "h5",
                    Title = "Characteristics of Prophet Ash Shama'il Al Muhammadiyah",
                    Description = "An in-depth study of Sahih Muslim collections.",
                    Category = CourseCategory.Hadith,
                    Level = CourseLevel.Beginner,
                    ThumbnailUrl = "h5.jpg",
                    InstructorId = assimAlhakeem
                },
                new Course
                {
                    Id = "h6",
                    Title = "Hadith - Semester 2 | Shaykh Dr. Muhammad Salah",
                    Description = "An in-depth study of Sahih Muslim collections.",
                    Category = CourseCategory.Hadith,
                    Level = CourseLevel.Advanced,
                    ThumbnailUrl = "h6.jpg",
                    InstructorId = muhammadSalah
                },
                new Course
                {
                    Id = "h7",
                    Title = "Hadith with Mufti Menk",
                    Description = "An in-depth study of Sahih Muslim collections.",
                    Category = CourseCategory.Hadith,
                    Level = CourseLevel.Advanced,
                    ThumbnailUrl = "h7.jpg",
                    InstructorId = muftiMenk
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
                    ThumbnailUrl = "a1.jpg",
                    InstructorId = aam
                },
                new Course
                {
                    Id = "a2",
                    Title = "Aqeedah/Creed",
                    Description = "Explore advanced topics in Islamic beliefs and theology.",
                    Category = CourseCategory.Aqeeda,
                    Level = CourseLevel.Advanced,
                    ThumbnailUrl = "a2.jpg",
                    InstructorId = ibnUthaymeen
                },
                new Course
                {
                    Id = "a3",
                    Title = "Islamic Beliefs and Practices",
                    Description = "Study the beliefs of Ahlus Sunnah wal Jama'ah.",
                    Category = CourseCategory.Aqeeda,
                    Level = CourseLevel.Intermediate,
                    ThumbnailUrl = "a3.jpg",
                    InstructorId = ibnFarooq
                },
                new Course
                {
                    Id = "a4",
                    Title = "Fundamentals of Aqeedah",
                    Description = "Learn the fundamentals of Islamic beliefs and Aqeedah.",
                    Category = CourseCategory.Aqeeda,
                    Level = CourseLevel.Beginner,
                    ThumbnailUrl = "a4.jpg",
                    InstructorId = assimAlhakeem
                },
                new Course
                {
                    Id = "a5",
                    Title = "Aqeedah - Semester 1 | Zad Academy",
                    Description = "Explore advanced topics in Islamic beliefs and theology.",
                    Category = CourseCategory.Aqeeda,
                    Level = CourseLevel.Beginner,
                    ThumbnailUrl = "a5.jpg",
                    InstructorId = zadAcademy
                },
                new Course
                {
                    Id = "a6",
                    Title = "Aqeedah - Semester 2 | Zad Academy",
                    Description = "Study the beliefs of Ahlus Sunnah wal Jama'ah.",
                    Category = CourseCategory.Aqeeda,
                    Level = CourseLevel.Intermediate,
                    ThumbnailUrl = "a6.jpg",
                    InstructorId = zadAcademy
                },
                new Course
                {
                    Id = "a7",
                    Title = "Aqeedah - Semester 3 | Zad Academy",
                    Description = "Study the beliefs of Ahlus Sunnah wal Jama'ah.",
                    Category = CourseCategory.Aqeeda,
                    Level = CourseLevel.Advanced,
                    ThumbnailUrl = "a7.jpg",
                    InstructorId = zadAcademy
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
                    ThumbnailUrl = "f1.jpg",
                    InstructorId = aam
                },
                new Course
                {
                    Id = "f2",
                    Title = "Fiqh - Semester 1 | Shaykh Assim Al-Hakeem",
                    Description = "Explore advanced topics in Islamic law and jurisprudence.",
                    Category = CourseCategory.Fiqh,
                    Level = CourseLevel.Beginner,
                    ThumbnailUrl = "f2.jpg",
                    InstructorId = assimAlhakeem
                },
                new Course
                {
                    Id = "f3",
                    Title = "Islamic Fiqh",
                    Description = "Study the principles of Islamic law and ethics.",
                    Category = CourseCategory.Fiqh,
                    Level = CourseLevel.Intermediate,
                    ThumbnailUrl = "f3.jpg",
                    InstructorId = assimAlhakeem
                },
                new Course
                {
                    Id = "f4",
                    Title = "FIQH IN ISLAM based on Sharh al-Umdah",
                    Description = "Learn the principles of Islamic law and jurisprudence.",
                    Category = CourseCategory.Fiqh,
                    Level = CourseLevel.Beginner,
                    ThumbnailUrl = "f4.jpg",
                    InstructorId = ibnFarooq
                },
                new Course
                {
                    Id = "f5",
                    Title = "Fiqh - Semester 2 | Shaykh Assim Al-Hakeem",
                    Description = "Explore advanced topics in Islamic law and jurisprudence.",
                    Category = CourseCategory.Fiqh,
                    Level = CourseLevel.Advanced,
                    ThumbnailUrl = "f5.jpg",
                    InstructorId = assimAlhakeem
                },
                new Course
                {
                    Id = "f6",
                    Title = "Fiqh - Semester 3 | Shaykh Assim Al-Hakeem",
                    Description = "Study the principles of Islamic law and ethics.",
                    Category = CourseCategory.Fiqh,
                    Level = CourseLevel.Advanced,
                    ThumbnailUrl = "f6.jpg",
                    InstructorId = assimAlhakeem
                },
                new Course
                {
                    Id = "f7",
                    Title = "Fiqh Reflections",
                    Description = "Study the principles of Islamic law and ethics.",
                    Category = CourseCategory.Fiqh,
                    Level = CourseLevel.Intermediate,
                    ThumbnailUrl = "f7.jpg",
                    InstructorId = aam
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
                    ThumbnailUrl = "fa1.jpg",
                    InstructorId = aam
                },
                new Course
                {
                    Id = "fa2",
                    Title = "The Six Articles of Faith in Islam",
                    Description = "Explore advanced topics in Islamic beliefs and theology.",
                    Category = CourseCategory.Faith,
                    Level = CourseLevel.Advanced,
                    ThumbnailUrl = "fa2.jpg",
                    InstructorId = aam
                },
                new Course
                {
                    Id = "fa3",
                    Title = "Islamic Faith",
                    Description = "Study the beliefs of Ahlus Sunnah wal Jama'ah.",
                    Category = CourseCategory.Faith,
                    Level = CourseLevel.Beginner,
                    ThumbnailUrl = "fa3.jpg",
                    InstructorId = assimAlhakeem
                },
                new Course
                {
                    Id = "fa4",
                    Title = "Islamic Reminders",
                    Description = "Learn the fundamentals of Islamic beliefs and Aqeedah.",
                    Category = CourseCategory.Faith,
                    Level = CourseLevel.Beginner,
                    ThumbnailUrl = "fa4.jpg",
                    InstructorId = ibnFarooq
                },
                new Course
                {
                    Id = "fa5",
                    Title = "Tarbiyah Islamiyah - Semester 1 | Zad Academy",
                    Description = "Explore advanced topics in Islamic beliefs and theology.",
                    Category = CourseCategory.Faith,
                    Level = CourseLevel.Beginner,
                    ThumbnailUrl = "fa5.jpg",
                    InstructorId = zadAcademy
                },
                new Course
                {
                    Id = "fa6",
                    Title = "Tarbiyah Islamiyah - Semester 2 | Zad Academy",
                    Description = "Study the beliefs of Ahlus Sunnah wal Jama'ah.",
                    Category = CourseCategory.Faith,
                    Level = CourseLevel.Intermediate,
                    ThumbnailUrl = "fa6.jpg",
                    InstructorId = zadAcademy
                },
                new Course
                {
                    Id = "fa7",
                    Title = "Tarbiyah Islamiyah - Semester 3 | Zad Academy",
                    Description = "Study the beliefs of Ahlus Sunnah wal Jama'ah.",
                    Category = CourseCategory.Faith,
                    Level = CourseLevel.Advanced,
                    ThumbnailUrl = "fa7.jpg",
                    InstructorId = zadAcademy
                },
                #endregion
            };

            // Add the courses to the model builder
            modelBuilder.Entity<Course>().HasData(courses);
        }
    }
}
