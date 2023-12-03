using static AdventOfCode.Year2023.Day3.Day3;

namespace AdventOfCode.Year2023.Day3;

public class Part1(string[] input)
{
    public const string PartSymbols = "%=*#$@&/-+";

    public int Run()
    {
        return ProcessSchematic(input, PartSymbols, SumPartNumbers);
    }

    public static int SumPartNumbers(List<int> partNumbers) => partNumbers.Sum();
}
