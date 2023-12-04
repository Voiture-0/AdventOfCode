namespace AdventOfCode.Year2023.Day3;

public class Part2(string[] input)
{
    public const string PartSymbols = "*";

    public int Run()
    {
        return Schematic.Process(input, PartSymbols, GetGearRatio).Sum();
    }

    public static int GetGearRatio(List<int> partNumbers) => IsGear(partNumbers) ? CalculateGearRatio(partNumbers) : 0;
    public static bool IsGear(List<int> partNumbers) => partNumbers.Count == 2;
    public static int CalculateGearRatio(List<int> partNumbers) => partNumbers[0] * partNumbers[1];
}
