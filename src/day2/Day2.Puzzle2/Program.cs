using Day2.Puzzle1;
var lines = await File.ReadAllLinesAsync("input.txt");
Console.WriteLine(lines
    .Select(p => new Game(p))
    .Select(p => p.RedCubes.Max() * p.GreenCubes.Max() * p.BlueCubes.Max())
    .Sum());