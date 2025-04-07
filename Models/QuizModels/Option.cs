using System.ComponentModel.DataAnnotations.Schema;

namespace EdufyAPI.Models.QuizModels
{
    public class Option
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string OptionText { get; set; } = string.Empty;

        public bool IsCorrect { get; set; } = false;


        [ForeignKey(nameof(Question))]
        public string QuestionId { get; set; } = string.Empty;
        public virtual Question Question { get; set; }

        public virtual Answer Answer { get; set; }
    }
}
