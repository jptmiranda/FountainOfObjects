namespace FountainOfObjects.Senses;

public class EntranceSense : ISense
{
    public void Display(Game game)
    {
        ConsoleUtilities.WriteLine("You see light coming from the cavern entrance.", ConsoleColor.Cyan);
    }
}