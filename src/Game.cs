public class Game
{
    public string CorrectWord { get; private set; }

    private Stickman stickman;
    private DrawHandler drawHandler;
    private List<char> guessedLetters;

    private bool gameRunning;


    public Game(string wordToGuess)
    {
        CorrectWord = wordToGuess;
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
            if (guessedLetters.Contains(c)) continue;

            guessedLetters.Add(c);
            if (CorrectWord.Contains(c))
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
        if (won)  drawHandler.DrawWin();
        else drawHandler.DrawLost();
    }
}
