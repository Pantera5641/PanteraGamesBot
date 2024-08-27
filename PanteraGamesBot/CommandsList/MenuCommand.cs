using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

using PanteraGamesBot.Config;

namespace PanteraGamesBot.CommandsList;

internal abstract class MenuCommand
{
    internal static async void OnMessageMenu(ITelegramBotClient client, Update update)
    {
        if (Switcher.GetMenu())
            switch (update.Message?.Text?.ToLower())
            {
                case "/menu":
                    await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 6940868301, "Выбери:",
                        replyMarkup: MakeKeyboard());
                    break;
            
                case "top-left":
                    await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 6940868301, "its done",
                        replyMarkup: new ReplyKeyboardRemove());
                    break;
                
                default:
                    Console.WriteLine("Дефолт в меню");
                    break;
            }
    }

    private static IReplyMarkup MakeKeyboard()
    {
        //Придумать функционал, поменять все
        KeyboardButton[][] keyboard =
        [
            ["Top-Left", "Top", "Top-Right"],
            ["Left", "Center", "Right"],
            ["Bottom-Left", "Bottom", "Bottom-Right"],
        ];
        
        ReplyKeyboardMarkup replyMarkup = new(keyboard: keyboard)
        {
            ResizeKeyboard = true,
        };
        
        return replyMarkup;
    }
}