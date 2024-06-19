using FountainOfObjects.Commands;
using FountainOfObjects.Senses;

namespace FountainOfObjects;

public class Game
{
    public Map Map { get; }
    public Player Player { get; }
    public bool IsFountainActive { get; set; }

    public Game(Map map, Player player)
    {
        Map = map;
        Player = player;
    }

    public void Run()
    {
        Introduction();
        while (true)
        {
            Status();

            var command = GetCommand();
            command.Run(this);

            if (Player.IsDead)
            {
                ConsoleUtilities.WriteLine("You died!", ConsoleColor.Red);
                return;
            }

            if (HasWon())
            {
                ConsoleUtilities.WriteLine("You have won!", ConsoleColor.Green);
                return;
            }
        }
    }

    private static void Introduction()
    {
        ConsoleUtilities.WriteLine(
            """
            You enter the Cavern of Objects, a maze of rooms filled with dangerous pits in search
            of the Fountain of Objects.
            Light is visible only in the entrance, and no other light is seen anywhere in the caverns.
            You must navigate the Caverns with your other senses.
            Find the Fountain of Objects, activate it, and return to the entrance.);
            Look out for pits. You will feel a breeze if a pit is in an adjacent room. If you enter a room with a pit, you will die.
            Maelstroms are violent forces of sentient wind. Entering a room with one could transport you to any other location in the caverns. You will be able to hear their growling and groaning in nearby rooms.
            Amaroks roam the caverns. Encountering one is certain death, but you can smell their rotten stench in nearby rooms.
            You carry with you a bow and a quiver of arrows. You can use them to shoot monsters in the caverns but be warned: you have a limited supply.
            """);
    }

    private void Status()
    {
        var row = Math.Abs(Player.Location.Row);
        var column = Math.Abs(Player.Location.Column);

        ConsoleUtilities.WriteLine($"You are in the room at (Row={row}, Column={column})", ConsoleColor.Cyan);
        var senses = new List<ISense>();
        switch (Map.GetRoom(Player.Location))
        {
            case RoomType.Entrance:
                senses.Add(new EntranceSense());
                break;
            case RoomType.Fountain:
                senses.Add(new FountainSense());
                break;
        }

        if (Map.IsRoomAround(Player.Location, RoomType.Pit))
        {
            senses.Add(new PitSense());
        }

        if (Map.IsRoomAround(Player.Location, RoomType.Maelstorm))
        {
            senses.Add(new MaelstormSense());
        }

        if (Map.IsRoomAround(Player.Location, RoomType.Amarok))
        {
            senses.Add(new AmarokSense());
        }

        foreach (var sense in senses)
        {
            sense.Display(this);
        }

        ConsoleUtilities.WriteLine($"You have {Player.Arrows} arrows remaining.", ConsoleColor.Cyan);
    }

    private static ICommand GetCommand()
    {
        while (true)
        {
            ConsoleUtilities.WriteLine("What do you want to do?");

            ICommand? command = Console.ReadLine() switch
            {
                "help" => new HelpCommand(),
                "move north" => new MoveCommand(Direction.North),
                "move south" => new MoveCommand(Direction.South),
                "move west" => new MoveCommand(Direction.West),
                "move east" => new MoveCommand(Direction.East),
                "activate fountain" => new ActivateFountainCommand(),
                "shoot north" => new ShootCommand(Direction.North),
                "shoot south" => new ShootCommand(Direction.South),
                "shoot west" => new ShootCommand(Direction.West),
                "shoot east" => new ShootCommand(Direction.East),
                _ => null
            };

            if (command != null) return command;
        }
    }

    private bool HasWon() => Map.GetRoom(Player.Location) == RoomType.Entrance && IsFountainActive;
}