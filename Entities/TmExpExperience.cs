using System;
using System.Collections.Generic;

namespace Job_Offre.Entities
{
    public partial class TmExpExperience
    {
        public TmExpExperience()
        {
            TrHexHaveExperiences = new HashSet<TrHexHaveExperience>();
        }

        public int ExpCode { get; set; }
        public string ExpName { get; set; } = null!;
        public string? ExpDesc { get; set; }
        public string ExpCompany { get; set; } = null!;
        public bool? ExpInProg { get; set; }
        public DateTime ExpSdate { get; set; }
        public DateTime? ExpEdate { get; set; }

        public virtual ICollection<TrHexHaveExperience> TrHexHaveExperiences { get; set; }
    }
}
