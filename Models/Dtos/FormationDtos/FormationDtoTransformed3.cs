namespace Job_Offre.Models.Dtos.FormationDtos
{
    public class FormationDtoTransformed3
    {
        public string FormGrad { get; set; } = null!;
        public string FormName { get; set; } = null!;
        public string? FormDesc { get; set; }
        public string SchoolName { get; set; } = null!;
        public bool? FormInProg { get; set; }
        public DateTime FormSdate { get; set; }
        public DateTime? FormEdate { get; set; }
        public int CandidateCode { get; set; }
        public int CountryCode { get; set; }
        public int RegionCode { get; set; }
    }
}
