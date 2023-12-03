using static AdventOfCode2023.Day3.Day3;

namespace AdventOfCode2023.Day3;

public class Part1(string[] input)
{
    public const string PartSymbols = "%=*#$@&/-+";

    public string Run()
    {
        var sum = 0;
        for (var y = 0; y < input.Length; ++y)
        for (var x = 0; x < input[y].Length; ++x)
        {
            if (!IsPartSymbol(input[y][x])) continue;
            var partNumbers = GetPartNumbers(input, x, y);
            sum += partNumbers.Sum();
        }
        return sum.ToString();
    }

    private static bool IsPartSymbol(char c) => PartSymbols.Contains(c);
}
