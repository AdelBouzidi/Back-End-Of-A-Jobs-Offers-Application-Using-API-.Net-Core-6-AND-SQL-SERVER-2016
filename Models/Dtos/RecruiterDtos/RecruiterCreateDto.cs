namespace Job_Offre.Models.Dtos.RecruiterDtos
{
    public class RecruiterCreateDto
    {
        public string RecruiterFname { get; set; } = null!;
        public string RecruiterLname { get; set; } = null!;
        public string RecruiterAdress { get; set; } = null!;
        public string RecruiterPhone { get; set; } = null!;
        public string? RecruiterDesc { get; set; }
        public int? GenderCode { get; set; }
        public int? UserCode { get; set; }
    }
}
