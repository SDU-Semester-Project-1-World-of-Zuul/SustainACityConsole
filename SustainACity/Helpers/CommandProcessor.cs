using SustainACity.Commands;
using SustainACity.Controller;
using SustainACity.Model;

namespace SustainACity.Helpers;

public class CommandProcessor
{
    private readonly Game _game;
    private readonly Player _player;
    private readonly Dictionary<(int, int), Room> _roomMap;
    private readonly MinigameFactory _minigameFactory;

    public CommandProcessor(Game game, Player player, Dictionary<(int, int), Room> roomMap, MinigameFactory minigameFactory)
    {
        _game = game;
        _player = player;
        _roomMap = roomMap;
        _minigameFactory = minigameFactory;
    }

    public string ProcessCommand(string input)
    {
        string[] parts = input.Trim().ToLower().Split(' ', 2);
        string commandName = parts[0];
        string argument = parts.Length > 1 ? parts[1] : null!;

        switch (commandName)
        {
            case "move":
                // Argument is expected to be a direction string like "north".
                // If not provided, the MoveCommand will handle the response.
                return new MoveCommand(_player, _roomMap, argument).Execute();
            case "back":
                return new BackCommand(_player, _roomMap).Execute();
            case "look":
                return new LookCommand(_player).Execute();
            case "talk":
                return new TalkCommand(_player, _minigameFactory).Execute();
            // Add cases for other commands like 'talk', 'take', etc.
            case "help":
                return new HelpCommand().Execute();
            case "exit":
                return new ExitCommand(_game).Execute();


            default:
                return "Unknown command.";
        }
    }
}