using AdventOfCode2023.Day1;

namespace Tests;

public class Day1Tests : DayTests
{
    public Day1Tests() : base(day: 1) {}

    public static readonly string[] Part1ExampleInput = ["1abc2", "pqr3stu8vwx", "a1b2c3d4e5f", "treb7uchet"];
    public const string Part1ExampleOutput = "142";
    public static readonly string[] Part2ExampleInput = ["two1nine", "eightwothree", "abcone2threexyz", "xtwone3four", "4nineeightseven2", "zoneight234", "7pqrstsixteen"];
    public const string Part2ExampleOutput = "281";

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
        // Incorrect guesses 54837, 54826
        Run(part: 2);
    }
}