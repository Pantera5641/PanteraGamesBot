namespace PanteraGamesBot.Games.DungeonFighter.Data;

internal class PlayerData
{
    private static int _playerHP = 30;
    private static int _playerMP = 10;
    
    private static readonly int[] PlayerAttack = [3, 5];
    private static int _playerTreatment;
    private static int _playerLostMP;
    private static int _playerAcquiredMP;
    
    private static int _treatmentCounter;

    
    internal static int[] GetPlayerStats()
    {
        return new int[] { _playerHP, _playerMP };
    }
    internal static int[] GetPlayerAttack()
    {
        return PlayerAttack;
    }
}