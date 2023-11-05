using SustainACity.Model;
using SustainACity.Helpers;

namespace SustainACity.View;

public class NewPlayerView
{
    private readonly Dictionary<string, string> _backgrounds = new()
    {
        {"1", "Architect"},
        {"2", "Engineer"},
        {"3", "Urban Planner"},
        {"4", "Environmental Scientist"}
    };
    private readonly string GuideName = "Morgan Freeman";

    public Player RegisterNewPlayer(Player newPlayer)
    {
        Console.Clear();
        Typewriter.TypePrint("As you open your eyes, the blur of colors starts to take shape.");
        Typewriter.TypePrint("An enthusiastic face looms into view, framed by a halo of wild hair.");

        // Introduction by the guide
        Typewriter.TypePrint("???: Ah, you're awake! Welcome to the world of Sustain A City!");
        Typewriter.TypePrint($"???: You can call me {GuideName}. I am known around here as the sustainability guru.");
        Typewriter.TypePrint($"{GuideName}: But enough about me. This is your story!");


        // Get the player's name
        Typewriter.TypePrint($"{GuideName}: Let's begin with your name. What do people call you? ");
        newPlayer.Name = Console.ReadLine();

        // Get the player's background
        Typewriter.TypePrint($"{GuideName}: Now, tell me, what expertise do you bring to our city?");
        _backgrounds.ToList().ForEach(b => Typewriter.TypePrint($"{b.Key}. {b.Value}"));

        Typewriter.TypePrint($"{GuideName}: Make your choice: ");
        string profession;
        while (!_backgrounds.TryGetValue(Console.ReadLine()!, out profession!))
            Typewriter.TypePrint($"{GuideName}: I didn't quite catch that. Please choose a number from the list:");

        Typewriter.TypePrint($"{GuideName}: Fascinating! An expert in {profession}, you say? Splendid!");
        Typewriter.TypePrint($"{GuideName}: Well then, {newPlayer.Name}, our city is in need of visionaries like you.");
        Typewriter.TypePrint($"{GuideName}: Your knowledge and skills will be the cornerstone of our sustainability efforts!");
        Typewriter.TypePrint($"{GuideName}: Bye now! Oh right, this is where you are...\n");

        return newPlayer;
    }
}