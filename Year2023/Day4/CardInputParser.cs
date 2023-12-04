namespace AdventOfCode.Year2023.Day4;

public class CardInputParser
{
    public static Card[] Parse(string[] input)
    {
        var cards = new Card[input.Length];
        for (var i = 0; i < input.Length; ++i)
        {
            var nums = input[i].Split(':')[1].Split('|');
            var winNums = nums[0].Split(' ').Where(n => !string.IsNullOrWhiteSpace(n)).Select(int.Parse).ToArray();
            var ourNums = nums[1].Split(' ').Where(n => !string.IsNullOrWhiteSpace(n)).Select(int.Parse).ToArray();
            cards[i] = new Card(winNums, ourNums);
        }
        return cards;
    }
}