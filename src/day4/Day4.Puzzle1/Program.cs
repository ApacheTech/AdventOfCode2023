var input = await File.ReadAllLinesAsync("input.txt");
var count = 0;

foreach (var line in input)
{
    var data = line.Split(':')[1];
    var sets = data.Split("|");

    var winningNumbers = sets[0]
        .Split(' ', StringSplitOptions.RemoveEmptyEntries)
        .Select(p => int.Parse(p.Trim()))
        .ToList();

    var myNumbers = sets[1]
        .Split(' ', StringSplitOptions.RemoveEmptyEntries)
        .Select(p => int.Parse(p.Trim()))
        .ToList();

    var matches = myNumbers.Intersect(winningNumbers).ToList();

    if (matches.Count > 0)
    {
        var value = (int)Math.Pow(2, matches.Count - 1);
        count += value;
        Console.WriteLine($"Matches: {matches.Count} | Value: {value} | Count: {count}");
    }
}

Console.WriteLine($"Total: {count}");