using System;
using System.Collections.Generic;

namespace Job_Offre.Entities
{
    public partial class TmUsrUserAccount
    {
        public TmUsrUserAccount()
        {
            TmCndCandidates = new HashSet<TmCndCandidate>();
            TmRecRecruiters = new HashSet<TmRecRecruiter>();
        }

        public int UserCode { get; set; }
        public string UserName { get; set; } = null!;
        public byte[] UserPw { get; set; } = null!;
        public int? RoleCode { get; set; }

        public virtual TmRolRole? RoleCodeNavigation { get; set; }
        public virtual ICollection<TmCndCandidate> TmCndCandidates { get; set; }
        public virtual ICollection<TmRecRecruiter> TmRecRecruiters { get; set; }
    }
}
