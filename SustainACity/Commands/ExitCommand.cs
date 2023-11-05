using SustainACity.Controller;

namespace SustainACity.Commands;

public class ExitCommand : Command
{
    private readonly Game _game;

    public ExitCommand(Game game)
    {
        _game = game;
    }

    public override string Execute()
    {
        // Here you can add any logic that needs to run before exiting, like saving the game.
        _game.IsRunning = false;
        return "Exiting the game. Goodbye!";
    }
}
