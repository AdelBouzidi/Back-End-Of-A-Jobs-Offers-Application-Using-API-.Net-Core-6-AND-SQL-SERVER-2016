using System;
using System.Collections.Generic;

namespace Job_Offre.Entities
{
    public partial class TcGdrGender
    {
        public TcGdrGender()
        {
            TmCndCandidates = new HashSet<TmCndCandidate>();
            TmRecRecruiters = new HashSet<TmRecRecruiter>();
        }

        public int GenderCode { get; set; }
        public string? GndLabel { get; set; }

        public virtual ICollection<TmCndCandidate> TmCndCandidates { get; set; }
        public virtual ICollection<TmRecRecruiter> TmRecRecruiters { get; set; }
    }
}
