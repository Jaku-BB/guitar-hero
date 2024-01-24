namespace GuitarHero;

public class Game
{
    // To properly center the board, 'Width' must be an odd number
    private const int Width = 13;
    private const int Height = 8;
    private const int ClickableHeight = Height - 2;
    private readonly int[] _horizontalPositions = { 0, Width / 2, Width - 1 };
    private readonly ConsoleKey[] _keys = { ConsoleKey.A, ConsoleKey.S, ConsoleKey.D };
    private readonly List<Note> _notes = new();
    private readonly Random _random = new();
    private bool _isRunning = true;
    private int _loopCount;

    public void Initialize()
    {
        Console.Clear();

        Thread keyPressThread = new(HandleKeyPress);
        keyPressThread.Start();

        int interval = 1000;

        while (_isRunning)
        {
            Update();
            Thread.Sleep(interval);

            if (_loopCount % 10 == 0)
                interval = Math.Max(200, interval - 100);

            _loopCount++;
        }
    }

    private void Render()
    {
        for (int row = 0; row < Height; row++)
        {
            bool isLastIndex = row == Height - 1;

            for (int keyIndex = 0; keyIndex < _keys.Length; keyIndex++)
                Utilities.WriteAt(_horizontalPositions[keyIndex], row,
                    isLastIndex ? _keys[keyIndex].ToString() : "|");
        }

        _notes.ForEach(note => Utilities.WriteAt(note.X, note.Y, "X"));
    }

    private void GenerateNote()
    {
        if (_loopCount != 0 && _random.Next(0, 2) != 0) return;

        int index = _random.Next(0, _keys.Length);
        _notes.Add(new Note(_horizontalPositions[index], _keys[index]));
    }

    private void MoveNotes()
    {
        try
        {
            Note lowestNote = _notes.OrderBy(note => note.Y).Last();

            if (lowestNote.Y >= ClickableHeight)
            {
                End();
                return;
            }

            _notes.ForEach(note => note.Y++);
        }
        catch (Exception error)
        {
            if (error is InvalidOperationException)
                return;

            throw;
        }
    }

    private void HandleKeyPress()
    {
        const int interval = 10;

        while (_isRunning)
        {
            if (!Console.KeyAvailable) continue;

            ConsoleKey key = Console.ReadKey(true).Key;

            try
            {
                Note lowestNote = _notes.OrderBy(note => note.Y).Last();

                if (!_keys.Contains(key) || lowestNote.Y != ClickableHeight)
                {
                    End();
                    return;
                }

                if (key == lowestNote.Key)
                {
                    _notes.Remove(lowestNote);
                }
                else
                {
                    End();
                    return;
                }
            }
            catch (Exception error)
            {
                if (error is InvalidOperationException)
                    continue;

                throw;
            }

            Thread.Sleep(interval);
        }
    }

    private void End()
    {
        _isRunning = false;

        Console.Clear();
        Console.WriteLine("Game over!");
    }

    private void Update()
    {
        GenerateNote();
        MoveNotes();

        if (!_isRunning) return;

        Render();
    }
}