namespace FountainOfObjects;

public class Map
{
    private RoomType[,] Rooms { get; }
    public int Size() => Rooms.GetLength(0);

    public Map(int size)
    {
        Rooms = new RoomType[size, size];
    }

    public void SetRoom(Location location, RoomType type)
    {
        if(!IsValidLocation(location)) throw new ArgumentException("Location is not valid.");
        Rooms[location.Row, location.Column] = type;
    }

    public RoomType GetRoom(Location location) => Rooms[location.Row, location.Column];

    public bool IsValidLocation(Location location)
    {
        return location.Row < Rooms.GetLength(0) && location.Row >= 0 && location.Column < Rooms.GetLength(1) &&
               location.Column >= 0;
    }

    public bool IsRoomAround(Location playerLocation, RoomType type)
    {
        var playerRow = playerLocation.Row;
        var playerColumn = playerLocation.Column;

        for (var column = playerColumn -1; column <= playerColumn+1; column++)
        {
            for (var row = playerRow - 1; row <= playerRow + 1; row++)
            {
                if (row == playerRow && column == playerColumn) continue;

                if (IsValidLocation(new Location(row, column)) && GetRoom(new Location(row, column)) == type)
                {
                    return true;
                }
            }
        }

        return false;
    }
}