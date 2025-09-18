/**
 * Handles the game loop
 */
public class Game
{
    public string CorrectWord { get; private set; }

    private Stickman stickman;
    private DrawHandler drawHandler;
    private List<char> guessedLetters;

    private bool gameRunning;


    public Game(ProgramSettings programSettings, Random random)
    {
        switch (programSettings.WordSource)
        {
            case ProgramSettings.WordSources.FromFile:
                CorrectWord = WordPicker.PickRandomLineFromFile(programSettings.WordSourceValue, random);
                break;
            case ProgramSettings.WordSources.SpecificWord:
                if (WordPicker.CheckWordIsValid(programSettings.WordSourceValue))
                {
                    CorrectWord = programSettings.WordSourceValue.ToLower();
                }
                else
                {
                    throw new InvalidDataException("Word contains invalid symbols");
                }
                break;
            default:
                // Just to remove editor warnings
                throw new InvalidDataException();
        }

        guessedLetters = new();
        stickman = new();
        drawHandler = new(CorrectWord, guessedLetters, stickman);

        gameRunning = true;
    }

    public void StartGame()
    {
        while (gameRunning)
        {
            drawHandler.DrawGameLoop();
            string? input = Console.ReadLine();
            if (input == null) continue;
            handleInput(input);
        }
    }

    public void handleInput(string input)
    {
        foreach (char c in input)
        {
            char loweredC = Char.ToLower(c);
            if (!char.IsLetter(loweredC)) continue;
            if (guessedLetters.Contains(loweredC)) continue;


            guessedLetters.Add(loweredC);
            if (CorrectWord.Contains(loweredC))
            {
                if (IsWon()) EndGame(true);
            }
            else
            {
                stickman.Lives--;
                if (stickman.Lives == 0) EndGame(false);
            }
        }
    }


    public bool IsWon()
    {
        foreach (char c in CorrectWord)
        {
            if (c == ' ') continue;
            if (!guessedLetters.Contains(c))
            {
                return false;
            }
        }
        return true;
    }

    public void EndGame(bool won)
    {
        gameRunning = false;
        if (won) drawHandler.DrawWin();
        else drawHandler.DrawLost();
    }
}
