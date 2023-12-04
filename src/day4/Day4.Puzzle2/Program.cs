using Day4.Puzzle2;

var input = await File.ReadAllLinesAsync("input.txt");
var cards = Enumerable.Range(0, input.Length).ToDictionary(p => p, _ => 0);

for (var i = 0; i < input.Length; i++)
{
    cards[i]++;

    for (var j = 0; j < cards[i]; j++)
    {
        var card = new Card(i, input[i]);
        if (card.Matches > 0)
        {
            for (var k = 1; k <= card.Matches; k++)
            {
                var l = i + k;
                if (l >= input.Length) continue;
                cards[l]++;
            }
        }
    }

    Console.WriteLine($"ID: {i} | Cards: {cards[i]}");
}

Console.WriteLine($"Total Cards: {cards.Sum(p => p.Value)}");