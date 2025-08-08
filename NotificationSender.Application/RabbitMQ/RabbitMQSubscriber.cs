using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace NotificationSender.Application.RabbitMQ
{
    public class RabbitMQSubscriber : IDisposable
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private const string ExchangeName = "notifications_exchange";
        private string _queueName;

        public RabbitMQSubscriber(string hostName)
        {
            var factory = new ConnectionFactory() 
            { 
               HostName = "localhost",
               UserName = "user",
               Password = "12345",

            };
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();

            _channel.ExchangeDeclare(exchange: ExchangeName, type: ExchangeType.Fanout);

            // Создаем временную очередь с уникальным именем
            _queueName = _channel.QueueDeclare().QueueName;

            // Привязываем очередь к exchange
            _channel.QueueBind(
                queue: _queueName,
                exchange: ExchangeName,
                routingKey: ""); // Для fanout не важно
        }

        public void StartConsuming(Action<object> handleNotification)
        {
            var consumer = new EventingBasicConsumer(_channel);

            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                var notification = JsonConvert.DeserializeObject<object>(message);

                handleNotification(notification);
            };

            _channel.BasicConsume(
                queue: _queueName,
                autoAck: true,
                consumer: consumer);
        }

        public void Dispose()
        {
            _channel?.Close();
            _connection?.Close();
        }
    }
}
