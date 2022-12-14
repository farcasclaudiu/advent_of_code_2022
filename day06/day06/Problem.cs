namespace day06;
using System.Text.RegularExpressions;

public class Problem
{
    public string Result1 { get; set; }
    public string Result2 { get; set; }

    public void ResolvePart1(string arg)
    {
        var lines = File.ReadAllLines(arg);

        var space = 4;
        List<int> lstIdx = new List<int>();
        foreach (var line in lines)
        {
            var idx = 0;
            for (int i = 0; i < line.Length - space; i++)
            {
                var current = line.Substring(i, space);
                //System.Console.WriteLine(current);
                if (current.ToArray().Distinct().Count() == space)
                {
                    idx = i + 4;
                    break;
                }
            }
            lstIdx.Add(idx);
            // System.Console.WriteLine($"for space {space} idx is {idx}");
            //1361
        }

        Result1 = string.Join(',', lstIdx);
    }

    public void ResolvePart2(string arg)
    {
        var lines = File.ReadAllLines(arg);

        var space = 14;
        List<int> lstIdx = new List<int>();
        foreach (var line in lines)
        {
            var idx = 0;
            for (int i = 0; i < line.Length - space; i++)
            {
                var current = line.Substring(i, space);
                //System.Console.WriteLine(current);
                if (current.ToArray().Distinct().Count() == space)
                {
                    idx = i + space;
                    break;
                }
            }
            lstIdx.Add(idx);
            // System.Console.WriteLine($"for space {space} idx is {idx}");
            //3263
        }

        Result2 = string.Join(',', lstIdx);
    }
}