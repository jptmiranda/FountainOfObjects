namespace FountainOfObjects;

public class Player
{
    public Location Location { get; set; }
    public bool IsDead { get; set; }
    public int Arrows { get; set; } = 5;

    public Player(Location location)
    {
        Location = location;
    }
}