namespace Job_Offre.Models.Dtos.SkillDtos
{
    public class SkillDtoCreate
    {
        public string SkillName { get; set; } = null!;
        public string? SkillDesc { get; set; }
        public int CandidateCode { get; set; }
        public string SkillLevel { get; set; } = null!;
    }
}
