namespace Job_Offre.Models.Dtos.PreferenceDtos
{
    public class PreferenceDtoTransformed3
    {
        public float DesiredSalary { get; set; }
        public string PrefMobility { get; set; } = null!;
        public int? CtrCode { get; set; }
        public int CandidateCode { get; set; }
        public int DomainCode { get; set; }
    }
}
