namespace day14;
public class Problem
{
    public string Result1 { get; set; }
    public string Result2 { get; set; }

    private HashSet<Point> obstacles = new HashSet<Point>();
    private HashSet<Point> allDrops = new HashSet<Point>();

    public void ResolvePart1(string arg)
    {
        var lines = File.ReadAllLines(arg);

        obstacles.Clear();
        allDrops.Clear();

        //reading rocks
        var bedrockLevel = 0;
        foreach (var line in lines)
        {
            var linecoords = line.Split("->",
                StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
            Point prevCoord = null;
            for (int i = 0; i < linecoords.Length; i++)
            {
                var currCoordStr = linecoords[i];
                var currCoords = currCoordStr.Split(",");
                var currCoord = new Point(int.Parse(currCoords[0]), int.Parse(currCoords[1]));
                //bedrock
                bedrockLevel = Math.Max(bedrockLevel, currCoord.Y);
                if (prevCoord != null)
                {
                    //build rock
                    if (prevCoord.X == currCoord.X)
                    {
                        //same X axis
                        var min = Math.Min(prevCoord.Y, currCoord.Y);
                        var max = Math.Max(prevCoord.Y, currCoord.Y);
                        for (int j = min; j <= max; j++)
                        {
                            obstacles.Add(new Point(prevCoord.X, j));
                        }
                    }
                    else if (prevCoord.Y == currCoord.Y)
                    {
                        //same y axis
                        var min = Math.Min(prevCoord.X, currCoord.X);
                        var max = Math.Max(prevCoord.X, currCoord.X);
                        for (int j = min; j <= max; j++)
                        {
                            obstacles.Add(new Point(j, prevCoord.Y));
                        }
                    }
                    else
                    {
                        throw new ArgumentException("invalid coordinates");
                    }
                }
                prevCoord = currCoord;
            }
        }
        // ShowMap(obstacles, bedrockLevel);

        // START FALLING
        var nrDrops = 0;
        var fallInVoid = false;
        while (!fallInVoid)
        {
            var isSettle = false;
            var drop = new Point(500, 0);
            nrDrops++;
            while (!isSettle)
            {
                if (drop.Y + 1 > bedrockLevel)
                {
                    nrDrops--;// subtract this last drop that will fall in void
                    fallInVoid = true;
                    break;
                }

                //bellow
                var next = new Point(drop.X, drop.Y + 1);
                var didMove = TryMove(next);
                if (didMove)
                {
                    drop = next;
                    continue;
                }
                //mode left
                next = new Point(drop.X - 1, drop.Y + 1);
                didMove = TryMove(next);
                if (didMove)
                {
                    drop = next;
                    continue;
                }
                //mode right
                next = new Point(drop.X + 1, drop.Y + 1);
                didMove = TryMove(next);
                if (didMove)
                {
                    drop = next;
                    continue;
                }
                //become obstacle
                obstacles.Add(drop);
                allDrops.Add(drop);
                isSettle = true;
            }
        }
        // System.Console.WriteLine($"nrDrops: {nrDrops}");
        // ShowMap(obstacles, bedrockLevel);


        Result1 = nrDrops.ToString();
    }

    private bool TryMove(Point next)
    {
        return !obstacles.Contains(next);
    }

    private void ShowMap(HashSet<Point> obstacles, int depth)
    {
        for (int j = 0; j <= depth; j++)
        {
            System.Console.Write($"{j} ");
            for (int i = 420; i < 550; i++)
            {
                var tP = new Point(i, j);
                if (obstacles.Contains(tP))
                {
                    if (allDrops.Contains(tP))
                    {
                        System.Console.Write("o");
                    }
                    else
                    {
                        System.Console.Write("#");
                    }
                }
                else
                {
                    System.Console.Write(".");
                }
            }
            System.Console.WriteLine();
        }
    }

    public void ResolvePart2(string arg)
    {
        var lines = File.ReadAllLines(arg);

        obstacles.Clear();
        allDrops.Clear();

        //reading rocks
        var bedrockLevel = 0;
        foreach (var line in lines)
        {
            var linecoords = line.Split("->",
                StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
            Point prevCoord = null;
            for (int i = 0; i < linecoords.Length; i++)
            {
                var currCoordStr = linecoords[i];
                var currCoords = currCoordStr.Split(",");
                var currCoord = new Point(int.Parse(currCoords[0]), int.Parse(currCoords[1]));
                //bedrock
                bedrockLevel = Math.Max(bedrockLevel, currCoord.Y);
                if (prevCoord != null)
                {
                    //build rock
                    if (prevCoord.X == currCoord.X)
                    {
                        //same X axis
                        var min = Math.Min(prevCoord.Y, currCoord.Y);
                        var max = Math.Max(prevCoord.Y, currCoord.Y);
                        for (int j = min; j <= max; j++)
                        {
                            obstacles.Add(new Point(prevCoord.X, j));
                        }
                    }
                    else if (prevCoord.Y == currCoord.Y)
                    {
                        //same y axis
                        var min = Math.Min(prevCoord.X, currCoord.X);
                        var max = Math.Max(prevCoord.X, currCoord.X);
                        for (int j = min; j <= max; j++)
                        {
                            obstacles.Add(new Point(j, prevCoord.Y));
                        }
                    }
                    else
                    {
                        throw new ArgumentException("invalid coordinates");
                    }
                }
                prevCoord = currCoord;
            }
        }
        bedrockLevel += 2;

        for (int i = 0; i < 1200; i++)
        {
            obstacles.Add(new Point(i, bedrockLevel));
        }
        // ShowMap(obstacles, bedrockLevel);

        // START FALLING
        var nrDrops = 0;
        var fallInVoid = false;
        while (!fallInVoid)
        {
            var isSettle = false;
            var drop = new Point(500, 0);
            nrDrops++;
            while (!isSettle)
            {
                if (drop.Y + 1 > bedrockLevel - 1)
                {
                    obstacles.Add(drop);
                    allDrops.Add(drop);
                    isSettle = true;
                    // nrDrops--;// subtract this last drop that will fall in void
                    // fallInVoid = true;
                    break;
                }

                //bellow
                var next = new Point(drop.X, drop.Y + 1);
                var didMove = TryMove(next);
                if (didMove)
                {
                    drop = next;
                    continue;
                }
                //mode left
                next = new Point(drop.X - 1, drop.Y + 1);
                didMove = TryMove(next);
                if (didMove)
                {
                    drop = next;
                    continue;
                }
                //mode right
                next = new Point(drop.X + 1, drop.Y + 1);
                didMove = TryMove(next);
                if (didMove)
                {
                    drop = next;
                    continue;
                }
                //become obstacle
                if (obstacles.Contains(drop))
                {
                    nrDrops--;// subtract this last drop that will fall in void
                    fallInVoid = true;
                    break;
                }
                else
                {
                    obstacles.Add(drop);
                    allDrops.Add(drop);
                    isSettle = true;
                }
            }
        }
        // System.Console.WriteLine($"nrDrops: {nrDrops}");

        // ShowMap(obstacles, bedrockLevel);


        Result2 = nrDrops.ToString();
    }
}
