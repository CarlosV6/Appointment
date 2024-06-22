using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelperModels
{
    public class tblSystemUsers
    {
        public int IdSystemUsers { get; set; }
        public int IdSUserProfile { get; set; }
        public string SystemUsers { get; set; } = null!;
        public string SystemUsersPass { get; set; } = null!;
        public bool SitSystemUsers { get; set; }
    }
}
