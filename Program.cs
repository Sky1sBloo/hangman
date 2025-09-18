Random random = new Random();
ProgramSettings? programSettings = null;

try
{
    programSettings = ArgumentHandler.HandleArguments(args);
}
catch (ArgumentNullException ex)
{
    Console.WriteLine(ex.Message);
    Environment.Exit(1);
}

if (programSettings == null)
{
    Console.WriteLine("Failed to load program settings");
    Environment.Exit(1);
}

try
{
    Game game = new Game(programSettings, random);
    game.StartGame();
}
catch (InvalidDataException ex)
{
    Console.WriteLine(ex.Message);
}
