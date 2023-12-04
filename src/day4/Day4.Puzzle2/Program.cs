using Day4.Puzzle2;

var input = await File.ReadAllLinesAsync("input.txt");
var cards = input.Select((p, i) => new Card(i, p)).ToList();
var count = Enumerable.Range(0, input.Length).ToDictionary(p => p, _ => 0);

for (var i = 0; i < input.Length; i++)
{
    count[i]++;

    for (var j = 0; j < count[i]; j++)
    {
        var card = cards[i];
        if (card.Matches > 0)
        {
            for (var k = 1; k <= card.Matches; k++)
            {
                var l = i + k;
                if (l >= input.Length) continue;
                count[l]++;
            }
        }
    }

    Console.WriteLine($"ID: {i} | Cards: {count[i]}");
}

Console.WriteLine($"Total Cards: {count.Sum(p => p.Value)}");