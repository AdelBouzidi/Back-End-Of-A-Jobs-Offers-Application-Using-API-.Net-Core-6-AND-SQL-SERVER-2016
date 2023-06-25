using Microsoft.OpenApi.Writers;
using System.Text.Json.Serialization;

namespace Job_Offre.Models.Dtos.ExperienceDtos
{
    public class ExperienceDtoTransformed3
    {
        public int ExpCode { get; set; }
        public string ExpName { get; set; } = null!;
        public string? ExpDesc { get; set; }
        public string ExpCompany { get; set; } = null!;
        public bool? ExpInProg { get; set; }
        public DateTime ExpSdate { get; set; }
        public DateTime? ExpEdate { get; set; }
        public int CandidateCode { get; set; }
        public int SkillCode { get; set; }
        public int DomainCode { get; set; }
        public int CountryCode { get; set; }
        public int RegionCode { get; set; }
        [JsonIgnore] // Ignorer cette propriété lors de la sérialisation JSON
        public string? CircularProperty { get; set; }
    }
}
