namespace stis_help_bot.Handler;

public class User
{
    public string Id { get; }
    public string? Nickname { get; }
    public string? Firstname { get; }

    public User(string id, string? nickname, string? firstname)
    {
        this.Id = id;
        this.Nickname = nickname;
        this.Firstname = firstname;
    }
}