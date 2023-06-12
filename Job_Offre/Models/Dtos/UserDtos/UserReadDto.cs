namespace Job_Offre.Models.Dtos.UserDtos
{
    public class UserReadDto
    {
        public int UserCode { get; set; }
        public string UserName { get; set; } = null!;
        public byte[] UserPw { get; set; } = null!;
        public int? RoleCode { get; set; }
    }
}
