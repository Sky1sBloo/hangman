public class Stickman
{
    public int Lives
    {
        get
        {
            return lives;
        }
        set
        {
            if (value < 0 || value > 6) { return; }
            lives = value;
        }
    }

    public Stickman()
    {
        lives = hangStages.Length - 1;
    }

    public string GetDrawing()
    {
        return hangStages[hangStages.Length - 1 - lives];
    }

    private int lives;
    private string[] hangStages = {
@"
  +---+
  |   |
      |
      |
      |
      |
=========",
@"
  +---+
  |   |
  O   |
      |
      |
      |
=========",
@"
  +---+
  |   |
  O   |
  |   |
      |
      |
=========",
@"
  +---+
  |   |
  O   |
 /|   |
      |
      |
=========",
@"
  +---+
  |   |
  O   |
 /|\  |
      |
      |
=========",
@"
  +---+
  |   |
  O   |
 /|\  |
 /    |
      |
=========",
@"
  +---+
  |   |
  O   |
 /|\  |
 / \  |
      |
========="
        };
};
