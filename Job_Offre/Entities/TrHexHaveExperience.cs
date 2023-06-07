using System;
using System.Collections.Generic;

namespace Job_Offre.Entities
{
    public partial class TrHexHaveExperience
    {
        public int ExpCode { get; set; }
        public int CandidateCode { get; set; }
        public int SkillCode { get; set; }
        public int DomainCode { get; set; }
        public int CountryCode { get; set; }
        public int RegionCode { get; set; }

        public virtual TmCndCandidate CandidateCodeNavigation { get; set; } = null!;
        public virtual TmCotCountry CountryCodeNavigation { get; set; } = null!;
        public virtual TmDmnDomain DomainCodeNavigation { get; set; } = null!;
        public virtual TmExpExperience ExpCodeNavigation { get; set; } = null!;
        public virtual TmRegRegion RegionCodeNavigation { get; set; } = null!;
        public virtual TmSklSkill SkillCodeNavigation { get; set; } = null!;
    }
}
