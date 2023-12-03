namespace Day1.Puzzle1.Extensions;

public static class StringExtensions
{
    public static IList<char> StripLetters(this string input) 
        => input.Where(char.IsDigit).ToList();

    public static int ConcatenateDigits(this IList<char> input) 
        => input.Count == 0 ? 0 : int.Parse($"{input.First()}{input.Last()}");
}