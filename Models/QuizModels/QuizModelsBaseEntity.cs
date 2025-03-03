using System.ComponentModel.DataAnnotations;

namespace EdufyAPI.Models.QuizModels
{
    // Base class for common properties
    public class QuizModelsBaseEntity
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }

        public string CreatedBy { get; set; } = "System";
        public string? UpdatedBy { get; set; }

    }
}
