using HelperModels;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelperRabbitMQ
{
    public abstract class BaseRabbitMQ
    {
        public ConnectionFactory _factory;
        public IConnection _connection;
        public IModel _model;
        public string _ExchangeName;
        public string _QueueName;
        public string _RoutingKey;

        public BaseRabbitMQ(ConfigurationRabbitMQ rabbitMQConfig)
        {
            _factory = new ConnectionFactory
            {
                HostName = rabbitMQConfig.HostName,
                UserName = rabbitMQConfig.UserName,
                Password = rabbitMQConfig.Password
            };

            _connection = _factory.CreateConnection();
            _model = _connection.CreateModel();

            _ExchangeName = rabbitMQConfig.Exchange;
            _QueueName = rabbitMQConfig.Queue;
            _RoutingKey = rabbitMQConfig.RoutenKey;
            _model.ExchangeDeclare(_ExchangeName, rabbitMQConfig.PatronType);// topic - para todos ,  fanout - un mensaje por consumer
            _model.QueueDeclare(_QueueName, true, false, false, null);
            _model.QueueBind(_QueueName, _ExchangeName, _RoutingKey);
        }
    }
}
