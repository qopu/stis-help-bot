using stis_help_bot.Handler;
using Telegram.Bot;
using Telegram.Bot.Types;
using User = stis_help_bot.Handler.User;

namespace stis_help_bot.Commands;

public class BackToMenu
{
    public static async void BackToMenuCommand(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken, User user, UserMessage message)
    {
        await botClient.SendTextMessageAsync(
            chatId: user.Id,
            text: "Возвращаюсь в главное меню...",
            replyMarkup: Keyboards.MainMenu,
            cancellationToken: cancellationToken);
    }
}