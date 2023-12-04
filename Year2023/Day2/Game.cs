namespace AdventOfCode.Year2023.Day2;

public class Game(int id)
{
    public int Id { get; init; } = id;
    public Dictionary<string, int> Cubes { get; } = [];
}
