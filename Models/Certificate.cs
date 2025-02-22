using EdufyAPI.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduConnectAPI.Models
{
    public class Certificate
    {
        //Id is used as the primary key for database efficiency and relationships.
        public string Id { get; set; }

        // Unique identifier for the certificate, generated as a GUID
        //CertificateNumber provides a user-friendly, unique identifier that can be exposed externally.
        [Required]
        public string CertificateNumber { get; set; } = Guid.NewGuid().ToString();

        // Date when the certificate is issued, defaults to the current UTC date and time
        [Required]
        public DateTime IssueDate { get; set; } = DateTime.UtcNow;

        // Optional field for additional remarks or notes on the certificate
        public string? Remarks { get; set; }
        #region Relationships
        [ForeignKey("Progress")]
        public string ProgressId { get; set; }
        public virtual Progress Progress { get; set; }
        #endregion

    }
}
