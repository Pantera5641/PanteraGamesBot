using PanteraGamesBot.Games.DungeonFighter.Data;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace PanteraGamesBot.Games.DungeonFighter.Logic;

internal static class GameLogic
{
    internal static void RootCommand(ITelegramBotClient client, Update update, string playerReplica = "")
    {
        string text;
        string enemyReplica = String.Empty;
        
        if (playerReplica != String.Empty)
            enemyReplica = EnemyLogic.AiAction(name: EnemyData.GetEnemyName());
        
        string[] playerStatsText = Interface.TextAlignment(
            name: update.CallbackQuery?.From.FirstName ?? update.Message?.From?.FirstName ?? "Игрок",
            stats: PlayerData.GetPlayerStats());
        
        string[] enemyStatsText = Interface.TextAlignment(
            name: EnemyData.GetEnemyName(), 
            stats: EnemyData.GetEnemyStats());
        
        if (playerReplica == String.Empty)
        {
            text = Interface.TextMaker(
                playerStatsText: playerStatsText,
                enemyStatsText: enemyStatsText,
                replicas: [String.Empty, String.Empty]);
            
            Interface.MakeInlineKeyboard(
                client: client,
                update: update,
                text: text);
        }
        else
        { 
            text = Interface.TextMaker(
                playerStatsText: playerStatsText,
                enemyStatsText: enemyStatsText,
                replicas: [playerReplica, enemyReplica]);
            
            Interface.EditInlineKeyboard(
                client: client,
                update: update,
                text: text);
        }
    }

    internal static void AttackCommand(ITelegramBotClient client, Update update)
    {
       string playerReplica = PlayerLogic.PlayerAttack(enemyName: EnemyData.GetEnemyName());
       
       RootCommand(
           client: client,
           update: update,
           playerReplica: playerReplica
           );
    }

    internal static void TreatmentCommand(ITelegramBotClient client, Update update)
    {
        string playerReplica = PlayerLogic.PlayerTreatment();
        
        RootCommand(
            client: client,
            update: update,
            playerReplica: playerReplica
        );
    }
    
    internal static void RechargeCommand(ITelegramBotClient client, Update update)
    {
        string playerReplica = PlayerLogic.PlayerRecharge();
        
        RootCommand(
            client: client,
            update: update,
            playerReplica: playerReplica
        );
    }
}