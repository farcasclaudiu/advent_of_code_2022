namespace day12;

using FastGraph;
using FastGraph.Algorithms;

public class Problem
{
    public string Result1 { get; set; }
    public string Result2 { get; set; }

    public void ResolvePart1(string arg)
    {
        var lines = File.ReadAllLines(arg);

        var nrLines = lines.Length;
        var nrColumns = lines[0].Length;

        var aStarts = new List<(int X, int Y)>();
        for (int i = 0; i < nrLines; i++)
        {
            var line = lines[i];
            var lineIdx = 0;
            while ((lineIdx = line.IndexOfAny("S".ToArray(), lineIdx)) >= 0)
            {
                aStarts.Add((lineIdx++, i));
            }
        }

        var endY = Array.IndexOf(lines, lines.First(x => x.Contains("E")));
        var endX = lines[endY].IndexOf('E');
        // System.Console.WriteLine($"E: {endX} - {endY}");

        var startY = aStarts.First().Y;
        var startX = aStarts.First().X;
        // System.Console.WriteLine($"S: {startX} - {startY}");

        Node.InitGraph();
        var root = Node.Create(startX, startY, "a");
        root.AddVertices(lines);

        var currentPathCount = -1;
        var endNode = Node.AllNodes.FirstOrDefault(n => n.X == endX && n.Y == endY);
        if (endNode != null)
        {
            var tryGetPaths = Node.graph.ShortestPathsDijkstra(t => 1, root);
            if (tryGetPaths(endNode, out IEnumerable<TaggedEdge<Node, string>> path))
            {
                currentPathCount = path.Count();
            }
        }
        // else
        // {
        //     System.Console.WriteLine("end node not reacheable.");
        // }

        Result1 = currentPathCount.ToString();
    }

    public void ResolvePart2(string arg)
    {
        var lines = File.ReadAllLines(arg);

        var nrLines = lines.Length;
        var nrColumns = lines[0].Length;

        var aStarts = new List<(int X, int Y)>();
        for (int i = 0; i < nrLines; i++)
        {
            var line = lines[i];
            var lineIdx = 0;
            while ((lineIdx = line.IndexOfAny("aS".ToArray(), lineIdx)) >= 0)
            {
                aStarts.Add((i, lineIdx++));
            }
        }

        var endY = Array.IndexOf(lines, lines.First(x => x.Contains("E")));
        var endX = lines[endY].IndexOf('E');
        // System.Console.WriteLine($"E: {endX} - {endY}");

        var minPathCount = int.MaxValue;
        foreach (var start in aStarts)
        {
            var startY = start.X;
            var startX = start.Y;
            // System.Console.WriteLine($"S: {startX} - {startY}");

            Node.InitGraph();
            var root = Node.Create(startX, startY, "a");
            root.AddVertices(lines);

            // System.Console.WriteLine($"Graph nodes: {Node.graph.VertexCount}");

            var endNode = Node.AllNodes.FirstOrDefault(n => n.X == endX && n.Y == endY);
            if (endNode != null)
            {
                var tryGetPaths = Node.graph.ShortestPathsDijkstra(t => 1, root);
                if (tryGetPaths(endNode, out IEnumerable<TaggedEdge<Node, string>> path))
                {
                    var currentPathCount = path.Count();
                    minPathCount = Math.Min(minPathCount, currentPathCount);
                }
            }
            // else
            // {
            //     System.Console.WriteLine("end node not reacheable.");
            // }
        }

        // System.Console.WriteLine($"minPathCount: {minPathCount}");
        Result2 = minPathCount.ToString();
    }
}
