using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelperModels
{
    public class tblDoctors
    {
        public int IdDoctor { get; set; } 
        public string NameDoctor { get; set; } = null!;
        public string PhoneDoctor { get; set; } = null!;
        public int IdSpecialty { get; set; }
    }
}
