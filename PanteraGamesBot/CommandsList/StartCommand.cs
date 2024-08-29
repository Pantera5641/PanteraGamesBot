using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

using PanteraGamesBot.Config;

namespace PanteraGamesBot.CommandsList;

internal abstract class StartCommand
{
    internal static async void OnMessageStart(ITelegramBotClient client, Update update)
    {
        if (Switcher.GetStart() && update.Message?.Type == MessageType.Text)
            switch (update.Message?.Text?.ToLower())
            {
                case "/start":
                    await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 6940868301,
                        text: Text(),
                        replyMarkup: new ReplyKeyboardRemove());
                    break;

                case "/cancel":
                    await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 6940868301,
                        text: "Ты собственно ничего и не делал");
                    Switcher.OffAll();
                    break;

                default:
                        //Заглушка, поменять на json
                        await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 6940868301,
                            text: "Вы можете обратиться к команде /help.");
                    break;
            }
    }
    
    //Заглушка, поменять на json
    private static string Text()
    {
        return "[n-time]";
    }
}