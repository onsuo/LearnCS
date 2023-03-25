using TextRPG.Unit;

namespace TextRPG.Entity;

internal abstract partial class BaseEntity : IBattleUnit
{
    public void Heal(int healed)
    {
        this.Hp += healed;
        Message.ColorWrite(this.Name, ConsoleColor.Green);
        Console.Write("의 체력이 ");
        Message.ColorWrite(healed, ConsoleColor.Yellow);
        Console.WriteLine(" 만큼 회복되었습니다.");
        this.PrintHp();
    }

    public void Damage(BaseEntity other)
    {
        if (other.Hp <= this.At)
        {
            other.Hp = 0;
        }
        else
        {
            other.Hp -= this.At;
        }
        Message.ColorWrite(this.Name, ConsoleColor.Green);
        Console.Write("이(가) ");
        Message.ColorWrite(other.Name, ConsoleColor.Green);
        Console.Write("에게 ");
        Message.ColorWrite(this.At, ConsoleColor.Yellow);
        Console.WriteLine(" 만큼의 피해를 주었습니다.");
        other.PrintHp();
    }

    public bool CheckDead()
    {
        return this.Hp <= 0;
    }

    public virtual void Kill(BaseEntity other)
    {
        Message.ColorWrite(this.Name, ConsoleColor.Green);
        Console.Write("이(가) ");
        Message.ColorWrite(other.Name, ConsoleColor.Green);
        Console.WriteLine("을(를) 처치했습니다.");
    }
}