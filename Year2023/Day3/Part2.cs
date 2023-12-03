using static AdventOfCode.Year2023.Day3.Day3;

namespace AdventOfCode.Year2023.Day3;

/// <summary>
/// Represents the second part of the Day 3 challenge.
/// Identifies gears in the schematic and calculates their gear ratios.
/// </summary>
public class Part2(string[] input)
{
    public const string PartSymbols = "*";

    /// <summary>
    /// Executes the logic for Part 2 of the Day 3 challenge.
    /// Identifies gears within the engine schematic and calculates their gear ratios.
    /// </summary>
    /// <returns>The sum of all gear ratios in the schematic as an integer.</returns>
    public int Run()
    {
        return ProcessSchematic(input, PartSymbols, SumGearRatios);
    }

    /// <summary>
    /// Processes a list of integers representing part numbers. If the list represents a valid gear (exactly two numbers), calculates the gear ratio; otherwise returns 0.
    /// </summary>
    /// <param name="partNumbers">List of integers representing part numbers adjacent to a potential gear.</param>
    /// <returns>The product of the two numbers if the list represents a gear, otherwise 0.</returns>
    public static int SumGearRatios(List<int> partNumbers) => IsGear(partNumbers) ? GetGearRatio(partNumbers) : 0;

    /// <summary>
    /// Determines whether a given list of integers represents a gear, which is defined as having exactly two numbers.
    /// </summary>
    /// <param name="partNumbers">List of integers representing part numbers.</param>
    /// <returns>True if the list contains exactly two numbers, otherwise false.</returns>
    public static bool IsGear(List<int> partNumbers) => partNumbers.Count == 2;

    /// <summary>
    /// Calculates the product of two integers, intended to represent the gear ratio calculated from two adjacent part numbers.
    /// </summary>
    /// <param name="partNumbers">A list containing exactly two integers representing part numbers.</param>
    /// <returns>The product of the two integers.</returns>
    public static int GetGearRatio(List<int> partNumbers) => partNumbers.First() * partNumbers.Last();
}
