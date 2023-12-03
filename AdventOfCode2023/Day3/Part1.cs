using static AdventOfCode2023.Day3.Day3;

namespace AdventOfCode2023.Day3;

/// <summary>
/// Represents the first part of the Day 3 challenge.
/// Sums up all part numbers adjacent to specific symbols in the engine schematic.
/// </summary>
public class Part1(string[] input)
{
    public const string PartSymbols = "%=*#$@&/-+";

    /// <summary>
    /// Executes the logic for Part 1 of the Day 3 challenge.
    /// Calculates the sum of all part numbers adjacent to specific symbols in the engine schematic.
    /// </summary>
    /// <returns>The sum of all relevant part numbers in the schematic as an integer.</returns>
    public int Run()
    {
        return ProcessSchematic(input, PartSymbols, SumPartNumbers);
    }

    /// <summary>
    /// Sums a list of integers. This method is intended to process a collection of part numbers by calculating their total sum.
    /// </summary>
    /// <param name="partNumbers">List of integers representing part numbers.</param>
    /// <returns>The sum of the integers in the provided list.</returns>
    public static int SumPartNumbers(List<int> partNumbers) => partNumbers.Sum();
}
