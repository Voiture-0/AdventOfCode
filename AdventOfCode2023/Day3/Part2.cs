using static AdventOfCode2023.Day3.Day3;

namespace AdventOfCode2023.Day3;

public class Part2(string[] input)
{
    public const string PartSymbols = "*";

    public string Run()
    {
        var sum = 0;
        for (var y = 0; y < input.Length; ++y)
        for (var x = 0; x < input[y].Length; ++x)
        {
            if (!IsPartSymbol(input[y][x])) continue;
            var partNumbers = GetPartNumbers(input, x, y);
            if (IsGear(partNumbers)) sum += GetGearRatio(partNumbers);
        }
        return sum.ToString();
    }

    private static bool IsPartSymbol(char c) => PartSymbols.Contains(c);
    public static bool IsGear(List<int> partNumbers) => partNumbers.Count == 2;
    public static int GetGearRatio(List<int> partNumbers) => partNumbers.First() * partNumbers.Last();
}
