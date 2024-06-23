using HelperModels;
using HelperSerialize;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelperRabbitMQ
{
    public class Producer(ConfigurationRabbitMQ rabbitMQConfig) : BaseRabbitMQ(rabbitMQConfig)
    {
        public void SendMessage(string message)
        {
            try
            {
                _model.BasicPublish(_ExchangeName, _RoutingKey, null, message.Serialize());
            }
            catch
            {
                throw;
            }
        }
        public void Close() 
        { 
            _connection.Close(); 
        }
    }
}
