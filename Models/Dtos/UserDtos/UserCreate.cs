namespace Job_Offre.Models.Dtos.UserDto.UserDtos
{
    public class UserCreate
    {
        public string UserName { get; set; } = null!;
        public string UserPw { get; set; } = null!;
        public int? RoleCode { get; set; }
    }
}
