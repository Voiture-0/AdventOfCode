using System.Text.RegularExpressions;

namespace AdventOfCode2023;

/// <summary>
/// Represents the Day 2 challenge of the Advent of Code 2023, involving a game with cubes of different colors.
/// The challenge involves guessing the number of cubes in a bag based on partial information.
/// 
/// Brief Overview:
/// - Each game has multiple rounds with a random number of colored cubes shown.
/// - The goal is to determine the validity of games based on cube count constraints and calculate specific metrics.
/// 
/// For the full puzzle description, see https://adventofcode.com/2023/day/2
/// </summary>
public partial class Day2
{
    public const string COLOR_RED = "red";
    public const string COLOR_GREEN = "green";
    public const string COLOR_BLUE = "blue";
    public static readonly string[] Colors = [ COLOR_RED, COLOR_GREEN, COLOR_BLUE ];

    /// <summary>
    /// Represents a single game in the Day 2 challenge.
    /// Stores the game's ID and a dictionary of cubes by color.
    /// Provides functionality to check if a game meets certain cube count constraints and calculate the game's "power".
    /// </summary>
    public class Game(int id)
    {
        public int Id { get; init; } = id;
        public Dictionary<string, int> Cubes { get; } = [];

        /// <summary>
        /// Determines if the game is valid based on the maximum number of cubes allowed per color.
        /// </summary>
        /// <param name="maxCubes">A dictionary representing the maximum allowed cubes per color.</param>
        /// <returns>True if the game is valid within the given cube constraints, otherwise false.</returns>
        public bool IsValidGame(Dictionary<string, int> maxCubes)
        {
            foreach (var kvp in Cubes)
            {
                var color = kvp.Key;
                var shownCubes = kvp.Value;
                maxCubes.TryGetValue(color, out int max);
                if (shownCubes > max) return false;
            }
            return true;
        }

        /// <summary>
        /// Calculates the "power" of the game, defined as the product of the cube counts for each color.
        /// </summary>
        /// <returns>The calculated power of the game.</returns>
        public int GetPower()
        {
            var power = 1;
            foreach (var color in Colors)
            {
                Cubes.TryGetValue(color, out int count);
                power *= count;
            }
            return power;
        }
    }

    /// <summary>
    /// Represents the first part of the Day 2 challenge.
    /// Determines which games are possible within specific cube count constraints.
    /// </summary>
    public class Part1(string[] input)
    {
        public const int MAX_RED_CUBES   = 12;
        public const int MAX_GREEN_CUBES = 13;
        public const int MAX_BLUE_CUBES  = 14;
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
        public string Run()
        {
            var sum = 0;
            foreach (var game in Games)
            {
                if (game.IsValidGame(MaxCubes)) sum += game.Id;
            }
            return sum.ToString();
        }
    }

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
                sum += game.GetPower();
            }
            return sum.ToString();
        }
    }

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
}
