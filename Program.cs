using FountainOfObjects;

Console.WriteLine("""
                  Welcome to the Fountain of Objects!
                  Which size game would you like to play?
                  small, medium, or large
                  """);
var game = Console.ReadLine()?.ToLower() switch
{
    "small" => CreateSmallGame(),
    "medium" => CreateMediumGame(),
    "large" => CreateLargeGame(),
    _ => null
};
game?.Run();

Game CreateSmallGame()
{
    var startLocation = new Location(0, 0);
    var fountainLocation = new Location(0, 2);

    var map = new Map(4);
    map.SetRoom(startLocation, RoomType.Entrance);
    map.SetRoom(fountainLocation, RoomType.Fountain);
    map.SetRoom(new Location(1, 0), RoomType.Pit);
    map.SetRoom(new Location(3, 0), RoomType.Maelstorm);

    var player = new Player(startLocation);

    return new Game(map, player);
}

Game CreateMediumGame()
{
    var startLocation = new Location(0, 0);
    var fountainLocation = new Location(3, 4);

    var map = new Map(6);
    map.SetRoom(startLocation, RoomType.Entrance);
    map.SetRoom(fountainLocation, RoomType.Fountain);
    map.SetRoom(new Location(3, 3), RoomType.Pit);
    map.SetRoom(new Location(5, 5), RoomType.Pit);
    map.SetRoom(new Location(6, 1), RoomType.Maelstorm);

    var player = new Player(startLocation);

    return new Game(map, player);
}

Game CreateLargeGame()
{
    var startLocation = new Location(0, 0);
    var fountainLocation = new Location(7, 5);

    var map = new Map(8);
    map.SetRoom(startLocation, RoomType.Entrance);
    map.SetRoom(fountainLocation, RoomType.Fountain);
    map.SetRoom(new Location(3, 3), RoomType.Pit);
    map.SetRoom(new Location(5, 5), RoomType.Pit);
    map.SetRoom(new Location(6, 1), RoomType.Maelstorm);
    map.SetRoom(new Location(2, 2), RoomType.Maelstorm);

    var player = new Player(startLocation);

    return new Game(map, player);
}