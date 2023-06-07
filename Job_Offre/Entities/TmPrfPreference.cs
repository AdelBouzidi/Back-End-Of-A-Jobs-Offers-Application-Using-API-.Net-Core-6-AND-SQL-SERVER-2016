using System;
using System.Collections.Generic;

namespace Job_Offre.Entities
{
    public partial class TmPrfPreference
    {
        public TmPrfPreference()
        {
            TrHprHavePreferences = new HashSet<TrHprHavePreference>();
        }

        public int PrefCode { get; set; }
        public float DesiredSalary { get; set; }
        public string PrefMobility { get; set; } = null!;
        public int? CtrCode { get; set; }

        public virtual TcCtrTypeContract? CtrCodeNavigation { get; set; }
        public virtual ICollection<TrHprHavePreference> TrHprHavePreferences { get; set; }
    }
}
