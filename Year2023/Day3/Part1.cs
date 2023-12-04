namespace AdventOfCode.Year2023.Day3;

public class Part1(string[] input)
{
    public const string PartSymbols = "%=*#$@&/-+";

    public int Run()
    {
        return Schematic.Process(input, PartSymbols, SumPartNumbers);
    }

    public static int SumPartNumbers(List<int> partNumbers) => partNumbers.Sum();
}
