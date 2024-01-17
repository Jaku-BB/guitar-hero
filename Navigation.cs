namespace GuitarHero;

public class Navigation
{
    private readonly string[] _data = { "Start a new game", "History", "Quit" };
    private int _navigationChoice;
    private const int StartNewGameIndex = 0;
    private const int HistoryIndex = 1;
    private const int QuitIndex = 2;

    public Navigation()
    {
        RunLoop();
    }

    private void RunLoop()
    {
        while (true)
        {
            Render();

            var key = Console.ReadKey(true).Key;
            
            if (HandleKeyPress(key))
            {
                switch (_navigationChoice)
                {
                    case StartNewGameIndex:
                        // Start a new game
                        break;
                    case HistoryIndex:
                        // History
                        break;
                    case QuitIndex:
                        // Quit
                        return;
                }
            }
        }
    }

    private void Render()
    {
        Console.Clear();
        Console.WriteLine("Welcome to Guitar Hero!");

        for (int index = 0; index < _data.Length; index++)
        {
            if (index == _navigationChoice)
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
            }

            Console.WriteLine(_data[index]);
            Console.ResetColor();
        }
    }

    private bool HandleKeyPress(ConsoleKey key)
    {
        // ReSharper disable once SwitchStatementHandlesSomeKnownEnumValuesWithDefault
        switch (key)
        {
            case ConsoleKey.Enter:
                return true;
            case ConsoleKey.UpArrow:
                _navigationChoice = _navigationChoice == 0 ? _data.Length - 1 : _navigationChoice - 1;
                return false;
            case ConsoleKey.DownArrow:
                _navigationChoice = _navigationChoice == _data.Length - 1 ? 0 : _navigationChoice + 1;
                return false;
            default:
                return false;
        }
    }
}