using HelperData;
using HelperModels;
using HelperSerialize;

namespace HelperBusiness
{
    public class BsUserManagement: InterfaceMessage
    {
        private readonly DataUserManagement _DataUserManagement;
        public BsUserManagement()
        {
            _DataUserManagement = new DataUserManagement();
        }
        public void ProcessMessage(string message)   
        {
            dataModelProcess _dataModelProcess = (dataModelProcess)message.Deserialize(typeof(dataModelProcess))!;

            if (_dataModelProcess.operation == "Consult")
            {
                if (_dataModelProcess.metod == "GetProfile")
                {
                    _DataUserManagement.GetProfile();
                }
                if (_dataModelProcess.metod == "GetUsers")
                {
                    _DataUserManagement.GetUsers();
                }
                if (_dataModelProcess.metod == "GetProfileUser")
                {
                    _DataUserManagement.GetProfileUser();
                }
            }
            else if (_dataModelProcess.operation == "Insert")
            {

            }
            else if (_dataModelProcess.operation == "Update")
            {

            }
            else if (_dataModelProcess.operation == "Delete")
            {

            }
        }
    }
}
