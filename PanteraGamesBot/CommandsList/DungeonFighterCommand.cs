using Telegram.Bot;
using Telegram.Bot.Types;

using PanteraGamesBot.Config;
using PanteraGamesBot.Games.DungeonFighter;

namespace PanteraGamesBot.CommandsList;

internal abstract class DungeonFighterCommand
{
    internal static async void OnMessageDungeonFighter(ITelegramBotClient client, Update update)
    {
        if (Switcher.GetDungeonFighter())
            switch (update.Message?.Text?.ToLower())
            {
                case "/dungeonfighter":
                    await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 6940868301, "Start a fight!",
                        replyMarkup: InterfaceLogic.MakeInlineKeyboard());
                    break;
            }

        switch (update.CallbackQuery?.Data)
        {
            case "attack":
                await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 6940868301, "Заглушка Атака!");
                break;
            
            case "treatment":
                await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 6940868301, "Заглушка Лечение");
                break;
            
            case "recharge":
                await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 6940868301, "Заглушка Перезарядка");
                break;
            
            case "new-game":
                await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 6940868301, "Заглушка Новая игра");
                break;
        }
    }
}