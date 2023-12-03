namespace AdventOfCode2023.Day3;

/// <summary>
/// Represents the Day 3 challenge of Advent of Code 2023, focused on repairing a gondola lift by analyzing an engine schematic.
/// The challenge involves identifying and processing specific part numbers and calculating gear ratios based on the schematic.
/// 
/// Brief Overview:
/// - The engine schematic is represented as a grid of symbols and numbers.
/// - Part numbers are identified as numbers adjacent to specific symbols in the grid.
/// - The first task is to sum all part numbers, and the second is to calculate the sum of gear ratios for identified gears.
/// 
/// For the full puzzle description, see https://adventofcode.com/2023/day/3
/// </summary>
public class Day3
{
    /// <summary>
    /// Processes the engine schematic by identifying part numbers based on the provided symbols
    /// and applying a custom processing function to them.
    /// </summary>
    /// <param name="input">The engine schematic as an array of strings.</param>
    /// <param name="partSymbols">Symbols indicating relevant parts in the schematic.</param>
    /// <param name="processParts">A function that defines how to process the identified part numbers.</param>
    /// <returns>The cumulative result of processing all relevant parts.</returns>
    public static int ProcessSchematic(string[] input, string partSymbols, Func<List<int>, int> processParts)
    {
        var values = new List<int>();
        for (var y = 0; y < input.Length; ++y)
        for (var x = 0; x < input[y].Length; ++x)
        {
            if (!partSymbols.Contains(input[y][x])) continue;
            var partNumbers = GetPartNumbers(input, x, y);
            values.Add(processParts(partNumbers));
        }
        return values.Sum();
    }

    /// <summary>
    /// Retrieves the numbers adjacent to a given position in the schematic that are considered part numbers.
    /// </summary>
    /// <param name="input">The engine schematic as an array of strings.</param>
    /// <param name="cX">The x-coordinate in the schematic.</param>
    /// <param name="cY">The y-coordinate in the schematic.</param>
    /// <returns>A list of integers representing adjacent part numbers.</returns>
    public static List<int> GetPartNumbers(string[] input, int cX, int cY)
    {
        var partNumbers = new List<int>();
        // Find adjacent numbers
        for (var y = cY-1; y <= cY+1; ++y)
        for (var x = cX-1; x <= cX+1; ++x)
        {
            if (!char.IsDigit(input[y][x])) continue;
            var number = "";
            // Check to the left until start of number
            while (--x >= 0 && char.IsDigit(input[y][x])) ;
            // Concatenate digits from right to left
            while (++x < input[y].Length && char.IsDigit(input[y][x])) number += input[y][x];
            // Save adjacent number
            partNumbers.Add(int.Parse(number));
        }
        return partNumbers;
    }    
}
