namespace TextRPG.Zone;

internal static class Town
{
    public static string Name { get; }

    static Town()
    {
        Name = "Starting Town";
    }
    
    public static void GoToTown(Player player)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("------------------------------------");
            Message.ColorWrite($"[{Name}]\n", ConsoleColor.DarkBlue);
            Console.WriteLine("@ 마을에서 무슨 일을 하시겠습니까?");
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
    
    private static void TownHeal(this Player player)
    {
        if (player.Hp >= player.MaxHp)
        {
            Message.Notify("이미 체력이 가득 찼습니다.");
            return;
        }
        player.Heal(player.MaxHp - player.Hp);
    }
}