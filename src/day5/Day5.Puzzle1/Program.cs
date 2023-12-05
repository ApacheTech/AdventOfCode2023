using Day5.Puzzle1;

var seeds = new List<long>
{
    2041142901, 113138307, 302673608, 467797997, 1787644422, 208119536, 143576771, 99841043, 4088720102, 111819874,
    946418697, 13450451, 3459931852, 262303791, 2913410855, 533641609, 2178733435, 26814354, 1058342395, 175406592
};

Console.WriteLine(seeds
    .MapToSoil()
    .MapToFertiliser()
    .MapToWater()
    .MapToLight()
    .MapToTemperature()
    .MapToHumidity()
    .MapToLocation()
    .Min());