using System;
using System.Collections.Generic;

namespace Job_Offre.Entities
{
    public partial class TmRegRegion
    {
        public TmRegRegion()
        {
            TmJobJobs = new HashSet<TmJobJob>();
            TrHexHaveExperiences = new HashSet<TrHexHaveExperience>();
            TrHfrHaveFormations = new HashSet<TrHfrHaveFormation>();
        }

        public int RegionCode { get; set; }
        public string RegionName { get; set; } = null!;
        public int? CountryCode { get; set; }

        public virtual TmCotCountry? CountryCodeNavigation { get; set; }
        public virtual ICollection<TmJobJob> TmJobJobs { get; set; }
        public virtual ICollection<TrHexHaveExperience> TrHexHaveExperiences { get; set; }
        public virtual ICollection<TrHfrHaveFormation> TrHfrHaveFormations { get; set; }
    }
}
