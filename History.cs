namespace GuitarHero;

public static class History
{
    private static readonly string HistoryFilePath = Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
        "GuitarHero", "History.txt");

    public static void AddScore(int score)
    {
        Directory.CreateDirectory(Path.GetDirectoryName(HistoryFilePath)!);

        using StreamWriter file = new(HistoryFilePath, true);
        file.WriteLine($"Date: {DateTime.Now.Date} | Score: {score}");
    }

    public static void Render()
    {
        Console.Clear();

        try
        {
            using StreamReader file = new(HistoryFilePath);

            while (!file.EndOfStream)
                Console.WriteLine(file.ReadLine());
        }
        catch
        {
            Console.WriteLine("No history yet!");
        }

        Console.WriteLine("Press Escape to go back to navigation.");

        while (!Console.KeyAvailable)
        {
            ConsoleKey key = Console.ReadKey(true).Key;

            if (key == ConsoleKey.Escape)
                return;
        }
    }
}