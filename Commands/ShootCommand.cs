namespace FountainOfObjects.Commands;

public class ShootCommand : ICommand
{
    private readonly Direction _direction;

    public ShootCommand(Direction direction)
    {
        _direction = direction;
    }

    public void Run(Game game)
    {
        if (game.Player.Arrows <= 0)
        {
            Console.WriteLine("You are out of arrows.");
            return;
        }

        var locationToShoot = _direction switch
        {
            Direction.North => game.Player.Location with { Row = game.Player.Location.Row - 1 },
            Direction.South => game.Player.Location with { Row = game.Player.Location.Row + 1 },
            Direction.West => game.Player.Location with { Column = game.Player.Location.Column - 1 },
            Direction.East => game.Player.Location with { Column = game.Player.Location.Column + 1 }
        };

        if (game.Map.IsValidLocation(locationToShoot))
        {
            if (game.Map.GetRoom(locationToShoot) == RoomType.Amarok ||
                game.Map.GetRoom(locationToShoot) == RoomType.Maelstorm)
            {
                game.Map.SetRoom(
                    locationToShoot,
                    RoomType.Normal);
            }
        }

        game.Player.Arrows--;
    }
}