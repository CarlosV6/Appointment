using HelperBusiness;
using HelperModels;
using HelperRabbitMQ;
using Microsoft.Extensions.Options;

namespace UserManagement
{
    public class UserManagementProcess(IOptionsSnapshot<ConfigurationRabbitMQ> RMOptions)
    {
        private readonly ConfigurationRabbitMQ _RabbitMQDestination = RMOptions.Get("RabbitMQDestination");
        private readonly BsUserManagement _BsUserManagement = new BsUserManagement();
        Consumer _consumer = new Consumer(RMOptions.Get("RabbitMQSource"));
        public void StartProcess()
        {
            try
            {
                _consumer.StartConsumingMessage("UserManagement", _RabbitMQDestination);
            }
            catch
            {
                throw;
            }
        }
    }
}