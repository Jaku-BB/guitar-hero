namespace GuitarHero;

public class Game
{
    private const int Width = 12;
    private const int Height = 8;
    private readonly (ConsoleKey, ConsoleKey, ConsoleKey) _keys = (ConsoleKey.A, ConsoleKey.S, ConsoleKey.D);

    public void Initialize()
    {
        Render();
    }

    private void Render()
    {
        Console.Clear();

        for (int index = 0; index < Height; index++)
        {
            bool isLastIndex = index == Height - 1;

            Utilities.WriteAt(0, index, isLastIndex ? _keys.Item1.ToString() : "|");
            Utilities.WriteAt(Width / 2 - 1, index, isLastIndex ? _keys.Item2.ToString() : "|");
            Utilities.WriteAt(Width - 1, index, isLastIndex ? _keys.Item3.ToString() : "|");
        }
    }
}