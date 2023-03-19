namespace TextRPG;

internal class Player
{
    private int _at = 10;
    private int _hp = 50;
    private int _maxHp = 100;
    
    public void PrintStatus()
    {
        Console.WriteLine("------------------------------------");
        Console.WriteLine($"공격력: {_at}");
        Console.WriteLine($"쳬력: {_hp}/{_maxHp}");
        Console.WriteLine("------------------------------------");
    }

    private void PrintHp()
    {
        Console.Write("현재 플레이어의 HP는 ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write(_hp);
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(" 입니다.");
    }
    
    public void MaxHeal()
    {
        if (_hp >= _maxHp)
        {
            Utility.PromptMessage("이미 체력이 가득 찼습니다.");
            return;
        }
        _hp = _maxHp;
        PrintHp();
        Console.ReadKey(true);
    }
}

internal class Monster
{
    
}

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
                    player.MaxHeal();
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
        Console.Clear();
        Utility.PromptMessage("아직 개장하지 않았습니다.");
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
