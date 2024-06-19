namespace FountainOfObjects;

public static class ConsoleUtilities
{
    public static void WriteLine(string message)
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(message);
    }

    public static void WriteLine(string message, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(message);
    }
}