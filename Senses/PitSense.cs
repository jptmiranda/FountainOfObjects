namespace FountainOfObjects.Senses;

public class PitSense : ISense
{
    public void Display(Game game)
    {
        ConsoleUtilities.WriteLine("You feel a draft. There is a pit in a nearby room.", ConsoleColor.Yellow);
    }
}