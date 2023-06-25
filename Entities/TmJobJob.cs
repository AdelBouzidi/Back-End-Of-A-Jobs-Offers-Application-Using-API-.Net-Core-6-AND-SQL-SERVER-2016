using System;
using System.Collections.Generic;

namespace Job_Offre.Entities
{
    public partial class TmJobJob
    {

        public TmJobJob()
        {
            TrAppApplies = new HashSet<TrAppApply>();
            SkillCodes = new HashSet<TmSklSkill>();
        }


        public int JobCode { get; set; }
        public string JobName { get; set; } = null!;
        public string JobDesc { get; set; } = null!;
        public string JobLevel { get; set; } = null!;
        public DateTime? JobExpDate { get; set; }
        public string? JobMode { get; set; }
        public int DomainCode { get; set; }
        public int RegionCode { get; set; }
        public int RecruiterCode { get; set; }
        public int CtrCode { get; set; }
        public int NumberOfPosts { get; set; }
        public int YearExperienceRequired { get; set; }
        public string FrenchLevel { get; set; } = null!;
        public string EnglishLevel { get; set; } = null!;
        public string Graduate { get; set; } = null!;

        public virtual TcCtrTypeContract CtrCodeNavigation { get; set; } = null!;
        public virtual TmDmnDomain DomainCodeNavigation { get; set; } = null!;
        public virtual TmRecRecruiter RecruiterCodeNavigation { get; set; } = null!;
        public virtual TmRegRegion RegionCodeNavigation { get; set; } = null!;
        public virtual ICollection<TrAppApply> TrAppApplies { get; set; }

        public virtual ICollection<TmSklSkill> SkillCodes { get; set; }
    }
}
