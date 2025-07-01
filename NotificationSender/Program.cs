using Telegram.Bot.Polling;
using Telegram.Bot.Types.Enums;
using Telegram.Bot;
using NotificationSender.Application;
using Telegram.Bot.Types;

var builder = WebApplication.CreateBuilder(args);

// ��������� �������
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ������������ Telegram ���� � �����������
builder.Services.AddSingleton<ITelegramBotClient>(_ =>
    new TelegramBotClient("8192162781:AAF1tzdsmeqc96-EmQkzC7OUsDrleBVega4"));
builder.Services.AddSingleton<ITelegramBotService, TelegramBotHandlers>();


var app = builder.Build();

// ����������� �������� HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

// ��������� Telegram ����
var botClient = app.Services.GetRequiredService<ITelegramBotClient>();
var botHandlerUpdate = app.Services.GetRequiredService<ITelegramBotService>();
var lifetime = app.Services.GetRequiredService<IHostApplicationLifetime>();



var receiverOptions = new ReceiverOptions
{
    AllowedUpdates = Array.Empty<UpdateType>(),
    ThrowPendingUpdates = true,
};

botClient.StartReceiving(
    updateHandler: HandleUpdateAsync,
    pollingErrorHandler: HandleErrorAsync,
    receiverOptions: receiverOptions,
    cancellationToken: lifetime.ApplicationStopping
);

// ��������� �������-��������
async Task HandleUpdateAsync(ITelegramBotClient client, Update update, CancellationToken ct)
    => await botHandlerUpdate.HandleUpdateAsync(client, update, ct);

async Task HandleErrorAsync(ITelegramBotClient client, Exception error, CancellationToken ct)
    => await botHandlerUpdate.HandleErrorAsync(client, error, ct);

// �������� ���������� � ����
var me = await botClient.GetMeAsync();

app.Logger.LogInformation($"Telegram bot {me.FirstName} �������");

app.Run();