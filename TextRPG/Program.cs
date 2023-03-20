using TextRPG.Entity;

namespace TextRPG;

internal enum StartSelection
{
    SelectTown,
    SelectBattle,
    None
}

internal static class Program
{
    private static StartSelection StartSelect()
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
                Utility.PromptMessage("마을로 이동합니다.");
                return StartSelection.SelectTown;
            case ConsoleKey.D2:
                Utility.PromptMessage("배틀을 시작합니다.");
                return StartSelection.SelectBattle;
            default:
                Utility.PromptMessage("잘못된 선택입니다.");
                return StartSelection.None;
        }
    }
    
    private static void Town(Player player)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("------------------------------------");
            Console.WriteLine("[마을에서 무슨 일을 하시겠습니까?]");
            Console.WriteLine("1. 체력을 회복한다.");
            Console.WriteLine("2. 무기를 강화한다.");
            Console.WriteLine("3. 마을을 나간다.");
            player.PrintStatus();

            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.D1:
                    Console.WriteLine("체력을 모두 회복합니다.");
                    player.TownHeal();
                    break;
                case ConsoleKey.D2:
                    break;
                case ConsoleKey.D3:
                    return;
            }
        }
    }

    private static void Battle(Player player)
    {
        Monster newMonster = new Monster();
        
        for (int i = 1; true; i++)
        {
            Console.Clear();
            player.PrintStatus();
            newMonster.PrintStatus();
            Console.ReadKey(true);
            Utility.PromptMessage($"{i}번째 턴");
            Utility.PromptMessage($"{player.Name}의 차례");
            player.Damage(newMonster);
            if (newMonster.CheckDead())
            {
                player.Kill(newMonster);
                Utility.PromptMessage("전투에서 승리하였습니다.\n처음으로 돌아갑니다.");
                break;
            }
            Utility.PromptMessage($"{newMonster.Name}의 차례");
            newMonster.Damage(player);
            if (player.CheckDead())
            {
                newMonster.Kill(player);
                Utility.PromptMessage("전투에서 패배하였습니다.");
                break;
            }
        }
    }
    
    private static void Main()
    {
        var newPlayer = new Player();
        
        while (true)
        {
            var selection = StartSelect();
            switch (selection)
            {
                case StartSelection.SelectTown:
                    Town(newPlayer);
                    break;
                case StartSelection.SelectBattle:
                    Battle(newPlayer);
                    break;
            }
        }
    }
}
