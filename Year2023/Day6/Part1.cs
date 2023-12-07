using System.Text.RegularExpressions;

namespace AdventOfCode.Year2023.Day6;

public partial class Part1(string[] input)
{
    [GeneratedRegex("^Time:( +(?<time>\\d+))+$")]
    public partial Regex GetTimePattern();

    [GeneratedRegex("^Distance:( +(?<dist>\\d+))+$")]
    public partial Regex GetDistPattern();

    public int Run()
    {
        // Parse input
        var timeMatches = GetTimePattern().Match(input[0]);
        var distMatches = GetDistPattern().Match(input[1]);
        var times = timeMatches.Groups["time"].Captures.Select(c => int.Parse(c.Value)).ToArray();
        var dists = distMatches.Groups["dist"].Captures.Select(c => int.Parse(c.Value)).ToArray();

        // loop through records
        var waysProduct = 1;
        for (var i = 0; i < times.Length; ++i)
        {
            var time = times[i];
            var dist = dists[i];
            var optimalTimeToHold = time / 2;
            var ways = 0;
            for (var j = optimalTimeToHold; j > 0; --j)
            {
                var newDist = j * (time - j);
                if (newDist > dist) ++ways;
                else break;
            }
            if (time % 2 == 0 && ways > 0) --ways;
            ways *= 2;
            if (time % 2 == 0 && ways > 0) ++ways;
            waysProduct *= ways;
        }
        return waysProduct;
    }
}
