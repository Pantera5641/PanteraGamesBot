namespace PanteraGamesBot.Games.DungeonFighter.Data;

internal static class EnemyData
{
    private static readonly string EnemyName = "EnemyName";
    
    private static int _enemyHP = 45;
    private static int _enemyMP = 20;
    
    private static int _enemyAttack;
    private static int _enemyTreatment;
    private static int _enemyLostMP;
    private static int _enemyAcquiredMP;


    internal static string GetEnemyName()
    {
        return EnemyName;
    }
    
    internal static int[] GetEnemyStats()
    {
        return new int[] { _enemyHP, _enemyMP };
    }
    
    internal static int GetEnemyHp()
    {
        return _enemyHP;
    }
    
    internal static void EnemyTakingDamage(int damage)
    {
        _enemyHP = _enemyHP - damage;
        
        if (_enemyHP < 0)
        {
            _enemyHP = 0;
        }
    }
}