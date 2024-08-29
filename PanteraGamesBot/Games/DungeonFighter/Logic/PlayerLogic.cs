using PanteraGamesBot.Games.DungeonFighter.Data;

namespace PanteraGamesBot.Games.DungeonFighter.Logic;

internal class PlayerLogic
{
    
    internal static string PlayerAttack(string enemyName)
    {
        int[] damage = PlayerData.GetPlayerAttack();
        
        int rndDamage = RandomNumberGenerator(min: damage[0], max: damage[1]);
        
        EnemyData.EnemyTakingDamage(damage: rndDamage);

        return $"Вы атакуете {enemyName} на {rndDamage} урона";
    }

    private static int RandomNumberGenerator(int min, int max)
    {
        Random random = new Random();
        return random.Next(min, max);
    }
}