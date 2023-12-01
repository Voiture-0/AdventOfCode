namespace Tests;

public class Day1Tests : DayTests
{
    public Day1Tests() : base(day: 1) {}

    public string[] Part1ExampleInput = ["1abc2", "pqr3stu8vwx", "a1b2c3d4e5f", "treb7uchet"];
    public string Part1ExampleOutput = "142";
    public string[] Part2ExampleInput = ["two1nine", "eightwothree", "abcone2threexyz", "xtwone3four", "4nineeightseven2", "zoneight234", "7pqrstsixteen"];
    public string Part2ExampleOutput = "281";

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
    public void Part1LinqExample()
    {
        var result = new Day1.Part1(Part1ExampleInput).RunLinq();
        var expected = Part1ExampleOutput;
        result.Should().Be(expected);
    }
    [Fact]
    public void Part1LinqAnswer()
    {
        var result = new Day1.Part1(_input).RunLinq();
        var expected = _dayConfig.Part1.Answer;
        result.Should().Be(expected);
    }

    [Fact]
    public void Part2Example()
    {
        Run(part: 2, Part2ExampleInput, Part2ExampleOutput);
    }
    [Fact]
    public void Part2Answer()
    {
        // Incorrect guesses 54837, 54826
        Run(part: 2);
    }
}