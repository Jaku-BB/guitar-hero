namespace GuitarHero;

public class Navigation
{
    private const int StartNewGameIndex = 0;
    private const int HistoryIndex = 1;
    private const int QuitIndex = 2;
    private readonly string[] _data = { "Start a new game", "History", "Quit" };
    private int _navigationChoice;

    public void Initialize()
    {
        Render();

        while (true)
        {
            if (!Console.KeyAvailable) continue;
            
            ConsoleKey key = Console.ReadKey(true).Key;

            if (HandleKeyPress(key))
                switch (_navigationChoice)
                {
                    case StartNewGameIndex:
                        Game game = new();
                        game.Initialize();

                        // TODO: change to 'break' when 'Game' is done
                        return;
                    case HistoryIndex:
                        // History
                        break;
                    case QuitIndex:
                        // Quit
                        return;
                }
            
            Render();
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