namespace GuitarHero;

public class Game
{
    // Make sure it's an odd number
    private const int Width = 13;
    private const int Height = 8;
    private const int ClickableHeight = Height - 2;
    private readonly int[] _horizontalPositions = { 0, Width / 2, Width - 1 };
    private readonly bool _isRunning = true;
    private readonly ConsoleKey[] _keys = { ConsoleKey.A, ConsoleKey.S, ConsoleKey.D };
    private readonly List<Note> _notes = new();
    private readonly Random _random = new();
    private int _loopCount;

    public void Initialize()
    {
        int interval = 1000;

        while (_isRunning)
        {
            Update();
            Thread.Sleep(interval);

            if (_loopCount % 10 == 0)
                interval = Math.Max(300, interval - 100);

            _loopCount++;
        }
    }

    private void Render()
    {
        Console.Clear();

        for (int row = 0; row < Height; row++)
        {
            bool isLastIndex = row == Height - 1;

            for (int keyIndex = 0; keyIndex < _keys.Length; keyIndex++)
                Utilities.WriteAt(_horizontalPositions[keyIndex], row, isLastIndex ? _keys[keyIndex].ToString() : "|");
        }

        for (int index = 0; index < _notes.Count; index++)
        {
            Note note = _notes[index];
            Utilities.WriteAt(note.X, note.Y, "X");
        }
    }

    private void GenerateNote()
    {
        if (_random.Next(0, 2) != 0) return;

        int index = _random.Next(0, _keys.Length);
        _notes.Add(new Note(_horizontalPositions[index], _keys[index]));
    }

    private void MoveNote()
    {
        List<Note> noteToRemoveList = new();

        for (int index = 0; index < _notes.Count; index++)
        {
            Note note = _notes[index];

            if (note.Y >= ClickableHeight)
            {
                noteToRemoveList.Add(note);
                continue;
            }

            note.Y++;
        }

        for (int index = 0; index < noteToRemoveList.Count; index++)
            _notes.Remove(noteToRemoveList[index]);
    }


    private void Update()
    {
        GenerateNote();
        Render();
        MoveNote();
    }
}