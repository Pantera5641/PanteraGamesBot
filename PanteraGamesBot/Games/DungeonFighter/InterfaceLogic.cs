using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace PanteraGamesBot.Games.DungeonFighter;

internal static class InterfaceLogic
{
    internal static IReplyMarkup MakeInlineKeyboard()
    {
        InlineKeyboardButton[][] inlineKeyboard =
        [
            new []
            {
                InlineKeyboardButton.WithCallbackData("Атака!", "attack"),
                InlineKeyboardButton.WithCallbackData("Лечение", "treatment"),
                InlineKeyboardButton.WithCallbackData("Перезарядка", "recharge"),
            },
            new []
            {
                InlineKeyboardButton.WithCallbackData("Новая игра", "new-game")
            },
        ];
        
        InlineKeyboardMarkup inlineKeyboardMarkup = new(inlineKeyboard: inlineKeyboard);
        
        return inlineKeyboardMarkup;
    }
    
    /*
     Как-то это починить
    internal static async void EditAfterAttack(ITelegramBotClient client, Update update)
    {
        await client.EditMessageReplyMarkupAsync(
            chatId: update.Message?.Chat.Id,
            messageId: update.Message?.MessageId,
            replyMarkup: MakeInlineKeyboard());
    }
    */
}