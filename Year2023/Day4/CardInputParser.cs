using System.Text.RegularExpressions;
using AdventOfCode.Utilities;

namespace AdventOfCode.Year2023.Day4;

public partial class CardInputParser : IInputParser<Card>
{
    [GeneratedRegex("Card +\\d+:(?<winningNumbers> +\\d+)+ \\|(?<ourNumbers> +\\d+)+")]
    public partial Regex GetInputPattern();
    public Regex Pattern => GetInputPattern();

    public static Card[] Parse(string[] input)
    {
        return InputParser<Card>.Parse(input, new CardInputParser());
    }

    public Card ParseMatch(Match match, string input)
    {
        var winningNumbers = match.Groups["winningNumbers"].Captures.Select(c => int.Parse(c.Value)).ToArray();
        var ourNumbers = match.Groups["ourNumbers"].Captures.Select(c => int.Parse(c.Value)).ToArray();
        return new Card(winningNumbers, ourNumbers);
    }
}