using Telegram.Bot;
using Telegram.Bot.Types;

namespace PanteraGamesBot.Config;

internal static class Switcher
{
    private static bool _startSwitch;
    private static bool _menuSwitch;

    internal static void OnMessageRoot(ITelegramBotClient client, Update update)
    {
        switch (update.Message?.Text?.ToLower())
        {
            case "/start":
                Start();
                break;

            case "/menu":
                Menu();
                break;
        }
    }
    
    internal static void Start()
    {
        OffAll();
        _startSwitch = true;
    }

    internal static bool GetStart()
    {
        return _startSwitch;
    }
    
    private static void Menu()
    {
        OffAll();
        _menuSwitch = true;
    }
    
    internal static bool GetMenu()
    {
        return _menuSwitch;
    }
    
    private static void OffAll()
    {
         _startSwitch = false;
         _menuSwitch = false;
    }
}