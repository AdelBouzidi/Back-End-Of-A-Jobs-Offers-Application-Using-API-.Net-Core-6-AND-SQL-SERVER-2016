using System;
using System.Collections.Generic;

namespace Job_Offre.Entities
{
    public partial class TmFrmFormation
    {
        public TmFrmFormation()
        {
            TrHfrHaveFormations = new HashSet<TrHfrHaveFormation>();
        }

        public int FormCode { get; set; }
        public string FormGrad { get; set; } = null!;
        public string FormName { get; set; } = null!;
        public string? FormDesc { get; set; }
        public string SchoolName { get; set; } = null!;
        public bool? FormInProg { get; set; }
        public DateTime FormSdate { get; set; }
        public DateTime? FormEdate { get; set; }

        public virtual ICollection<TrHfrHaveFormation> TrHfrHaveFormations { get; set; }
    }
}
