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
/// 
/// The newly-improved calibration document consists of lines of text; each line originally contained a specific calibration value that the Elves now need to recover.On each line, the calibration value can be found by combining the first digit and the last digit(in that order) to form a single two-digit number.
/// For example:
/// 
/// 1abc2
/// pqr3stu8vwx
/// a1b2c3d4e5f
/// treb7uchet
/// In this example, the calibration values of these four lines are 12, 38, 15, and 77. Adding these together produces 142.
/// 
/// Consider your entire calibration document.What is the sum of all of the calibration values?
/// </summary>
public class Day1
{
    public class Part1
    {
        public string Run(string[] input)
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

        public string RunLinq(string[] input)
        {
            return input
                .Select(line => Int32.Parse(line.First(c => char.IsDigit(c)).ToString() + line.Last(c => char.IsDigit(c)).ToString()))
                .Sum()
                .ToString();
        }
    }

    public class Part2
    {
        static string[] Numbers = [ "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" ];

        public string Run(string[] input)
        {
            var sum = 0;
            foreach (var line in input)
            {
                var firstNumber = GetFirstDigit(line);
                var lastNumber = GetLastDigit(line);

                var number = int.Parse(firstNumber + lastNumber);
                sum += int.Parse(GetFirstDigit(line) + GetLastDigit(line));
            }
            return sum.ToString();
        }

        private string GetLastDigit(string line)
        {
            return GetFirstDigit(line, forwards: false);
        }

        private string GetFirstDigit(string line, bool forwards = true)
        {
            var word = "";
            var numberLetterIndex = 0;
            var possibleNumbers = Numbers.ToList();
            int i = 0; // Declared outside of for loop to simplifying backstepping
            for (; i < line.Length; ++i)
            {
                var character = (forwards ? line[i] : line[^(i+1)]);

                // Found digit!
                if (char.IsDigit(character)) return character.ToString();
                
                // Check if letter could spell a number
                bool charIsNextInNumber = false;
                foreach (var numChar in possibleNumbers)
                {
                    var index = (forwards ? numberLetterIndex : (^(numberLetterIndex + 1)));
                    if (numChar[index] == character)
                    {
                        charIsNextInNumber = true;
                        break;
                    }
                }

                // Continue checking possible matching letter for word
                if (charIsNextInNumber)
                {
                    word = (forwards ? word + character : character + word);
                    numberLetterIndex++;
                    if (possibleNumbers.Contains(word))
                    {
                        // Found digit word!
                        var digitAsNumber = Array.IndexOf(Numbers, word) + 1;
                        return digitAsNumber.ToString();
                    }
                    else
                    {
                        // Get new list of possible numbers now with the new letter
                        var filteredNumbers = new List<string>();
                        foreach (var num in possibleNumbers)
                        {
                            if (forwards ? num.StartsWith(word) : num.EndsWith(word))
                            {
                                filteredNumbers.Add(num);
                            }
                        }
                        possibleNumbers = filteredNumbers;

                        // If no possible matches
                        if (possibleNumbers.Count == 0 && word.Length > 0)
                        {
                            Rewind();
                        }
                    }
                }
                else if (word.Length > 0) // If we were checking a word
                {
                    Rewind();
                }
            }

            throw new Exception("Could not find digit.");

            void Rewind()
            {
                // Backstep back to after the first letter in the word we were checking
                i -= word.Length;
                word = "";
                numberLetterIndex = 0;
                possibleNumbers = Numbers.ToList();
            }
        }
    }
}
