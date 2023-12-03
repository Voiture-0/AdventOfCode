namespace AdventOfCode2023.Day3;

public class Day3
{
    public static int ProcessSchematic(string[] input, string partSymbols, Func<List<int>, int> processParts)
    {
        var values = new List<int>();
        for (var y = 0; y < input.Length; ++y)
        for (var x = 0; x < input[y].Length; ++x)
        {
            if (!partSymbols.Contains(input[y][x])) continue;
            var partNumbers = GetPartNumbers(input, x, y);
            values.Add(processParts(partNumbers));
        }
        return values.Sum();
    }

    public static List<int> GetPartNumbers(string[] input, int cX, int cY)
    {
        var partNumbers = new List<int>();
        // Find adjacent numbers
        for (var y = cY-1; y <= cY+1; ++y)
        for (var x = cX-1; x <= cX+1; ++x)
        {
            if (!char.IsDigit(input[y][x])) continue;
            var number = "";
            // Check to the left until start of number
            while (--x >= 0 && char.IsDigit(input[y][x])) ;
            // Concatenate digits from right to left
            while (++x < input[y].Length && char.IsDigit(input[y][x])) number += input[y][x];
            // Save adjacent number
            partNumbers.Add(int.Parse(number));
        }
        return partNumbers;
    }    
}
