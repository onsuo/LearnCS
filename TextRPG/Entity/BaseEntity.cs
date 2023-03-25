namespace TextRPG.Entity;

internal abstract partial class BaseEntity
{
    public string Name { get; protected set; }
    protected int MaxLv;
    protected int Lv;
    public int MaxHp { get; protected set; }
    protected int m_Hp;
    protected int MaxAt;
    protected int m_At;
    public int KillExp { get; protected set; }
    
    public int Hp
    {
        get
        {
            if (this.m_Hp > this.MaxHp)
            {
                Message.ShowError($"[Error] 체력이 최대치({this.MaxHp})를 초과하였습니다. ({this.m_Hp})");
                return 1;
            }

            return this.m_Hp;
        }
        set
        {
            if (value > this.MaxHp)
            {
                Message.ShowError($"[Error] 체력은 {this.MaxHp}을(를) 초과할 수 없습니다.");
                return;
            }

            this.m_Hp = value;
        }
    }
    
    public int At
    {
        get
        {
            if (this.m_At > this.MaxAt)
            {
                Message.ShowError($"[Error] 공격력이 최대치({this.MaxAt})를 초과하였습니다. ({this.m_At})");
                return 1;
            }

            return this.m_At;
        }
        set
        {
            if (value > this.MaxAt)
            {
                Message.ShowError($"[Error] 공격력은 {this.MaxAt}을(를) 초과할 수 없습니다.");
                return;
            }

            this.m_At = value;
        }
    }

    public BaseEntity()
    {
        this.Name = "BaseEntity";
        this.MaxLv = 1;
        this.Lv = 1;
        this.MaxHp = 1;
        this.Hp = 1;
        this.MaxAt = 1;
        this.At = 1;
        this.KillExp = 1;
    }

    public virtual void PrintStatus()
    {
        Console.WriteLine("----------------------------------------------");
        Console.Write("|");
        Message.ColorWrite(this.Name, ConsoleColor.Green);
        Console.WriteLine($"| Lv.{this.Lv}");
        Console.WriteLine($"공격력: {this.At}");
        Console.WriteLine($"쳬력: {this.Hp}/{this.MaxHp}");
        Console.WriteLine("----------------------------------------------");
    }
    
    protected void PrintHp()
    {
        Console.Write("현재 ");
        Message.ColorWrite(this.Name, ConsoleColor.Green);
        Console.Write("의 HP는 ");
        Message.ColorWrite(this.Hp, ConsoleColor.Yellow);
        Message.Notify(" 입니다.");
    }
}