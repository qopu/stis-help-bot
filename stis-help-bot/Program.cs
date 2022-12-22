using System;
using System.Text;
using System.Text.Json;
using stis_help_bot.Configuration;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types.Enums;
using stis_help_bot.Handler;


var botConfig = BotConfig.Initialize(configFilePath: @"..\..\..\Configuration\config.json");

var botClient = new TelegramBotClient(botConfig.Token);
botClient.StartReceiving(
    updateHandler: Handler.HandleUpdateAsync, 
    pollingErrorHandler: Handler.HandleErrorAsync);

var me = await botClient.GetMeAsync();

Console.WriteLine($"Running as @{me.Username}");
Console.ReadLine();