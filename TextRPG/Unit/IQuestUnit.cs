namespace TextRPG.Unit;

internal interface IQuestUnit
{
    public void Talk(IQuestUnit other);
    public void Event(IQuestUnit other);
}