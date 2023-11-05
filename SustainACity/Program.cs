using SustainACity.Controller;
using SustainACity.View;
using SustainACity.Model;

namespace SustainACity;

static class Program
{
    static void Main(string[] args)
    {
        StartView startView = new();
        startView.Show(); // Show the start screen and wait for user input.

        Player player = new();
        NewPlayerView newPlayerView = new();
        player = newPlayerView.RegisterNewPlayer(player);

        Game game = new(player);
        game.Run();
    }
}