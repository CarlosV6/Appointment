using HelperData;
using HelperModels;
using HelperSerialize;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelperBusiness
{
    public class BsUserManagement
    {
        private readonly DataUserManagement _DataUserManagement;

        public BsUserManagement(ConfigurationSQL _ConfigurationSQL)
        {
            _DataUserManagement = new DataUserManagement(_ConfigurationSQL);
        }
        public string StartProcess(string message)   
        {

            string mensaje = _DataUserManagement.GetProfile().SerializeText() ?? "";

            return mensaje;
        }
    }
}
