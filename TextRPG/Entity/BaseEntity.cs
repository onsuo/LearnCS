namespace TextRPG.Entity;

internal abstract class BaseEntity
{
    public string Name { get; protected init; }
    protected int Lv;

    protected int At;
    protected int Hp;
    protected int MaxHp;
    
    public int KillExp { get; protected set; }
    
    protected BaseEntity()
    {
        this.Name = "BaseEntity";
        this.Lv = 1;
        this.At = 1;
        this.Hp = 1;
        this.MaxHp = 1;
        this.KillExp = 1;
    }

    public virtual void PrintStatus()
    {
        Console.WriteLine("----------------------------------------------");
        Console.WriteLine($"|{this.Name}| Lv.{this.Lv}");
        Console.WriteLine($"공격력: {this.At}");
        Console.WriteLine($"쳬력: {this.Hp}/{this.MaxHp}");
        Console.WriteLine("----------------------------------------------");
    }
    
    protected void PrintHp()
    {
        Console.Write($"현재 {this.Name}의 HP는 ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write(Hp);
        Console.ForegroundColor = ConsoleColor.White;
        Utility.PromptMessage(" 입니다.");
    }

    public void Heal(int healed)
    {
        this.Hp += healed;
        Console.WriteLine($"{this.Name}의 체력이 {healed} 만큼 회복되었습니다.");
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
        Console.WriteLine($"{this.Name}이(가) {other.Name}에게 {this.At} 만큼의 피해를 주었습니다.");
        other.PrintHp();
    }

    public bool CheckDead()
    {
        return this.Hp <= 0;
    }

    public virtual void Kill(BaseEntity other)
    {
        Console.WriteLine($"{this.Name}이(가) {other.Name}을(를) 처치했습니다.");
    }
}