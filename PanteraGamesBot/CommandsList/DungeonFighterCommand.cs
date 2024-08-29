using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

using PanteraGamesBot.Config;
using PanteraGamesBot.Games.DungeonFighter;
using PanteraGamesBot.Games.DungeonFighter.Logic;

namespace PanteraGamesBot.CommandsList;

internal abstract class DungeonFighterCommand
{
    internal static async void OnMessageDungeonFighter(ITelegramBotClient client, Update update)
    {
        if (Switcher.GetDungeonFighter() && update.Message?.Type == MessageType.Text)
            switch (update.Message?.Text?.ToLower())
            {
                case "/dungeonfighter":
                    await client.SendTextMessageAsync(update.Message?.Chat.Id ?? 6940868301, "Start a fight!",
                        replyMarkup: Interface.MakeInlineKeyboard());
                    break;
            }
        
        switch (update.CallbackQuery?.Data)
        { 
            case "attack":
                GameLogic.AttackCommand(
                    client: client,
                    update: update);
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