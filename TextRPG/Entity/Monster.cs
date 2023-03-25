namespace TextRPG.Entity;

internal class Monster : BaseEntity
{
    public Monster()
    {
        this.Name = "Monster";
        this.MaxLv = 50;
        this.MaxHp = 50;
        this.Hp = 50;
        this.MaxAt = 99;
        this.At = 5;
        this.KillExp = 10;
    }
}