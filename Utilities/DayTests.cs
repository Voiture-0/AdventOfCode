using FluentAssertions;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace AdventOfCode.Utilities;

public class DayTests
{
    protected readonly string[] _input;
    protected readonly IConfiguration _configuration;
    protected readonly Type _sutType1;
    protected readonly Type _sutType2;
    protected readonly int _day;
    protected readonly int _year;

    public DayTests(int day)
    {
        _day = day;
        _input = File.ReadAllLines($"Inputs/Day{_day}Input.txt");
        _configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

        _year = int.Parse(_configuration["year"] ?? throw new Exception("Missing \"year\" in appsettings.json"));

        var assemblyName = $"AdventOfCode.Year{_year}";
        var classLibraryAssembly = Assembly.Load(assemblyName) ?? throw new Exception($"Could not find Assembly {assemblyName}");
        var dayPartTypePrefix = $"{assemblyName}.Day{_day}.Part";
        var dayPart1TypeName = dayPartTypePrefix + "1";
        var dayPart2TypeName = dayPartTypePrefix + "2";
        _sutType1 = classLibraryAssembly.GetType(dayPart1TypeName) ?? throw new Exception($"Could not find type {dayPart1TypeName}");
        _sutType2 = classLibraryAssembly.GetType(dayPart2TypeName) ?? throw new Exception($"Could not find type {dayPart2TypeName}");
    }

    public void Run(int part, string[]? input = null, string? expect = null)
    {
        var partType = part switch
        {
            1 => _sutType1,
            2 => _sutType2,
            _ => throw new Exception($"No type for {_year} day {_day} part {part}"),
        };
        var partInstance = Activator.CreateInstance(partType, [input ?? _input]);
        var runMethod = partType.GetMethod("Run");
        var result = runMethod?.Invoke(partInstance, null)?.ToString();
        var expected = expect ?? _configuration[$"days:day{_day}:part{part}:answer"];
        result.Should().Be(expected);
    }
}
