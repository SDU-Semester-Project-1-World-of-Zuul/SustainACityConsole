using SustainACity.Model;

namespace SustainACity.Commands;

public class LookCommand : Command
{
    private readonly Player _player;

    public LookCommand(Player player)
    {
        _player = player;
    }

    public override string Execute()
    {
        // Ensure that there is a current room to look at
        if (_player.CurrentRoom != null)
        {
            // Return the description of the current room
            return _player.CurrentRoom.Description!;
        }
        else
        {
            // If the player somehow has no current room, return an error message
            return "There is nothing to look at.";
        }
    }
}
