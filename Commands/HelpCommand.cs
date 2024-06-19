namespace FountainOfObjects.Commands;

public class HelpCommand : ICommand
{
    public void Run(Game game)
    {
        ConsoleUtilities.WriteLine(
            """
            Commands:
            help -> Display this help message.
            move north/south/east/west -> Move in the specified direction.
            shoot north/south/east/west -> Shoot in the specified direction.
            activate fountain -> Activate the fountain.
            """, ConsoleColor.Cyan);
    }
}