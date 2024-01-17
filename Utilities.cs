namespace GuitarHero;

public static class Utilities
{
    public static void WriteAt(int x, int y, string text)
    {
        Console.SetCursorPosition(x, y);
        Console.Write(text);
    }
}