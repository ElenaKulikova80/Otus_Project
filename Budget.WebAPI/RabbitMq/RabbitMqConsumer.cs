using Npgsql.EntityFrameworkCore.PostgreSQL.Storage.Internal.Mapping;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Diagnostics;
using System.Net.Sockets;
using System.Text;

namespace Budget.WebAPI.RabbitMq
{
    public class RabbitMqConsumer: BackgroundService
    {
        private IConnection _connection;
        private IModel _channel;

        public RabbitMqConsumer () 
        {
            //установление соединения с брокером
            var factory = new ConnectionFactory { HostName = "localhost" };
            _connection = factory.CreateConnection();

            //создание канала для взаимодействия с Api RabbitMq
            _channel = _connection.CreateModel();
            
            //создание очереди
            _channel.QueueDeclare("UserAdd",
                                   durable: false,
                                   exclusive: false,
                                   autoDelete: false,
                                   arguments: null);
            
        }
        
        protected override Task ExecuteAsync(CancellationToken stoppingToken) //CancellationToken - отслеживать запросы на отмену операций
        {
            stoppingToken.ThrowIfCancellationRequested();

            Thread.Sleep(3000);
            //создание consumer
            var consumer = new EventingBasicConsumer(_channel);

            consumer.Received += (model, EventArgs) =>
            {
                var body = EventArgs.Body.ToArray();
                var message_consumer = Encoding.UTF8.GetString(body);
                Debug.WriteLine($"Получено сообщение: {message_consumer}");              
                
              _channel.BasicAck(EventArgs.DeliveryTag,false);
            };
            _channel.BasicConsume(queue: "UserAdd", autoAck: true, consumer: consumer);
            return Task.CompletedTask;
        }

        public override void Dispose()
        {
            _channel.Close();
            _connection.Close();
            base.Dispose();
        }
       
    }
}
