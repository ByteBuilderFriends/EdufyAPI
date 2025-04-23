using System.ComponentModel.DataAnnotations;

namespace AskAMuslimAPI.Enums
{
    public enum CourseLevel
    {
        [Display(Name = "Beginner")]
        Beginner = 1,

        [Display(Name = "Intermediate")]
        Intermediate = 2,

        [Display(Name = "Advanced")]
        Advanced = 3,

        [Display(Name = "All Levels")]
        AllLevels = 4
    }
}