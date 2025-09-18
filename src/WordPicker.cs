/**
 * Class for handling word picking
 */
public class WordPicker
{
    /**
     * Picks a line based on filepath
     */
    public static string PickRandomLineFromFile(string filePath, Random randomizer)
    {
        string chosenLine;
        StreamReader streamReader = new(filePath);
        string? line = streamReader.ReadLine();
        List<string> lines = new();
        while (line != null)
        {
            lines.Add(line);
            if (!CheckWordIsValid(line))
            {
                throw new InvalidDataException("Text contains non alphabetic values");
            }

            line = streamReader.ReadLine();
        }

        streamReader.Close();
        chosenLine = lines[randomizer.Next(lines.Count)];

        return chosenLine;
    }

    /// <summary>
    /// Checks if the word is for use in the game
    /// </summary>
    public static bool CheckWordIsValid(string word)
    {
        foreach (char c in word)
        {
            if (!Char.IsLetter(c) && c != ' ') return false;
        }
        return true;
    }
}
