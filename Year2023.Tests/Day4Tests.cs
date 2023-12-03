namespace AdventOfCode.Year2023.Tests;

public class Day4Tests : DayTests
{
    public Day4Tests() : base(year: 2023, day: 4) { }

    public static readonly string[] Part1ExampleInput = [];
    public const string Part1ExampleOutput = "";
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