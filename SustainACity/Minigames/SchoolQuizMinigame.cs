using System.Diagnostics;
using System.Reflection.Emit;
using SustainACity.Model;

namespace SustainACity.Minigames;
public class SchoolQuizMinigame : IMinigame
{
    private List<TriviaQuestion> _questions;
    private int TriviaScore;
    private Stopwatch _stopwatch;
    private const int TimeLimitSeconds = 60; // 1 minute time limit
    private Player? _player;

    private struct TriviaQuestion
    {
        public string Query { get; }
        public string[] Options { get; }
        public string CorrectAnswer { get; }
        public bool IsBonus { get; }

        public TriviaQuestion(string query, string[] options, string correctAnswer, bool isBonus = false)
        {
            Query = query;
            Options = options;
            CorrectAnswer = correctAnswer;
            IsBonus = isBonus;
        }
    }

    public SchoolQuizMinigame()
    {
        _questions = new List<TriviaQuestion>
        {
            // Populate with school and sustainability-themed questions
            new TriviaQuestion(
                "What percentage of paper can be saved by printing double-sided in schools?",
                new[] {"25%", "50%", "75%", "100%"},
                "50%"),

            new TriviaQuestion(
                "Identify an alternative to driving that can reduce the school's carbon footprint.",
                new[] {"Carpooling", "Walking", "Biking", "All of the above"},
                "All of the above"),
            
            // Additional school-related questions
            new TriviaQuestion(
                "What is the most energy-efficient way to conduct a class during daytime?",
                new[] {"Using electric lights", "Using natural sunlight", "Using candles", "Classes do not need light"},
                "Using natural sunlight"),

            new TriviaQuestion(
                "Which school supply can be reused to minimize waste?",
                new[] {"Pencil shavings", "Adhesive stickers", "Plastic binders", "Single-use pens"},
                "Plastic binders"),

            // ... Other questions

            // A challenging question that adds a twist
            new TriviaQuestion(
                "Calculate the amount of water saved annually by fixing a dripping faucet in a school bathroom.",
                new[] {"1,000 gallons", "3,000 gallons", "5,000 gallons", "10,000 gallons"},
                "3,000 gallons",
                isBonus: true)
        };

        // Randomize question order
        _questions = _questions.OrderBy(q => Guid.NewGuid()).ToList();
        _stopwatch = new Stopwatch();
    }

    public void Play(Player player)
    {
        _player = player;

        Console.WriteLine("Welcome to the School Quiz Challenge!");
        Console.WriteLine($"You have {TimeLimitSeconds} seconds to answer as many questions correctly as you can. Ready, set, go!\n");
        _stopwatch.Start();

        foreach (var question in _questions)
        {
            if (_stopwatch.Elapsed.Seconds >= TimeLimitSeconds)
            {
                Console.WriteLine("\nTime's up!");
                break;
            }

            bool correct = AskQuestion(question);

            // If it's a bonus question, add a gameplay twist
            if (question.IsBonus && correct)
            {
                Console.WriteLine("Bonus Round! Solve this extra challenge for bonus points!");
                // Implement the bonus round challenge here
            }
        }

        _stopwatch.Stop();
        _player.Score += TriviaScore;
        Console.WriteLine($"Game Over! Your score: {_player.Score}");
    }

    private bool AskQuestion(TriviaQuestion question)
    {
        Console.WriteLine(question.Query);
        for (int i = 0; i < question.Options.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {question.Options[i]}");
        }

        Console.Write("Your answer (number): ");
        string input = Console.ReadLine()!;
        if (int.TryParse(input, out int chosenAnswer) &&
            chosenAnswer > 0 && chosenAnswer <= question.Options.Length)
        {
            if (question.Options[chosenAnswer - 1] == question.CorrectAnswer)
            {
                Console.WriteLine("Correct!");
                TriviaScore += question.IsBonus ? 2 : 1; // Double points for a bonus question
                return true;
            }
            else
            {
                Console.WriteLine($"Wrong! The correct answer was: {question.CorrectAnswer}");
            }
        }
        else
        {
            Console.WriteLine("Invalid input. No points awarded.");
        }
        return false;
    }
}