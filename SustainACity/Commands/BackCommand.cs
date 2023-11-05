using SustainACity.Model;

namespace SustainACity.Commands;

public class BackCommand : Command
{
    private readonly Player _player;
    private readonly Dictionary<(int, int), Room> _roomMap;

    public BackCommand(Player player, Dictionary<(int, int), Room> roomMap)
    {
        _player = player;
        _roomMap = roomMap;
    }

    public override string Execute()
    {
        // Check if there is a previous room to go back to
        if (_player.MovementHistory.Any())
        {
            // Get the last coordinates from the movement history
            var lastCoordinates = _player.MovementHistory.Pop();

            // Check if the room still exists (sanity check)
            if (_roomMap.TryGetValue(lastCoordinates, out Room? lastRoom))
            {
                _player.CurrentRoom = lastRoom;
                return $"You moved back to {_player.CurrentRoom.Name}.";
            }
            else
            {
                return "The way back seems to be blocked now.";
            }
        }
        else
        {
            return "There's nowhere to go back to.";
        }
    }
}
