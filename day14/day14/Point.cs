namespace day14;

public class Point : IEquatable<Point>
{
    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }
    public int X { get; set; }
    public int Y { get; set; }

    public override string ToString()
    {
        return $"({X},{Y})";
    }
    public override int GetHashCode()
    {
        return this.ToString().GetHashCode();
    }

    public bool Equals(Point other)
    {
        return this.X == other.X && this.Y == other.Y;
    }
}
