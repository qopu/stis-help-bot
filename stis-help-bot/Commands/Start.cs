using stis_help_bot.Handler;
using Telegram.Bot;
using Telegram.Bot.Types;
using User = stis_help_bot.Handler.User;

namespace stis_help_bot.Commands;

public class Start
{
    public static async void StartCommand(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken, User user, UserMessage message)
    {
        await botClient.SendTextMessageAsync(
            chatId: user.Id,
            text: "Привет!\nЭтот бот помогает с расписанием в ТИСе",
            replyMarkup: Keyboards.MainMenu,
            cancellationToken: cancellationToken);
    }
}