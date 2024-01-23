namespace GuitarHero;

public class Note
{
    public readonly ConsoleKey Key;
    public readonly int X;
    public int Y = 0;

    public Note(int x, ConsoleKey key)
    {
        X = x;
        Key = key;
    }
}