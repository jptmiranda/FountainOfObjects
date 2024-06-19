namespace FountainOfObjects.Senses;

public class FountainSense : ISense
{
    public void Display(Game game)
    {
        ConsoleUtilities.WriteLine(game.IsFountainActive
            ? "You hear the rushing waters from the Fountain of Objects. It has been reactivated!"
            : "You hear water dripping in this room. The Fountain of Objects is here!", ConsoleColor.Green);
    }
}