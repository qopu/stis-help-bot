namespace stis_help_bot.Handler;

public class UserMessage
{
    public string Id { get; }
    public string Date { get; }
    public string Text { get; }
    public UserMessage(string id, string date, string text)
    {
        this.Id = id;
        this.Date = date;
        this.Text = text;
    }
}