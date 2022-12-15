namespace day15;

using System.Text.RegularExpressions;
using System.Linq;

public class Problem
{
    public string Result1 { get; set; }
    public string Result2 { get; set; }

    Regex rg = new Regex(
            "Sensor at x=(?<sx>-?[0-9]+), y=(?<sy>-?[0-9]+): closest beacon is at x=(?<bx>-?[0-9]+), y=(?<by>-?[0-9]+)"
        );

    public void ResolvePart1(string arg, int testY)
    {
        var lines = File.ReadAllLines(arg);

        List<Sensor> lstSensors = new List<Sensor>();
        HashSet<Point> lstBeacons = new HashSet<Point>();

        foreach (var line in lines)
        {
            var match = rg.Match(line);
            if (match.Success)
            {
                var sx = int.Parse(match.Groups["sx"].Captures[0].Value);
                var sy = int.Parse(match.Groups["sy"].Captures[0].Value);
                var bx = int.Parse(match.Groups["bx"].Captures[0].Value);
                var by = int.Parse(match.Groups["by"].Captures[0].Value);
                lstSensors.Add(new Sensor(sx, sy, bx, by));
                lstBeacons.Add(new Point(bx, by));
            }
        }

        //scan testy line
        var minX = lstSensors.Min(x => x.Position.X - x.Distance);
        var maxX = lstSensors.Max(x => x.Position.X + x.Distance);

        var lstX = Enumerable.Range(minX, maxX - minX)
            .Where(tX =>
            {
                var tPoint = new Point(tX, testY);
                return !lstBeacons.Contains(tPoint) &&
                    lstSensors.Any(s => s.Distance >= Point.ComputeDistance(tPoint, s.Position));
            }).ToList();

        Result1 = lstX.Count.ToString();
    }

    public void ResolvePart2(string arg, int maxSpace)
    {
        var lines = File.ReadAllLines(arg);

        List<Sensor> lstSensors = new List<Sensor>();
        HashSet<Point> lstBeacons = new HashSet<Point>();

        foreach (var line in lines)
        {
            var match = rg.Match(line);
            if (match.Success)
            {
                var sx = int.Parse(match.Groups["sx"].Captures[0].Value);
                var sy = int.Parse(match.Groups["sy"].Captures[0].Value);
                var bx = int.Parse(match.Groups["bx"].Captures[0].Value);
                var by = int.Parse(match.Groups["by"].Captures[0].Value);
                lstSensors.Add(new Sensor(sx, sy, bx, by));
                lstBeacons.Add(new Point(bx, by));
            }
        }

        Point solution = null;
        foreach (var sensor in lstSensors)
        {
            //test only boundaries of the sensor area
            var candidates = sensor.GetBoundaries(maxSpace)
                .Where(b => !lstSensors.Any(s =>
                        s != sensor &&
                        s.Distance >= Point.ComputeDistance(b, s.Position)))
                .ToList();
            if (candidates.Count > 0)
            {
                // System.Console.WriteLine($"candidates {candidates.Count}: {candidates[0]}");
                solution = candidates[0];
                break;
            }
        }

        decimal freq = solution != null ? ((decimal)solution.X * 4000000 + solution.Y) : -1;
        Result2 = freq.ToString();
    }
}
