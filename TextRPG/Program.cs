global using Utility;
global using TextRPG.Entity;
global using TextRPG.Zone;
global using TextRPG.Unit;

namespace TextRPG;

internal static class Program
{
    private static void Main()
    {
        var player = new Player();

        while (true)
        {
            switch (MainMenu.SelectMainMenu())
            {
                case MainMenu.MenuSelection.GameStart:
                    GoToMap(player);
                    break;
                case MainMenu.MenuSelection.Options:
                    Message.NotMade();
                    Console.ReadKey(true);
                    break;
                case MainMenu.MenuSelection.Credits:
                    Message.NotMade();
                    Console.ReadKey(true);
                    break;
                case MainMenu.MenuSelection.Quit:
                    Message.Notify("게임을 종료합니다.");
                    return;
            }
        }
    }

    private static void GoToMap(Player player)
    {
        while (true)
        {
            switch (Map.SelectZone())
            {
                case Map.ZoneSelection.Town:
                    Town.GoToTown(player);
                    break;
                case Map.ZoneSelection.Battle:
                    Battle.StartBattle(player);
                    Town.GoToTown(player);
                    break;
                case Map.ZoneSelection.MainMenu:
                    return;
            }
        }
    }
}
