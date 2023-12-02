namespace AdventOfCode2023;

/// <summary>
/// --- Day 2: Cube Conundrum ---
/// You're launched high into the atmosphere! The apex of your trajectory just barely reaches the surface of a large island floating in the sky. You gently land in a fluffy pile of leaves. It's quite cold, but you don't see much snow. An Elf runs over to greet you.
/// 
/// The Elf explains that you've arrived at Snow Island and apologizes for the lack of snow. He'll be happy to explain the situation, but it's a bit of a walk, so you have some time. They don't get many visitors up here; would you like to play a game in the meantime?
/// 
/// As you walk, the Elf shows you a small bag and some cubes which are either red, green, or blue.Each time you play this game, he will hide a secret number of cubes of each color in the bag, and your goal is to figure out information about the number of cubes.
/// 
/// To get information, once a bag has been loaded with cubes, the Elf will reach into the bag, grab a handful of random cubes, show them to you, and then put them back in the bag. He'll do this a few times per game.
/// 
/// You play several games and record the information from each game (your puzzle input). Each game is listed with its ID number(like the 11 in Game 11: ...) followed by a semicolon-separated list of subsets of cubes that were revealed from the bag(like 3 red, 5 green, 4 blue).
/// 
/// For example, the record of a few games might look like this:
/// 
/// Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green
/// Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue
/// Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red
/// Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red
/// Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green
/// In game 1, three sets of cubes are revealed from the bag (and then put back again). The first set is 3 blue cubes and 4 red cubes; the second set is 1 red cube, 2 green cubes, and 6 blue cubes; the third set is only 2 green cubes.
/// </summary>
public class Day2
{
    public const string COLOR_RED = "red";
    public const string COLOR_GREEN = "green";
    public const string COLOR_BLUE = "blue";
    public static readonly string[] Colors = [ COLOR_RED, COLOR_GREEN, COLOR_BLUE ];

    public class Game
    {
        public int Id { get; init; }
        public Dictionary<string, int> Cubes { get; init; } = [];

        public Game(string input)
        {
            // TODO: Clean this up!
            // Example Input = "Game 1: 2 red, 3 blue; 4 blue, 5 green"
            var colonSplit = input.Split(':');
            Id = int.Parse(colonSplit[0].Split(' ')[1]);
            var sets = colonSplit[1].Split(';');
            foreach (var set in sets)
            {
                var cubes = set.Split(',');
                foreach (var c in cubes)
                {
                    var data = c.Split(' ');
                    var count = int.Parse(data[1]);
                    var color = data[2];
                    Cubes.TryGetValue(color, out int value);
                    Cubes[color] = Math.Max(value, count);
                }
            }
        }

        public bool HasEnoughCubes(Dictionary<string, int> maxCubes)
        {
            foreach (var kvp in Cubes)
            {
                var color = kvp.Key;
                var count = kvp.Value;
                maxCubes.TryGetValue(color, out int max);
                if (count > max) return false;
            }
            return true;
        }
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
    
    private static Game[] ParseGames(string[] input)
    {
        return input
            .Select(i => new Game(i))
            .ToArray();
    }

    /// <summary>
    /// --- Part One ---
    /// The Elf would first like to know which games would have been possible if the bag contained only 12 red cubes, 13 green cubes, and 14 blue cubes?
    /// 
    /// In the example above, games 1, 2, and 5 would have been possible if the bag had been loaded with that configuration. However, game 3 would have been impossible because at one point the Elf showed you 20 red cubes at once; similarly, game 4 would also have been impossible because the Elf showed you 15 blue cubes at once. If you add up the IDs of the games that would have been possible, you get 8.
    /// 
    /// Determine which games would have been possible if the bag had been loaded with only 12 red cubes, 13 green cubes, and 14 blue cubes. What is the sum of the IDs of those games?
    /// </summary>
    public class Part1(string[] input)
    {
        public readonly Dictionary<string, int> MaxColors = new() { { COLOR_RED, 12 }, { COLOR_GREEN, 13 }, { COLOR_BLUE, 14 } };

        public readonly Game[] Games = ParseGames(input);

        public string Run()
        {
            var sum = 0;
            foreach (var game in Games)
            {
                if (game.HasEnoughCubes(MaxColors)) sum += game.Id;
            }
            return sum.ToString();
        }
    }

    /// <summary>
    /// --- Part Two ---
    /// The Elf says they've stopped producing snow because they aren't getting any water! He isn't sure why the water stopped; however, he can show you how to get to the water source to check it out for yourself. It's just up ahead!
    /// 
    /// As you continue your walk, the Elf poses a second question: in each game you played, what is the fewest number of cubes of each color that could have been in the bag to make the game possible?
    /// 
    /// Again consider the example games from earlier:
    /// 
    /// Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green
    /// Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue
    /// Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red
    /// Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red
    /// Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green
    /// In game 1, the game could have been played with as few as 4 red, 2 green, and 6 blue cubes.If any color had even one fewer cube, the game would have been impossible.
    /// Game 2 could have been played with a minimum of 1 red, 3 green, and 4 blue cubes.
    /// Game 3 must have been played with at least 20 red, 13 green, and 6 blue cubes.
    /// Game 4 required at least 14 red, 3 green, and 15 blue cubes.
    /// Game 5 needed no fewer than 6 red, 3 green, and 2 blue cubes in the bag.
    /// The power of a set of cubes is equal to the numbers of red, green, and blue cubes multiplied together.The power of the minimum set of cubes in game 1 is 48. In games 2-5 it was 12, 1560, 630, and 36, respectively.Adding up these five powers produces the sum 2286.
    /// 
    /// For each game, find the minimum set of cubes that must have been present.What is the sum of the power of these sets?
    /// </summary>
    public class Part2(string[] input)
    {
        public readonly Game[] Games = ParseGames(input);

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
}
