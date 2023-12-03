using AdventOfCode.Year2023.Tests.Config;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using System.Security.Cryptography;

namespace AdventOfCode.Year2023.Tests;

public class DayTestsOld
{
    private const string _assemblyName = "AdventOfCode2023";
    protected readonly string[] _input;
    protected readonly IConfiguration _configuration;
    protected readonly DayConfig _dayConfig;
    protected readonly Type _sutType1;
    protected readonly Type _sutType2;
    protected readonly int _day;

    public DayTestsOld(int day, bool partsHaveSameInput = false)
    {
        _day = day;
        _input = File.ReadAllLines($"Inputs/Day{_day}Input.txt");
        _configuration = new ConfigurationBuilder()
            .AddUserSecrets(GetType().Assembly)
            .Build();
        _dayConfig = _configuration.GetSection($"day{_day}").Get<DayConfig>()!;

        var classLibraryAssembly = Assembly.Load(_assemblyName) ?? throw new Exception($"Could not find Assembly {_assemblyName}");
        var dayPartTypePrefix = $"{_assemblyName}.Day{_day}.Part";
        var dayPart1TypeName = dayPartTypePrefix + "1";
        var dayPart2TypeName = dayPartTypePrefix + "2";
        _sutType1 = classLibraryAssembly.GetType(dayPart1TypeName) ?? throw new Exception($"Could not find type {dayPart1TypeName}");
        _sutType2 = classLibraryAssembly.GetType(dayPart2TypeName) ?? throw new Exception($"Could not find type {dayPart2TypeName}");
    }

    public void Run(int part, string[]? input = null, string? expect = null)
    {
        var partType = part == 1 ? _sutType1 : _sutType2;
        if (partType != null)
        {
            var partInstance = Activator.CreateInstance(partType, new object[] { input ?? _input });
            var runMethod = partType.GetMethod("Run");
            var result = runMethod?.Invoke(partInstance, null)?.ToString();
            var expected = expect ?? _configuration[$"day{_day}:part{part}:answer"];
            Console.WriteLine($"Day {_day} {partType.Name} result: {result}");
            result.Should().Be(expected);
        }
    }
}
