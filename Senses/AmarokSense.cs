namespace FountainOfObjects.Senses;

public class AmarokSense : ISense
{
    public void Display(Game game)
    {
        ConsoleUtilities.WriteLine("You can smell the rotten stench of an amarok in a nearby room.", ConsoleColor.Yellow);
    }
}