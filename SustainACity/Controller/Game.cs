using SustainACity.Model;
using SustainACity.Helpers;
using SustainACity.View;

namespace SustainACity.Controller;

public class Game
{
    public bool IsRunning;
    private readonly CommandProcessor _commandProcessor;
    private readonly GameView _gameView;
    private readonly Player _player;
    private readonly Dictionary<(int, int), Room> _roomMap = new();
    private readonly MinigameFactory _minigameFactory;

    public Game(Player player)
    {
        IsRunning = true;
        _gameView = new GameView();
        JsonLoader jsonLoader = new(Path.Combine(AppContext.BaseDirectory, "Data/Rooms.json"));
        _roomMap = jsonLoader.LoadRooms().ToDictionary(room => (room.X, room.Y));
        _player = player;
        _player = new() { CurrentRoom = _roomMap.GetValueOrDefault((0, 0))! };
        _minigameFactory = new();
        _commandProcessor = new CommandProcessor(this, _player, _roomMap, _minigameFactory);
    }

    public void Run()
    {
        // Initial help displayed
        _gameView.DisplayOutput($"You are in {_player.CurrentRoom!.Name}.\n");
        _gameView.DisplayOutput(_commandProcessor.ProcessCommand("help"));

        while (IsRunning)
        {
            string input = _gameView.GetInput();
            string output = _commandProcessor.ProcessCommand(input);
            _gameView.DisplayOutput(output);
        }
    }
}