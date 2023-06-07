using System;
using System.Collections.Generic;

namespace Job_Offre.Entities
{
    public partial class TrHfrHaveFormation
    {
        public int FormCode { get; set; }
        public int CandidateCode { get; set; }
        public int CountryCode { get; set; }
        public int RegionCode { get; set; }

        public virtual TmCndCandidate CandidateCodeNavigation { get; set; } = null!;
        public virtual TmCotCountry CountryCodeNavigation { get; set; } = null!;
        public virtual TmFrmFormation FormCodeNavigation { get; set; } = null!;
        public virtual TmRegRegion RegionCodeNavigation { get; set; } = null!;
    }
}
