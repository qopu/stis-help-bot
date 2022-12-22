using PuppeteerSharp;
using Telegram.Bot;
using Telegram.Bot.Types;
using stis_help_bot.Handler;
using Telegram.Bot.Types.Enums;
using User = stis_help_bot.Handler.User;

namespace stis_help_bot.Commands;

public class CheckWeek
{
    private static async void GetWeekFromWebsite(string domain, ITelegramBotClient botClient, Update update, CancellationToken cancellationToken, User user, UserMessage message)
    {
        var sentProcessMessage = await botClient.SendTextMessageAsync(
            chatId: user.Id,
            text: $"Ищу неделю...",
            replyMarkup: Keyboards.GoBackMenu,
            cancellationToken: cancellationToken,
            protectContent: false
        );
        
        using var browserFetcher = new BrowserFetcher();
        await browserFetcher.DownloadAsync(BrowserFetcher.DefaultChromiumRevision);
        var browser = await Puppeteer.LaunchAsync(new LaunchOptions
        {
            Headless = true
        });
        await using var page = await browser.NewPageAsync();
        await page.GoToAsync(domain);
        var pageHeaderHandle = await page.QuerySelectorAllAsync("span");
        for (var i = 0; i < pageHeaderHandle.Length; i++)
        {
            if (i != 2) continue;
            var innerTextHandle = await pageHeaderHandle[i].GetPropertyAsync("innerText");
            var innerText = await innerTextHandle.JsonValueAsync();
            SendWeek(innerText.ToString()?.ToLower(), sentProcessMessage, botClient, update, cancellationToken, user, message);
        }
    }

    private static async void SendWeek(string? week, Message sentProcessMessage, ITelegramBotClient botClient, Update update, CancellationToken cancellationToken, User user, UserMessage message)
    {
        await botClient.SendTextMessageAsync(
            chatId: user.Id,
            text: $"Сейчас <b>{week}</b> неделя",
            replyMarkup: Keyboards.GoBackMenu,
            cancellationToken: cancellationToken,
            parseMode: ParseMode.Html);
    }
    public static void CheckWeekCommand(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken, User user, UserMessage message)
    {
        GetWeekFromWebsite("https://new.stis.su/schedule", botClient, update, cancellationToken, user, message);
    }
}