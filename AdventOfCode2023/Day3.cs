namespace AdventOfCode2023;

public class Day3
{
    public static int SumAdjacentNumbers(string[] input, int cX, int cY, bool gearsOnly = false)
    {
        int height = input.Length;
        int width = input[0].Length;
        var sum = 0;
        var adjacentNumbers = new List<int>();
        // Get top left corner (respecting bounds of input)
        var tlX = Math.Max(0, cX - 1);
        var tlY = Math.Max(0, cY - 1);
        // Get bottom right corner (respecting bounds of input)
        var brX = Math.Min(width, cX + 1);
        var brY = Math.Min(height, cY + 1);
        for (var y = tlY; y <= brY; ++y)
        {
            for (var x = tlX; x <= brX; ++x)
            {
                if (char.IsDigit(input[y][x]))
                {
                    var number = "";
                    // Check to the right until end of number
                    while (++x < width && char.IsDigit(input[y][x])) ;
                    // Concatenate digits from right to left
                    while (--x >= 0 && char.IsDigit(input[y][x]))
                    {
                        number = input[y][x].ToString() + number;
                    }

                    var parsedNum = int.Parse(number);
                    sum += parsedNum;
                    adjacentNumbers.Add(parsedNum);
                    // Move X to end of number, to continue search after
                    x += number.Length;
                }
            }
        }

        if (gearsOnly)
        {
            if (adjacentNumbers.Count == 2) return adjacentNumbers[0] * adjacentNumbers[1];
            else return 0;
        }

        return sum;
    }

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
                        sum += SumAdjacentNumbers(input, x, y);
                    }
                }
            }
            return sum.ToString();
        }
    }

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
                        sum += SumAdjacentNumbers(input, x, y, gearsOnly: true);
                    }
                }
            }
            return sum.ToString();
        }
    }
}
