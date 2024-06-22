using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelperModels
{
    public class tblPatients
    {
        public int IdPatient { get; set; }
        public string NamePatient { get; set; } = null!;
        public string PhonePatient { get; set; } = null!;
        public string AddressPatient { get; set; } = null!;
        public string Observations { get; set; } = null!;
    }
}
