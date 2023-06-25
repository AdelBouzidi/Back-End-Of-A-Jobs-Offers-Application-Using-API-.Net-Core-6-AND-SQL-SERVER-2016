namespace Job_Offre.Models.Dtos.ExperienceDtos
{
    public class ExperienceReadDto
    {
        public string ExpName { get; set; } = null!;
        public string? ExpDesc { get; set; }
        public string ExpCompany { get; set; } = null!;
        public bool? ExpInProg { get; set; }
        public DateTime ExpSdate { get; set; }
        public DateTime? ExpEdate { get; set; }
    }
}


