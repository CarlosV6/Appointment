using HelperModels;
using HelperSerialize;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelperRabbitMQ
{
    public class Consumer(ConfigurationRabbitMQ rabbitMQSourceConfig) : BaseRabbitMQ(rabbitMQSourceConfig)
    {
        public void StartConsumingMessage()
        {
            string message= String.Empty;
            try 
            {
                var msgsRecievedGate = new ManualResetEventSlim(false);
                var consumer = new EventingBasicConsumer(_model);
                byte[] body = [];

                consumer.Received += (model, ea) =>
                {
                    body = ea.Body.ToArray();
                    message = body.DeserializeText() ?? "";
                    Console.WriteLine(" ");
                    Console.WriteLine($"Received message in process: {message}");
                    _model.BasicAck(ea.DeliveryTag, true); //borra el mensaje de la cola 
                    //_model.BasicNack(ea.DeliveryTag, true); //mantiene en la cola con estado negativo

                };
                _model.BasicConsume(queue: _QueueName, autoAck: false, consumer: consumer);
                msgsRecievedGate.Wait();//espera hasta recibir el mensaje
            }
            catch 
            {
                throw;
            }
        }
    }
}
