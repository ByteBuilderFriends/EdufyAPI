using System.ComponentModel.DataAnnotations;

namespace AskAMuslimAPI.Enums
{
    public enum CourseCategory
    {
        [Display(Name = "Quran Interpretation (Tafseer)")]
        Tafseer = 1,

        [Display(Name = "Sayings of the Prophet (Hadith)")]
        Hadith = 2,

        [Display(Name = "Islamic Law (Fiqh)")]
        Fiqh = 3,

        [Display(Name = "Islamic Beliefs (Aqeedah)")]
        Aqeeda = 4,

        [Display(Name = "Life of the Prophet (Seerah)")]
        Seerah = 5,

        [Display(Name = "Quran Memorization")]
        QuranMemorization = 6,

        [Display(Name = "Arabic for Beginners")]
        ArabicLanguage = 7,

        [Display(Name = "Islamic Manners & Etiquette")]
        MannersAndEtiquette = 8,

        [Display(Name = "Islamic Law (Advanced)")]
        IslamicJurisprudence = 9,

        [Display(Name = "Essentials for New Muslims")]
        NewMuslimEssentials = 10,

        [Display(Name = "Daily Duas & Supplications")]
        DuasAndSupplications = 11,

        [Display(Name = "Islamic Ethics")]
        IslamicEthics = 12,

        [Display(Name = "Family Life & Marriage in Islam")]
        FamilyAndMarriage = 13,

        [Display(Name = "Modern-Day Issues in Islam")]
        ContemporaryIssues = 14,

        [Display(Name = "Stories of the Prophets")]
        BiographyOfProphets = 15,

        [Display(Name = "Quran")]
        Quran = 16,

        [Display(Name = "Faith")]
        Faith = 17,

        [Display(Name = "Other")]
        Other = 18
    }
}
