using HelperBusiness;
using System.Runtime.CompilerServices;

namespace HelperProcessMessage
{
    public class ProcessMessage
    {
        private InterfaceMessage _interfaceMessage = null!;
        public string ProcessAllMessage(string messageInPut, string process)
        {
            string messageOutPut = string.Empty;
            if (process == EnumOperationsMessage.AppointmentManagement)
            {
            }
            else if (process == EnumOperationsMessage.AuthenticationAuthorization)
            {
            }
            else if (process == EnumOperationsMessage.MedicalManagement)
            {
            }
            else if (process == EnumOperationsMessage.NotificationManagement)
            {
            }
            else if (process == EnumOperationsMessage.PatientManagement)
            {
            }
            else if (process == EnumOperationsMessage.ThirdPartyManagement)
            {
            }
            else if (process == EnumOperationsMessage.UserManagement)
            {
                _interfaceMessage = new BsUserManagement();
                messageOutPut = _interfaceMessage.ProcessMessage(messageInPut);
            }
            return messageOutPut;
        }
    }
}
