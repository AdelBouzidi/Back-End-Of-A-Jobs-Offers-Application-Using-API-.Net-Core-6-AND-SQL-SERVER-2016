using System;
using System.Collections.Generic;

namespace Job_Offre.Entities
{
    public partial class TmCndCandidate
    {
        public TmCndCandidate()
        {
            TrAppApplies = new HashSet<TrAppApply>();
            TrCskCandidateSkills = new HashSet<TrCskCandidateSkill>();
            TrHexHaveExperiences = new HashSet<TrHexHaveExperience>();
            TrHfrHaveFormations = new HashSet<TrHfrHaveFormation>();
            TrHprHavePreferences = new HashSet<TrHprHavePreference>();
        }

        public int CandidateCode { get; set; }
        public string CandidateFname { get; set; } = null!;
        public string CandidateLname { get; set; } = null!;
        public string CandidateAdress { get; set; } = null!;
        public string CandidatePhone { get; set; } = null!;
        public bool? CandidateMs { get; set; }
        public string? CandidateDesc { get; set; }
        public int? GenderCode { get; set; }
        public int? UserCode { get; set; }

        public virtual TcGdrGender? GenderCodeNavigation { get; set; }
        public virtual TmUsrUserAccount? UserCodeNavigation { get; set; }
        public virtual ICollection<TrAppApply> TrAppApplies { get; set; }
        public virtual ICollection<TrCskCandidateSkill> TrCskCandidateSkills { get; set; }
        public virtual ICollection<TrHexHaveExperience> TrHexHaveExperiences { get; set; }
        public virtual ICollection<TrHfrHaveFormation> TrHfrHaveFormations { get; set; }
        public virtual ICollection<TrHprHavePreference> TrHprHavePreferences { get; set; }
    }
}
