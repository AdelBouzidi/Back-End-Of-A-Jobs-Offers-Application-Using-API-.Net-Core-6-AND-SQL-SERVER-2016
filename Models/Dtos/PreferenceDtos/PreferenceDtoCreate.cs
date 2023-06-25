namespace Job_Offre.Models.Dtos.PreferenceDtos
{
    public class PreferenceDtoCreate
    {
        public float DesiredSalary { get; set; }
        public string PrefMobility { get; set; } = null!;
        public string? CtrName { get; set; }
        public int CandidateCode { get; set; }
        public string? DomainName { get; set; }
    }
}
