namespace GuitarHero;

public class Note
{
    public readonly ConsoleKey Key;

    public readonly int X;

    // 'Y' is by default -1 in order to increment it to 0 on the first update
    public int Y = -1;

    public Note(int x, ConsoleKey key)
    {
        X = x;
        Key = key;
    }
}