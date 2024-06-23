using HelperBusiness;

namespace HelperProcessMessage
{
    public class ProcessMessage
    {
        public void ProcessAllMessage(string message, string process) 
        {
            if (process == OperationsMessage.UserManagement)
            {
                InterfaceMessage _interfaceMessage = new BsUserManagement();
                _interfaceMessage.ProcessMessage(message);
            }
        }
    }
}
