namespace FountainOfObjects.Commands;

public class ActivateFountainCommand : ICommand
{
    public void Run(Game game)
    {
        if (game.Map.GetRoom(game.Player.Location) == RoomType.Fountain)
        {
            game.IsFountainActive = true;
            Console.WriteLine("You activate the fountain.");
        }
        else
        {
            Console.WriteLine("There is not fountain in sight.");
        }
    }
}