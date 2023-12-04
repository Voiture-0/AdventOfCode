namespace AdventOfCode.Year2023.Day4;

public class Part1(string[] input)
{
    public Card[] Cards = CardInputParser.Parse(input);

    public int Run()
    {
        return Cards.Sum(GetPoints);
    }

    private static int GetPoints(Card card) => card.Wins == 0 ? 0 : (int)Math.Pow(2, card.Wins-1);
}
