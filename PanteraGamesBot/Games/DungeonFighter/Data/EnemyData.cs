namespace PanteraGamesBot.Games.DungeonFighter.Data;

internal static class EnemyData
{
    private static readonly string EnemyName = "EnemyName";
    
    private static int _enemyHp = 45;
    private static int _enemyMp = 20;
    
    private static readonly int[] EnemyAttack = [3, 5];
    private static readonly int[] EnemySpecialAttack = [6, 7];
    private static readonly int EnemyTreatment = 4;
    private static readonly int EnemyStealMp = 2;


    internal static string GetEnemyName()
    {
        return EnemyName;
    }
    
    internal static int[] GetEnemyStats()
    {
        return new int[] { _enemyHp, _enemyMp };
    }
    
    internal static int GetEnemyHp()
    {
        return _enemyHp;
    }
    
    internal static int GetEnemyMp()
    {
        return _enemyMp;
    }
    
    internal static int[] GetEnemyAttack()
    {
        return EnemyAttack;
    }
    
    internal static int[] GetSpecialEnemyAttack()
    {
        return EnemySpecialAttack;
    }
    
    internal static int GetEnemyTreatment()
    {
        return EnemyTreatment;
    }
    
    internal static int GetEnemyStealMp()
    {
        return EnemyStealMp;
    }
    
    internal static void SetEnemyAddsHp(int addHp)
    {
        _enemyHp += addHp;
            
        if (_enemyHp > 45)
        {
            _enemyHp = 45;
        }
    }
    
    internal static void SetEnemyAddsMp(int addMp)
    {
        _enemyMp += addMp;
            
        if (_enemyMp > 45)
        {
            _enemyMp = 45;
        }
    }
    
    internal static void SetEnemySubtractHp(int subtractHp)
    {
        _enemyHp -= subtractHp;
        
        if (_enemyHp < 0)
        {
            _enemyHp = 0;
        }
    }
    
    internal static void SetEnemySubtractMp(int subtractMp)
    {
        _enemyMp -= subtractMp;
        
        if (_enemyMp < 0)
        {
            _enemyMp = 0;
        }
    }
}