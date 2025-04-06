using EdufyAPI.Models.Roles;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EdufyAPI.Models.QuizModels
{
    public class Answer
    {
        public bool IsCorrect
        {
            get
            {
                if (Option == null || Question == null)
                    return false;
                if (Option.IsCorrect == null)
                    return false;
                return Option.IsCorrect == true;
            }
        }


        #region Navigation Properties
        [Key]
        [Column(Order = 1)]  // This specifies the order of the key in the composite key.
        [ForeignKey(nameof(Student))]
        public string StudentId { get; set; } = string.Empty;
        public virtual Student Student { get; set; } = new Student();

        [Key]
        [Column(Order = 2)]  // This specifies the order of the key in the composite key.
        [ForeignKey(nameof(Question))]
        public string QuestionId { get; set; } = string.Empty;
        public virtual Question Question { get; set; } = new Question();


        [ForeignKey(nameof(Option))]
        public string SelectedOptionId { get; set; } = string.Empty;
        public virtual Option Option { get; set; } = new Option();
        #endregion
    }
}
