public class ArgumentHandler
{
    /// <summary>
    /// Handles the arguments for the program
    /// </summary>
    ///
    /// <returns>
    /// Returns the program settings for the game
    /// </returns>
    public static ProgramSettings HandleArguments(string[] args)
    {
        ProgramSettings programSettings = new();
        for (int i = 0; i < args.Length; i++)
        {
            switch (args[i])
            {
                case "--help":
                    printHelp();
                    break;
                case "--file":
                    if (i + 1 >= args.Length)
                    {
                        throw new ArgumentNullException("file", "The --file argument requires a file but none was specified");
                    }
                    programSettings.WordSource = ProgramSettings.WordSources.FromFile;
                    programSettings.WordSourceValue = args[i + 1];
                    i++;
                    break;
                case "--word":
                    if (i + 1 >= args.Length)
                    {
                        throw new ArgumentNullException("word", "The --word argument requires a word but none was specified");
                    }
                    programSettings.WordSource = ProgramSettings.WordSources.SpecificWord;
                    programSettings.WordSourceValue = args[i + 1];
                    i++;
                    break;
            }
        }
        return programSettings;
    }

    private static void printHelp()
    {
        Console.WriteLine("--help | For help");
        Console.WriteLine("--file [file] | To specify specific file");
        Console.WriteLine("--word [word] | To specify specific word");
        Console.WriteLine("By default the program will find Words.txt");
    }
}
