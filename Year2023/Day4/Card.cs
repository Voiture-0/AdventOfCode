namespace AdventOfCode.Year2023.Day4;

public class Card(int id, int[] winningNumbers, int[] numbers)
{
    public int Id { get; init; } = id;
    public int[] WinningNumbers { get; init; } = winningNumbers;
    public int[] Numbers { get; init; } = numbers;
    public int Copies { get; private set; } = 1;

    public int GetWinCount()
    {
        var wins = 0;
        foreach (var num in Numbers)
        {
            if (WinningNumbers.Contains(num)) wins++;
        }
        return wins;
    }

    public void Copy(int count)
    {
        Copies += count;
    }
}
