namespace Tests;

public class Day3Tests : DayTests
{
    public Day3Tests() : base(day: 3) {}

    public static string[] Part1ExampleInput = [ "467..114..", "...*......", "..35..633.", "......#...", "617*......", ".....+.58.", "..592.....", "......755.", "...$.*....", ".664.598.." ];
    public const string Part1ExampleOutput = "4361";
    public static string[] Part2ExampleInput = Part1ExampleInput;
    public const string Part2ExampleOutput = "467835";

    [Fact]
    public void Part1Example()
    {
        Run(part: 1, Part1ExampleInput, Part1ExampleOutput);
    }
    [Fact]
    public void Part1Answer()
    {
        Run(part: 1);
    }

    [Fact]
    public void Part2Example()
    {
        Run(part: 2, Part2ExampleInput, Part2ExampleOutput);
    }
    [Fact]
    public void Part2Answer()
    {
        Run(part: 2);
    }
}