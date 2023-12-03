using static AdventOfCode2023.Day3.Day3;

namespace AdventOfCode2023.Day3;

public class Part1(string[] input)
{
    public const string PartSymbols = "%=*#$@&/-+";

    public int Run()
    {
        return ProcessSchematic(input, PartSymbols, ProcessParts);
    }

    public static int ProcessParts(List<int> partNumbers) => partNumbers.Sum();
}
