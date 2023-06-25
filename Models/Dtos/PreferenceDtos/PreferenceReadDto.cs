namespace Job_Offre.Models.Dtos.PreferenceDtos
{
    public class PreferenceReadDto
    {
        public float DesiredSalary { get; set; }
        public string PrefMobility { get; set; } = null!;
        public int? CtrCode { get; set; }
    }
}
