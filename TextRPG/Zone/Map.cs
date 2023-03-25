namespace TextRPG.Zone;

public static class Map
{
    public enum ZoneSelection
    {
        Town,
        Battle,
        MainMenu,
        None
    }
    
    public static ZoneSelection SelectZone()
    {
        Console.Clear();
        Console.WriteLine("------------------------------------");
        Console.WriteLine("[어디로 가시겠습니까?]");
        Console.WriteLine("1. 마을");
        Console.WriteLine("2. 배틀");
        Console.WriteLine("------------------------------------");
        
        switch (Console.ReadKey(true).Key)
        {
            case ConsoleKey.D1:
                Message.Notify("마을로 이동합니다.");
                return ZoneSelection.Town;
            case ConsoleKey.D2:
                Message.Notify("배틀을 시작합니다.");
                return ZoneSelection.Battle;
            case ConsoleKey.Q:
                if (AskGoToMainMenu())
                {
                    return ZoneSelection.MainMenu;
                }
                return ZoneSelection.None;
            default:
                return ZoneSelection.None;
        }
    }

    private static bool AskGoToMainMenu()
    {
        Console.WriteLine("메인 메뉴로 돌아가시겠습니까? [y / n]");
        while (true)
        {
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.Y:
                    return true;
                case ConsoleKey.N:
                    return false;
            }
        }
    }
}