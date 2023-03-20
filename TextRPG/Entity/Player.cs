namespace TextRPG.Entity;

internal class Player : BaseEntity
{
    protected int Exp;
    protected int MaxExp;
    
    public Player()
    {
        this.Name = "Player";
        this.Lv = 1;
        this.At = 10;
        this.Hp = 50;
        this.MaxHp = 100;
        this.KillExp = 10;
        
        this.Exp = 0;
        this.MaxExp = 10;
    }

    public override void PrintStatus()
    {
        Console.WriteLine("----------------------------------------------");
        Console.WriteLine($"|{this.Name}| Lv.{this.Lv}(Exp:{this.Exp}/{this.MaxExp})");
        Console.WriteLine($"공격력: {this.At}");
        Console.WriteLine($"쳬력: {this.Hp}/{this.MaxHp}");
        Console.WriteLine("----------------------------------------------");
    }

    protected void CheckLevel()
    {
        while (true)
        {
            if (this.Exp < this.MaxExp)
            {
                break;
            }
            this.Exp -= this.MaxExp;
            Lv++;
            this.MaxExp++;
            this.KillExp += 2;
        }
        Utility.PromptMessage($"Lv.{this.Lv} 이 되었습니다.");
    }
    
    public override void Kill(BaseEntity other)
    {
        Utility.PromptMessage($"{this.Name}이(가) {other.Name}을(를) 처치했습니다.");
        this.Exp += other.KillExp;
        Utility.PromptMessage($"+ {other.KillExp} Exp 를 얻었습니다.");
        this.CheckLevel();
    }
    
    public void TownHeal()
    {
        if (Hp >= MaxHp)
        {
            Utility.PromptMessage("이미 체력이 가득 찼습니다.");
            return;
        }
        Hp = MaxHp;
        this.PrintHp();
    }
}