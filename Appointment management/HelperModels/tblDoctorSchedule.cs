using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelperModels
{
    public class tblDoctorSchedule
    {
        public int IdDocSch { get; set; }
        public int IdDoctor { get; set; }
        public int IdSchedule { get; set; } 
        public int IdDaysWeek { get; set; }
        public int IdOffce { get; set; }
    }
}
