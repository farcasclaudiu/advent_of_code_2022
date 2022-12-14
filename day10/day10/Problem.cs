namespace day10;

using System.Text;
public class Problem
{
    public string Result1 { get; set; }
    public string Result2 { get; set; }

    private List<int> lstCycle = new List<int>{
        20, 60, 100, 140, 180, 220
    };
    private int crtIdx = 0;

    StringBuilder sbRes2 = new();

    public void ResolvePart1(string arg)
    {
        var lines = File.ReadAllLines(arg);

        var cycle = 0;
        var regX = 1;
        var sumSignal = 0;
        //
        for (int i = 0; i < lines.Length; i++)
        {
            var line = lines[i];
            var lineParts = line.Split(" ");
            var cmd = lineParts[0];
            switch (cmd)
            {
                case "noop":
                    cycle++;
                    sumSignal += DisplayForCycle(cycle, regX, i);
                    break;
                case "addx":
                    cycle++;
                    sumSignal += DisplayForCycle(cycle, regX, i);
                    cycle++;
                    sumSignal += DisplayForCycle(cycle, regX, i);
                    regX += int.Parse(lineParts[1]);
                    break;
                default:
                    throw new ArgumentException($"invalid cmd {cmd}");
                    break;
            }
        }
        // System.Console.WriteLine($"sumSignal: {sumSignal}");
        //13140
        //11720

        Result1 = sumSignal.ToString();
    }

    public void ResolvePart2(string arg)
    {
        ResolvePart1(arg);

        Result2 = sbRes2.ToString();
    }

    public int DisplayForCycle(int cycle, int regX, int lineNo)
    {
        //
        if (SpriteIntersect(regX, crtIdx))
        {
            sbRes2.Append("#");
            // System.Console.Write("#");
        }
        else
        {
            sbRes2.Append(".");
            // System.Console.Write(".");
        }
        crtIdx++;
        if (crtIdx % 40 == 0)
        {
            sbRes2.Append(Environment.NewLine);
            // System.Console.WriteLine("");
        }
        //
        if (regX < -1)
        {
            //System.Console.WriteLine($"regX is less than zero. {regX}");
        }
        if (lstCycle.Contains(cycle))
        {
            //System.Console.WriteLine($"cycle: {cycle} X: {regX} ss:{cycle * regX} on lineNo: {lineNo}");
            return cycle * regX;
        }
        return 0;
    }

    public bool SpriteIntersect(int regX, int crtIdx)
    {
        var m40 = regX % 40;
        var c40 = crtIdx % 40;
        return (c40 >= m40 - 1 && c40 <= m40 + 1);
    }
}
