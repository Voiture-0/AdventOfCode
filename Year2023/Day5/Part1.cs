namespace AdventOfCode.Year2023.Day5;

public class Part1(string[] input)
{
    public Int64 Run()
    {
        var almanac = new AlmanacParser().Parse(input);
        var minLocation = Int64.MaxValue;
        foreach (var seed in almanac.Seeds)
        {
            var value = seed;
            foreach (var map in almanac.Mappings)
            {
                var range = map.Ranges
                    .Where(r => r.SourceStart <= value && value < r.SourceStart+r.Length)
                    .FirstOrDefault();
                if (range == null) continue; // maps to itself
                var offset = range.DestinationStart - range.SourceStart;
                value += offset;
            }
            if (value < minLocation) minLocation = value;
        }
        return minLocation;
    }
}
