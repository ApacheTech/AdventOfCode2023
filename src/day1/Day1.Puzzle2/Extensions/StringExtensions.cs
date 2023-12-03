namespace Day1.Puzzle2.Extensions;

public static class StringExtensions
{
    public static string ConvertWordsToDigits(this string input)
        => input
            .ConvertWordsToDigits(Overlaps)
            .ConvertWordsToDigits(NumberWords);

    public static IList<char> StripLetters(this string input) 
        => string.Concat(input.Where(char.IsDigit)).ToList();

    public static int ConcatenateDigits(this IList<char> input) 
        => input.Count == 0 ? 0 : int.Parse($"{input.First()}{input.Last()}");
    private static string ConvertWordsToDigits(this string input, Dictionary<string, string> substitutes)
        => substitutes.Aggregate(input, (current, substitute) => current.Replace(substitute.Key, substitute.Value));

    private static readonly Dictionary<string, string> Overlaps = new()
    {
        {"oneight", "18"},
        {"twone", "21"},
        {"threeight", "38"},
        {"fiveight", "58"},
        {"sevenine", "79"},
        {"eightwo", "82"},
        {"eighthree", "83"},
        {"nineight", "98"}
    };

    private static readonly Dictionary<string, string> NumberWords = new()
    {
        {"one", "1"},
        {"two", "2"},
        {"three", "3"},
        {"four", "4"},
        {"five", "5"},
        {"six", "6"},
        {"seven", "7"},
        {"eight", "8"},
        {"nine", "9"},
    };
}