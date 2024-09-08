using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace PanteraGamesBot.Games.DungeonFighter;

internal static class Interface
{
    internal static string[] TextAlignment(string name, int[] stats)
    {
        string statsString = $"HP: {stats[0]} MP: {stats[1]}";
            
        int ident1 = Math.Abs((name.Length - statsString.Length) / 2);
        int ident2 = Math.Abs((name.Length - statsString.Length) % 2 == 0 ? ident1 : ident1 - 1);
        
        string[] idents = new[] {new string(' ', count: ident1), new string(' ', count: ident2)};

        
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
        return $"<code>\u2800{playerStatsText[0]} | {enemyStatsText[0]}</code>\n" +
               $"<code>\u2800{playerStatsText[1]} | {enemyStatsText[1]}</code>\n" +
               $"{replicas[0]}\n" +
               $"{replicas[1]}";
    }

    internal static async void MakeInlineKeyboard(ITelegramBotClient client, Update update, string text)
    {
            await client.SendTextMessageAsync(
                chatId: update.Message?.Chat.Id ?? 6940868301,
                text: text,
                replyMarkup: CreatePlayInlineKeyboard(),
                parseMode: ParseMode.Html);
    }

    internal static async void EditInlineKeyboard(ITelegramBotClient client, Update update, string text, bool deathTrue = false)
    {
        InlineKeyboardMarkup? replyMarkup;
        
        if (!deathTrue)
        {
            replyMarkup = (InlineKeyboardMarkup?)CreatePlayInlineKeyboard();
        }
        else
        {
            replyMarkup = (InlineKeyboardMarkup?)CreateDeathInlineKeyboard();
        }
        
        try
        {
            await client.EditMessageTextAsync(
            chatId: update.CallbackQuery?.Message?.Chat.Id ?? 6940868301,
            messageId: update.CallbackQuery?.Message?.MessageId ?? 0,
            text: text,
            replyMarkup: replyMarkup,
            parseMode: ParseMode.Html);
        }
        catch (Exception)
        {
            EditInlineKeyboard(
                client: client,
                update: update,
                text: text + " ");
        }
    }

    private static IReplyMarkup CreatePlayInlineKeyboard()
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
    
    private static IReplyMarkup CreateDeathInlineKeyboard()
    {
        InlineKeyboardButton[][] inlineKeyboard =
        [
            new []
            {
                InlineKeyboardButton.WithCallbackData(text: "Новая игра", callbackData: "new-game")
            },
        ];
            
        InlineKeyboardMarkup inlineKeyboardMarkup = new(inlineKeyboard: inlineKeyboard);
            
        return inlineKeyboardMarkup;
    }
}