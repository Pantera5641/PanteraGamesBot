using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

using PanteraGamesBot.Config;

namespace PanteraGamesBot.CommandsList;

internal abstract class MenuCommand
{
    internal static async void OnMessageMenu(ITelegramBotClient client, Update update)
    {
        if (Switcher.GetDungeonFighter())
            switch (update.Message?.Text?.ToLower())
            {
                case "/menu":
                    await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 6940868301, "Выбери:",
                        replyMarkup: MakeInlineKeyboard());
                    break;
                
                case "/cancel":
                    await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 6940868301,
                        text: "Я так и знал что ты не одолеешь меня");
                    
                    //метод удаляющий игру
                    
                    Switcher.OffAll();
                    break;
                
                default:
                    await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 6940868301,
                        text: "Вы можете обратиться к команде /help.");
                    break;
            }

        switch (update.CallbackQuery?.Data)
        {
            case "Атака!":
                await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 6940868301, "Выбери:");
                break;
            
            case "Лечение":
                await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 6940868301, "Выбери:");
                break;
            
            case "Перезарядка":
                await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 6940868301, "Выбери:");
                break;
            
            case "Новая игра":
                await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 6940868301, "Выбери:");
                break;
        }
    }

    private static IReplyMarkup MakeInlineKeyboard()
    {
        InlineKeyboardButton[][] inlineKeyboard =
        [
            //Как-нибудь исправить подчеркивание
            ["Атака!", "Лечение", "Перезарядка"],
            ["Новая игра"]
        ];
        
        InlineKeyboardMarkup inlineKeyboardMarkup = new InlineKeyboardMarkup(inlineKeyboard);
        
        return inlineKeyboardMarkup;
    }
}