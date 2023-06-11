using System.ComponentModel.DataAnnotations;

namespace Job_Offre.Models.Dtos.UserDtos
{
    public class UserCreateDto
    {
        [Required]
        public byte[] UserPw { get; set; }

        [Required]
        public int? RoleCode { get; set; }

        [Required]
        public string? UserName { get; set; }

    }
}
