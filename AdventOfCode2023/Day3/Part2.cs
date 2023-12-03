using static AdventOfCode2023.Day3.Day3;

namespace AdventOfCode2023.Day3;

public class Part2(string[] input)
{
    public const string PartSymbols = "*";

    public string Run()
    {
        return ProcessSchematic(input, PartSymbols, ProcessParts).ToString();
    }

    public static int ProcessParts(List<int> partNumbers) => IsGear(partNumbers) ? GetGearRatio(partNumbers) : 0;
    public static bool IsGear(List<int> partNumbers) => partNumbers.Count == 2;
    public static int GetGearRatio(List<int> partNumbers) => partNumbers.First() * partNumbers.Last();
}
