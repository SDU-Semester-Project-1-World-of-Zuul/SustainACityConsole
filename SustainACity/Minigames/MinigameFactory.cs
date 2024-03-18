using System;
using System.Reflection;
using SustainACity.Minigames;

public class MinigameFactory
{
    public IMinigame CreateMinigame(string minigameName)
    {
        // Combines the minigame name with the namespace
        string typeName = $"SustainACity.Minigames.{minigameName}";

        // Get the Type from the minigame name
        Type? minigameType = Type.GetType(typeName);

        if (minigameType != null)
        {
            ConstructorInfo constructor = minigameType.GetConstructor(Type.EmptyTypes) ?? throw new InvalidOperationException($"Minigame '{minigameName}' does not have a parameterless constructor.");
            return (IMinigame)constructor.Invoke(null);
        }
        else
        {
            throw new ArgumentException($"Minigame '{minigameName}' does not exist.", nameof(minigameName));
        }
    }
}