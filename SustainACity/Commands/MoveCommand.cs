using SustainACity.Controller;
using SustainACity.Model;

namespace SustainACity.Commands;

public class MoveCommand : Command
{
    private readonly Player _player;
    private readonly Dictionary<(int, int), Room> _roomMap;
    private readonly string _direction;

    private readonly Dictionary<string, (int x, int y)> _directions = new()
{
    {"north", (0, -1)},
    {"south", (0, 1)},
    {"east", (1, 0)},
    {"west", (-1, 0)}
};

    public MoveCommand(Player player, Dictionary<(int, int), Room> roomMap, string direction)
    {
        _player = player;
        _roomMap = roomMap;
        _direction = direction;
    }

    public override string Execute()
    {
        if (!_directions.TryGetValue(_direction, out var movement))
        {
            return "Invalid direction.";
        }

        // Calculate new coordinates based on direction
        var newCoordinates = (_player.CurrentRoom!.X + movement.x, _player.CurrentRoom.Y + movement.y);

        // Check if the new coordinates correspond to a valid room and move the player
        if (_roomMap.TryGetValue(newCoordinates, out Room? newRoom))
        {
            _player.MovementHistory.Push((_player.CurrentRoom.X, _player.CurrentRoom.Y));
            _player.CurrentRoom = newRoom;
            return $"Player moves {_direction} to {newRoom.Name}.";
        }
        else
        {
            return "You can't move in that direction.";
        }
    }
}