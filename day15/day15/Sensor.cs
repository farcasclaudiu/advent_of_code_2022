namespace day15;
using System.Linq;
public class Sensor
{
    private Sensor() { }
    public Sensor(int x, int y, int bX, int bY)
    {
        Position = new Point(x, y);
        Beacon = new Point(bX, bY);
        Distance = Point.ComputeDistance(Position, Beacon);
    }

    public Point Position { get; set; }
    public Point Beacon { get; set; }
    public int Distance { get; }


    public HashSet<Point> GetBoundaries(int maxSize)
    {
        var boundaries = new HashSet<Point>();

        var boundDist = Distance + 1;
        for (int i = 0; i <= boundDist; i++)
        {
            AddToBoundaries(boundaries,
                new Point(Position.X - i, Position.Y + (boundDist - i)),
                maxSize);
            AddToBoundaries(boundaries,
                new Point(Position.X - i, Position.Y - (boundDist - i)),
                maxSize);
            AddToBoundaries(boundaries,
                new Point(Position.X + i, Position.Y + (boundDist - i)),
                maxSize);
            AddToBoundaries(boundaries,
                new Point(Position.X + i, Position.Y - (boundDist - i)),
                maxSize);
        }

        return boundaries;
    }

    private void AddToBoundaries(HashSet<Point> boundaries, Point pct, int maxSize)
    {
        if (pct.X >= 0 && pct.X <= maxSize && pct.Y >= 0 && pct.Y <= maxSize)
        {
            boundaries.Add(pct);
        }
    }

}
