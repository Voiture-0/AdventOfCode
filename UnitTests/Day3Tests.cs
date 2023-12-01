using AdventOfCode2023;
using FluentAssertions;

namespace Tests;

public class Day3Tests
{
    public const string InputFilePath = "Inputs/Day3Input.txt";

    [Fact]
    public void Part1Example()
    {
        string[] input = [];
        var result = new Day3.Part1().Run(input);
        result.Should().Be("");
    }
    [Fact]
    public void Part1Answer()
    {
        var input = File.ReadAllLines(InputFilePath);
        var result = new Day3.Part1().Run(input);
        result.Should().Be("");
    }

    [Fact]
    public void Part2Example()
    {
        string[] input = [];
        var result = new Day3.Part2().Run(input);
        result.Should().Be("");
    }
    [Fact]
    public void Part2Answer()
    {
        var input = File.ReadAllLines(InputFilePath);
        var result = new Day3.Part2().Run(input);
        result.Should().Be("");
    }
}