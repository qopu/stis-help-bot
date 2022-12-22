using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Types;
using stis_help_bot.Handler;
using User = stis_help_bot.Handler.User;

namespace stis_help_bot.Commands;

public class Unknown
{
    public static async void UnknownCommand(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken, User user, UserMessage message)
    {
        await botClient.SendTextMessageAsync(
            chatId: user.Id,
            text: "Команда не найдена!",
            replyMarkup: Keyboards.MainMenu,
            cancellationToken: cancellationToken);
    }
}