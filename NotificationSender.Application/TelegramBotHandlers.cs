using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types;
using Telegram.Bot;


namespace NotificationSender.Application
{
    public class TelegramBotHandlers : ITelegramBotService
    {
        private readonly ILogger<TelegramBotHandlers> _logger;

        public TelegramBotHandlers(ILogger<TelegramBotHandlers> logger)
        {
            _logger = logger;
        }

        

        public async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            // Обязательно ставим блок try-catch, чтобы наш бот не "падал" в случае каких-либо ошибок
            try
            {
                // Сразу же ставим конструкцию switch, чтобы обрабатывать приходящие Update
                switch (update.Type)
                {   
                    case UpdateType.Message:
                        {   
                            // эта переменная будет содержать в себе все связанное с сообщениями
                            var message = update.Message;

                            if (message.Text == "/start")
                            {
                                await botClient.SendTextMessageAsync(
                                    chatId: message.Chat.Id,
                                    text: $"Ваш ID: {message.Chat.Id}\nСохраните его для уведомлений");

                                
                            }
                            else
                            {    // From - это от кого пришло сообщение (или любой другой Update)
                                var user = message.From;

                                // Выводим на экран то, что пишут нашему боту, а также небольшую информацию об отправителе
                                _logger.LogInformation($"{user.FirstName} ({user.Id}) написал сообщение: {message.Text}");

                                // Chat - содержит всю информацию о чате
                                var chat = message.Chat;
                                await botClient.SendTextMessageAsync(
                                    chat.Id,
                                    message.Text, // отправляем то, что написал пользователь
                                    replyToMessageId: message.MessageId // по желанию можем поставить этот параметр, отвечающий за "ответ" на сообщение
                                    );


                            }
                           return;
                            
                        }
                }
            }
            catch (Exception ex)
            {
               _logger.LogError(ex.ToString());
            }
        }

        public Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            var errorMessage = exception switch
            {
                ApiRequestException apiRequestException
                    => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
                _ => exception.ToString()
            };

            _logger.LogError(errorMessage);
            return Task.CompletedTask;
        }
    }
}
