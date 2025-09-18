public class Program
{
    static int Main(string[] args)
    {
        Random random = new Random();
        ProgramSettings? programSettings = null;

        try
        {
            programSettings = ArgumentHandler.HandleArguments(args);
        }
        catch (ArgumentNullException ex)
        {
            Console.WriteLine(ex.Message);
            return 1;
        }

        if (programSettings == null)
        {
            Console.WriteLine("Failed to load program settings");
            return 2;
        }

        try
        {
            Game game = new Game(programSettings, random);
            game.StartGame();
        }
        catch (InvalidDataException ex)
        {
            Console.WriteLine(ex.Message);
            return 3;
        }
        return 0;
    }
}

