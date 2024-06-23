using HelperModels;
using HelperSerialize;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using HelperProcessMessage;

namespace HelperRabbitMQ
{
    public class Consumer(ConfigurationRabbitMQ rabbitMQSourceConfig) : BaseRabbitMQ(rabbitMQSourceConfig)
    {
        public void StartConsumingMessage(string process, ConfigurationRabbitMQ _RabbitMQDestination)
        {
            string messageInPut= String.Empty;
            string messageOutPut= String.Empty;
            ProcessMessage _processMessage = new ProcessMessage();
            Producer _producer = new Producer(_RabbitMQDestination);
            try 
            {
                var msgsRecievedGate = new ManualResetEventSlim(false);
                var consumer = new EventingBasicConsumer(_model);
                byte[] body = [];

                consumer.Received += (model, ea) =>
                {
                    body = ea.Body.ToArray();
                    messageInPut = body.DeserializeText() ?? "";
                    Console.WriteLine(" ");
                    Console.WriteLine($"Received message: {messageInPut}");
                    _model.BasicAck(ea.DeliveryTag, true); //borra el mensaje de la cola 
                                                           //_model.BasicNack(ea.DeliveryTag, true); //mantiene en la cola con estado negativo
                    messageOutPut = _processMessage.ProcessAllMessage(messageInPut, process);
                    _producer.SendMessage(messageOutPut);
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
