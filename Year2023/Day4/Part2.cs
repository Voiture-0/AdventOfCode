namespace AdventOfCode.Year2023.Day4;

public class Part2(string[] input)
{
    public Card[] Cards = CardInputParser.Parse(input);

    public int Run()
    {
        for (var i = 0; i < Cards.Length; ++i)
        {
            for (var j = 1; j <= Cards[i].Wins; ++j)
            {
                Cards[i+j].Copies += Cards[i].Copies;
            }
        }
        return Cards.Sum(c => c.Copies);
    }
}
