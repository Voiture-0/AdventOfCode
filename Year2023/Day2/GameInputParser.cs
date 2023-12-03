using AdventOfCode.Year2023.Day2;
using System.Text.RegularExpressions;

namespace AdventOfCode2023;

/// <summary>
/// Provides functionality to parse game data from input strings.
/// Utilizes regex to extract game details such as ID and cube counts per color.
/// </summary>
public static partial class GameInputParser
{
    // Compiled regex for efficient repeated use. 
    // It captures game ID, followed by several color-count pairs.
    [GeneratedRegex("Game (?<id>\\d+):( (?<count>\\d+) (?<color>\\w+)(?<separator>,|;)?)+")]
    private static partial Regex GetInputPattern();

    /// <summary>
    /// Parses an array of input strings into Game objects.
    /// Each string represents a game's data including its ID and cube counts.
    /// </summary>
    /// <param name="input">Array of input strings, each representing a game's data.</param>
    /// <returns>An array of parsed Game objects.</returns>
    /// <exception cref="FormatException">Thrown when an input string does not match the expected format.</exception>
    public static Game[] Parse(string[] input)
    {
        var games = new Game[input.Length];
        for (var i = 0; i < input.Length; ++i)
        {
            var match = GetInputPattern().Match(input[i]);
            if (!match.Success) throw new FormatException($"Invalid input format: \"{input[i]}\"");
            games[i] = ParseGame(match, input[i]);
        }
        return games;
    }

    /// <summary>
    /// Parses the details of a single game from a regex match.
    /// Extracts and processes the game's ID and cube counts per color.
    /// </summary>
    /// <param name="match">The Regex Match object containing the game data.</param>
    /// <param name="input">The input string being parsed.</param>
    /// <returns>A parsed Game object.</returns>
    private static Game ParseGame(Match match, string input)
    {
        // Parse game ID
        var id = int.Parse(match.Groups["id"].Captures.First().Value);
        // Capture groups for counts and colors
        var counts = match.Groups["count"].Captures;
        var colors = match.Groups["color"].Captures;
        if (counts.Count != colors.Count) throw new FormatException($"Mismatched counts and colors in input: \"{input}\"");

        var game = new Game(id);
        for (var i = 0; i < counts.Count; ++i)
        {
            // Parse count and color
            var count = int.Parse(counts[i].Value);
            var color = colors[i].Value;
            // Update the game's cube record
            game.Cubes.TryGetValue(color, out int existingCount);
            game.Cubes[color] = Math.Max(existingCount, count);
        }
        return game;
    }
}
