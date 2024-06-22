using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelperModels
{
    public class ConfigurationSQL
    {
        public string Server { get; set; } = null!;
        public string DataBase { get; set; } = null!;
        public string User { get; set; } = null!;
        public string PassWord { get; set; } = null!;
        public string TimeOut { get; set; } = null!;
        public string integratedSecurity { get; set; } = null!;
        public string trustServerCertificate { get; set; } = null!;
    }
}
