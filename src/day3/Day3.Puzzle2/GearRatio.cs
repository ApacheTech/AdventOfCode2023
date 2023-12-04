namespace Day3.Puzzle2;

public record GearRatio(int X, int Y)
{
    public int Ratio => X * Y;
}