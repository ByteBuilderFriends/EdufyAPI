using System.ComponentModel.DataAnnotations.Schema;

namespace EdufyAPI.Models.QuizModels
{
    public class Question
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string QuestionText { get; set; } = string.Empty;

        public int Marks { get; set; } = 0;

        [ForeignKey(nameof(Quiz))]
        public string QuizId { get; set; } = string.Empty;
        public virtual Quiz Quiz { get; set; }

        public virtual Answer Answer { get; set; }
        public virtual ICollection<Option> Options { get; set; } = new List<Option>();

    }
}
