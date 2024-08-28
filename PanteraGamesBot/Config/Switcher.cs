using Telegram.Bot;
using Telegram.Bot.Types;

namespace PanteraGamesBot.Config;

internal static class Switcher
{
    private static bool _startSwitch;
    private static bool _dungeonFighterSwitch;

    internal static void OnMessageRoot(ITelegramBotClient client, Update update)
    {
        switch (update.Message?.Text?.ToLower())
        {
            case "/start":
                Start();
                break;

            case "/dungeonfighter":
                DungeonFighter();
                break;
        }
    }

    private static void Start()
    {
        OffAll();
        _startSwitch = true;
    }

    internal static bool GetStart()
    {
        return _startSwitch;
    }
    
    private static void DungeonFighter()
    {
        OffAll();
        _dungeonFighterSwitch = true;
    }
    
    internal static bool GetDungeonFighter()
    {
        return _dungeonFighterSwitch;
    }
    
    internal static void OffAll()
    {
         _startSwitch = false;
         _dungeonFighterSwitch = false;
    }
}