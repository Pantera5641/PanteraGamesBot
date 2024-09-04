using Telegram.Bot;
using Telegram.Bot.Types;

using PanteraGamesBot.Games.DungeonFighter.Data;

namespace PanteraGamesBot.Games.DungeonFighter.Logic;

internal static class GameLogic
{
    internal static void RootCommand(ITelegramBotClient client, Update update, string playerReplica = "")
    {
        string enemyReplica = String.Empty;
        
        if (playerReplica != String.Empty)
            enemyReplica = EnemyLogic.AiAction(name: EnemyData.GetEnemyName());
        
        if (PlayerData.GetPlayerHp() <= 0 || PlayerData.GetPlayerMp() <= 0)
        {
            PlayerLogic.PlayerDeath(
                client: client,
                update: update);
            
            ResetGame();
            return;
        }
        
        if (EnemyData.GetEnemyHp() <= 0 || EnemyData.GetEnemyMp() <= 0)
        {
            EnemyLogic.EnemyDeath(
                client: client,
                update: update,
                name: EnemyData.GetEnemyName());
            
            ResetGame();
            return;
        }
        
        string[] playerStatsText = Interface.TextAlignment(
            name: update.CallbackQuery?.From.FirstName ?? update.Message?.From?.FirstName ?? "Игрок",
            stats: PlayerData.GetPlayerStats());
        
        string[] enemyStatsText = Interface.TextAlignment(
            name: EnemyData.GetEnemyName(), 
            stats: EnemyData.GetEnemyStats());
        
        string text = Interface.TextMaker(
            playerStatsText: playerStatsText,
            enemyStatsText: enemyStatsText,
            replicas: [playerReplica, enemyReplica]);
        
        if (playerReplica == String.Empty)
        {
            Interface.MakeInlineKeyboard(
                client: client,
                update: update,
                text: text);
        }
        else
        { 
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

    private static void ResetGame()
    {
        PlayerData.Reset();
        EnemyData.Reset();
    }
}