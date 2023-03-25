namespace TextRPG.Entity;

internal partial class Player : BaseEntity
{
    protected int MaxExp;
    protected int m_Exp;
    
    public int Exp
    {
        get => m_Exp;
        
        set
        {
            if (value > 999)
            {
                Message.ShowError($"[Error] 1회 획득 가능한 경험치를 초과했습니다.({value})");
                return;
            }

            this.m_Exp = value;
        }
    }

    public Player()
    {
        this.Name = "Player";
        this.MaxLv = 99;
        this.MaxHp = 100;
        this.Hp = 50;
        this.MaxAt = 999;
        this.At = 10;
        this.KillExp = 10;
        
        this.MaxExp = 10;
        this.Exp = 0;
    }

    public override void PrintStatus()
    {
        Console.WriteLine("----------------------------------------------");
        Console.Write("|");
        Message.ColorWrite(this.Name, ConsoleColor.Green);
        Console.WriteLine($"| Lv.{this.Lv}(Exp:{this.Exp}/{this.MaxExp})");
        Console.WriteLine($"공격력: {this.At}");
        Console.WriteLine($"쳬력: {this.Hp}/{this.MaxHp}");
        Console.WriteLine("----------------------------------------------");
    }

    protected void CheckLevel()
    {
        if (this.Lv == this.MaxLv)
        {
            Console.WriteLine("이미 최대레벨 입니다.");
            return;
        }
        
        while (true)
        {
            if (this.Lv == this.MaxLv)
            {
                this.MaxExp = -1;
                this.Exp = this.MaxExp;
                return;
            }
            if (this.Exp < this.MaxExp)
            {
                break;
            }
            this.Exp -= this.MaxExp;
            Lv++;
            this.MaxExp++;
            this.KillExp += 2;
        }
        Message.Notify($"Lv.{this.Lv} 이(가) 되었습니다.");
    }
}