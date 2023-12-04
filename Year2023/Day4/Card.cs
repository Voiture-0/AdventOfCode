namespace AdventOfCode.Year2023.Day4;

public class Card
{
    public int Id { get; init; }
    public int[] WinningNumbers { get; init; }
    public int[] Numbers { get; init; }
    public int Wins { get; init; }
    public int Copies { get; set; } = 1;

    public Card(int id, int[] winningNumbers, int[] numbers)
    {
        Id = id;
        WinningNumbers = winningNumbers;
        Numbers = numbers;
        Wins = GetWinCount();
    }

    private int GetWinCount()
    {
        var wins = 0;
        foreach (var num in Numbers)
        {
            if (WinningNumbers.Contains(num)) wins++;
        }
        return wins;
    }
}
