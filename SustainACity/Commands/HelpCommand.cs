using System.Text;

namespace SustainACity.Commands;

public class HelpCommand : Command
{
    public override string Execute()
    {
        StringBuilder helpMessage = new();

        helpMessage.AppendLine("Available commands:");
        helpMessage.AppendLine("'move <direction>' - Moves the player in the specified direction.");
        helpMessage.AppendLine("'look' - Describes the current room.");
        helpMessage.AppendLine("'talk' - Talks to an NPC if present.");
        helpMessage.AppendLine("'help' - Shows this help message.");
        helpMessage.AppendLine("'exit' - Exits the game.");

        return helpMessage.ToString();
    }
}