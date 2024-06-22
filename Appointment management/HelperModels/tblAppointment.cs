using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelperModels
{
    public class tblAppointment
    {
        public int IdAppointment { get; set; }
        public int IdPatient { get; set; }
        public int IdDocSch { get; set; }
        public string Observations { get; set; } = null!;
        public DateTime DateAppointment { get; set; }
        public bool SitAppointment { get; set; }    
    }
}
