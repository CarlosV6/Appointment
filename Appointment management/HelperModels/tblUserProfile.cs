using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelperModels
{
    public class tblUserProfile
    {
        public string metod { get; set; } = null!;
        public string operation { get; set; } = null!;
        public string message { get; set; } = null!;
        public List<tblUserprofiledata> tblUserProfileData { get; set; } = new List<tblUserprofiledata>();
    }
    public class tblUserprofiledata
    {
        public string IdSUserProfile { get; set; }
        public string UserProfile { get; set; } = null!;
    }
}
