namespace Utility;

public static class Message
{
    public static void Notify(string msg)
    {
        Console.WriteLine(msg);
        Console.ReadKey(true);
    }

    public static void ShowError(string msg)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(msg);
        Console.ForegroundColor = ConsoleColor.Gray;
    }

    public static void ColorWrite<T>(T msg, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.Write(msg);
        Console.ForegroundColor = ConsoleColor.Gray;
    }

    public static void NotMade()
    {
        Message.ColorWrite("in development..", ConsoleColor.DarkGray);
    }
}