namespace Tests;

public class Day3Tests : DayTests
{
    public Day3Tests() : base(day: 3) {}

    public string[] Part1ExampleInput = [];
    public string Part1ExampleOutput = "";
    public string[] Part2ExampleInput = [];
    public string Part2ExampleOutput = "";

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