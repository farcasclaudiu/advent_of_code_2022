namespace day05;
using System.Text.RegularExpressions;

public class Problem
{
    public string Result1 { get; set; }
    public string Result2 { get; set; }

    public void ResolvePart1(string arg)
    {
        var lines = File.ReadAllLines(arg);

        var baseStackLine = lines.First(x => x.Contains("1"));
        var idxBaseLine = Array.IndexOf(lines, baseStackLine);
        // System.Console.WriteLine($"idxBaseLine: {idxBaseLine}");

        var noStacks = int.Parse(lines[idxBaseLine].Split(' ', StringSplitOptions.RemoveEmptyEntries).Last());
        // System.Console.WriteLine($"noStacks: {noStacks}");

        List<Stack<string>> listOfStacks = new List<Stack<string>>();
        for (int j = 0; j < noStacks; j++)
        {
            listOfStacks.Add(new Stack<string>());
        }
        for (int i = idxBaseLine - 1; i >= 0; i--)
        {
            var line = lines[i];
            // System.Console.WriteLine($"i: {i} - {line}");
            for (int j = 0; j < noStacks; j++)
            {
                var crateLetter = line[j * 4 + 1].ToString();
                if (!string.IsNullOrWhiteSpace(crateLetter))
                {
                    listOfStacks[j].Push(crateLetter);
                }
            }
        }

        var firstMoveLine = lines.First(x => x.Contains("move"));
        var idxFirstModeLine = Array.IndexOf(lines, firstMoveLine);
        // System.Console.WriteLine($"idxFirstModeLine: {idxFirstModeLine}");

        for (int i = idxFirstModeLine; i < lines.Length; i++)
        {
            var moveLine = lines[i];
            Regex rg = new Regex("move (?<pieces>[0-9]+) from (?<from>[0-9]+) to (?<to>[0-9]+)");
            var match = rg.Match(moveLine);
            if (match.Success)
            {
                var pieces = int.Parse(match.Groups["pieces"].Captures[0].Value);
                var from = int.Parse(match.Groups["from"].Captures[0].Value);
                var to = int.Parse(match.Groups["to"].Captures[0].Value);
                // System.Console.WriteLine($"pieces: {pieces} from: {from} to: {to}");

                var fromStack = listOfStacks[from - 1];
                var toStack = listOfStacks[to - 1];
                var movingStack = new Stack<string>();
                for (int idxPieces = 0; idxPieces < pieces; idxPieces++)
                {
                    var elementToMove = fromStack.Pop();
                    movingStack.Push(elementToMove);
                    toStack.Push(elementToMove);
                }
            }
        }

        var final = string.Join("", listOfStacks.Select(s => s.First()).ToArray());
        // System.Console.WriteLine($"final: {final}");
        // NTWZZWHFV
        Result1 = final.ToString();
    }

    public void ResolvePart2(string arg)
    {
        var lines = File.ReadAllLines(arg);

        var baseStackLine = lines.First(x => x.Contains("1"));
        var idxBaseLine = Array.IndexOf(lines, baseStackLine);
        // System.Console.WriteLine($"idxBaseLine: {idxBaseLine}");

        var noStacks = int.Parse(lines[idxBaseLine].Split(' ', StringSplitOptions.RemoveEmptyEntries).Last());
        // System.Console.WriteLine($"noStacks: {noStacks}");

        List<Stack<string>> listOfStacks = new List<Stack<string>>();
        for (int j = 0; j < noStacks; j++)
        {
            listOfStacks.Add(new Stack<string>());
        }
        for (int i = idxBaseLine - 1; i >= 0; i--)
        {
            var line = lines[i];
            // System.Console.WriteLine($"i: {i} - {line}");
            for (int j = 0; j < noStacks; j++)
            {
                var crateLetter = line[j * 4 + 1].ToString();
                if (!string.IsNullOrWhiteSpace(crateLetter))
                {
                    listOfStacks[j].Push(crateLetter);
                }
            }
        }

        var firstMoveLine = lines.First(x => x.Contains("move"));
        var idxFirstModeLine = Array.IndexOf(lines, firstMoveLine);
        // System.Console.WriteLine($"idxFirstModeLine: {idxFirstModeLine}");

        for (int i = idxFirstModeLine; i < lines.Length; i++)
        {
            var moveLine = lines[i];
            Regex rg = new Regex("move (?<pieces>[0-9]+) from (?<from>[0-9]+) to (?<to>[0-9]+)");
            var match = rg.Match(moveLine);
            if (match.Success)
            {
                var pieces = int.Parse(match.Groups["pieces"].Captures[0].Value);
                var from = int.Parse(match.Groups["from"].Captures[0].Value);
                var to = int.Parse(match.Groups["to"].Captures[0].Value);
                // System.Console.WriteLine($"pieces: {pieces} from: {from} to: {to}");

                var fromStack = listOfStacks[from - 1];
                var toStack = listOfStacks[to - 1];
                var movingStack = new Stack<string>();
                for (int idxPieces = 0; idxPieces < pieces; idxPieces++)
                {
                    var elementToMove = fromStack.Pop();
                    movingStack.Push(elementToMove);
                }
                while (movingStack.Count > 0)
                {
                    var elementToMove = movingStack.Pop();
                    toStack.Push(elementToMove);
                }
            }
        }

        var final = string.Join("", listOfStacks.Select(s => s.First()).ToArray());
        // System.Console.WriteLine($"final: {final}");
        // BRZGFVBTJ
        Result2 = final.ToString();
    }
}