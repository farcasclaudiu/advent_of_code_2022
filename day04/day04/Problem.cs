namespace day04;
public class Problem
{
    public string Result1 { get; set; }
    public string Result2 { get; set; }

    public void ResolvePart1(string arg)
    {
        var lines = File.ReadAllLines(arg);

        var containCount = 0;
        var overlapingCount = 0;
        foreach (var line in lines)
        {
            var linesplit = line.Split(',');
            var elf1 = linesplit[0];
            var rangeElf1 = elf1.Split('-');
            var start1 = int.Parse(rangeElf1[0]);
            var end1 = int.Parse(rangeElf1[1]);
            var elf2 = linesplit[1];
            var rangeElf2 = elf2.Split('-');
            var start2 = int.Parse(rangeElf2[0]);
            var end2 = int.Parse(rangeElf2[1]);
            //for problem 2
            if (start1 <= end2 && start2 <= end1)
            {
                overlapingCount++;
            }
            //for problem 1
            if ((start1 <= start2 && end2 <= end1) ||
                 (start2 <= start1 && end1 <= end2))
            {
                containCount++;
            }
        }

        // System.Console.WriteLine(containCount);
        //513
        Result1 = containCount.ToString();

        // System.Console.WriteLine(overlapingCount);
        //878
        Result2 = overlapingCount.ToString();
    }

    public void ResolvePart2(string arg)
    {
        ResolvePart1(arg);
    }
}