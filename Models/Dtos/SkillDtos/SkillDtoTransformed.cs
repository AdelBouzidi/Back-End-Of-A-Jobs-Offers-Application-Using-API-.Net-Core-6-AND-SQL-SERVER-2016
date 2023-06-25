namespace Job_Offre.Models.Dtos.SkillDtos
{
    public class SkillDtoTransformed
    {
        public int SkillCode { get; set; }
        public string SkillName { get; set; } = null!;
        public string? SkillDesc { get; set; }
        public string SkillLevel { get; set; } = null!;

    }
}
