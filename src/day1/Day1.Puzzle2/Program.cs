using Day1.Puzzle2.Extensions;
var lines = await File.ReadAllLinesAsync("input.txt");
Console.WriteLine(lines
    .Select(p => p.ConvertWordsToDigits())
    .Select(p => p.StripLetters())
    .Select(p => p.ConcatenateDigits())
    .Sum());