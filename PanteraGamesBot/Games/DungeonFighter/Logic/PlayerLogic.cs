using Telegram.Bot;
using Telegram.Bot.Types;

using PanteraGamesBot.Games.DungeonFighter.Data;

namespace PanteraGamesBot.Games.DungeonFighter.Logic;

internal static class PlayerLogic
{
    
    internal static string PlayerAttack(string enemyName)
    {
        PlayerData.PlayerTreatmentCounterDelete();
        
        int[] damage = PlayerData.GetPlayerAttack();
        int rndDamage = RandomNumberGenerator(min: damage[0], max: damage[1]);
        
        EnemyData.SetEnemySubtractHp(subtractHp: rndDamage);

        return $"Вы атакуете {enemyName} на {rndDamage} урона";
    }
    
    internal static string PlayerTreatment()
    {
        PlayerData.PlayerTreatmentCounterPlus();
        
        int[] treatment = PlayerData.GetPlayerTreatment();
        int rndTreatment = RandomNumberGenerator(min: treatment[0], max: treatment[1]);
        
        int[] subtractMp = PlayerData.GetPlayerSubtractMp();
        int rndSubtractMp = RandomNumberGenerator(min: subtractMp[0], max: subtractMp[1]);
        
        PlayerData.SetPlayerAddsHp(addsHp: rndTreatment);
        PlayerData.SetPlayerSubtractMp(subtractMp: rndSubtractMp);

        return $"Вы используете {rndSubtractMp} маны, чтобы исцелить {rndTreatment} урона";
    }
    
    internal static string PlayerRecharge()
    {
        PlayerData.PlayerTreatmentCounterDelete();
        
        int[] recharge = PlayerData.GetPlayerRecharge();
        int rndRecharge = RandomNumberGenerator(min: recharge[0], max: recharge[1]);
        
        PlayerData.SetPlayerAddsMp(addsMp: rndRecharge);
            
        return $"Вы перезаряжаете {rndRecharge} магии";
    }

    internal static void PlayerDeath(ITelegramBotClient client, Update update)
    {
        string text = "вы умерли";
        
        Interface.EditInlineKeyboard(
            client: client,
            update: update,
            text: text,
            deathTrue: true
            );
    }

    private static int RandomNumberGenerator(int min, int max)
    {
        Random random = new Random();
        return random.Next(min, max + 1);
    }
}