namespace stis_help_bot.Logs;


public static class Logger
{
    public static void LogMessage(Handler.User user, Handler.UserMessage message)
    {
        Console.WriteLine($"Received message \"{message.Text}\" | " +
                          $"From user_id:{user.Id} username:{user.Nickname} firstname: {user.Firstname}");
    }
}