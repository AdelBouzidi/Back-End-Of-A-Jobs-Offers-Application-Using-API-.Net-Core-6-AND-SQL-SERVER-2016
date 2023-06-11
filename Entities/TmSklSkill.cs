using System;
using System.Collections.Generic;

namespace Job_Offre.Entities
{
    public partial class TmSklSkill
    {
        public TmSklSkill()
        {
            TrCskCandidateSkills = new HashSet<TrCskCandidateSkill>();
            TrHexHaveExperiences = new HashSet<TrHexHaveExperience>();
            JobCodes = new HashSet<TmJobJob>();
        }

        public int SkillCode { get; set; }
        public string SkillName { get; set; } = null!;
        public string? SkillDesc { get; set; }

        public virtual ICollection<TrCskCandidateSkill> TrCskCandidateSkills { get; set; }
        public virtual ICollection<TrHexHaveExperience> TrHexHaveExperiences { get; set; }

        public virtual ICollection<TmJobJob> JobCodes { get; set; }
    }
}
