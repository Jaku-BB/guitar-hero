namespace GuitarHero;

public static class Utilities
{
    public static void WriteAt(int x, int y, string text)
    {
        Console.SetCursorPosition(x, y);
        Console.Write(text);
    }

    public static void WaitForKeyPress(ConsoleKey key)
    {
        Console.WriteLine($"\nPress {key} to continue...");

        while (Console.ReadKey(true).Key != key)
        {
        }
    }
}