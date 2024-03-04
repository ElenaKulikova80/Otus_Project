using Microsoft.EntityFrameworkCore.Storage.Json;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace Identity.WebAPI.RabbitMq
{
    public class RabbitMqProducer: IRabbitMqProducer
    {
        public void SendMessage<T> (T message)
        {
            //установление соединения с брокером
            var factory = new ConnectionFactory { HostName = "localhost" };
            var connection = factory.CreateConnection();

            //создание канала для взаимодействия с Api RabbitMq
            using (var channel = connection.CreateModel())
            {
                //создание очереди
                channel.QueueDeclare("UserAdd",
                                      durable: false,
                                      exclusive: false,
                                      autoDelete: false,
                                      arguments: null);

                //отправка сообщения в созданную очередь
                var json = JsonConvert.SerializeObject(message);
                var body = Encoding.UTF8.GetBytes(json);

                channel.BasicPublish(exchange: "", routingKey: "UserAdd", body: body);
                //channel.Close();
            }
            //connection.Close();
            
        }
    }
}
