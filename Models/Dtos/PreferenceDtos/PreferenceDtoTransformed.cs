namespace Job_Offre.Models.Dtos.PreferenceDtos
{
    public class PreferenceDtoTransformed
    {
        public int PrefCode { get; set; }
        public float DesiredSalary { get; set; }
        public string PrefMobility { get; set; } = null!;
        public string? CtrName { get; set; }
        public string? DomainName { get; set; }
    }
}
