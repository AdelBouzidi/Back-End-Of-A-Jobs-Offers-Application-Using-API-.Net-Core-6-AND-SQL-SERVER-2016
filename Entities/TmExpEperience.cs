using System;
using System.Collections.Generic;

namespace Job_Offre.Entities
{
    public partial class TmExpEperience
    {
        public TmExpEperience()
        {
            TrHexHaveExperiences = new HashSet<TrHexHaveExperience>();
        }

        public string ExpCode { get; set; } = null!;
        public string ExpName { get; set; } = null!;
        public string? ExpDesc { get; set; }
        public string ExpCompany { get; set; } = null!;
        public bool? ExpInProg { get; set; }
        public DateTime ExpSdate { get; set; }
        public DateTime? ExpEdate { get; set; }

        public virtual ICollection<TrHexHaveExperience> TrHexHaveExperiences { get; set; }
    }
}
