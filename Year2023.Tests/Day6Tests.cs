namespace AdventOfCode.Year2023.Tests;

public class Day6Tests : DayTests
{
    public Day6Tests() : base(day: 6) { }

    public static readonly string[] Part1ExampleInput = ["Time:      7  15   30", "Distance:  9  40  200"];
    public const string Part1ExampleOutput = "288";
    public static readonly string[] Part2ExampleInput = [];
    public const string Part2ExampleOutput = "";

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