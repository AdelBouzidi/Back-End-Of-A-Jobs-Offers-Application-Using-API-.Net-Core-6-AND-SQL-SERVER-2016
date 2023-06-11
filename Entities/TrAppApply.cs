using System;
using System.Collections.Generic;

namespace Job_Offre.Entities
{
    public partial class TrAppApply
    {
        public int JobCode { get; set; }
        public int CandidateCode { get; set; }
        public DateTime ApplyDate { get; set; }

        public virtual TmCndCandidate CandidateCodeNavigation { get; set; } = null!;
        public virtual TmJobJob JobCodeNavigation { get; set; } = null!;
    }
}
