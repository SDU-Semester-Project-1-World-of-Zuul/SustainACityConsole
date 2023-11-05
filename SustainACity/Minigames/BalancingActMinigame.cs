using SustainACity.Model;

namespace SustainACity.Minigames;

public class BalancingActMinigame : IMinigame
{
    private const int InitialNumbersCount = 3; // Starting difficulty with 3 numbers

    public void Play(Player player)
    {
        Console.WriteLine("Welcome to the Balancing Act Minigame!");

        int difficultyLevel = 1; // Initial difficulty level
        bool keepPlaying = true;

        while (keepPlaying)
        {
            int[] values = GenerateValues(InitialNumbersCount + difficultyLevel - 1);
            Console.WriteLine($"Your numbers are: {string.Join(", ", values)}");

            int attemptsLeft = 3; // You can adjust the number of attempts as needed
            while (attemptsLeft > 0 && !CheckIfBalanced(values))
            {
                values = PlayerAttempt(values);
                attemptsLeft--;
            }

            if (CheckIfBalanced(values))
            {
                Console.WriteLine("Congratulations! You've balanced all numbers!");
                player.Score += CalculateScore(difficultyLevel); // Add score based on difficulty level
                                                                 // Ask the player if they want to continue playing
                Console.WriteLine("Do you want to play another round? (yes/no)");
                keepPlaying = Console.ReadLine()!.Trim().ToLower()! == "yes";
            }
            else
            {
                Console.WriteLine("You've failed to balance the numbers. Negative credits applied.");
                player.Score -= CalculatePenalty(difficultyLevel); // Subtract score as a penalty
            }

            if (keepPlaying)
            {
                difficultyLevel++; // Increase difficulty for the next round (more numbers to balance)
                Console.WriteLine($"Moving on to difficulty level {difficultyLevel}.");
            }
            else
            {
                Console.WriteLine("Thanks for playing the Balancing Act Minigame!");
            }
        }
    }

    private int[] GenerateValues(int count)
    {
        Random rnd = new Random();
        return Enumerable.Range(1, count).Select(x => rnd.Next(1, 101)).ToArray(); // Values between 1 and 100
    }

    private int[] PlayerAttempt(int[] values)
    {
        Console.WriteLine("Enter the positions of two numbers to swap (e.g., '1 2'): ");
        string? input = Console.ReadLine();

        var positions = input!.Split(' ').Select(int.Parse).ToArray();
        if (positions.Length == 2 && positions.All(pos => pos >= 1 && pos <= values.Length))
        {
            int temp = values[positions[0] - 1];
            values[positions[0] - 1] = values[positions[1] - 1];
            values[positions[1] - 1] = temp;
        }
        else
        {
            Console.WriteLine("Invalid positions entered.");
        }

        return values;
    }

    private bool CheckIfBalanced(int[] values)
    {
        return values.Distinct().Count() == 1; // All values are equal
    }

    private int CalculateScore(int difficultyLevel)
    {
        // Score calculation can be adjusted as needed
        return 10 * difficultyLevel; // Example: base score multiplied by difficulty level
    }

    private int CalculatePenalty(int difficultyLevel)
    {
        // Penalty calculation can be adjusted as needed
        return 5 * difficultyLevel; // Example: base penalty multiplied by difficulty level
    }
}
