using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace PanteraGamesBot.Games.DungeonFighter;

internal static class Interface
{
    internal static string[] TextAlignment(string name, int[] stats)
    {
        string statsString = $"HP:\u2800{stats[0]}\u2800MP:\u2800{stats[1]}";
            
        int ident1 = Math.Abs((name.Length - statsString.Length) / 2);
        int ident2 = 
            Math.Abs(name.Length - statsString.Length) % 2 == 0 ? ident1 : ident1 - 1;
        
        string[] idents = new[] {new string('\u2800', count: ident1), new string('\u2800', count: ident2)};

        
        if (name.Length < statsString.Length)
        {
            name = $"{idents[0]}{name}{idents[1]}";
        }
        else
        {
            statsString = $"{idents[0]}{statsString}{idents[1]}";
        }
        
        return new[] { name, statsString };
    }

    internal static string TextMaker(string[] playerStatsText, string[] enemyStatsText, string[] replicas)
    {
        return $"{playerStatsText[0]}\u2800|\u2800{enemyStatsText[0]}\n" +
               $"{playerStatsText[1]}\u2800  |\u2800{enemyStatsText[1]}\n" +
               $"{replicas[0]}\n" +
               $"{replicas[1]}";
    }
    
    internal static async void EditInlineKeyboard(ITelegramBotClient client, Update update, string text)
    {
        try
        {
            await client.EditMessageTextAsync(
            chatId: update.Message?.Chat.Id ?? 6940868301,
            messageId: update.CallbackQuery?.Message?.MessageId ?? 0,
            text: text,
            replyMarkup: (InlineKeyboardMarkup?)MakeInlineKeyboard());
        }
        catch (Exception e)
        {
            EditInlineKeyboard(client: client,
                update: update,
                text: text + "\u2800");
        }
    }
    
    internal static IReplyMarkup MakeInlineKeyboard()
        {
            InlineKeyboardButton[][] inlineKeyboard =
            [
                new []
                {
                    InlineKeyboardButton.WithCallbackData(text: "Атака!", callbackData: "attack"),
                    InlineKeyboardButton.WithCallbackData(text: "Лечение", callbackData: "treatment"),
                    InlineKeyboardButton.WithCallbackData(text: "Перезарядка", callbackData: "recharge"),
                },
                new []
                {
                    InlineKeyboardButton.WithCallbackData(text: "Новая игра", callbackData: "new-game")
                },
            ];
            
            InlineKeyboardMarkup inlineKeyboardMarkup = new(inlineKeyboard: inlineKeyboard);
            
            return inlineKeyboardMarkup;
        }
}