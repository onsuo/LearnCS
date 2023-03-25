namespace TextRPG.Unit;

internal interface IBattleUnit
{
    public void Heal(int healed);
    public void Damage(BaseEntity other);
    public bool CheckDead();
    public void Kill(BaseEntity other);
}