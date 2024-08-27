using PanteraGamesBot.CommandsList;
using PanteraGamesBot.Config;

namespace PanteraGamesBot;

internal class Bot
{
    private static void Main()
    {
        Host panteragamesbot = new Host("7271288966:AAHJKYaAFCPyILZ_a27w8TqkbL-RXexASMA");
        
        Console.WriteLine("Бот запущен.");
        
        panteragamesbot.Start();
        
        panteragamesbot.OnMessage += Switcher.OnMessageRoot;
        panteragamesbot.OnMessage += StartCommand.OnMessageStart;
        panteragamesbot.OnMessage += MenuCommand.OnMessageMenu;
        
        Thread.Sleep(Timeout.Infinite);
    }
}
