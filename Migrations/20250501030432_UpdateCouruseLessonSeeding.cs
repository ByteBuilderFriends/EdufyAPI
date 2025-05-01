using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AskAMuslimAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCouruseLessonSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePictureUrl", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "b4567890-12cd-5ghi-0h34-56789012def1", 0, "fixed-concurrency-stamp-9", "Instructor", "zad.academy@example.com", false, "Zad", "Academy", false, null, "ZAD.ACADEMY@EXAMPLE.COM", "ZAD.ACADEMY", "AQAAAAIAAYagAAAAEDy4zHzmVDpQm3uvHQclPBfiD/NvWb8IlA6tbjdzGp5B0V5RBoTxAjB4vKnV8qvG8w==", "0334455667", false, "", "fixed-security-stamp-9", false, "zad.academy" });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: "h1",
                column: "Description",
                value: "Welcome to the Comprehensive Hadith Course - Mishkat-ul-Masabih.");

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Category", "Description", "InstructorId", "Level", "ThumbnailUrl", "Title" },
                values: new object[,]
                {
                    { "f5", 3, "Explore advanced topics in Islamic law and jurisprudence.", "d1234567-89ab-4cde-8f01-23456789abcd", 3, "f5.jpg", "Fiqh - Semester 2 | Shaykh Assim Al-Hakeem" },
                    { "f6", 3, "Study the principles of Islamic law and ethics.", "d1234567-89ab-4cde-8f01-23456789abcd", 3, "f6.jpg", "Fiqh - Semester 3 | Shaykh Assim Al-Hakeem" },
                    { "f7", 3, "Study the principles of Islamic law and ethics.", "626b8c7f-f4d4-4467-bb37-570f1aa6fd66", 2, "f7.jpg", "Fiqh Reflections" },
                    { "h5", 2, "An in-depth study of Sahih Muslim collections.", "d1234567-89ab-4cde-8f01-23456789abcd", 1, "h5.jpg", "Characteristics of Prophet Ash Shama'il Al Muhammadiyah" },
                    { "h6", 2, "An in-depth study of Sahih Muslim collections.", "f2345678-90ab-4def-9f12-34567890bcde", 3, "h6.jpg", "Hadith - Semester 2 | Shaykh Dr. Muhammad Salah" },
                    { "h7", 2, "An in-depth study of Sahih Muslim collections.", "2c179b2d-1d3b-42a3-8d6f-d2fd86b73c29", 3, "h7.jpg", "Hadith with Mufti Menk" },
                    { "q5", 16, "Learn the fundamentals of Quranic Arabic grammar.", "626b8c7f-f4d4-4467-bb37-570f1aa6fd66", 1, "q5.jpg", "Scientific Miracles In The Quran" },
                    { "q6", 16, "Explore the linguistic miracles of the Quran.", "f2345678-90ab-4def-9f12-34567890bcde", 3, "q6.jpg", "Muhammad Salah - Tafseer Quran" },
                    { "a5", 4, "Explore advanced topics in Islamic beliefs and theology.", "b4567890-12cd-5ghi-0h34-56789012def1", 1, "a5.jpg", "Aqeedah - Semester 1 | Zad Academy" },
                    { "a6", 4, "Study the beliefs of Ahlus Sunnah wal Jama'ah.", "b4567890-12cd-5ghi-0h34-56789012def1", 2, "a6.jpg", "Aqeedah - Semester 2 | Zad Academy" },
                    { "a7", 4, "Study the beliefs of Ahlus Sunnah wal Jama'ah.", "b4567890-12cd-5ghi-0h34-56789012def1", 3, "a7.jpg", "Aqeedah - Semester 3 | Zad Academy" },
                    { "fa5", 17, "Explore advanced topics in Islamic beliefs and theology.", "b4567890-12cd-5ghi-0h34-56789012def1", 1, "fa5.jpg", "Tarbiyah Islamiyah - Semester 1 | Zad Academy" },
                    { "fa6", 17, "Study the beliefs of Ahlus Sunnah wal Jama'ah.", "b4567890-12cd-5ghi-0h34-56789012def1", 2, "fa6.jpg", "Tarbiyah Islamiyah - Semester 2 | Zad Academy" },
                    { "fa7", 17, "Study the beliefs of Ahlus Sunnah wal Jama'ah.", "b4567890-12cd-5ghi-0h34-56789012def1", 3, "fa7.jpg", "Tarbiyah Islamiyah - Semester 3 | Zad Academy" },
                    { "q7", 16, "Learn the fundamentals of Quranic Arabic grammar.", "b4567890-12cd-5ghi-0h34-56789012def1", 1, "q7.jpg", "Tafsir - Semester 1 - Zad Academy" }
                });

            migrationBuilder.InsertData(
                table: "Lessons",
                columns: new[] { "Id", "Content", "CourseId", "ExternalVideoUrl", "ThumbnailUrl", "Title", "VideoUrl" },
                values: new object[,]
                {
                    { "l1f5", "This lesson covers the importance of understanding the rules of purification.", "f5", "https://youtu.be/klqoNWM4VAY?si=ri8J8zol4qXqQbWS", "", "Fiqh - Semester 2 - Introduction | Shaykh Assim Al-Hakeem | Zad Academy English", "" },
                    { "l1f6", "This lesson emphasizes the importance of understanding the rules of fasting.", "f6", "https://youtu.be/tZWh2Kjk8w8?si=me3EoJxXSXPRAhoO", "", "Fiqh - Semester 3 - Introduction | Shaykh Assim Al-Hakeem | Zad Academy English", "" },
                    { "l1f7", "This lesson covers the importance of understanding the rules of Hajj.", "f7", "https://youtu.be/StPVvgAzm5M?si=bIIHaJKiuQc-Jn92", "", "What is the difference between clean water and cleansing water? | Fiqh Reflections", "" },
                    { "l1h5", "This lesson covers the importance of seeking knowledge with a pure intention.", "h5", "https://youtu.be/rmLwEI3Vl5Q?si=05Dp5yDxdwqduBkL", "", "Characteristics of Prophet Ash Shama'il Al Muhammadiyah VS Seerah &Benefits of learning this science", "" },
                    { "l1h6", "This lesson emphasizes the importance of seeking knowledge with humility.", "h6", "https://youtu.be/B5jp7shbu5A?si=NQaXOPD-aqLONTbG", "", "Hadith - Semester 2 - Introduction | Shaykh Dr. Muhammad Salah | Zad Academy English", "" },
                    { "l1h7", "This lesson covers the importance of seeking knowledge with sincerity.", "h7", "https://youtu.be/4-X4mF_MlDs?si=XDLI8dCwK-rQTcoG", "", "Immorality - What do you do? - Mufti Menk", "" },
                    { "l1q5", "This lesson covers the importance of understanding the meanings of the Quran.", "q5", "https://youtu.be/CBYnOQL4M9U?si=0DNylkvKZg_u2Ffr", "", "Sun's Orbit | Scientific Miracles In The Quran", "" },
                    { "l1q6", "This lesson emphasizes the importance of understanding the Quran as a guide for life.", "q6", "https://youtu.be/85fygWT-dt8?si=ddGH27LhXxlEJEMl", "", "Why is Tafsir al-Tabari not translated in English? | Dr Muhammad Salah", "" },
                    { "l2f5", "This lesson discusses the significance of understanding the rules of prayer.", "f5", "https://youtu.be/wxuWOrtPHaQ?si=CaNUCTRT4VXGSPSk", "", "Fiqh - Semester 2 - Lecture 1 | Shaykh Assim Al-Hakeem | Zad Academy English", "" },
                    { "l2f6", "This lesson discusses the significance of understanding the rules of Zakat.", "f6", "https://youtu.be/zx4Xg6DKkBQ?si=GO6XCeWC3eH8ExtR", "", "Fiqh - Semester 3 - Lecture 1 | Shaykh Assim Al-Hakeem | Zad Academy English", "" },
                    { "l2f7", "This lesson discusses the significance of understanding the rules of family matters.", "f7", "https://youtu.be/CTS6Hv9qTHw?si=nAEyQOfJ0LA0JEp6", "", "Types Of Water I Can Use To Make Wudu | Fiqh Reflections", "" },
                    { "l2h5", "This lesson discusses the significance of applying knowledge in daily life.", "h5", "https://youtu.be/5pfF2PU_7iQ?si=dmxH0161Xah_mFav", "", "How did Prophet ﷺ look like? (Part 1) Noble features of the Prophet ﷺ #islam #quran assim al hakeem", "" },
                    { "l2h6", "This lesson covers the importance of seeking knowledge with sincerity", "h6", "https://youtu.be/KXeyOFyJEm8?si=4gZXI1Dkytts9whl", "", "Hadith - Semester 2 - Lecture 1 | Shaykh Dr. Muhammad Salah | Zad Academy English.", "" },
                    { "l2h7", "This lesson discusses the significance of seeking knowledge with a pure heart.", "h7", "https://youtu.be/q6jXoxHNL6E?si=9pUx8u2cLt5xTli6", "", "What to do when you see something wrong - Mufti Menk", "" },
                    { "l2q5", "This lesson discusses the significance of applying the teachings of the Quran in daily life.", "q5", "https://youtu.be/mtDDmeWdjEY?si=l0b5c2I0FyIQWCUA", "", "Big Bang | Scientific Miracles In The Quarn", "" },
                    { "l2q6", "This lesson discusses the significance of understanding the Quran as a source of guidance.", "q6", "https://youtu.be/-6GEhL3T2cQ?si=CEEDF7rDIAPLUTfp", "", "If we stay away from major sins, will Allah grant us Paradise? | Dr Muhammad Salah", "" },
                    { "l1a5", "This lesson covers the importance of understanding the concept of Iman.", "a5", "https://youtu.be/iz2p-5Hj89E?si=i4IftM-viksIrtJJ", "", "Aqeedah - Semester 1 - Introduction | Shaykh Ahmad Al Romh | Zad Academy English", "" },
                    { "l1a6", "This lesson emphasizes the importance of understanding the concept of Nifaq.", "a6", "https://youtu.be/GY_puy17iTg?si=_1DCoM4GlVso4vfn", "", "Aqeedah - Semester 2 - Introduction | Shaykh Ibrahim Zidan | Zad Academy English", "" },
                    { "l1a7", "This lesson covers the importance of understanding the concept of Iman.", "a7", "https://youtu.be/MKGNQRdNnuU?si=vmnuIMV5sCPMbfGH", "", "Aqeedah - Semester 3 - Introduction | Shaykh Ibrahim Zidan | Zad Academy English", "" },
                    { "l1fa5", "This lesson covers the importance of understanding the concept of Tawheed.", "fa5", "https://youtu.be/hFCP7SPGsHQ?si=G9gxXRItQUX8Eom4", "", "Tarbiyah Islamiyah - Semester 1 - Introduction | Shaykh Ibrahim Zidan | Zad Academy English", "" },
                    { "l1fa6", "This lesson emphasizes the importance of understanding the concept of Iman.", "fa6", "https://youtu.be/PB3XpZde2JU?si=-MexgBEKCDZFtu7W", "", "Tarbiyah Islamiyah - Semester 2 - Introduction | Shaykh Ibrahim Zidan | Zad Academy English", "" },
                    { "l1fa7", "This lesson covers the importance of understanding the concept of Nifaq.", "fa7", "https://youtu.be/JohV6BNKrzc?si=B4wCGVYkcOd8Cac3", "", "Tarbiyah Islamiyah - Semester 3 - Introduction | Shaykh Ibrahim Zidan | Zad Academy English", "" },
                    { "l1q7", "This lesson covers the importance of understanding the Quran as a source of wisdom.", "q7", "https://youtu.be/084DT4u1CnA?si=GTnc4c7pF5-9ZCd_", "", "Tafsir - Semester 1 - Introduction | Shaykh Dr. Ahmad ibn Saifuddin | Zad Academy English", "" },
                    { "l2a5", "This lesson discusses the significance of understanding the concept of Kufr.", "a5", "https://youtu.be/fsB2W88_en0?si=8fthYQO9c4k8V4YZ", "", "Aqeedah - Semester 1 - Lecture 1 | Shaykh Ahmad Al Romh | Zad Academy English", "" },
                    { "l2a6", "This lesson discusses the significance of understanding the concept of Tawheed.", "a6", "https://youtu.be/luJZ1e46ezI?si=jsSgGBEW7T_R7l5w", "", "Aqeedah - Semester 2 - Lecture 1 | Shaykh Ahmad Al Romh | Zad Academy English", "" },
                    { "l2a7", "This lesson discusses the significance of understanding the concept of Kufr.", "a7", "https://youtu.be/NAf-tkZ3jlg?si=XAtfaY1FKuq7kgIy", "", "Aqeedah - Semester 3 - Lecture 1 | Shaykh Ibrahim Zidan | Zad Academy English", "" },
                    { "l2fa5", "This lesson discusses the significance of understanding the concept of Shirk.", "fa5", "https://youtu.be/G3TtwBDR508?si=d4x7gDw1jcmiPm45", "", "Tarbiyah Islamiyah - Semester 1 - Lecture 1 | Shaykh Ibrahim Zidan | Zad Academy English", "" },
                    { "l2fa6", "This lesson discusses the significance of understanding the concept of Kufr.", "fa6", "https://youtu.be/2apUdbF6fh4?si=77IbQwMKDKH-KBNV", "", "Tarbiyah Islamiyah - Semester 2 - Lecture 1 | Shaykh Ibrahim Zidan | Zad Academy English", "" },
                    { "l2fa7", "This lesson discusses the significance of understanding the concept of Tawheed.", "fa7", "https://youtu.be/W5R0IWE1HAY?si=TL6pScVxgSIrluh2", "", "Tarbiyah Islamiyah - Semester 3 - Lecture 1 | Shaykh Ibrahim Zidan | Zad Academy English", "" },
                    { "l2q7", "This lesson discusses the significance of understanding the Quran as a source of knowledge.", "q7", "https://youtu.be/cElkGs8Aw8k?si=39JOdVcD8MDTw7X9", "", "Tafsir - Semester 1 - Lecture 1 | Shaykh Dr. Ahmad ibn Saifuddin | Zad Academy English", "" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: "l1a5");

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: "l1a6");

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: "l1a7");

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: "l1f5");

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: "l1f6");

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: "l1f7");

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: "l1fa5");

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: "l1fa6");

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: "l1fa7");

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: "l1h5");

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: "l1h6");

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: "l1h7");

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: "l1q5");

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: "l1q6");

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: "l1q7");

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: "l2a5");

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: "l2a6");

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: "l2a7");

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: "l2f5");

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: "l2f6");

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: "l2f7");

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: "l2fa5");

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: "l2fa6");

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: "l2fa7");

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: "l2h5");

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: "l2h6");

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: "l2h7");

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: "l2q5");

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: "l2q6");

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: "l2q7");

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: "a5");

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: "a6");

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: "a7");

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: "f5");

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: "f6");

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: "f7");

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: "fa5");

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: "fa6");

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: "fa7");

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: "h5");

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: "h6");

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: "h7");

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: "q5");

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: "q6");

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: "q7");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b4567890-12cd-5ghi-0h34-56789012def1");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: "h1",
                column: "Description",
                value: "Welcome to the **Comprehensive Hadith Course - Mishkat-ul-Masabih**...");
        }
    }
}
