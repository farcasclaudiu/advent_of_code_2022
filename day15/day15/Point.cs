namespace day15;

public record Point(int X, int Y)
{
    public static int ComputeDistance(Point from, Point to)
    {
        return Math.Abs(from.X - to.X) + Math.Abs(from.Y - to.Y);
    }
}
