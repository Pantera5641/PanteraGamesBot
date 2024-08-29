using PanteraGamesBot.Games.DungeonFighter.Data;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace PanteraGamesBot.Games.DungeonFighter.Logic;

internal class GameLogic
{
    internal static void AttackCommand(ITelegramBotClient client, Update update)
    {
       string playerReplica = PlayerLogic.PlayerAttack(enemyName: EnemyData.GetEnemyName());
       string[] playerStatsText = Interface.TextAlignment(
           name: update.Message?.From?.FirstName ?? "Игрок",
           stats: PlayerData.GetPlayerStats());

       string enemyReplica = "no replica"; //получение реплики монстра и тд
       string[] enemyStatsText = Interface.TextAlignment(
           name: EnemyData.GetEnemyName(), 
           stats: EnemyData.GetEnemyStats());
       
       string text = Interface.TextMaker(
           playerStatsText: playerStatsText,
           enemyStatsText: enemyStatsText,
           replicas: [playerReplica, enemyReplica]);
       
       Interface.EditInlineKeyboard(
           client: client,
           update: update,
           text: text);
    }
}