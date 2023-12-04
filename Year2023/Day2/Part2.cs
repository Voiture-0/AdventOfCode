namespace AdventOfCode.Year2023.Day2;

public class Part2(string[] input)
{
    public readonly Game[] Games = GameInputParser.Parse(input);

    public int Run()
    {
        var sum = 0;
        foreach (var game in Games)
        {
            sum += GetPower(game.Cubes);
        }
        return sum;
    }

    public static int GetPower(Dictionary<string, int> cubes)
    {
        var power = 1;
        foreach (var color in CubeColors.All)
        {
            cubes.TryGetValue(color, out int count);
            power *= count;
        }
        return power;
    }
}
