namespace Utility;

public static class Algorithm
{
    public static void Shuffle<T>(this IList<T> list)
    {
        Random random = new Random();
        for (int i = list.Count - 1; i >= 1; i--)
        {
            int k = random.Next(i + 1);
            (list[k], list[i]) = (list[i], list[k]);
        }
    }
}