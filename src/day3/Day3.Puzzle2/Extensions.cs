namespace Day3.Puzzle2;

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

    public static List<Point> MapGears(this string[] input)
    {
        var list = new List<Point>();
        for (var y = 0; y < input.Length; y++)
        {
            var line = input[y];
            for (var x = 0; x < line.Length; x++)
            {
                var c = line[x];
                if (c == '*') list.Add(new Point(x, y));
            }
        }
        return list;
    }

    public static List<GearRatio> FindWorkingGears(this List<Point> symbols, Dictionary<Point, int> allCodes)
    {
        var dict = new List<GearRatio>();

        foreach (var symbol in symbols)
        {
            var boundCodes = allCodes.SelectMany(p => p.Value.ToPoints(p.Key));
            var bounds = symbol.GetSurroundingPoints();
            var intersects = bounds.Intersect(boundCodes).ToList();
            var distinctValues = allCodes.ToDistinctValues(intersects);
            if (distinctValues.Count == 2)
            {
                dict.Add(new GearRatio(distinctValues[0], distinctValues[1]));
            }
        }
        
        return dict;
    }
    
    private static List<int> ToDistinctValues(this IReadOnlyDictionary<Point, int> allCodes, List<Point> points)
    {
        return points
            .Select(allCodes.GetStartingPoint)
            .Distinct()
            .Select(p => allCodes[p])
            .ToList();
    }

    private static Point GetStartingPoint(this IReadOnlyDictionary<Point, int> allCodes, Point point)
    {
        while (true)
        {
            if (allCodes.ContainsKey(point)) return point;
            point = point with { X = point.X - 1 };
        }
    }

    private static List<Point> ToPoints(this int code, Point startingPoint)
    {
        var list = new List<Point>();
        var x = startingPoint.X;
        
        for (var i = 0; i < code.ToString().Length; i++)
        {
            list.Add(startingPoint with { X = x + i });
        }

        return list;
    }

    private static List<Point> GetSurroundingPoints(this Point initial)
    {
        var list = new List<Point>();

        var minX = initial.X - 1;
        var maxX = initial.X + 1;
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