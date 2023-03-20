namespace TextRPG.Entity;

internal class Monster : BaseEntity
{
    public Monster()
    {
        this.Name = "Monster";
        this.Lv = 1;
        this.At = 5;
        this.Hp = 50;
        this.MaxHp = 50;
        this.KillExp = 10;
    }
}