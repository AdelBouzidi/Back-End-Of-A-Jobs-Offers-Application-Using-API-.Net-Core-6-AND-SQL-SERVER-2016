using System;
using System.Collections.Generic;

namespace Job_Offre.Entities
{
    public partial class TmCotCountry
    {
        public TmCotCountry()
        {
            TmRegRegions = new HashSet<TmRegRegion>();
            TrHexHaveExperiences = new HashSet<TrHexHaveExperience>();
            TrHfrHaveFormations = new HashSet<TrHfrHaveFormation>();
        }

        public int CountryCode { get; set; }
        public string CountryName { get; set; } = null!;

        public virtual ICollection<TmRegRegion> TmRegRegions { get; set; }
        public virtual ICollection<TrHexHaveExperience> TrHexHaveExperiences { get; set; }
        public virtual ICollection<TrHfrHaveFormation> TrHfrHaveFormations { get; set; }
    }
}
