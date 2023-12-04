using System.Text.RegularExpressions;
using AdventOfCode.Utilities;

namespace AdventOfCode.Year2023.Day4;

public partial class CardInputParser : IInputParser<Card>
{
    [GeneratedRegex("Card +\\d+:(?<winningNumbers> +\\d+)+ \\|(?<ourNumbers> +\\d+)+")]
    public partial Regex GetInputPattern();
    public Regex Pattern => GetInputPattern();

    public Card ParseItem(Match match, string input)
    {
        var winningNumbers = match.Groups["winningNumbers"].Captures.Select(c => int.Parse(c.Value)).ToArray();
        var ourNumbers = match.Groups["ourNumbers"].Captures.Select(c => int.Parse(c.Value)).ToArray();
        return new Card(winningNumbers, ourNumbers);
    }

    public static Card[] Parse(string[] input)
    {
        return GenericInputParser<Card>.Parse(input, new CardInputParser());
    }
}