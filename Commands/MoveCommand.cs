namespace FountainOfObjects.Commands;

public class MoveCommand : ICommand
{
    private readonly Direction _direction;

    public MoveCommand(Direction direction)
    {
        _direction = direction;
    }

    public void Run(Game game)
    {
        var newLocation = _direction switch
        {
            Direction.North => game.Player.Location with { Row = game.Player.Location.Row - 1 },
            Direction.South => game.Player.Location with { Row = game.Player.Location.Row + 1 },
            Direction.West => game.Player.Location with { Column = game.Player.Location.Column - 1 },
            Direction.East => game.Player.Location with { Column = game.Player.Location.Column + 1 }
        };

        if (game.Map.IsValidLocation(newLocation))
        {
            game.Player.Location = newLocation;

            switch (game.Map.GetRoom(newLocation))
            {
                case RoomType.Pit:
                    game.Player.IsDead = true;
                    break;
                case RoomType.Maelstorm:
                    HandleMaelstorm(game);
                    break;
                case RoomType.Amarok:
                    game.Player.IsDead = true;
                    break;
            }
        }
        else
        {
            Console.WriteLine("You found a wall.");
        }
    }

    private static void HandleMaelstorm(Game game)
    {
        var currentRow = game.Player.Location.Row;
        var currentColumn = game.Player.Location.Column;

        game.Map.SetRoom(
            new Location(currentRow, currentColumn),
            RoomType.Normal);

        // Set Player new room
        var newLocation = new Location(currentRow - 1, currentColumn + 2);
        if(game.Map.IsValidLocation(newLocation)) game.Player.Location = newLocation;
        else
        {
            if (newLocation.Row < 0) newLocation = newLocation with { Row = 0 };
            if (newLocation.Column >= game.Map.Size()) newLocation = newLocation with { Column = game.Map.Size() - 1 };

            game.Player.Location = newLocation;
        }

        // Set Maelstorm new room
        try
        {
            game.Map.SetRoom(
                new Location(currentRow + 1, currentColumn - 2),
                RoomType.Maelstorm);
        }
        catch (ArgumentException)
        {
            var newRow = currentRow;
            var newColumn = currentColumn;
            if(currentRow + 1 >= game.Map.Size()) newRow = game.Map.Size() - 1;
            if(currentColumn - 2 < 0) newColumn = 0;

            game.Map.SetRoom(
                new Location(newRow, newColumn),
                RoomType.Maelstorm);
        }

        ConsoleUtilities.WriteLine("You have been moved by the Maelstorm.", ConsoleColor.Red);
    }
}