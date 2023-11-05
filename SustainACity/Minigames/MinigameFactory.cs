using SustainACity.Minigames;

public class MinigameFactory
{
    public IMinigame CreateMinigame(string minigameName)
    {
        switch (minigameName)
        {
            case "SchoolQuizMinigame":
                return new SchoolQuizMinigame();
            case "TriviaMinigame":
                return new WIPMinigame();
            case "BalancingActMinigame":
                return new BalancingActMinigame();
            // Add other minigames here
            default:
                throw new ArgumentException("Invalid minigame name");
        }
    }
}