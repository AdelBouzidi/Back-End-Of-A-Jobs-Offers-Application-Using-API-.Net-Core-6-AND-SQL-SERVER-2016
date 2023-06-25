using Job_Offre.Models.Dtos.ExperienceDtos;
using Job_Offre.Models.Dtos.FormationDtos;
using Job_Offre.Models.Dtos.PreferenceDtos;
using Job_Offre.Models.Dtos.SkillDtos;

namespace Job_Offre.Models.Dtos.ProfileDto
{
    public class ProfleDtoCandidate
    {
        public IEnumerable<FormationDtoTransformed> FormationProfile { get; set; }
        public PreferenceDtoTransformed PreferenceProfile { get; set; }
        public IEnumerable<ExperienceDtoTransformed> ExperienceProfile { get; set; }
        public IEnumerable<SkillDtoTransformed> SkillProfile { get; set; }
    }
}
