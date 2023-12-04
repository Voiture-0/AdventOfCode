namespace AdventOfCode.Year2023.Day1;

public class Part1(string[] input)
{
    public int Run()
    {
        var sum = 0;
        foreach (var line in input)
        {
            var firstNumber = "";
            var lastNumber = "";
            for (var i = 0; i < line.Length; ++i)
            {
                var character = line[i];
                if (char.IsDigit(character))
                {
                    firstNumber = character.ToString();
                    break;
                }
            }
            for (var i = line.Length-1; i >= 0; --i)
            {
                var character = line[i];
                if (char.IsDigit(character))
                {
                    lastNumber = character.ToString();
                    break;
                }
            }
            var number = int.Parse(firstNumber + lastNumber);
            sum += number;
        }
        return sum;
    }
}
