using HelperBusiness;
using HelperModels;
using HelperRabbitMQ;
using Microsoft.Extensions.Options;

namespace UserManagement
{
    public class UserManagementProcess(IOptionsSnapshot<ConfigurationRabbitMQ> RMOptions, IOptionsSnapshot<ConfigurationSQL> SqlOptions)
    {
        private readonly ConfigurationRabbitMQ _RabbitMQSource =  RMOptions.Get("RabbitMQSource");
        private readonly ConfigurationRabbitMQ _RabbitMQDestination = RMOptions.Get("RabbitMQDestination");
        private readonly BsUserManagement _BsUserManagement = new BsUserManagement(SqlOptions.Get("SQLConfiguration"));

        public void StartProcess()
        {
            try
            {
                Consumer _consumer = new Consumer(_RabbitMQSource);
                _consumer.StartConsumingMessage();
            }
            catch
            {
                throw;
            }
        }
    }
}