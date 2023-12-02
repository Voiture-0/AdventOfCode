namespace AdventOfCode2023;

/// <summary>
/// 
/// </summary>
public class Day2
{
    public class Part1(string[] input)
    {
        const int MaxRed = 12;
        const int MaxGreen = 13;
        const int MaxBlue = 14;
        private class Game
        {
            public int Id { get; set; }
            public int Red { get; set; } = 0;
            public int Blue { get; set; } = 0;
            public int Green { get; set; } = 0;
            public Game(string input)
            {
                var colonSplit = input.Split(':');
                Id = int.Parse(colonSplit[0].Split(' ')[1]);
                var sets = colonSplit[1].Split(';');
                foreach(var set in sets)
                {
                    var cubes = set.Split(',');
                    foreach (var c in cubes)
                    {
                        var data = c.Split(' ');
                        var count = int.Parse(data[1]);
                        var color = data[2];
                        switch (color)
                        {
                            case "red":
                                Red = Math.Max(Red, count);
                                break;
                            case "blue":
                                Blue = Math.Max(Blue, count);
                                break;
                            case "green":
                                Green = Math.Max(Green, count);
                                break;
                        }
                    }
                }
            }
            public override string ToString()
            {
                return $"Game {Id}: {Red} red, {Blue} blue, {Green} green";
            }
        }
        public string Run()
        {
            var sum = 0;
            foreach(var line in input)
            {
                var game = new Game(line);
                if (game.Red <= MaxRed
                    && game.Green <= MaxGreen
                    && game.Blue <= MaxBlue)
                {
                    sum += game.Id;
                }
            }
            return sum.ToString();
        }
    }

    public class Part2(string[] input)
    {
        public string Run()
        {
            return string.Empty;
        }
    }
}
