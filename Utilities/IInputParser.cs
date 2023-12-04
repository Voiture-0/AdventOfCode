using System.Text.RegularExpressions;

namespace AdventOfCode.Utilities;

public interface IInputParser<T> where T : class
{
    Regex Pattern { get; }
    T ParseItem(Match match, string input);
}