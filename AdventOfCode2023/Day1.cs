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

        string Word = "";
        int NumberLetterIndex = 0;
        List<string> PossibleNumbers = Numbers.ToList();

        public string Run(string[] input)
        {
            var sum = 0;
            foreach (var line in input)
            {
                // Get a list of just the digits
                var digits = new List<string>();
                ResetVars();
                for (var i = 0; i < line.Length; ++i)
                {
                    var character = line[i];
                    if (char.IsDigit(character))
                    { 
                        digits.Add(character.ToString());
                        ResetVars();
                    }
                    else if (PossibleNumbers.Select(n => n[NumberLetterIndex]).Contains(character))
                    {
                        Word += character;
                        NumberLetterIndex++;
                        if (PossibleNumbers.Contains(Word))
                        {
                            var num = Array.IndexOf(Numbers, Word) + 1;
                            digits.Add(num.ToString());
                            i -= Word.Length-1;
                            ResetVars();
                        }
                        else
                        {
                            PossibleNumbers = PossibleNumbers
                                .Where(n => n.StartsWith(Word))
                                .ToList();

                            if (PossibleNumbers.Count == 0 && Word.Length > 0)
                            {
                                i -= Word.Length;
                                ResetVars();
                            }
                        }
                    }
                    else if (Word.Length > 0)
                    {
                        i -= Word.Length;
                        ResetVars();
                    }
                }

                var firstNumber = digits.First();
                var lastNumber = digits.Last();

                var number = Int32.Parse(firstNumber + lastNumber);
                sum += number;
            }
            return sum.ToString();
        }

        private void ResetVars()
        {
            Word = "";
            NumberLetterIndex = 0;
            PossibleNumbers = Numbers.ToList();
        }
    }
}
