namespace Day3.Puzzle1;

public static class Extensions
{
    public static Dictionary<Point, int> MapCodes(this string[] input)
    {
        var dict = new Dictionary<Point, int>();

        for (var y = 0; y < input.Length; y++)
        {
            var line = input[y];

            Point? initial = null;
            var code = "";

            for (var x = 0; x < line.Length; x++)
            {
                var c = line[x];

                if (initial is null && char.IsDigit(c))
                {
                    initial = new Point(x, y);
                }

                if (initial is not null && char.IsDigit(c))
                {
                    code += c;
                    if (x < line.Length - 1) continue;
                    dict.Add(initial, int.Parse(code));
                    initial = null;
                    code = "";
                }

                if (initial is not null && !char.IsDigit(c))
                {
                    dict.Add(initial, int.Parse(code));
                    initial = null;
                    code = "";
                }
            }
        }
        return dict;
    }

    public static List<Point> MapSymbols(this string[] input)
    {
        var list = new List<Point>();
        for (var y = 0; y < input.Length; y++)
        {
            var line = input[y];
            for (var x = 0; x < line.Length; x++)
            {
                var c = line[x];
                if (char.IsDigit(c) || c == '.') continue;
                list.Add(new Point(x, y));
            }
        }
        return list;
    }

    public static IEnumerable<int> FilterValidPartCodes(this Dictionary<Point, int> codes, List<Point> symbols)
    {
        var list = new List<int>();
        foreach (var code in codes)
        {
            var length = code.Value.ToString().Length;
            var validPositions = code.Key.GetValidPositions(length);
            if (symbols.Intersect(validPositions).Any())
            {
                list.Add(code.Value);
            }
        }
        return list;
    }

    private static List<Point> GetValidPositions(this Point initial, int length)
    {
        var list = new List<Point>();

        var minX = initial.X - 1;
        var maxX = initial.X + length;
        var minY = initial.Y - 1;
        var maxY = initial.Y + 1;

        for (var x = minX; x <= maxX; x++)
        {
            for (var y = minY; y <= maxY; y++)
            {
                list.Add(new Point(x, y));
            }
        }

        return list;
    }
}