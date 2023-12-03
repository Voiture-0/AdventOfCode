using static AdventOfCode.Year2023.Day3.Day3;

namespace AdventOfCode.Year2023.Day3;

public class Part2(string[] input)
{
    public const string PartSymbols = "*";

    public int Run()
    {
        return ProcessSchematic(input, PartSymbols, SumGearRatios);
    }

    public static int SumGearRatios(List<int> partNumbers) => IsGear(partNumbers) ? GetGearRatio(partNumbers) : 0;
    public static bool IsGear(List<int> partNumbers) => partNumbers.Count == 2;
    public static int GetGearRatio(List<int> partNumbers) => partNumbers.First() * partNumbers.Last();
}
