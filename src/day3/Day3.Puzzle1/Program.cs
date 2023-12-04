using Day3.Puzzle1;
var input = await File.ReadAllLinesAsync("input.txt");

var codes = input.MapCodes();
var symbols = input.MapSymbols();
var validPartCodes = codes.FilterValidPartCodes(symbols);

Console.WriteLine(validPartCodes.Sum());