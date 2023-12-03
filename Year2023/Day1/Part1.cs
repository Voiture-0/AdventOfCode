namespace AdventOfCode.Year2023.Day1;

/// <summary>
/// Represents the first part of the Day 1 challenge.
/// Focuses on recovering calibration values from a document where each line contains a two-digit number formed by the first and last digit.
/// The task is to calculate the sum of these two-digit numbers across all lines.
/// </summary>
public class Part1(string[] input)
{
    /// <summary>
    /// Executes the logic for Part 1 of the Day 1 challenge.
    /// Calculates the sum of two-digit calibration values derived from the first and last digits on each line of the input.
    /// </summary>
    /// <returns>The sum of the calibration values as a string.</returns>
    public int Run()
    {
        var sum = 0;
        foreach (var line in input)
        {
            var firstNumber = "";
            var lastNumber = "";
            for (var i = 0; i < line.Length; ++i)
            {
                var character = line[i];
                if (char.IsDigit(character))
                {
                    firstNumber = character.ToString();
                    break;
                }
            }
            for (var i = line.Length - 1; i >= 0; --i)
            {
                var character = line[i];
                if (char.IsDigit(character))
                {
                    lastNumber = character.ToString();
                    break;
                }
            }
            var number = int.Parse(firstNumber + lastNumber);
            sum += number;
        }
        return sum;
    }

    public int RunLinq()
    {
        return input
            .Select(line => int.Parse(line.First(c => char.IsDigit(c)).ToString() + line.Last(c => char.IsDigit(c)).ToString()))
            .Sum();
    }
}
