namespace AdventOfCode2023.Day3;

public class Day3
{
    public static List<int> GetPartNumbers(string[] input, int cX, int cY)
    {
        var adjacentNumbers = new List<int>();

        for (var y = cY-1; y <= cY+1; ++y)
        for (var x = cX-1; x <= cX+1; ++x)
        {
            if (!char.IsDigit(input[y][x])) continue;
                
            var number = "";
            // Check to the left until start of number
            while (--x >= 0 && char.IsDigit(input[y][x])) ;
            // Concatenate digits from right to left
            while (++x < input[y].Length && char.IsDigit(input[y][x]))
            {
                number += input[y][x];
            }
            var parsedNum = int.Parse(number);
            adjacentNumbers.Add(parsedNum);
        }


        return adjacentNumbers;
    }    
}
