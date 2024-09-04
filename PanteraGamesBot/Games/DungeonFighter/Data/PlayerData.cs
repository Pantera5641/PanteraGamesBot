namespace PanteraGamesBot.Games.DungeonFighter.Data;

internal static class PlayerData
{
    private static int _playerHp = 30;
    private static int _playerMp = 10;
    
    private static readonly int[] PlayerAttack = [3, 5];
    private static readonly int[] PlayerTreatment = [6, 7];
    private static readonly int[] PlayerSubtractMp = [1, 2];
    private static readonly int[] PlayerRecharge = [4, 6];
    
    private static int _treatmentCounter;

    
    internal static int[] GetPlayerStats()
    {
        return new int[] { _playerHp, _playerMp };
    }
    
    internal static int GetPlayerHp()
    {
        return _playerHp;
    }
    
    internal static int GetPlayerMp()
    {
        return _playerMp;
    }
    
    internal static int[] GetPlayerAttack()
    {
        return PlayerAttack;
    }
    
    internal static int[] GetPlayerTreatment()
    {
        return PlayerTreatment;
    }
    
    internal static int[] GetPlayerRecharge()
    {
        return PlayerRecharge;
    }
    
    internal static int[] GetPlayerSubtractMp()
    {
        return PlayerSubtractMp;
    }

    internal static int GetPlayerTreatmentCounter()
    {
        return _treatmentCounter;
    }
    
    internal static void PlayerTreatmentCounterPlus()
    {
        _treatmentCounter += 1;
    }

    internal static void PlayerTreatmentCounterDelete()
    {
        _treatmentCounter = 0;
    }

    internal static void SetPlayerAddsHp(int addsHp)
    {
        _playerHp += addsHp;
        
        if (_playerHp > 30)
        {
            _playerHp = 30;
        }
    }
    
    internal static void SetPlayerAddsMp(int addsMp)
    {
        _playerMp += addsMp;
        
        if (_playerMp > 10)
        {
            _playerMp = 10;
        }
    }
    
    internal static void SetPlayerSubtractHp(int subtractHp)
    {
        _playerHp -= subtractHp;
        
        if (_playerHp < 0)
        {
            _playerHp = 0;
        }
    }
    
    internal static void SetPlayerSubtractMp(int subtractMp)
    {
        _playerMp -= subtractMp;
        
        if (_playerMp < 0)
        {
            _playerMp = 0;
        }
    }
    
    internal static void Reset()
    {
        _playerHp = 30;
        _playerMp = 10;
    }
}