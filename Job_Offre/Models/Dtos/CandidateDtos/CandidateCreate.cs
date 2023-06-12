using System.ComponentModel.DataAnnotations;

namespace Job_Offre.Models.Dtos.CandidateDtos
{
    public class CandidateCreate
    {

        [Required]
        public string CandidateFname { get; set; } = null!;
        
        [Required]
        public string CandidateLname { get; set; } = null!;
        
        [Required]
        [EmailAddress]
        public string CandidateAdress { get; set; } = null!;
        
        [Required]
        [MinLength(8)]
        [MaxLength(50)]
        public string UserPw { get; set; } = null!;

        [Required]
        public string CandidatePhone { get; set; } = null!;
        
        [Required]
        public bool? CandidateMs { get; set; }
        
        [Required]
        public string? CandidateDesc { get; set; }
        
        [Required]
        public int? GenderCode { get; set; }
    }
}
