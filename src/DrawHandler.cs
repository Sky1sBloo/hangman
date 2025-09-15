public class DrawHandler
{
    private string correctWord;
    private List<char> guessedLetters;
    private Stickman stickman;

    public DrawHandler(string word, List<char> guessedLetters, Stickman stickman)
    {
        this.correctWord = word;
        this.guessedLetters = guessedLetters;
        this.stickman = stickman;
    }

    public void DrawGameLoop()
    {
        Console.Clear();
        DrawWord();
        DrawStickman();
        DrawGuessedWords();
    }

    public void DrawWin()
    {
        DrawGameLoop();
        Console.WriteLine("You Won!");
    }

    public void DrawLost()
    {
        Console.Clear();
        Console.WriteLine("Game Over");
        Console.WriteLine("Correct Word: " + correctWord);
        DrawStickman();
        DrawGuessedWords();

    }

    public void DrawWord()
    {
        Console.Write("Word: ");
        foreach (char c in correctWord)
        {
            string marker = c == ' ' ? "  " : "_ ";
            if (guessedLetters.Contains(c))
            {
                Console.Write(c + " ");
            }
            else
            {
                Console.Write(marker);
            }
        }
        Console.WriteLine();
    }

    public void DrawStickman()
    {
        Console.WriteLine(stickman.GetDrawing());
    }

    public void DrawGuessedWords()
    {
        for (int i = 0; i < 26; i++)
        {
            char letter = (char)('a' + i);
            if (guessedLetters.Contains(letter))
            {
                letter = '_';
            }
            Console.Write(letter + " ");
        }
        Console.WriteLine();
    }
}
