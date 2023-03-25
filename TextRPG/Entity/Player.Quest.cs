namespace TextRPG.Entity;

internal partial class Player : IQuestUnit
{
    public void Talk(IQuestUnit other)
    {
        Message.NotMade();
    }

    public void Event(IQuestUnit other)
    {
        Message.NotMade();
    }
}