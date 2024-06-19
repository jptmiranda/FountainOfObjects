namespace FountainOfObjects.Senses;

public class MaelstormSense : ISense
{
    public void Display(Game game)
    {
        ConsoleUtilities.WriteLine("You hear the growling and groaning of a maelstrom nearby.", ConsoleColor.Yellow);
    }
}