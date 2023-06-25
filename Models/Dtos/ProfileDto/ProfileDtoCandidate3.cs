using Job_Offre.Models.Dtos.ExperienceDtos;
using Job_Offre.Models.Dtos.FormationDtos;
using Job_Offre.Models.Dtos.PreferenceDtos;
using Job_Offre.Models.Dtos.SkillDtos;

namespace Job_Offre.Models.Dtos.ProfileDto
{
    public class ProfileDtoCandidate3
    {
        public IEnumerable<FormationDtoTransformed2> FormationProfile { get; set; }
        public PreferenceDtoTranformed2 PreferenceProfile { get; set; }
        public IEnumerable<ExperienceDtoTransformed2> ExperienceProfile { get; set; }
        public IEnumerable<SkillDtoTransformed2> SkillProfile { get; set; }
        public int pourcentageProfile { get; set; }
    }
}
