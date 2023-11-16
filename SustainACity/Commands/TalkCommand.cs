using SustainACity.Model;
using SustainACity.Minigames;

namespace SustainACity.Commands;

public class TalkCommand : Command
{
    private readonly Player _player;
    private readonly MinigameFactory _minigameFactory;

    public TalkCommand(Player player, MinigameFactory minigameFactory)
    {
        _player = player;
        _minigameFactory = minigameFactory;
    }

    public override string Execute()
    {
        if (_player.CurrentRoom!.NPC != null)
        {
            if (!string.IsNullOrEmpty(_player.CurrentRoom.NPC.Minigame))
            {
                var minigameName = _player.CurrentRoom.NPC.Minigame;
                Console.WriteLine($"You start talking to {_player.CurrentRoom.NPC.Name} and they challenge you to a game of {minigameName}.");

                try
                {
                    IMinigame minigame = _minigameFactory.CreateMinigame(minigameName);
                    minigame.Play(_player);
                }
                catch (Exception ex)
                {
                    return $"Failed to navigate to the minigame: {ex.Message}";
                }

                return $"You finished playing {minigameName} with {_player.CurrentRoom.NPC.Name}.";
            }
            return $"You talk to {_player.CurrentRoom.NPC.Name}, but they don't have a minigame for you.";
        }
        return "There is no one here to talk to.";
    }
}