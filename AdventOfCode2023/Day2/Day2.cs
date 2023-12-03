namespace AdventOfCode2023.Day2;

/// <summary>
/// Represents the Day 2 challenge of the Advent of Code 2023, involving a game with cubes of different colors.
/// The challenge involves guessing the number of cubes in a bag based on partial information.
/// 
/// Brief Overview:
/// - Each game has multiple rounds with a random number of colored cubes shown.
/// - The goal is to determine the validity of games based on cube count constraints and calculate specific metrics.
/// 
/// For the full puzzle description, see https://adventofcode.com/2023/day/2
/// </summary>
public class Day2
{
    public const string COLOR_RED = "red";
    public const string COLOR_GREEN = "green";
    public const string COLOR_BLUE = "blue";
    public static readonly string[] Colors = [ COLOR_RED, COLOR_GREEN, COLOR_BLUE ];
}
