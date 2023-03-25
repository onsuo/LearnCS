namespace TextRPG.Zone;

internal static class Battle
{
    public static void StartBattle(Player player)
    {
        var monster = new Monster();
        
        for (var i = 1; true; i++)
        {
            Console.Clear();
            player.PrintStatus();
            monster.PrintStatus();
            Console.ReadKey(true);
            Message.Notify($"[{i}번째 턴]");
            Message.ColorWrite(player.Name, ConsoleColor.Green);
            Message.Notify("의 차례");
            player.Damage(monster);
            if (monster.CheckDead())
            {
                player.Kill(monster);
                Message.Notify("전투에서 승리하였습니다. 마을로 돌아갑니다.");
                break;
            }
            
            Console.Clear();
            player.PrintStatus();
            monster.PrintStatus();
            Message.Notify($"[{i}번째 턴]");
            Message.ColorWrite(monster.Name, ConsoleColor.Green);
            Message.Notify("의 차례");
            monster.Damage(player);
            if (player.CheckDead())
            {
                monster.Kill(player);
                Message.Notify("전투에서 패배하였습니다. 마을로 이송됩니다.");
                break;
            }
        }
    }
}