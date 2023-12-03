using static AdventOfCode2023.Day2.Day2;

namespace AdventOfCode2023.Day2;

/// <summary>
/// Represents the first part of the Day 2 challenge.
/// Determines which games are possible within specific cube count constraints.
/// </summary>
public class Part1(string[] input)
{
    public const int MAX_RED_CUBES = 12;
    public const int MAX_GREEN_CUBES = 13;
    public const int MAX_BLUE_CUBES = 14;
    public readonly Dictionary<string, int> MaxCubes = new()
    {
        { COLOR_RED,   MAX_RED_CUBES   },
        { COLOR_GREEN, MAX_GREEN_CUBES },
        { COLOR_BLUE,  MAX_BLUE_CUBES  },
    };

    public readonly Game[] Games = GameInputParser.Parse(input);

    /// <summary>
    /// Executes the logic for Part 1 of the Day 2 challenge.
    /// Calculates the sum of IDs of all games that are possible within the specified cube count constraints.
    /// </summary>
    /// <returns>The sum of the IDs of valid games as a string.</returns>
    public int Run()
    {
        var sum = 0;
        foreach (var game in Games)
        {
            if (IsValidGame(game.Cubes, MaxCubes)) sum += game.Id;
        }
        return sum;
    }

    /// <summary>
    /// Determines if the game is valid based on the maximum number of cubes allowed per color.
    /// </summary>
    /// <param name="game">A Game object to validate its cubes.</param>
    /// <param name="maxCubes">A dictionary representing the maximum allowed cubes per color.</param>
    /// <returns>True if the game is valid within the given cube constraints, otherwise false.</returns>
    public static bool IsValidGame(Dictionary<string, int> gameCubes, Dictionary<string, int> maxCubes)
    {
        foreach (var kvp in gameCubes)
        {
            var color = kvp.Key;
            var shownCubes = kvp.Value;
            maxCubes.TryGetValue(color, out int max);
            if (shownCubes > max) return false;
        }
        return true;
    }
}
