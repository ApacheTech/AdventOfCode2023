using Day2.Puzzle2.Extensions;

namespace Day2.Puzzle2;

public class Game
{
    public Game(string gameData)
    {
        var parts = gameData.Split(':');
        Id = int.Parse(parts[0].StripLetters());
        var data = parts[1].Replace(";", ",").Split(", ").Select(p => p.Trim());

        foreach (var cubes in data)
        {
            var cubeData = cubes.Split(" ");
            var key = cubeData[1];
            var value = int.Parse(cubeData[0]);
            switch (key)
            {
                case "red":
                    RedCubes.Add(value);
                    break;
                case "green":
                    GreenCubes.Add(value);
                    break;
                case "blue":
                    BlueCubes.Add(value);
                    break;
            }
        }
    }

    public int Id { get; }

    public List<int> RedCubes { get; } = new();

    public List<int> GreenCubes { get; } = new();

    public List<int> BlueCubes { get; } = new();
}