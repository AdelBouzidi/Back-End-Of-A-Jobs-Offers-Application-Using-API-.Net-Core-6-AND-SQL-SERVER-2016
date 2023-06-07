namespace Job_Offre.Models
{
    public class userDto
    {
        public int UserCode { get; set; }
        public string UserName { get; set; } = null!;
        public byte[] UserPw { get; set; } = null!;
        public int? RoleCode { get; set; }
    }
}
