using Microsoft.Extensions.Hosting;
using NotificationSender.Application.RabbitMQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationSender.Application
{
    public class NotificationBackgroundService : BackgroundService
    {
        private readonly RabbitMQSubscriber _subscriber;
        private readonly ITelegramBotService _telegramBotService;

        public NotificationBackgroundService(ITelegramBotService telegramBotService)
        {
            _subscriber = new RabbitMQSubscriber("localhost");
            _telegramBotService = telegramBotService;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _subscriber.StartConsuming(notification =>
            {
                _telegramBotService.SendNotificationAsync($"🛒 Выбран товар:  {notification}");
            });

            return Task.CompletedTask;
        }

        public override void Dispose()
        {
            _subscriber.Dispose();
            base.Dispose();
        }
    }
}
