namespace Day5.Puzzle1;

public static class MappingExtensions
{
    public static IEnumerable<long> MapToSoil(this IEnumerable<long> x)
        => x.Select(p => p.Map(Maps.SeedToSoilMap));

    public static IEnumerable<long> MapToFertiliser(this IEnumerable<long> x)
        => x.Select(p => p.Map(Maps.SoilToFertiliserMap));

    public static IEnumerable<long> MapToWater(this IEnumerable<long> x)
        => x.Select(p => p.Map(Maps.FertiliserToWaterMap));

    public static IEnumerable<long> MapToLight(this IEnumerable<long> x)
        => x.Select(p => p.Map(Maps.WaterToLightMap));

    public static IEnumerable<long> MapToTemperature(this IEnumerable<long> x)
        => x.Select(p => p.Map(Maps.LightToTemperatureMap));

    public static IEnumerable<long> MapToHumidity(this IEnumerable<long> x)
        => x.Select(p => p.Map(Maps.TemperatureToHumidityMap));

    public static IEnumerable<long> MapToLocation(this IEnumerable<long> x)
        => x.Select(p => p.Map(Maps.HumidityToLocationMap));

    public static TOut Bind<TIn, TOut>(this TIn @this, Func<TIn, TOut> f)
        => f(@this);

    private static long Map(this long value, IEnumerable<Entry> mappingData)
    {
        foreach (var entry in mappingData)
        {
            var mapped = value.Map(entry.SourceStart, entry.DestinationStart, entry.Range);
            if (mapped != value) return mapped;
        }
        return value;
    }

    private static long Map(this long value, long minimumValue, long destinationStart, long range)
        => value.IsInRange(minimumValue, range)
            ? destinationStart + value.Offset(minimumValue) 
            : value;

    private static long Offset(this long value, long minimumValue)
        => value - minimumValue;

    private static bool IsInRange(this long value, long minimumValue, long range) 
        => value.Offset(minimumValue).Bind(o => o > 0 && o <= range);
}