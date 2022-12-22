using Telegram.Bot.Types.ReplyMarkups;

namespace stis_help_bot.Commands;

public static class Keyboards
{
    public static ReplyKeyboardMarkup MainMenu = new(new[]
    {
        new KeyboardButton[] { "Узнать неделю" },
        new KeyboardButton[] { "Узнать расписание" },
        new KeyboardButton[] { "Профиль" },
    }) { ResizeKeyboard = true };
    
    public static ReplyKeyboardMarkup YearChoiceMenu = new(new[]
    {
        new KeyboardButton[] { "1 Курс" },
        new KeyboardButton[] { "2 Курс" },
        new KeyboardButton[] { "3 Курс" },
        new KeyboardButton[] { "4 Курс" },
    }) { ResizeKeyboard = true };
    
    public static ReplyKeyboardMarkup GoBackMenu = new(new[]
    {
        new KeyboardButton[] { "⬅️ Назад в меню" },
    }) { ResizeKeyboard = true };
}