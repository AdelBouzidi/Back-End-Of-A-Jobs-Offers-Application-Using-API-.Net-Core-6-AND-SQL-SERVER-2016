namespace Job_Offre.Models.Dtos.ExperienceDtos
{
    public class ExperienceDtoTransformed
    {
        public int ExpCode { get; set; }
        public string ExpName { get; set; } = null!;
        public string? ExpDesc { get; set; }
        public string ExpCompany { get; set; } = null!;
        public bool? ExpInProg { get; set; }
        public DateTime ExpSdate { get; set; }
        public DateTime? ExpEdate { get; set; }
        public int CandidateCode { get; set; }
        public string? SkillName { get; set; }
        public string? DomainName { get; set; }
        public string? CountryName { get; set; }
        public string? RegionName { get; set; }
    }
}
