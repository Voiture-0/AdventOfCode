namespace AdventOfCode.Year2023.Day4;

public class Part1(string[] input)
{
    public Card[] Cards = CardInputParser.Parse(input);

    public int Run()
    {
        var sum = 0;
        foreach (var card in Cards)
        {
            sum += GetPoints(card);
        }
        return sum;
    }

    private static int GetPoints(Card card) => card.Wins == 0 ? 0 : (int)Math.Pow(2, card.Wins-1);
}
