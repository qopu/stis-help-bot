using stis_help_bot.Handler;
using System.IO;
using System.IO;
using System.Net;
using Spire.Pdf;
using PuppeteerSharp;
using PuppeteerSharp.Input;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

using Telegram.Bot.Types.Passport;
using Telegram.Bot.Types.InlineQueryResults;
using User = stis_help_bot.Handler.User;

namespace stis_help_bot.Commands;

public class GetSchedule
{

    public static async void GetScheduleFirst(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken, User user, UserMessage message)
    {
        try
        {
            var httpClient = new HttpClient();
            using (var stream = await httpClient.GetStreamAsync("https://new.stis.su/assets/Schedule/ochnoe/1.20.09.22.pdf"))
            {
                using (var fileStream = new FileStream(@"..\..\..\Files\1 курс\Расписание.pdf", FileMode.CreateNew))
                {
                    await stream.CopyToAsync(fileStream);
                }
            }
        }
        catch (System.IO.IOException)
        {
            if(System.IO.File.Exists(@"..\..\..\Files\1 курс\Расписание.pdf"))
            {
                System.IO.File.Delete(@"..\..\..\Files\1 курс\Расписание.pdf");
            }
            var httpClient = new HttpClient();
            using (var stream = await httpClient.GetStreamAsync("https://new.stis.su/assets/Schedule/ochnoe/1.20.09.22.pdf"))
            {
                using (var fileStream = new FileStream(@"..\..\..\Files\1 курс\Расписание.pdf", FileMode.CreateNew))
                {
                    await stream.CopyToAsync(fileStream);
                }
            }
        }
        

        await using Stream week1 = System.IO.File.OpenRead(@"..\..\..\Files\1 курс\Расписание.pdf");
        var msg1 = await botClient.SendDocumentAsync(
            chatId: user.Id,
            document: new InputFile(content: week1, fileName: "Расписание.pdf"),
            caption: "Расписание на <b>1 и 2 неделю</b>",
            replyMarkup: Keyboards.GoBackMenu,
            cancellationToken: cancellationToken,
            parseMode: ParseMode.Html
        );
    }
    public static async void GetScheduleSecond(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken, User user, UserMessage message)
    {
        await using Stream week1 = System.IO.File.OpenRead(@"..\..\..\Files\2 Курс\1 неделя.png");
        var msg1 = await botClient.SendDocumentAsync(
            chatId: user.Id,
            document: new InputFile(content: week1, fileName: "1 неделя.jpg"),
            caption: "1 неделя",
            replyMarkup: Keyboards.GoBackMenu,
            cancellationToken: cancellationToken
        );
        
        await using Stream week2 = System.IO.File.OpenRead(@"..\..\..\Files\2 Курс\2 неделя.png");
        var msg2 = await botClient.SendDocumentAsync(
            chatId: user.Id,
            document: new InputFile(content: week2, fileName: "2 неделя.jpg"),
            caption: "2 неделя",
            replyMarkup: Keyboards.GoBackMenu,
            cancellationToken: cancellationToken
        );
    }
    public static async void GetScheduleThird(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken, User user, UserMessage message)
    {
        await using Stream week1 = System.IO.File.OpenRead(@"..\..\..\Files\3 Курс\1 неделя.png");
        var msg1 = await botClient.SendDocumentAsync(
            chatId: user.Id,
            document: new InputFile(content: week1, fileName: "1 неделя.jpg"),
            caption: "1 неделя",
            replyMarkup: Keyboards.GoBackMenu,
            cancellationToken: cancellationToken
        );
        
        await using Stream week2 = System.IO.File.OpenRead(@"..\..\..\Files\3 Курс\2 неделя.png");
        var msg2 = await botClient.SendDocumentAsync(
            chatId: user.Id,
            document: new InputFile(content: week2, fileName: "2 неделя.jpg"),
            caption: "2 неделя",
            replyMarkup: Keyboards.GoBackMenu,
            cancellationToken: cancellationToken
        );
    } 
    public static async void GetScheduleFourth(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken, User user, UserMessage message)
    {
        await using Stream week1 = System.IO.File.OpenRead(@"..\..\..\Files\4 Курс\1 неделя.png");
        var msg1 = await botClient.SendDocumentAsync(
            chatId: user.Id,
            document: new InputFile(content: week1, fileName: "1 неделя.jpg"),
            caption: "1 неделя",
            replyMarkup: Keyboards.GoBackMenu,
            cancellationToken: cancellationToken
        );
        
        await using Stream week2 = System.IO.File.OpenRead(@"..\..\..\Files\4 Курс\2 неделя.png");
        var msg2 = await botClient.SendDocumentAsync(
            chatId: user.Id,
            document: new InputFile(content: week2, fileName: "2 неделя.jpg"),
            caption: "2 неделя",
            replyMarkup: Keyboards.GoBackMenu,
            cancellationToken: cancellationToken
        );
    }
    public static void GetScheduleCommand(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken, User user, UserMessage message)
    {
        botClient.SendTextMessageAsync(
            chatId: user.Id,
            text: $"Выберите курс",
            replyMarkup: Keyboards.YearChoiceMenu,
            cancellationToken: cancellationToken,
            parseMode: ParseMode.Html
        );
    }
}