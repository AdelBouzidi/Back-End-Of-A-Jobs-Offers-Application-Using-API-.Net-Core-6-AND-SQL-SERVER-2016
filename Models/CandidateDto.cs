namespace Job_Offre.Models
{
    public class CandidateDto
    {
        public int CandidateCode { get; set; }
        public string CandidateFname { get; set; } = null!;
        public string CandidateLname { get; set; } = null!;
        public string CandidateAdress { get; set; } = null!;
        public string CandidatePhone { get; set; } = null!;
        public bool? CandidateMs { get; set; }
        public string? CandidateDesc { get; set; }
        public int? GenderCode { get; set; }
        public int? UserCode { get; set; }
    }
}
