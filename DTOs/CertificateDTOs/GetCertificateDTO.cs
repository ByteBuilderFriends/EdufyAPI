namespace EdufyAPI.DTOs.CertificateDTOs
{
    public class GetCertificateDTO
    {
        public string CertificateNumber { get; set; }
        public DateTime IssueDate { get; set; }
        public string? Remarks { get; set; }
    }
}
