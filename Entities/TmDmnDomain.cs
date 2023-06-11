using System;
using System.Collections.Generic;

namespace Job_Offre.Entities
{
    public partial class TmDmnDomain
    {
        public TmDmnDomain()
        {
            TmJobJobs = new HashSet<TmJobJob>();
            TrHexHaveExperiences = new HashSet<TrHexHaveExperience>();
            TrHprHavePreferences = new HashSet<TrHprHavePreference>();
        }

        public int DomainCode { get; set; }
        public string DomainName { get; set; } = null!;
        public string? DomainDesc { get; set; }

        public virtual ICollection<TmJobJob> TmJobJobs { get; set; }
        public virtual ICollection<TrHexHaveExperience> TrHexHaveExperiences { get; set; }
        public virtual ICollection<TrHprHavePreference> TrHprHavePreferences { get; set; }
    }
}
