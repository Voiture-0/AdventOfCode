namespace Tests;

public class Day1Tests
{
    public const string InputFilePath = "Inputs/Day1Input.txt";

    [Fact]
    public void Part1Example()
    {
        string[] input = ["1abc2", "pqr3stu8vwx", "a1b2c3d4e5f", "treb7uchet"];
        var result = new Day1.Part1().Run(input);
        result.Should().Be("142");
    }
    [Fact]
    public void Part1Answer()
    {
        var input = File.ReadAllLines(InputFilePath);
        var result = new Day1.Part1().Run(input);
        result.Should().Be("55386");
    }

    [Fact]
    public void Part2Example()
    {
        string[] input = ["two1nine", "eightwothree", "abcone2threexyz", "xtwone3four", "4nineeightseven2", "zoneight234", "7pqrstsixteen"];
        var result = new Day1.Part2().Run(input);
        result.Should().Be("281");
    }
    [Fact]
    public void Part2Answer()
    {
        var input = File.ReadAllLines(InputFilePath);
        var result = new Day1.Part2().Run(input);
        result.Should().NotBe("54837");
        result.Should().NotBe("54826");
        result.Should().Be("54824");
    }
}