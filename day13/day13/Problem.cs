namespace day13;

/// <summary>
/// HINT - https://github.com/jcollard/AdventOfCode2022/tree/main/Day13
/// </summary>
public class Problem
{
    public string Result1 { get; set; }
    public string Result2 { get; set; }

    public void ResolvePart1(string arg)
    {
        var lines = File.ReadAllLines(arg);

        var inRightOrder = 0;
        var idx = 0;
        var idxSum = 0;
        for (int i = 0; i < lines.Length; i++)
        {
            idx++;
            var line1 = lines[i++];
            var line2 = lines[i++];

            Message msg1 = Message.Create(line1);
            Message msg2 = Message.Create(line2);

            if (msg1.Compare(msg2) <= 0)
            {
                inRightOrder++;
                idxSum += idx;
            }
        }

        // System.Console.WriteLine($"inRightOrder: {inRightOrder}  sum: {idxSum}");
        Result1 = idxSum.ToString();
    }

    public void ResolvePart2(string arg)
    {
        var lines = File.ReadAllLines(arg);

        // PROBLEM 2
        List<Message> lstMessages = new();
        for (int i = 0; i < lines.Length; i++)
        {
            var line1 = lines[i++];
            lstMessages.Add(Message.Create(line1));
            var line2 = lines[i++];
            lstMessages.Add(Message.Create(line2));
        }
        var div1 = Message.Create("[[2]]");
        lstMessages.Add(div1);
        var div2 = Message.Create("[[6]]");
        lstMessages.Add(div2);
        lstMessages.Sort((a, b) => a.Compare(b));

        var idxDiv1 = lstMessages.IndexOf(div1) + 1;
        var idxDiv2 = lstMessages.IndexOf(div2) + 1;
        var decoderKey = idxDiv1 * idxDiv2;

        // System.Console.WriteLine($"decoderKey: {decoderKey}");
        Result2 = decoderKey.ToString();
    }
}
