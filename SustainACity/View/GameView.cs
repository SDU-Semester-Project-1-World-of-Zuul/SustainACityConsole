using SustainACity.Helpers;

namespace SustainACity.View;

public class GameView
{
    public string GetInput()
    {
        Console.Write("> ");
        return Parser.ParseCommand(Console.ReadLine()!);
    }

    public void DisplayOutput(string output)
    {
        Typewriter.TypePrint(output);
    }
}