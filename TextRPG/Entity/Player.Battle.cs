namespace TextRPG.Entity;

internal partial class Player : IBattleUnit
{
    public override void Kill(BaseEntity other)
    {
        Message.ColorWrite(this.Name, ConsoleColor.Green);
        Console.Write("이(가) ");
        Message.ColorWrite(other.Name, ConsoleColor.Green);
        Message.Notify("을(를) 처치했습니다.");
        this.Exp += other.KillExp;
        Message.ColorWrite($"{other.KillExp} Exp", ConsoleColor.Yellow);
        Message.Notify(" 를 얻었습니다.");
        this.CheckLevel();
    }
}