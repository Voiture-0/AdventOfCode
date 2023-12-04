namespace AdventOfCode.Year2023.Day4;

public class Part1(string[] input)
{
    public Card[] Cards = CardInputParser.Parse(input);

    public int Run()
    {
        var sum = 0;
        foreach (var card in Cards)
        {
            var wins = card.GetWinCount();
            if (wins > 0) sum += (int)Math.Pow(2, wins-1);
        }
        return sum;
    }
}
