namespace AdventOfCode.Year2023.Day4;

public class Card
{
    public int Wins { get; }
    public int Copies { get; set; } = 1;

    public Card(int[] winningNumbers, int[] ourNumbers)
    {
        Wins = ourNumbers.Intersect(winningNumbers).Count();
    }
}
