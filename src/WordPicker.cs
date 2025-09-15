/**
 * Class for handling word picking
 */
public class WordPicker
{
    /**
     * Picks a line based on filepath
     */
    public static string PickRandomLine(string filePath, Random randomizer)
    {
        string chosenLine;
        StreamReader streamReader = new(filePath);
        string? line = streamReader.ReadLine();
        List<string> lines = new();
        while (line != null)
        {
            lines.Add(line);
            line = streamReader.ReadLine();
        }

        streamReader.Close();
        chosenLine = lines[randomizer.Next(lines.Count)];

        return chosenLine;
    }
}
