namespace AdventOfCode2023.Day2;

/// <summary>
/// Represents a single game in the Day 2 challenge.
/// Stores the game's ID and a dictionary of cubes by color.
/// Provides functionality to check if a game meets certain cube count constraints and calculate the game's "power".
/// </summary>
public class Game(int id)
{
    public int Id { get; init; } = id;
    public Dictionary<string, int> Cubes { get; } = [];
}
