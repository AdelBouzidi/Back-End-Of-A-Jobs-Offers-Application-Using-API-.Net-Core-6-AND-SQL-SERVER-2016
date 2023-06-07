using System;
using System.Collections.Generic;

namespace Job_Offre.Entities
{
    public partial class TmRecRecruiter
    {
        public TmRecRecruiter()
        {
            TmJobJobs = new HashSet<TmJobJob>();
        }

        public int RecruiterCode { get; set; }
        public string RecruiterFname { get; set; } = null!;
        public string RecruiterLname { get; set; } = null!;
        public string RecruiterAdress { get; set; } = null!;
        public string RecruiterPhone { get; set; } = null!;
        public string? RecruiterDesc { get; set; }
        public int? GenderCode { get; set; }
        public int? UserCode { get; set; }

        public virtual TcGdrGender? GenderCodeNavigation { get; set; }
        public virtual TmUsrUserAccount? UserCodeNavigation { get; set; }
        public virtual ICollection<TmJobJob> TmJobJobs { get; set; }
    }
}
