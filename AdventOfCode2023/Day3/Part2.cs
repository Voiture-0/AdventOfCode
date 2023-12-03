namespace AdventOfCode2023.Day3;

public class Part2(string[] input)
{
    public int Height = input.Length;
    public int Width = input[0].Length;

    public const char Gear = '*';

    public string Run()
    {
        var sum = 0;
        for (var y = 0; y < Height; ++y)
        {
            for (var x = 0; x < Width; ++x)
            {
                if (Gear == input[y][x])
                {
                    // Check adjacent numbers
                    sum += Day3.SumAdjacentNumbers(input, x, y, gearsOnly: true);
                }
            }
        }
        return sum.ToString();
    }
}
