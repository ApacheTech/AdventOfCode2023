namespace Day4.Puzzle2;

public record Card
{
    public Card(int cardNumber, string line)
    {
        CardNumber = cardNumber;

        var data = line.Split(':')[1];
        var sets = data.Split("|");

        var targetNumbers = sets[0]
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(p => int.Parse(p.Trim()))
            .ToList();

        var cardNumbers = sets[1]
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(p => int.Parse(p.Trim()))
            .ToList();

        Matches = cardNumbers.Intersect(targetNumbers).Count();
    }

    public int CardNumber { get; init; }

    public int Matches { get; }
}