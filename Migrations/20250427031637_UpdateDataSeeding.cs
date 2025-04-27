using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AskAMuslimAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDataSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: "a1",
                column: "ThumbnailUrl",
                value: "https://ask-a-muslim.runasp.net/uploads/course-thumbnails/a1.jpg");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: "a2",
                column: "ThumbnailUrl",
                value: "https://ask-a-muslim.runasp.net/uploads/course-thumbnails/a2.jpg");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: "a3",
                column: "ThumbnailUrl",
                value: "https://ask-a-muslim.runasp.net/uploads/course-thumbnails/a3.jpg");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: "a4",
                column: "ThumbnailUrl",
                value: "https://ask-a-muslim.runasp.net/uploads/course-thumbnails/a4.jpg");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: "f1",
                column: "ThumbnailUrl",
                value: "https://ask-a-muslim.runasp.net/uploads/course-thumbnails/f1.jpg");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: "f2",
                column: "ThumbnailUrl",
                value: "https://ask-a-muslim.runasp.net/uploads/course-thumbnails/f2.jpg");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: "f3",
                column: "ThumbnailUrl",
                value: "https://ask-a-muslim.runasp.net/uploads/course-thumbnails/f3.jpg");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: "f4",
                column: "ThumbnailUrl",
                value: "https://ask-a-muslim.runasp.net/uploads/course-thumbnails/f4.jpg");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: "fa1",
                column: "ThumbnailUrl",
                value: "https://ask-a-muslim.runasp.net/uploads/course-thumbnails/fa1.jpg");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: "fa2",
                column: "ThumbnailUrl",
                value: "https://ask-a-muslim.runasp.net/uploads/course-thumbnails/fa2.jpg");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: "fa3",
                column: "ThumbnailUrl",
                value: "https://ask-a-muslim.runasp.net/uploads/course-thumbnails/fa3.jpg");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: "fa4",
                column: "ThumbnailUrl",
                value: "https://ask-a-muslim.runasp.net/uploads/course-thumbnails/fa4.jpg");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: "h1",
                columns: new[] { "Description", "ThumbnailUrl" },
                values: new object[] { "Welcome to the **Comprehensive Hadith Course - Mishkat-ul-Masabih**...", "https://ask-a-muslim.runasp.net/uploads/course-thumbnails/h1.jpg" });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: "h2",
                columns: new[] { "Description", "ThumbnailUrl" },
                values: new object[] { "The Free Advanced Diploma Course in Quran and Hadith...", "https://ask-a-muslim.runasp.net/uploads/course-thumbnails/h2.jpg" });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: "h3",
                column: "ThumbnailUrl",
                value: "https://ask-a-muslim.runasp.net/uploads/course-thumbnails/h3.jpg");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: "h4",
                column: "ThumbnailUrl",
                value: "https://ask-a-muslim.runasp.net/uploads/course-thumbnails/h4.jpg");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: "q1",
                column: "ThumbnailUrl",
                value: "https://ask-a-muslim.runasp.net/uploads/course-thumbnails/q1.jpg");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: "q2",
                column: "ThumbnailUrl",
                value: "https://ask-a-muslim.runasp.net/uploads/course-thumbnails/q2.jpg");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: "q3",
                column: "ThumbnailUrl",
                value: "https://ask-a-muslim.runasp.net/uploads/course-thumbnails/q3.jpg");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: "q4",
                column: "ThumbnailUrl",
                value: "https://ask-a-muslim.runasp.net/uploads/course-thumbnails/q4.jpg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: "a1",
                column: "ThumbnailUrl",
                value: "aqeedah_basics_thumbnail.jpg");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: "a2",
                column: "ThumbnailUrl",
                value: "advanced_aqeedah_thumbnail.jpg");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: "a3",
                column: "ThumbnailUrl",
                value: "ahlus_sunnah_thumbnail.jpg");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: "a4",
                column: "ThumbnailUrl",
                value: "aqeedah_basics_thumbnail.jpg");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: "f1",
                column: "ThumbnailUrl",
                value: "fiqh_basics_thumbnail.jpg");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: "f2",
                column: "ThumbnailUrl",
                value: "advanced_fiqh_thumbnail.jpg");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: "f3",
                column: "ThumbnailUrl",
                value: "fiqh_ethics_thumbnail.jpg");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: "f4",
                column: "ThumbnailUrl",
                value: "fiqh_basics_thumbnail.jpg");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: "fa1",
                column: "ThumbnailUrl",
                value: "faith_basics_thumbnail.jpg");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: "fa2",
                column: "ThumbnailUrl",
                value: "advanced_faith_thumbnail.jpg");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: "fa3",
                column: "ThumbnailUrl",
                value: "ahlus_sunnah_thumbnail.jpg");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: "fa4",
                column: "ThumbnailUrl",
                value: "faith_basics_thumbnail.jpg");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: "h1",
                columns: new[] { "Description", "ThumbnailUrl" },
                values: new object[] { "Welcome to the **Comprehensive Hadith Course - Mishkat-ul-Masabih**. This playlist provides a thorough exploration of Hadith from the Mishkat-ul-Masabih collection. Each lesson offers detailed explanations and context for the sayings of the Prophet Muhammad (peace be upon him), aiming to enhance your understanding of these important teachings. Covering a broad range of topics, the course is structured to guide you through the Hadith in a systematic way, suitable for learners at various levels. The content includes scholarly insights and reflections to help you connect with and apply the Prophet’s teachings in everyday life. We invite you to join us in this study to deepen your knowledge and practice of Islam.\r\n", "hadith_intro_thumbnail.jpg" });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: "h2",
                columns: new[] { "Description", "ThumbnailUrl" },
                values: new object[] { "The Free Advanced Diploma Course in Quran and Hadith will in-sha-Allah benefit both Muslims who aspire to study the Quran and Hadith in depth, and scholars seeking to revise key aspects of the Aalim course (Dars-i Nizami). It follows mainstream Islamic teachings, avoiding promotion of any modern sect, and aims to educate based on earlier Islamic scholars' teachings. The course focuses on Tafseer and Hadees, with Tafseer explanations referencing renowned scholars like Tabari, Bawdawi, Ibn Kaseer, Qurtabi, and Razi. The explanations of Hadith will follow the interpretations provided by Hadith scholars, with particular emphasis on the authentication of the Ahadith. When Fiqh matters arise, perspectives from the main Sunni schools—Hanafi, Maliki, Shafie, and Hanbali—are usually provided.", "hadith_manners_thumbnail.jpg" });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: "h3",
                column: "ThumbnailUrl",
                value: "sahih_bukhari_thumbnail.jpg");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: "h4",
                column: "ThumbnailUrl",
                value: "authentic_hadith_thumbnail.jpg");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: "q1",
                column: "ThumbnailUrl",
                value: "quran_memorization_thumbnail.jpg");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: "q2",
                column: "ThumbnailUrl",
                value: "tajweed_thumbnail.jpg");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: "q3",
                column: "ThumbnailUrl",
                value: "quran_recitation_thumbnail.jpg");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: "q4",
                column: "ThumbnailUrl",
                value: "advanced_quran_studies_thumbnail.jpg");
        }
    }
}
