namespace day01;
public class Problem
{
    List<Elf> lst = new List<Elf>();

    public string Result1 { get; set; }
    public string Result2 { get; set; }

    public void ResolvePart1(string arg)
    {
        var lines = File.ReadAllLines(arg);

        int maxValue = 0;
        int currentValue = 0;
        int idx = -1;
        int maxIdx = -1;
        int elfno = 1;
        int maxelfno = 0;
        foreach (var line in lines)
        {
            idx++;
            if (string.IsNullOrEmpty(line))
            {
                lst.Add(new Elf
                {
                    Index = idx,
                    Calories = currentValue
                });
                // System.Console.WriteLine($"elf: {elfno} calories: {currentValue} at line {idx}");
                if (currentValue > maxValue)
                {
                    maxIdx = idx;
                    maxValue = currentValue;
                    maxelfno = elfno;
                }
                currentValue = 0;
                elfno++;
            }
            else
            {
                currentValue += int.Parse(line);
            }
        }
        if (currentValue > 0)
        {
            lst.Add(new Elf
            {
                Index = idx,
                Calories = currentValue
            });
        }

        // System.Console.WriteLine($"max elf {maxelfno} calories: {maxValue} at line {maxIdx}");
        Result1 = maxValue.ToString();
    }

    public void ResolvePart2(string arg)
    {
        ResolvePart1(arg);

        var topThree = lst
            .OrderByDescending(x => x.Calories)
            .Take(3);
        // foreach (var tt in topThree)
        // {
        //     System.Console.WriteLine($"tt {tt.Index} v: {tt.Calories}");
        // }
        var ttTotal = topThree.Sum(x => x.Calories);
        // System.Console.WriteLine($"tt total: {ttTotal}");
        Result2 = ttTotal.ToString();
    }

}