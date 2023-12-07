using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode.Year2023.Day5;
public partial class AlmanacParser
{
    [GeneratedRegex("^seeds:( (?<seedNumber>\\d+))+$")]
    public partial Regex GetSeedsPattern();

    [GeneratedRegex("^(?<source>\\w+)-to-(?<destination>\\w+) map:$")]
    public partial Regex GetMappingLabelPattern();

    [GeneratedRegex("^(?<destination>\\d+) (?<source>\\d+) (?<length>\\d+)$")]
    public partial Regex GetMappingPattern();

    public Almanac Parse(string[] input)
    {
        var almanac = new Almanac();
        for (var i = 0; i < input.Length; ++i)
        {
            var line = input[i];
            Match match;
            
            match = GetSeedsPattern().Match(line);
            if (match.Success) ParseSeeds(almanac, match);

            match = GetMappingLabelPattern().Match(line);
            if (match.Success) ParseMappingLabel(almanac, match);
            
            match = GetMappingPattern().Match(line);
            if (match.Success) ParseMapping(almanac, match);
        }
        return almanac;
    }

    private void ParseSeeds(Almanac almanac, Match match)
    {
        var seeds = match.Groups["seedNumber"].Captures.Select(c => Int64.Parse(c.Value)).ToArray();
        almanac.Seeds = seeds;
    }

    private void ParseMappingLabel(Almanac almanac, Match match)
    {
        var map = new AlmanacMap
        {
            SourceName = match.Groups["source"].Captures.First().Value,
            DestinationName = match.Groups["destination"].Captures.First().Value,
        };
        almanac.Mappings.Add(map);
    }

    private void ParseMapping(Almanac almanac, Match match)
    {
        var range = new AlmanacMapRange
        {
            DestinationStart = Int64.Parse(match.Groups["destination"].Captures.First().Value),
            SourceStart = Int64.Parse(match.Groups["source"].Captures.First().Value),
            Length = Int64.Parse(match.Groups["length"].Captures.First().Value),
        };
        almanac.Mappings.Last().Ranges.Add(range);
    }
}

public class Almanac
{
    public Int64[] Seeds { get; set; } = [];
    public List<AlmanacMap> Mappings { get; set; } = [];

    public override string ToString()
    {
        return $"seeds: {string.Join(' ', Seeds)}";
    }
}
public class AlmanacMap
{
    public string SourceName { get; set; } = "Unknown";
    public string DestinationName { get; set; } = "Unknown";
    public List<AlmanacMapRange> Ranges { get; set; } = [];

    public override string ToString()
    {
        return $"{SourceName}-to-{DestinationName} map ({Ranges.Count})";
    }

}
public class AlmanacMapRange
{
    public Int64 SourceStart { get; set; }
    public Int64 DestinationStart { get; set; }
    public Int64 Length { get; set; }

    public override string ToString()
    {
        return $"{SourceStart} -> {DestinationStart}; {Length}";
    }
}