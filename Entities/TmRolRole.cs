using System;
using System.Collections.Generic;

namespace Job_Offre.Entities
{
    public partial class TmRolRole
    {
        public TmRolRole()
        {
            TmUsrUserAccounts = new HashSet<TmUsrUserAccount>();
        }

        public int RoleCode { get; set; }
        public string? RoleLabel { get; set; }

        public virtual ICollection<TmUsrUserAccount> TmUsrUserAccounts { get; set; }
    }
}
