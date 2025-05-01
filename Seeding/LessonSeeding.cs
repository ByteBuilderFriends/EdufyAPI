using EdufyAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EdufyAPI.RoleSeeding
{
    public class LessonSeeding
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            // Course ids
            var q1 = "q1";
            var q2 = "q2";
            var q3 = "q3";
            var q4 = "q4";
            var q5 = "q5";
            var q6 = "q6";
            var q7 = "q7";

            var h1 = "h1";
            var h2 = "h2";
            var h3 = "h3";
            var h4 = "h4";
            var h5 = "h5";
            var h6 = "h6";
            var h7 = "h7";

            var a1 = "a1";
            var a2 = "a2";
            var a3 = "a3";
            var a4 = "a4";
            var a5 = "a5";
            var a6 = "a6";
            var a7 = "a7";

            var f1 = "f1";
            var f2 = "f2";
            var f3 = "f3";
            var f4 = "f4";
            var f5 = "f5";
            var f6 = "f6";
            var f7 = "f7";

            var fa1 = "fa1";
            var fa2 = "fa2";
            var fa3 = "fa3";
            var fa4 = "fa4";
            var fa5 = "fa5";
            var fa6 = "fa6";
            var fa7 = "fa7";


            modelBuilder.Entity<Lesson>().HasData(
            #region Quran Lessons
                 new Lesson
                 {
                     Id = "l1q1",
                     CourseId = q1,
                     Title = "Quran Tafseer 1?",
                     Content = "This lesson discusses the virtues of memorizing the Quran and how it strengthens one’s connection with Allah.",
                     ExternalVideoUrl = "https://youtu.be/2qds-xNU4Xc?si=JOYbgc9mNGNWAosV"
                 },
                new Lesson
                {
                    Id = "l2q1",
                    CourseId = q1,
                    Title = "Quran Tafseer 2",
                    Content = "This lesson provides practical tips and techniques for starting the memorization journey.",
                    ExternalVideoUrl = "https://youtu.be/jRYb9NfNDZA?si=B3jkn9O3J6yZ9iN7"
                },
                new Lesson
                {
                    Id = "l1q2",
                    CourseId = q2,
                    Title = "Principles of Tafseer - 1",
                    Content = "This lesson emphasizes the importance of consistency and setting realistic goals.",
                    ExternalVideoUrl = "https://youtu.be/d6hLVtnDSWQ?si=M2HFkEO5_XDg65GY"
                },
                new Lesson
                {
                    Id = "l2q2",
                    CourseId = q2,
                    Title = "Principles of Tafseer - 2",
                    Content = "This lesson discusses the significance of understanding the context and background of the verses.",
                    ExternalVideoUrl = "https://youtu.be/FY7yZhNw-XA?si=K7SElOuXowXvAmus"
                },
                new Lesson
                {
                    Id = "l1q3",
                    CourseId = q3,
                    Title = "TAFSEER OF QUR'AN Ep 02 Sheikh Assim Al Hakeem",
                    Content = "This lesson covers the importance of seeking knowledge from reliable sources.",
                    ExternalVideoUrl = "https://youtu.be/-qQNhf8tank?si=OKHub6BfIC0OVV2z"
                },
                new Lesson
                {
                    Id = "l2q3",
                    CourseId = q3,
                    Title = "TAFSEER OF QUR'AN Ep 03 Surah Naba 1 4 Sheikh Assim Al Hakeem",
                    Content = "This lesson discusses the significance of understanding the Arabic language.",
                    ExternalVideoUrl = "https://youtu.be/1qh0G5uFVlw?si=4i_Y7J53XBOpyBVC"
                },
                new Lesson
                {
                    Id = "l1q4",
                    CourseId = q4,
                    Title = "Mufti Menk - Quran Tafseer Day1",
                    Content = "This lesson emphasizes the importance of reflecting on the meanings of the verses.",
                    ExternalVideoUrl = "https://youtu.be/ZN9lzkWGA_E?si=KstXa-RsPxGSFgUZ"
                },
                new Lesson
                {
                    Id = "l2q4",
                    CourseId = q4,
                    Title = "Mufti Menk - Quran Tafseer Day2",
                    Content = "This lesson discusses the significance of memorizing and reciting the Quran regularly.",
                    ExternalVideoUrl = "https://youtu.be/2XMyXyLs1fc?si=wAAyLxgvWZtKqsQk"
                },
                new Lesson
                {
                    Id = "l1q5",
                    CourseId = q5,
                    Title = "Sun's Orbit | Scientific Miracles In The Quran",
                    Content = "This lesson covers the importance of understanding the meanings of the Quran.",
                    ExternalVideoUrl = "https://youtu.be/CBYnOQL4M9U?si=0DNylkvKZg_u2Ffr"
                },
                new Lesson
                {
                    Id = "l2q5",
                    CourseId = q5,
                    Title = "Big Bang | Scientific Miracles In The Quarn",
                    Content = "This lesson discusses the significance of applying the teachings of the Quran in daily life.",
                    ExternalVideoUrl = "https://youtu.be/mtDDmeWdjEY?si=l0b5c2I0FyIQWCUA"
                },
                new Lesson
                {
                    Id = "l1q6",
                    CourseId = q6,
                    Title = "Why is Tafsir al-Tabari not translated in English? | Dr Muhammad Salah",
                    Content = "This lesson emphasizes the importance of understanding the Quran as a guide for life.",
                    ExternalVideoUrl = "https://youtu.be/85fygWT-dt8?si=ddGH27LhXxlEJEMl"
                },
                new Lesson
                {
                    Id = "l2q6",
                    CourseId = q6,
                    Title = "If we stay away from major sins, will Allah grant us Paradise? | Dr Muhammad Salah",
                    Content = "This lesson discusses the significance of understanding the Quran as a source of guidance.",
                    ExternalVideoUrl = "https://youtu.be/-6GEhL3T2cQ?si=CEEDF7rDIAPLUTfp"
                },
                new Lesson
                {
                    Id = "l1q7",
                    CourseId = q7,
                    Title = "Tafsir - Semester 1 - Introduction | Shaykh Dr. Ahmad ibn Saifuddin | Zad Academy English",
                    Content = "This lesson covers the importance of understanding the Quran as a source of wisdom.",
                    ExternalVideoUrl = "https://youtu.be/084DT4u1CnA?si=GTnc4c7pF5-9ZCd_"
                },
                new Lesson
                {
                    Id = "l2q7",
                    CourseId = q7,
                    Title = "Tafsir - Semester 1 - Lecture 1 | Shaykh Dr. Ahmad ibn Saifuddin | Zad Academy English",
                    Content = "This lesson discusses the significance of understanding the Quran as a source of knowledge.",
                    ExternalVideoUrl = "https://youtu.be/cElkGs8Aw8k?si=39JOdVcD8MDTw7X9"
                },
            #endregion

            #region Hadith Lessons
                new Lesson
                {
                    Id = "l1h1",
                    CourseId = h1,
                    Title = "Principles of Hadith - 1",
                    Content = "This lesson covers the importance of seeking knowledge and its impact on personal growth.",
                    ExternalVideoUrl = "https://youtu.be/ZrrVbZhTqXk?si=4aoP0Y9tBPNfik8g"
                },
                new Lesson
                {
                    Id = "l2h1",
                    CourseId = h1,
                    Title = "Principles of Hadith - 2",
                    Content = "This lesson discusses the significance of sincerity in seeking knowledge.",
                    ExternalVideoUrl = "https://youtu.be/iQxLrk9y2pU?si=Kxi-qEFzjvvbZWCR"
                },
                new Lesson
                {
                    Id = "l1h2",
                    CourseId = h2,
                    Title = "Hadith 1",
                    Content = "This lesson emphasizes the importance of acting upon knowledge.",
                    ExternalVideoUrl = "https://youtu.be/x82aep1XRvw?si=nk5JJtk7I7K-o36t"
                },
                new Lesson
                {
                    Id = "l2h2",
                    CourseId = h2,
                    Title = "Hadith 2",
                    Content = "This lesson discusses the significance of sharing knowledge with others.",
                    ExternalVideoUrl = "https://youtu.be/w6ps627J2SA?si=tIMVfO7eaICOb7aB"
                },
                new Lesson
                {
                    Id = "l1h3",
                    CourseId = h3,
                    Title = "Hadith - Semester 1 - Introduction",
                    Content = "This lesson covers the importance of humility in seeking knowledge.",
                    ExternalVideoUrl = "https://youtu.be/mWbG69wdO-Q?si=fXwrVbVi92JOdTHU"
                },
                new Lesson
                {
                    Id = "l2h3",
                    CourseId = h3,
                    Title = "Hadith - Semester 1 - Lecture 1 | Shaykh Dr. Muhammad Salah",
                    Content = "This lesson discusses the significance of patience in the pursuit of knowledge.",
                    ExternalVideoUrl = "https://youtu.be/pJgBEUO_cu0?si=gKdL_UgVbzvt9TIN"
                },
                new Lesson
                {
                    Id = "l1h4",
                    CourseId = h4,
                    Title = "01-Explanation of the first hadith of intention for Ibn Uthaymeen",
                    Content = "This lesson emphasizes the importance of gratitude in seeking knowledge.",
                    ExternalVideoUrl = "https://youtu.be/rcsJ_RorUSs?si=CxqJPcqTNR198eIm"
                },
                new Lesson
                {
                    Id = "l2h4",
                    CourseId = h4,
                    Title = "03-Explanation of the third Hadith ''Islam is built upon five'' by Ibn Uthaymeen",
                    Content = "This lesson discusses the significance of perseverance in the face of challenges.",
                    ExternalVideoUrl = "https://youtu.be/yB0IK5iF5sI?si=9BPv146lsh6p-uLF"
                },
                new Lesson
                {
                    Id = "l1h5",
                    CourseId = h5,
                    Title = "Characteristics of Prophet Ash Shama'il Al Muhammadiyah VS Seerah &Benefits of learning this science",
                    Content = "This lesson covers the importance of seeking knowledge with a pure intention.",
                    ExternalVideoUrl = "https://youtu.be/rmLwEI3Vl5Q?si=05Dp5yDxdwqduBkL"
                },
                new Lesson
                {
                    Id = "l2h5",
                    CourseId = h5,
                    Title = "How did Prophet ﷺ look like? (Part 1) Noble features of the Prophet ﷺ #islam #quran assim al hakeem",
                    Content = "This lesson discusses the significance of applying knowledge in daily life.",
                    ExternalVideoUrl = "https://youtu.be/5pfF2PU_7iQ?si=dmxH0161Xah_mFav"
                },
                new Lesson
                {
                    Id = "l1h6",
                    CourseId = h6,
                    Title = "Hadith - Semester 2 - Introduction | Shaykh Dr. Muhammad Salah | Zad Academy English",
                    Content = "This lesson emphasizes the importance of seeking knowledge with humility.",
                    ExternalVideoUrl = "https://youtu.be/B5jp7shbu5A?si=NQaXOPD-aqLONTbG"
                },
                new Lesson
                {
                    Id = "l2h6",
                    CourseId = h6,
                    Title = "Hadith - Semester 2 - Lecture 1 | Shaykh Dr. Muhammad Salah | Zad Academy English.",
                    Content = "This lesson covers the importance of seeking knowledge with sincerity",
                    ExternalVideoUrl = "https://youtu.be/KXeyOFyJEm8?si=4gZXI1Dkytts9whl"
                },

                new Lesson
                {
                    Id = "l1h7",
                    CourseId = h7,
                    Title = "Immorality - What do you do? - Mufti Menk",
                    Content = "This lesson covers the importance of seeking knowledge with sincerity.",
                    ExternalVideoUrl = "https://youtu.be/4-X4mF_MlDs?si=XDLI8dCwK-rQTcoG"
                },
                new Lesson
                {
                    Id = "l2h7",
                    CourseId = h7,
                    Title = "What to do when you see something wrong - Mufti Menk",
                    Content = "This lesson discusses the significance of seeking knowledge with a pure heart.",
                    ExternalVideoUrl = "https://youtu.be/q6jXoxHNL6E?si=9pUx8u2cLt5xTli6"
                },
            #endregion

            #region Aqeedah Lessons
                new Lesson
                {
                    Id = "l1a1",
                    CourseId = a1,
                    Title = "Principles of Belief: The Basis of rationale and proof",
                    Content = "This lesson covers the importance of understanding the fundamentals of Aqeedah.",
                    ExternalVideoUrl = "https://youtu.be/mKF693FWc6A?si=IUg8K_Hcn82pCy1E"
                },
                new Lesson
                {
                    Id = "l2a1",
                    CourseId = a1,
                    Title = "Principles of Belief: MENTAL EVIDENCE IN ISLAM",
                    Content = "This lesson discusses the significance of Tawheed and its implications in daily life.",
                    ExternalVideoUrl = "https://youtu.be/urwR3bgRqB0?si=tUvMXeyr5WLdSXyG"
                },
                new Lesson
                {
                    Id = "l1a2",
                    CourseId = a2,
                    Title = "02 - Seeking a cure using specific Names of Allaah to treat a particular illness - Shaikh Uthaymeen",
                    Content = "This lesson emphasizes the importance of understanding the attributes of Allah.",
                    ExternalVideoUrl = "https://youtu.be/Ioy35ni7NXs?si=k6vVjInPQ6pkr1Rq"
                },
                new Lesson
                {
                    Id = "l2a2",
                    CourseId = a2,
                    Title = "03 - What does Al-‘Uboodiyyah (servitude: Oneness of Allah in worship) comprise of? Sh. Al-Uthaymeen\r\n",
                    Content = "This lesson discusses the significance of belief in the Prophets and Messengers.",
                    ExternalVideoUrl = "https://youtu.be/wmnK6ZnXj7I?si=ugldutKHd0S1_Emf"
                },
                new Lesson
                {
                    Id = "l1a3",
                    CourseId = a3,
                    Title = "1 Explanation of the Islāmic Belief : Introduction",
                    Content = "This lesson covers the importance of understanding the Day of Judgment.",
                    ExternalVideoUrl = "https://youtu.be/5bdrB9Gu_Y0?si=KVtWr4RArQJa6J_P"
                },
                new Lesson
                {
                    Id = "l2a3",
                    CourseId = a3,
                    Title = "2 Explanation of the Islāmic Belief:Praise of Allah",
                    Content = "This lesson discusses the significance of belief in Angels.",
                    ExternalVideoUrl = "https://youtu.be/5fCEQBaHI28?si=Mi1VYzS8gq9ccNqx"
                },
                new Lesson
                {
                    Id = "l1a4",
                    CourseId = a4,
                    Title = "The three Fundamental Principles (Thalaathat-ul-usool) Part 1 - Assim al hakeem",
                    Content = "This lesson emphasizes the importance of understanding the concept of Shirk.",
                    ExternalVideoUrl = "https://youtu.be/2R0lqMBWzGE?si=EOCu9y3MtHRTbbys"
                },
                new Lesson
                {
                    Id = "l2a4",
                    CourseId = a4,
                    Title = "The three Fundamental Principles (Thalaathat-ul-usool) Part 2 - Assim al hakeem",
                    Content = "This lesson discusses the significance of belief in Divine Decree.",
                    ExternalVideoUrl = "https://youtu.be/1Rj5EtLGnKU?si=q595x4yKEz0sIMVj"
                },
                new Lesson
                {
                    Id = "l1a5",
                    CourseId = a5,
                    Title = "Aqeedah - Semester 1 - Introduction | Shaykh Ahmad Al Romh | Zad Academy English",
                    Content = "This lesson covers the importance of understanding the concept of Iman.",
                    ExternalVideoUrl = "https://youtu.be/iz2p-5Hj89E?si=i4IftM-viksIrtJJ"
                },
                new Lesson
                {
                    Id = "l2a5",
                    CourseId = a5,
                    Title = "Aqeedah - Semester 1 - Lecture 1 | Shaykh Ahmad Al Romh | Zad Academy English",
                    Content = "This lesson discusses the significance of understanding the concept of Kufr.",
                    ExternalVideoUrl = "https://youtu.be/fsB2W88_en0?si=8fthYQO9c4k8V4YZ"
                },
                new Lesson
                {
                    Id = "l1a6",
                    CourseId = a6,
                    Title = "Aqeedah - Semester 2 - Introduction | Shaykh Ibrahim Zidan | Zad Academy English",
                    Content = "This lesson emphasizes the importance of understanding the concept of Nifaq.",
                    ExternalVideoUrl = "https://youtu.be/GY_puy17iTg?si=_1DCoM4GlVso4vfn"
                },
                new Lesson
                {
                    Id = "l2a6",
                    CourseId = a6,
                    Title = "Aqeedah - Semester 2 - Lecture 1 | Shaykh Ahmad Al Romh | Zad Academy English",
                    Content = "This lesson discusses the significance of understanding the concept of Tawheed.",
                    ExternalVideoUrl = "https://youtu.be/luJZ1e46ezI?si=jsSgGBEW7T_R7l5w"
                },
                new Lesson
                {
                    Id = "l1a7",
                    CourseId = a7,
                    Title = "Aqeedah - Semester 3 - Introduction | Shaykh Ibrahim Zidan | Zad Academy English",
                    Content = "This lesson covers the importance of understanding the concept of Iman.",
                    ExternalVideoUrl = "https://youtu.be/MKGNQRdNnuU?si=vmnuIMV5sCPMbfGH"
                },
                new Lesson
                {
                    Id = "l2a7",
                    CourseId = a7,
                    Title = "Aqeedah - Semester 3 - Lecture 1 | Shaykh Ibrahim Zidan | Zad Academy English",
                    Content = "This lesson discusses the significance of understanding the concept of Kufr.",
                    ExternalVideoUrl = "https://youtu.be/NAf-tkZ3jlg?si=XAtfaY1FKuq7kgIy"
                },
            #endregion

            #region Fiqh Lessons
                new Lesson
                {
                    Id = "l1f1",
                    CourseId = f1,
                    Title = "What Is Fasting? | Fiqh Of Ramadan",
                    Content = "This lesson covers the importance of understanding the rules of prayer.",
                    ExternalVideoUrl = "https://youtu.be/TRq7E0gCe_w?si=AyJJpa4xsNBfuY65"
                },
                new Lesson
                {
                    Id = "l2f1",
                    CourseId = f1,
                    Title = "Do I Have to Make the Intention to Fast? | Fiqh of Ramadan",
                    Content = "This lesson discusses the significance of understanding the rules of fasting.",
                    ExternalVideoUrl = "https://youtu.be/aDK3sTkrOZE?si=sfQgMyI1tJWYZe3h"
                },
                new Lesson
                {
                    Id = "l1f2",
                    CourseId = f2,
                    Title = "Fiqh - Semester 1 - Introduction",
                    Content = "This lesson emphasizes the importance of understanding the rules of Zakat.",
                    ExternalVideoUrl = "https://youtu.be/V0tOuxRXgW8?si=KI0a2sRjiOdmWtJq"
                },
                new Lesson
                {
                    Id = "l2f2",
                    CourseId = f2,
                    Title = "Fiqh - Semester 1 - Lecture 1",
                    Content = "This lesson discusses the significance of understanding the rules of Hajj.",
                    ExternalVideoUrl = "https://youtu.be/Zxl94-DFGx4?si=Zd31VXLlRis6eMWF"
                },
                new Lesson
                {
                    Id = "l1f3",
                    CourseId = f3,
                    Title = "Islamic Fiqh 13 - Assim al hakeem",
                    Content = "This lesson covers the importance of understanding the rules of transactions.",
                    ExternalVideoUrl = "https://www.youtube.com/live/SNaabBT5hTw?si=Wi5SRFQdZHd7PF4f"
                },
                new Lesson
                {
                    Id = "l2f3",
                    CourseId = f3,
                    Title = "Islamic Fiqh 14 - Assim al hakeem",
                    Content = "This lesson discusses the significance of understanding the rules of contracts.",
                    ExternalVideoUrl = "https://www.youtube.com/live/opr8cfX6lSM?si=OdbdSheKXTXfi_qp"
                },
                new Lesson
                {
                    Id = "l1f4",
                    CourseId = f4,
                    Title = "Sharh 'Umdah al-Fiqh 1 [Introduction-Ibn Qudamah]",
                    Content = "This lesson emphasizes the importance of understanding the rules of family matters.",
                    ExternalVideoUrl = "https://youtu.be/2DVTYk1jVE4?si=wv0RdDQM0Sjtz8N_"
                },
                new Lesson
                {
                    Id = "l2f4",
                    CourseId = f4,
                    Title = "Sharh 'Umdah al-Fiqh 2",
                    Content = "This lesson discusses the significance of understanding the rules of inheritance.",
                    ExternalVideoUrl = "https://youtu.be/PJrknK2MZck?si=EF4dkX9mXtJefR4w"
                },
                new Lesson
                {
                    Id = "l1f5",
                    CourseId = f5,
                    Title = "Fiqh - Semester 2 - Introduction | Shaykh Assim Al-Hakeem | Zad Academy English",
                    Content = "This lesson covers the importance of understanding the rules of purification.",
                    ExternalVideoUrl = "https://youtu.be/klqoNWM4VAY?si=ri8J8zol4qXqQbWS"
                },
                new Lesson
                {
                    Id = "l2f5",
                    CourseId = f5,
                    Title = "Fiqh - Semester 2 - Lecture 1 | Shaykh Assim Al-Hakeem | Zad Academy English",
                    Content = "This lesson discusses the significance of understanding the rules of prayer.",
                    ExternalVideoUrl = "https://youtu.be/wxuWOrtPHaQ?si=CaNUCTRT4VXGSPSk"
                },
                new Lesson
                {
                    Id = "l1f6",
                    CourseId = f6,
                    Title = "Fiqh - Semester 3 - Introduction | Shaykh Assim Al-Hakeem | Zad Academy English",
                    Content = "This lesson emphasizes the importance of understanding the rules of fasting.",
                    ExternalVideoUrl = "https://youtu.be/tZWh2Kjk8w8?si=me3EoJxXSXPRAhoO"
                },
                new Lesson
                {
                    Id = "l2f6",
                    CourseId = f6,
                    Title = "Fiqh - Semester 3 - Lecture 1 | Shaykh Assim Al-Hakeem | Zad Academy English",
                    Content = "This lesson discusses the significance of understanding the rules of Zakat.",
                    ExternalVideoUrl = "https://youtu.be/zx4Xg6DKkBQ?si=GO6XCeWC3eH8ExtR"
                },
                new Lesson
                {
                    Id = "l1f7",
                    CourseId = f7,
                    Title = "What is the difference between clean water and cleansing water? | Fiqh Reflections",
                    Content = "This lesson covers the importance of understanding the rules of Hajj.",
                    ExternalVideoUrl = "https://youtu.be/StPVvgAzm5M?si=bIIHaJKiuQc-Jn92"
                },
                new Lesson
                {
                    Id = "l2f7",
                    CourseId = f7,
                    Title = "Types Of Water I Can Use To Make Wudu | Fiqh Reflections",
                    Content = "This lesson discusses the significance of understanding the rules of family matters.",
                    ExternalVideoUrl = "https://youtu.be/CTS6Hv9qTHw?si=nAEyQOfJ0LA0JEp6"
                },
            #endregion

            #region Faith
                new Lesson
                {
                    Id = "l1fa1",
                    CourseId = fa1,
                    Title = "Faith Part 1",
                    Content = "This lesson covers the importance of understanding the concept of faith.",
                    ExternalVideoUrl = "https://youtu.be/pyUySSuyHNw?si=wKhwmoS9s5HidZyy"
                },
                new Lesson
                {
                    Id = "l2fa1",
                    CourseId = fa1,
                    Title = "Faith Part 2",
                    Content = "This lesson discusses the significance of understanding the pillars of faith.",
                    ExternalVideoUrl = "https://youtu.be/rLgfs2eBu3Y?si=Kpko5UiGDAIR9vZq"
                },
                new Lesson
                {
                    Id = "l1fa2",
                    CourseId = fa2,
                    Title = "What Are the Six Articles of Faith in Islam? | Pillars of Iman",
                    Content = "This lesson emphasizes the importance of understanding the concept of Tawheed.",
                    ExternalVideoUrl = "https://youtu.be/foNaMDvYLPo?si=bkTPg4JXrV5_vsHp"
                },
                new Lesson
                {
                    Id = "l2fa2",
                    CourseId = fa2,
                    Title = "The Oneness of Allah in Islam: Tawheed and Monotheism",
                    Content = "This lesson discusses the significance of understanding the concept of Shirk.",
                    ExternalVideoUrl = "https://youtu.be/eKnIJqe8gc8?si=c6BpfWHl_Uv2g_K4"
                },
                new Lesson
                {
                    Id = "l1fa3",
                    CourseId = fa3,
                    Title = "The Islamic faith # 1",
                    Content = "This lesson covers the importance of understanding the concept of Iman.",
                    ExternalVideoUrl = "https://youtu.be/VlQKUOIB8fM?si=QGIqI2wlEpALJd85"
                },
                new Lesson
                {
                    Id = "l2fa3",
                    CourseId = fa3,
                    Title = "The Islamic Faith # 2",
                    Content = "This lesson discusses the significance of understanding the concept of Kufr.",
                    ExternalVideoUrl = "https://youtu.be/GKY3ycmTXZA?si=RQYWL0BpGa8WbOWN"
                },
                new Lesson
                {
                    Id = "l1fa4",
                    CourseId = fa4,
                    Title = "THIS SHOULD MAKE YOU CRY | Islamic Reminder",
                    Content = "This lesson emphasizes the importance of understanding the concept of Nifaq.",
                    ExternalVideoUrl = "https://youtu.be/Z76LIk2fr6U?si=RsmZtJ0pSOn6fhR_"
                },
                new Lesson
                {
                    Id = "l2fa4",
                    CourseId = fa4,
                    Title = "Message to those who sell out their Deen",
                    Content = "This lesson discusses the significance of understanding the concept of Iman.",
                    ExternalVideoUrl = "https://youtu.be/uioedvBAZb4?si=CjnPuUvnVSyJ1X41"
                },
                new Lesson
                {
                    Id = "l1fa5",
                    CourseId = fa5,
                    Title = "Tarbiyah Islamiyah - Semester 1 - Introduction | Shaykh Ibrahim Zidan | Zad Academy English",
                    Content = "This lesson covers the importance of understanding the concept of Tawheed.",
                    ExternalVideoUrl = "https://youtu.be/hFCP7SPGsHQ?si=G9gxXRItQUX8Eom4"
                },
                new Lesson
                {
                    Id = "l2fa5",
                    CourseId = fa5,
                    Title = "Tarbiyah Islamiyah - Semester 1 - Lecture 1 | Shaykh Ibrahim Zidan | Zad Academy English",
                    Content = "This lesson discusses the significance of understanding the concept of Shirk.",
                    ExternalVideoUrl = "https://youtu.be/G3TtwBDR508?si=d4x7gDw1jcmiPm45"
                },
                new Lesson
                {
                    Id = "l1fa6",
                    CourseId = fa6,
                    Title = "Tarbiyah Islamiyah - Semester 2 - Introduction | Shaykh Ibrahim Zidan | Zad Academy English",
                    Content = "This lesson emphasizes the importance of understanding the concept of Iman.",
                    ExternalVideoUrl = "https://youtu.be/PB3XpZde2JU?si=-MexgBEKCDZFtu7W"
                },
                new Lesson
                {
                    Id = "l2fa6",
                    CourseId = fa6,
                    Title = "Tarbiyah Islamiyah - Semester 2 - Lecture 1 | Shaykh Ibrahim Zidan | Zad Academy English",
                    Content = "This lesson discusses the significance of understanding the concept of Kufr.",
                    ExternalVideoUrl = "https://youtu.be/2apUdbF6fh4?si=77IbQwMKDKH-KBNV"
                },
                new Lesson
                {
                    Id = "l1fa7",
                    CourseId = fa7,
                    Title = "Tarbiyah Islamiyah - Semester 3 - Introduction | Shaykh Ibrahim Zidan | Zad Academy English",
                    Content = "This lesson covers the importance of understanding the concept of Nifaq.",
                    ExternalVideoUrl = "https://youtu.be/JohV6BNKrzc?si=B4wCGVYkcOd8Cac3"
                },
                new Lesson
                {
                    Id = "l2fa7",
                    CourseId = fa7,
                    Title = "Tarbiyah Islamiyah - Semester 3 - Lecture 1 | Shaykh Ibrahim Zidan | Zad Academy English",
                    Content = "This lesson discusses the significance of understanding the concept of Tawheed.",
                    ExternalVideoUrl = "https://youtu.be/W5R0IWE1HAY?si=TL6pScVxgSIrluh2"
                }
                #endregion
            );
        }
    }
}
