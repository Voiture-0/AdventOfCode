using static AdventOfCode2023.Day2.Day2;

namespace AdventOfCode2023.Day2;

/// <summary>
/// Represents the second part of the Day 2 challenge.
/// Calculates the sum of the "power" of each game, where the power is a specific metric based on cube counts.
/// </summary>
public class Part2(string[] input)
{
    public readonly Game[] Games = GameInputParser.Parse(input);

    /// <summary>
    /// Executes the logic for Part 2 of the Day 2 challenge.
    /// Calculates the sum of the power of each game.
    /// </summary>
    /// <returns>The sum of the powers of all games as a string.</returns>
    public string Run()
    {
        var sum = 0;
        foreach (var game in Games)
        {
            sum += GetPower(game.Cubes);
        }
        return sum.ToString();
    }

    /// <summary>
    /// Calculates the "power" of the game, defined as the product of the cube counts for each color.
    /// </summary>
    /// <param name="cubes">A dictionary of cube colors and their counts for a game.</param>
    /// <returns>The calculated power of the game.</returns>
    public int GetPower(Dictionary<string, int> cubes)
    {
        var power = 1;
        foreach (var color in Colors)
        {
            cubes.TryGetValue(color, out int count);
            power *= count;
        }
        return power;
    }
}
