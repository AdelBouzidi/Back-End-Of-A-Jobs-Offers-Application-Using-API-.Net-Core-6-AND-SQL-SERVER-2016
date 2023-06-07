using System;
using System.Collections.Generic;

namespace Job_Offre.Entities
{
    public partial class TrCskCandidateSkill
    {
        public int SkillCode { get; set; }
        public int CandidateCode { get; set; }
        public string SkillLevel { get; set; } = null!;

        public virtual TmCndCandidate CandidateCodeNavigation { get; set; } = null!;
        public virtual TmSklSkill SkillCodeNavigation { get; set; } = null!;
    }
}
