using Day3.Puzzle2;
var input = await File.ReadAllLinesAsync("input.txt");
Console.WriteLine(input
    .MapGears()
    .FindWorkingGears(input.MapCodes())
    .Select(p => p.Ratio)
    .Sum());