using Newtonsoft.Json;
using OnlineShop.Application.DTOs;
using OnlineShop.Application.RabbitMQSender.Model;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace OnlineShop.Application.RabbitMQSender
{
    public class RabbitMQCartMessageSender
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private const string ExchangeName = "notifications_exchange";

        public RabbitMQCartMessageSender(string hostName)
        {
            var factory = new ConnectionFactory() 
            {
                HostName = "localhost",
                UserName = "user",
                Password = "12345",

            };
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();

            // Создаем exchange типа fanout (можно использовать direct/topic в зависимости от потребностей)
            _channel.ExchangeDeclare(exchange: ExchangeName, type: ExchangeType.Fanout);
        }

        public void PublishNotification(object notification)
        {
            var message = JsonConvert.SerializeObject(notification);
            var body = Encoding.UTF8.GetBytes(message);

            _channel.BasicPublish(
                exchange: ExchangeName,
                routingKey: "", // Для fanout не важно
                basicProperties: null,
                body: body);
        }

        public void Dispose()
        {
            _channel?.Close();
            _connection?.Close();
        }
    }
}
