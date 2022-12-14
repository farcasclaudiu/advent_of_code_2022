namespace day09;
public class Problem
{
    public string Result1 { get; set; }
    public string Result2 { get; set; }

    public void ResolvePart1(string arg)
    {
        var lines = File.ReadAllLines(arg);

        var tailPositions = new HashSet<(int, int)>();
        tailPositions.Add((0, 0));//start position
        var currentHeadPos = (x: 0, y: 0);
        var knots = new List<(int x, int y)>();
        // nr of knots
        // PART 1
        var knotsNo = 1;
        knots.Add(currentHeadPos);
        for (int i = 0; i < knotsNo; i++)
        {
            knots.Add((0, 0));
        }
        foreach (var line in lines)
        {
            var linecmd = line.Split(" ");
            var direction = linecmd[0];
            var tiles = int.Parse(linecmd[1]);
            // System.Console.WriteLine($"{direction} {tiles}");
            for (int i = 0; i < tiles; i++)
            {
                switch (direction)
                {
                    case "U":
                        currentHeadPos = (currentHeadPos.x, currentHeadPos.y - 1);
                        break;
                    case "D":
                        currentHeadPos = (currentHeadPos.x, currentHeadPos.y + 1);
                        break;
                    case "L":
                        currentHeadPos = (currentHeadPos.x - 1, currentHeadPos.y);
                        break;
                    case "R":
                        currentHeadPos = (currentHeadPos.x + 1, currentHeadPos.y);
                        break;
                    default:
                        throw new ArgumentException($"command {direction} not supported", nameof(direction));
                }
                knots[0] = currentHeadPos;

                for (int j = 0; j < knotsNo; j++)
                {
                    var firstKnot = knots[j];
                    var secondKnot = knots[j + 1];
                    AdjustTailPos(ref firstKnot, ref secondKnot);
                    knots[j + 1] = secondKnot;
                }
                tailPositions.Add(knots.Last());//add tail pos
            }
        }
        // get # of unique positions visited by the tail - T
        // System.Console.WriteLine($"tail visited positions {tailPositions.Count}");
        // P1
        //5710

        Result1 = tailPositions.Count.ToString();
    }

    public void ResolvePart2(string arg)
    {
        var lines = File.ReadAllLines(arg);

        var tailPositions = new HashSet<(int, int)>();
        tailPositions.Add((0, 0));//start position
        var currentHeadPos = (x: 0, y: 0);
        var knots = new List<(int x, int y)>();
        // nr of knots
        //PART2
        var knotsNo = 9;
        knots.Add(currentHeadPos);
        for (int i = 0; i < knotsNo; i++)
        {
            knots.Add((0, 0));
        }
        foreach (var line in lines)
        {
            var linecmd = line.Split(" ");
            var direction = linecmd[0];
            var tiles = int.Parse(linecmd[1]);
            // System.Console.WriteLine($"{direction} {tiles}");
            for (int i = 0; i < tiles; i++)
            {
                switch (direction)
                {
                    case "U":
                        currentHeadPos = (currentHeadPos.x, currentHeadPos.y - 1);
                        break;
                    case "D":
                        currentHeadPos = (currentHeadPos.x, currentHeadPos.y + 1);
                        break;
                    case "L":
                        currentHeadPos = (currentHeadPos.x - 1, currentHeadPos.y);
                        break;
                    case "R":
                        currentHeadPos = (currentHeadPos.x + 1, currentHeadPos.y);
                        break;
                    default:
                        throw new ArgumentException($"command {direction} not supported", nameof(direction));
                }
                knots[0] = currentHeadPos;

                for (int j = 0; j < knotsNo; j++)
                {
                    var firstKnot = knots[j];
                    var secondKnot = knots[j + 1];
                    AdjustTailPos(ref firstKnot, ref secondKnot);
                    knots[j + 1] = secondKnot;
                }
                tailPositions.Add(knots.Last());//add tail pos
            }
        }
        // get # of unique positions visited by the tail - T
        // System.Console.WriteLine($"tail visited positions {tailPositions.Count}");
        // P2
        //2259

        Result2 = tailPositions.Count.ToString();
    }

    public static void AdjustTailPos(ref (int x, int y) headPos, ref (int x, int y) tailPos)
    {
        var dX = headPos.x - tailPos.x;
        var dY = headPos.y - tailPos.y;
        if (Math.Abs(dX) > 1 || Math.Abs(dY) > 1)
        {
            if (Math.Abs(dX) * Math.Abs(dY) > 1)
            {
                //diagonal
                tailPos = (
                    tailPos.x + Math.Sign(dX),
                    tailPos.y + Math.Sign(dY)
                );
            }
            else
            {
                tailPos = (
                    tailPos.x + (Math.Abs(dX) > 0 ? (dX - Math.Sign(dX) * 1) : 0),
                    tailPos.y + (Math.Abs(dY) > 0 ? (dY - Math.Sign(dY) * 1) : 0)
                );
            }
        }
    }
}
