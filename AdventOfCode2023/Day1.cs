namespace AdventOfCode2023;

/// <summary>
/// --- Day 1: Trebuchet?! ---
/// Something is wrong with global snow production, and you've been selected to take a look. The Elves have even given you a map; on it, they've used stars to mark the top fifty locations that are likely to be having problems.
/// 
/// You've been doing this long enough to know that to restore snow operations, you need to check all fifty stars by December 25th.
/// 
/// Collect stars by solving puzzles.Two puzzles will be made available on each day in the Advent calendar; the second puzzle is unlocked when you complete the first.Each puzzle grants one star. Good luck!
/// 
/// You try to ask why they can't just use a weather machine ("not powerful enough") and where they're even sending you ("the sky") and why your map looks mostly blank("you sure ask a lot of questions") and hang on did you just say the sky("of course, where do you think snow comes from") when you realize that the Elves are already loading you into a trebuchet("please hold still, we need to strap you in").
/// 
/// As they're making the final adjustments, they discover that their calibration document (your puzzle input) has been amended by a very young Elf who was apparently just excited to show off her art skills. Consequently, the Elves are having trouble reading the values on the document.
/// </summary>
public class Day1
{
    /// <summary>
    /// --- Part One ---
    /// The newly-improved calibration document consists of lines of text; each line originally contained a specific calibration value that the Elves now need to recover.On each line, the calibration value can be found by combining the first digit and the last digit(in that order) to form a single two-digit number.
    /// For example:
    /// 
    /// 1abc2
    /// pqr3stu8vwx
    /// a1b2c3d4e5f
    /// treb7uchet
    /// In this example, the calibration values of these four lines are 12, 38, 15, and 77. Adding these together produces 142.
    /// 
    /// Consider your entire calibration document. What is the sum of all of the calibration values?
    /// </summary>
    public class Part1(string[] input)
    {
        public string Run()
        {
            var sum = 0;
            foreach(var line in input)
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
                var number = Int32.Parse(firstNumber + lastNumber);
                sum += number;
            }
            return sum.ToString();
        }

        public string RunLinq()
        {
            return input
                .Select(line => int.Parse(line.First(c => char.IsDigit(c)).ToString() + line.Last(c => char.IsDigit(c)).ToString()))
                .Sum()
                .ToString();
        }
    }

    /// <summary>
    /// --- Part Two ---
    /// Your calculation isn't quite right. It looks like some of the digits are actually spelled out with letters: one, two, three, four, five, six, seven, eight, and nine also count as valid "digits".
    /// 
    /// Equipped with this new information, you now need to find the real first and last digit on each line.For example:
    /// 
    /// two1nine
    /// eightwothree
    /// abcone2threexyz
    /// xtwone3four
    /// 4nineeightseven2
    /// zoneight234
    /// 7pqrstsixteen
    /// In this example, the calibration values are 29, 83, 13, 24, 42, 14, and 76. Adding these together produces 281.
    /// 
    /// What is the sum of all of the calibration values?
    /// </summary>
    public class Part2(string[] input)
    {
        static readonly string[] Numbers = [ "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" ];

        public string Run()
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
            return sum.ToString();
        }

        private int GetDigit(string line, bool searchFromStart = true)
        {
            for (var i = 0; i < line.Length; ++i)
            {
                var character = (searchFromStart ? line[i] : line[^(i+1)]);

                // Check if the character is a digit and return it immediately if so
                if (char.IsDigit(character)) return character-'0'; // subtracting char 0 to simply convert to int (without it would be its ASCII code number)

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
}
