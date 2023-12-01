using Microsoft.Extensions.Configuration;
using System.Reflection;
using System.Security.Cryptography;
using Tests.Config;

namespace Tests;

public class DayTests
{
    private const string _assemblyName = "AdventOfCode2023";
    protected readonly string[] _input;
    protected readonly IConfiguration _configuration;
    protected readonly DayConfig _dayConfig;
    protected readonly Type _sutType;
    protected readonly int _day;

    public DayTests(int day)
    {
        _day = day;
        _input = File.ReadAllLines($"Inputs/Day{_day}Input.txt");
        _configuration = new ConfigurationBuilder()
            .AddUserSecrets(this.GetType().Assembly)
            .Build();
        _dayConfig = _configuration.GetSection($"day{_day}").Get<DayConfig>()!;

        var classLibraryAssembly = Assembly.Load(_assemblyName) ?? throw new Exception($"Could not find Assembly {_assemblyName}");
        var dayTypeName = $"{_assemblyName}.Day{_day}";
        _sutType = classLibraryAssembly.GetType(dayTypeName) ?? throw new Exception($"Could not find type {dayTypeName}");
    }

    public void Run(int part, string[]? input = null, string? expect = null)
    {
        var partType = _sutType.GetNestedType($"Part{part}");
        if (partType != null)
        {
            var partInstance = Activator.CreateInstance(partType);
            var runMethod = partType.GetMethod("Run");
            var result = runMethod?.Invoke(partInstance, new object[] { input ?? _input });
            var expected = expect ?? _configuration[$"day{_day}:part{part}:answer"];
            Console.WriteLine($"{_sutType.Name} {partType.Name} result: {result}");
            result.Should().Be(expected);
        }
    }
}
