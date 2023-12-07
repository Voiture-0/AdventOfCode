namespace AdventOfCode.Year2023.Tests;

public class Day5Tests : DayTests
{
    public Day5Tests() : base(day: 5) { }

    public static readonly string[] Part1ExampleInput = ["seeds: 79 14 55 13", "seed-to-soil map:", "50 98 2", "52 50 48", "", "soil-to-fertilizer map:", "0 15 37", "37 52 2", "39 0 15", "", "fertilizer-to-water map:", "49 53 8", "0 11 42", "42 0 7", "57 7 4", "", "water-to-light map:", "88 18 7", "18 25 70", "", "light-to-temperature map:", "45 77 23", "81 45 19", "68 64 13", "", "temperature-to-humidity map:", "0 69 1", "1 0 69", "", "humidity-to-location map:", "60 56 37", "56 93 4"];
    public const string Part1ExampleOutput = "35";
    public static readonly string[] Part2ExampleInput = Part1ExampleInput;
    public const string Part2ExampleOutput = "46";

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