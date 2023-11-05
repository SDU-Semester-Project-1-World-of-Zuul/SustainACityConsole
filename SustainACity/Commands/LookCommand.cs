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
        return (_player.CurrentRoom != null) ? _player.CurrentRoom.Description! : "There is nothing to look at.";
    }
}