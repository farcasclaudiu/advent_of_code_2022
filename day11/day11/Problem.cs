namespace day11;
public class Problem
{
    public string Result1 { get; set; }
    public string Result2 { get; set; }

    public void ResolvePart1(string arg)
    {
        var lines = File.ReadAllLines(arg);

        List<MonkeyV1> allMonkeys = new List<MonkeyV1>();

        //capture monkeys
        for (int i = 0; i < lines.Length; i++)
        {
            var line = lines[i++];
            //monkey index
            var idx = int.Parse(line.Substring(0, line.Length - 1).Split(" ")[1]);
            var monkey = new MonkeyV1();
            allMonkeys.Add(monkey);
            //items
            line = lines[i++];
            monkey.Items.AddRange(line.Split(":")[1].Split(",").Select(x => long.Parse(x)));
            //operation
            line = lines[i++];
            monkey.NewFormula = line.Split(":")[1].Split("=")[1].Trim();
            //test divisor
            line = lines[i++];
            monkey.TestDivisor = int.Parse(line.Substring("  Test: divisible by ".Length));
            //test monkey true
            line = lines[i++];
            monkey.TeskMonkeyTrue = int.Parse(line.Substring("    If true: throw to monkey ".Length));
            //test monkey false
            line = lines[i++];
            monkey.TeskMonkeyFalse = int.Parse(line.Substring("    If false: throw to monkey".Length));
        }

        long allDivisors = 1;
        foreach (var monkey in allMonkeys)
        {
            allDivisors *= monkey.TestDivisor;
        }
        var nrRound = 20;
        // var nrRound = 10000;
        for (int i = 0; i < nrRound; i++)
        {
            // System.Console.WriteLine($"ROUND: {i + 1}");
            foreach (var monkey in allMonkeys)
            {
                monkey.DoTurn(allMonkeys, allDivisors);
            }
        }

        var prods = allMonkeys.OrderByDescending(x => x.Inspections).Take(2).ToArray();
        var monkeyBusiness = prods[0].Inspections * prods[1].Inspections;
        // System.Console.WriteLine($"MonkeyBusiness: {monkeyBusiness}");

        Result1 = monkeyBusiness.ToString();
    }

    public void ResolvePart2(string arg)
    {
        var lines = File.ReadAllLines(arg);

        List<MonkeyV2> allMonkeys = new List<MonkeyV2>();

        //capture monkeys
        for (int i = 0; i < lines.Length; i++)
        {
            var line = lines[i++];
            //monkey index
            var idx = int.Parse(line.Substring(0, line.Length - 1).Split(" ")[1]);
            var monkey = new MonkeyV2();
            allMonkeys.Add(monkey);
            //items
            line = lines[i++];
            monkey.Items.AddRange(line.Split(":")[1].Split(",").Select(x => long.Parse(x)));
            //operation
            line = lines[i++];
            monkey.NewFormula = line.Split(":")[1].Split("=")[1].Trim();
            //test divisor
            line = lines[i++];
            monkey.TestDivisor = int.Parse(line.Substring("  Test: divisible by ".Length));
            //test monkey true
            line = lines[i++];
            monkey.TeskMonkeyTrue = int.Parse(line.Substring("    If true: throw to monkey ".Length));
            //test monkey false
            line = lines[i++];
            monkey.TeskMonkeyFalse = int.Parse(line.Substring("    If false: throw to monkey".Length));
        }

        long allDivisors = 1;
        foreach (var monkey in allMonkeys)
        {
            allDivisors *= monkey.TestDivisor;
        }
        //var nrRound = 20;
        var nrRound = 10000;
        for (int i = 0; i < nrRound; i++)
        {
            // System.Console.WriteLine($"ROUND: {i + 1}");
            foreach (var monkey in allMonkeys)
            {
                monkey.DoTurn(allMonkeys, allDivisors);
            }
        }

        var prods = allMonkeys.OrderByDescending(x => x.Inspections).Take(2).ToArray();
        var monkeyBusiness = prods[0].Inspections * prods[1].Inspections;
        // System.Console.WriteLine($"MonkeyBusiness: {monkeyBusiness}");

        Result2 = monkeyBusiness.ToString();
    }
}
