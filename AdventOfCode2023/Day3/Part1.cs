namespace AdventOfCode2023.Day3;

public class Part1(string[] input)
{
    public int Height = input.Length;
    public int Width = input[0].Length;

    public const string Symbols = "%=*#$@&/-+";

    public string Run()
    {
        var sum = 0;
        for (var y = 0; y < Height; ++y)
        {
            for (var x = 0; x < Width; ++x)
            {
                if (Symbols.Contains(input[y][x]))
                {
                    // Check adjacent numbers
                    sum += Day3.SumAdjacentNumbers(input, x, y);
                }
            }
        }
        return sum.ToString();
    }
}
