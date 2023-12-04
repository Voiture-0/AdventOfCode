namespace AdventOfCode.Year2023.Day4;

public class Part2(string[] input)
{
    public Card[] Cards = CardInputParser.Parse(input);

    public int Run()
    {
        var count = 0;
        for (var i = 0; i < Cards.Length; ++i)
        {
            var card= Cards[i];
            count += card.Copies;
            var wins = card.GetWinCount();
            for (var j = i+1; j <= i+wins; ++j)
            {
                Cards[j].Copy(card.Copies);
            }
        }
        return count;
    }
}
