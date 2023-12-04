namespace Day2.Puzzle2.Extensions;

public static class StringExtensions
{
    public static string StripLetters(this string input)
        => string.Concat(input.Where(char.IsDigit));
}