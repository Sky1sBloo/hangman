string chosenWord = "";
Random random = new Random();
try
{
    chosenWord = WordPicker.PickRandomLine("Words.txt", random);
}
catch (Exception)
{
    Console.WriteLine("Cannot access Words.txt");
    Environment.Exit(1);
}
Game game = new Game(chosenWord);
game.StartGame();
