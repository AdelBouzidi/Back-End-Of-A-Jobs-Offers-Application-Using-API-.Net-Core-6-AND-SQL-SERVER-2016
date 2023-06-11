using System;
using System.Collections.Generic;

namespace Job_Offre.Entities
{
    public partial class TcCtrTypeContract
    {
        public TcCtrTypeContract()
        {
            TmJobJobs = new HashSet<TmJobJob>();
            TmPrfPreferences = new HashSet<TmPrfPreference>();
        }

        public int CtrCode { get; set; }
        public string CtrLabel { get; set; } = null!;

        public virtual ICollection<TmJobJob> TmJobJobs { get; set; }
        public virtual ICollection<TmPrfPreference> TmPrfPreferences { get; set; }
    }
}
