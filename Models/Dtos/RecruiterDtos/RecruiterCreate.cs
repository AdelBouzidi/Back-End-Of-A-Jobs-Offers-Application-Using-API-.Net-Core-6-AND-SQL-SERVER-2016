using System.ComponentModel.DataAnnotations;

namespace Job_Offre.Models.Dtos.RecruiterDtos
{
    public class RecruiterCreate
    {
        [Required]
        public string RecruiterFname { get; set; } = null!;

        [Required]
        public string RecruiterLname { get; set; } = null!;

        //[DataType(DataType.EmailAddress)]
        [Required]
        [EmailAddress]
        public string RecruiterAdress { get; set; } = null!;

        [Required]
        [MinLength(8)]
        [MaxLength(50)]
        public string UserPw { get; set; } = null!;

        [Required]
        public string RecruiterPhone { get; set; } = null!;

        [Required]
        public string? RecruiterDesc { get; set; }

        [Required]
        public int? GenderCode { get; set; }

    }
}
