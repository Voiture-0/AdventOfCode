using System.Text.RegularExpressions;
using AdventOfCode.Utilities;

namespace AdventOfCode.Year2023.Day2;

public partial class GameInputParser : IInputParser<Game>
{
    [GeneratedRegex("Game (?<id>\\d+):( (?<count>\\d+) (?<color>\\w+)(?<separator>,|;)?)+")]
    private static partial Regex GetInputPattern();
    public Regex Pattern => GetInputPattern();

    public static Game[] Parse(string[] input)
    {
        return InputParser<Game>.Parse(input, new GameInputParser());
    }

    public Game ParseMatch(Match match, string input)
    {
        var id = int.Parse(match.Groups["id"].Captures.First().Value);
        var counts = match.Groups["count"].Captures;
        var colors = match.Groups["color"].Captures;
        if (counts.Count != colors.Count) throw new FormatException($"Mismatched counts and colors in input: \"{input}\"");

        var game = new Game(id);
        for (var i = 0; i < counts.Count; ++i)
        {
            var count = int.Parse(counts[i].Value);
            var color = colors[i].Value;
            
            game.Cubes.TryGetValue(color, out int existingCount);
            game.Cubes[color] = Math.Max(existingCount, count);
        }
        return game;
    }
}
