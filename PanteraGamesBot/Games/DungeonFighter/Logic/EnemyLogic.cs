using PanteraGamesBot.Games.DungeonFighter.Data;

namespace PanteraGamesBot.Games.DungeonFighter.Logic;

internal static class EnemyLogic
{
    internal static string AiAction(string name)
    {
        if (PlayerData.GetPlayerTreatmentCounter() >= 4 && RandomChanceGenerator(chance: 0.2f) || RandomChanceGenerator(chance: 0.1f))
        {
            return EnemySpecialAttack(name: name);
        }
        
        if (EnemyData.GetEnemyHp() <= 10 && EnemyData.GetEnemyMp() > 4 || RandomChanceGenerator(chance: 0.4f))
        {
            return EnemyTreatment(name: name);
        }

        if (EnemyData.GetEnemyMp() <= 5 && RandomChanceGenerator(chance: 0.6f))
        {
            return EnemyStealMp(name: name);
        }
        
        return EnemyAttack(name: name);
    }

    private static string EnemyAttack(string name)
    {
        int[] damage = EnemyData.GetEnemyAttack();
        int rndDamage = RandomNumberGenerator(min: damage[0], max: damage[1]);
        
        PlayerData.SetPlayerSubtractHp(subtractHp: rndDamage);

        return $"{name} атакует вас и наносит вам {rndDamage} урона";
    }
    
    private static string EnemySpecialAttack(string name)
    {
        int[] damage = EnemyData.GetSpecialEnemyAttack();
        int rndDamage = RandomNumberGenerator(min: damage[0], max: damage[1]);
        
        PlayerData.SetPlayerSubtractHp(subtractHp: rndDamage);

        return $"{name} бьет по вам со всей силы и наносит вам {rndDamage} урона";
    }
    
    private static string EnemyTreatment(string name)
    {
        int treatment = EnemyData.GetEnemyTreatment();
        
        EnemyData.SetEnemyAddsHp(addHp: treatment);
        EnemyData.SetEnemySubtractMp(subtractMp: treatment);
        
        return $"{name} использует {treatment} маны, чтобы исцелить {treatment} урона";
    }

    private static string EnemyStealMp(string name)
    {
        int stealMp = EnemyData.GetEnemyStealMp();
        
        PlayerData.SetPlayerSubtractMp(subtractMp: stealMp);
        EnemyData.SetEnemyAddsMp(addMp: stealMp);
        
        return $"{name} ворует у вас {stealMp} маны";
    }
    
    private static int RandomNumberGenerator(int min, int max)
    {
        Random random = new Random();
        return random.Next(minValue: min, maxValue: max + 1);
    }
    
    private static bool RandomChanceGenerator(float chance)
    {
        Random random = new Random();

        if (chance >= random.NextDouble())
        {
            return true;
        }
        return false;
    }
}