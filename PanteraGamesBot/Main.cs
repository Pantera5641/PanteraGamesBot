using PanteraGamesBot.CommandsList;
using PanteraGamesBot.Config;

namespace PanteraGamesBot;

internal static class Bot
{
    private static void Main()
    {
        Host panteraGamesBot = new Host("7271288966:AAHJKYaAFCPyILZ_a27w8TqkbL-RXexASMA");
        
        Console.WriteLine("Бот запущен.");
        
        panteraGamesBot.Start();
        
        panteraGamesBot.OnMessage += Switcher.OnMessageRoot;
        panteraGamesBot.OnMessage += StartCommand.OnMessageStart;
        panteraGamesBot.OnMessage += DungeonFighterCommand.OnMessageDungeonFighter;
        
        Thread.Sleep(Timeout.Infinite);
    }
}
