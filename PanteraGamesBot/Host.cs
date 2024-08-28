using Telegram.Bot;
using Telegram.Bot.Types;

namespace PanteraGamesBot;

public class Host
{
    public Action<ITelegramBotClient, Update>? OnMessage;
    
    private readonly TelegramBotClient _bot;

    internal Host(string token)
    {
        _bot = new TelegramBotClient(token);
        Console.WriteLine("Запуск...");
    }

    internal void Start()
    {
        _bot.StartReceiving(UpdateHandler, ErrorHandler);
    }
    
    private async Task UpdateHandler(ITelegramBotClient client, Update update, CancellationToken token)
    {
        Console.WriteLine($"Пришло сообщение: {update.Message?.Text ?? "[не текст]"}");
        
        OnMessage?.Invoke(client, update);
        
        await Task.CompletedTask;
    }
    
    private async Task ErrorHandler(ITelegramBotClient client, Exception exception, CancellationToken token)
    {
        Console.WriteLine($"Ошибка:{exception}");
        await Task.CompletedTask;
    }
}