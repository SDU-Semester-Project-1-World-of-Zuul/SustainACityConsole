namespace SustainACity.Helpers;

public static class Typewriter
{
    public static void TypePrint(string message, int delay = 20) // Default delay can be changed if needed e.g. 0 for instant print
    {
        foreach (char c in message)
        {
            Console.Write(c);
            Thread.Sleep(delay); // Wait a bit before printing the next character
        }
        Console.WriteLine();
    }
}