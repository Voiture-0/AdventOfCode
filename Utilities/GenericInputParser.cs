namespace AdventOfCode.Utilities;

public static class GenericInputParser<T> where T : class
{
    public static T[] Parse(string[] input, IInputParser<T> parser)
    {
        var items = new T[input.Length];
        for (var i = 0; i < input.Length; ++i)
        {
            var match = parser.Pattern.Match(input[i]);
            if (!match.Success) throw new FormatException($"Invalid input format: \"{input[i]}\"");
            items[i] = parser.ParseItem(match, input[i]);
        }
        return items;
    }
}
