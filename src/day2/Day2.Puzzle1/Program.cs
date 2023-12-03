using Day2.Puzzle1;
var lines = await File.ReadAllLinesAsync("input.txt");
Console.WriteLine(lines
    .Select(p => new Game(p))
    .Where(p => p.RedCubes.Max() <= 12)
    .Where(p => p.GreenCubes.Max() <= 13)
    .Where(p => p.BlueCubes.Max() <= 14)
    .Select(p => p.Id)
    .Sum());