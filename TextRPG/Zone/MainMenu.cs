namespace TextRPG.Zone;

public static class MainMenu
{
    public enum MenuSelection
    {
        GameStart,
        Options,
        Credits,
        Quit,
        None
    }
    
    public static MenuSelection SelectMainMenu()
    {
        RenderMenu();
        switch (Console.ReadKey(true).Key)
        {
            case ConsoleKey.D1:
                return MenuSelection.GameStart;
            case ConsoleKey.D2:
                return MenuSelection.Options;
            case ConsoleKey.D3:
                return MenuSelection.Credits;
            case ConsoleKey.D4:
                return MenuSelection.Quit;
            default:
                return MenuSelection.None;
        }
    }

    private static void RenderMenu()
    {
        Console.Clear();
        Console.WriteLine("------------------------------------");
        Console.WriteLine("         [ ouun's TextRPG ]   v0.3.0");
        Console.WriteLine("------------- Main Menu ------------");
        Console.WriteLine("           1. Game Start            ");
        Message.ColorWrite("           2. Options               \n", ConsoleColor.DarkGray);
        Message.ColorWrite("           3. Credits               \n", ConsoleColor.DarkGray);
        Console.WriteLine("           4. Quit                  ");
        Console.WriteLine("------------------------------------");
    }
}