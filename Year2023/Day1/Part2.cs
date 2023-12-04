namespace AdventOfCode.Year2023.Day1;

public class Part2(string[] input)
{
    public static readonly string[] Numbers = ["one", "two", "three", "four", "five", "six", "seven", "eight", "nine"];

    public int Run()
    {
        var sum = 0;
        foreach (var line in input)
        {
            // Extract the first and last digits (as numbers) from each line
            var firstDigit = GetDigit(line, searchFromStart: true);
            var lastDigit = GetDigit(line, searchFromStart: false);
            // Combine the two digits into a two-digit number and add to the sum
            sum += firstDigit*10 + lastDigit;
        }
        return sum;
    }

    public static int GetDigit(string line, bool searchFromStart)
    {
        for (var i = 0; i < line.Length; ++i)
        {
            var character = searchFromStart ? line[i] : line[^(i+1)];

            // Check if the character is a digit and return it immediately if so
            if (char.IsDigit(character)) return character - '0'; // subtracting char 0 to simply convert to int (without it would be its ASCII code number)

            // Iterate over all possible number words
            for (var j = 0; j < Numbers.Length; ++j)
            {
                // Get the current number word to compare against
                var possibleNumber = Numbers[j];
                // Calculate the end index of the substring to extract, adjusting for search direction
                var endIndex = searchFromStart ? i + possibleNumber.Length : i+1 - possibleNumber.Length;
                // Ensure the endIndex is within the bounds of the string
                if (0 <= endIndex && endIndex <= line.Length)
                {
                    // Extract the word from the line and compare with the number word      //var word = searchFromStart ? line.Substring(i, possibleNumber.Length) : line.Substring(line.Length-(i+1), possibleNumber.Length);
                    var word = searchFromStart
                        ? line[i..endIndex]         // Get the substring of a word from the current index of the same length as the possible number
                        : line[^(i+1)..^endIndex];  // Do the same thing as above, but go backwards
                    // If the extracted word matches the current number word, return its numeric value
                    if (word == possibleNumber) return j+1; // "one" is at index 0, and so on. So add 1 to compensate
                }
            }
        }
        throw new Exception("Could not find digit.");
    }
}
