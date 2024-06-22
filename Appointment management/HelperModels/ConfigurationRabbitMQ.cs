using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelperModels
{
    public class ConfigurationRabbitMQ
    {
        public string HostName { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Exchange { get; set; } = null!;
        public string Queue { get; set; } = null!;
        public string RoutenKey { get; set; } = null!;
        public string PatronType { get; set; } = null!;
    }
}
