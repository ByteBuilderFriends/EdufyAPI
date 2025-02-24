using System.ComponentModel.DataAnnotations;

//Question Types Enum
public enum QuestionType
{
    [Display(Name = "Single Choice")]
    SingleChoice = 1,
    [Display(Name = "Multiple Choice")]
    MultipleChoice = 2,
    [Display(Name = "True/False")]
    TrueFalse = 3,
    [Display(Name = "Short Answer")]
    ShortAnswer = 4
}