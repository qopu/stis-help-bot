using System.ComponentModel.Design;
using System.Globalization;
using stis_help_bot.Commands;
using stis_help_bot.Logs;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Types;
using stis_help_bot.Logs;

namespace stis_help_bot.Handler;

public static class Handler
{
    public static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        if (update.Message is not { Text: { } messageText } message || message.From == null)
        {
            return;
        }

        var user = new User(
                id: Convert.ToString(message.From.Id),
                nickname: Convert.ToString(message.From.Username),
                firstname: Convert.ToString(message.From.FirstName)
        );

        var msg = new UserMessage(
            id: Convert.ToString(message.MessageId),
            date: Convert.ToString(message.Date, CultureInfo.CurrentCulture),
            text: Convert.ToString(message.Text)
        );

        Logger.LogMessage(user: user, message: msg);

        switch (msg.Text.ToLower())
        {
            case ("/start"):
            {
                Start.StartCommand(botClient, update, cancellationToken, user: user, message: msg);
                break;
            }
            case ("узнать неделю"):
            {
                CheckWeek.CheckWeekCommand(botClient, update, cancellationToken, user: user, message: msg);
                break;
            }
            case ("узнать расписание"):
            {
                GetSchedule.GetScheduleCommand(botClient, update, cancellationToken, user: user, message: msg);
                break;
            }
            case ("1 курс"):
            {
                GetSchedule.GetScheduleFirst(botClient, update, cancellationToken, user: user, message: msg);
                break;
            }
            case ("2 курс"):
            {
                GetSchedule.GetScheduleSecond(botClient, update, cancellationToken, user: user, message: msg);
                break;
            }
            case ("3 курс"):
            {
                GetSchedule.GetScheduleThird(botClient, update, cancellationToken, user: user, message: msg);
                break;
            }
            case ("4 курс"):
            {
                GetSchedule.GetScheduleFourth(botClient, update, cancellationToken, user: user, message: msg);
                break;
            }
            case ("⬅️ назад в меню"):
            {
                BackToMenu.BackToMenuCommand(botClient, update, cancellationToken, user: user, message: msg);
                break;
            }
            default:
            {
                Unknown.UnknownCommand(botClient, update, cancellationToken, user: user, message: msg);
                break;
            }
        }
    }    
    
    public static Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
    {
        var errorMessage = exception switch
        {
            ApiRequestException apiRequestException
                => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
            _ => exception.ToString()
        };
    
        Console.WriteLine(errorMessage);
        return Task.CompletedTask;
    }
}