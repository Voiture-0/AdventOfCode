namespace AdventOfCode.Year2023.Day2;

public class Part1(string[] input)
{
    public const int MAX_RED_CUBES   = 12;
    public const int MAX_GREEN_CUBES = 13;
    public const int MAX_BLUE_CUBES  = 14;
    public readonly Dictionary<string, int> MaxCubes = new()
    {
        { CubeColors.RED,   MAX_RED_CUBES   },
        { CubeColors.GREEN, MAX_GREEN_CUBES },
        { CubeColors.BLUE,  MAX_BLUE_CUBES  },
    };

    public readonly Game[] Games = GameInputParser.Parse(input);

    public int Run()
    {
        var sum = 0;
        foreach (var game in Games)
        {
            if (IsValidGame(game.Cubes, MaxCubes)) sum += game.Id;
        }
        return sum;
    }

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
