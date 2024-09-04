using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

using PanteraGamesBot.Config;
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
                    GameLogic.RootCommand(
                        client: client,
                        update: update);
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
                GameLogic.TreatmentCommand(
                    client: client,
                    update: update);
                break;
            
            case "recharge":
                GameLogic.RechargeCommand(
                    client: client,
                    update: update);
                break;
            
            case "new-game":
                await client.SendTextMessageAsync(update.CallbackQuery?.Message?.Chat.Id ?? 6940868301, "Временно не работает");
                break;
        }
    }
}