using System;
using System.Collections.Generic;

namespace Job_Offre.Entities
{
    public partial class TrHprHavePreference
    {
        public int CandidateCode { get; set; }
        public int PrefCode { get; set; }
        public int DomainCode { get; set; }

        public virtual TmCndCandidate CandidateCodeNavigation { get; set; } = null!;
        public virtual TmDmnDomain DomainCodeNavigation { get; set; } = null!;
        public virtual TmPrfPreference PrefCodeNavigation { get; set; } = null!;
    }
}
