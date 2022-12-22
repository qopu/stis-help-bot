using System.Text.Json;

namespace stis_help_bot.Configuration;

public class BotConfig
{
    public string Token { get; set; } = null!;

    public static BotConfig Initialize(string configFilePath)
    {
        var jsonConfig = File.ReadAllText(configFilePath);
        var botConfig = JsonSerializer.Deserialize<BotConfig>(jsonConfig)!;

        return botConfig;
    }
}