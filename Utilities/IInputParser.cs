using System.Text.RegularExpressions;

namespace AdventOfCode.Utilities;

public interface IInputParser<T> where T : class
{
    Regex Pattern { get; }
    T ParseMatch(Match match, string input);
}