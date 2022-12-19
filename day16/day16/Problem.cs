namespace day16;
using System.Text.RegularExpressions;
using System.Linq;

public class Problem
{
    public string Result1 { get; set; }
    public string Result2 { get; set; }



    Regex rg = new Regex(
        "Valve (?<valve>[A-Z]+) has flow rate=(?<flow>[0-9]+); tunnels? leads? to valves? (?<leads>.+)"
    );


    private int totalMinutes = 30;
    private int previousPressure = 0;

    public static int MaxPressure;
    public void ResolvePart1(string arg)
    {
        var lines = File.ReadAllLines(arg);

        List<Valve> lstValves = new List<Valve>();
        foreach (var line in lines)
        {
            var match = rg.Match(line);
            if (match.Success)
            {
                var valve = match.Groups["valve"].Captures[0].Value;
                var flow = match.Groups["flow"].Captures[0].Value;
                var leads = match.Groups["leads"].Captures[0].Value;
                lstValves.Add(new Valve(valve, flow, leads));
            }
        }

        var machine = new Machine
        (
            totalMinutes, //max minutes
            1, // current minute
            lstValves, //valves
            new(), //open valves
            0, //total flow
            "AA", //current valve,
            "m" + "AA" //first action
        );
        machine.MoveList = new List<string>();
        var maxFlow = machine.MoveNext();

        Result1 = maxFlow.ToString();
    }




    public void ResolvePart2(string arg)
    {
        var lines = File.ReadAllLines(arg);


        Result2 = "x".ToString();
    }
}


public class Machine
{
    private Machine() { }

    public Machine(int maxMinutes,
        int currentMinute,
        List<Valve> valves,
        List<Valve> openValves,
        int totalFlow,
        string currentValve,
        string path)
    {
        MaxMinutes = maxMinutes;
        CurrentMinute = currentMinute;
        Valves = new List<Valve>(valves);
        OpenValves = new List<Valve>(openValves);
        TotalFlow = totalFlow;
        CurrentValve = currentValve;
        Path = path;
    }

    public int MaxMinutes { get; }
    public int CurrentMinute { get; internal set; }
    public List<Valve> Valves { get; }
    public List<Valve> OpenValves { get; }
    public int TotalFlow { get; }
    public string CurrentValve { get; }
    public string Path { get; }
    public List<string> MoveList { get; set; } = new List<string>();

    public int MoveNext()
    {
        // System.Console.WriteLine($"{TotalFlow} : {Path}");
        var result = TotalFlow;
        if (CurrentMinute < MaxMinutes)
        {
            var unopened = Valves.Count(v => v.Flow > 0) - OpenValves.Count;
            if (unopened > 0)
            {
                var valve = Valves.First(v => v.Label == CurrentValve);

                //open current valve if possible
                if (valve.Flow > 0 && !OpenValves.Contains(valve))
                {
                    var cOV = new List<Valve>(OpenValves);
                    cOV.Add(valve);
                    var childMachine = new Machine(
                        MaxMinutes,
                        CurrentMinute + 1,
                        Valves,
                        cOV,
                        TotalFlow + (MaxMinutes - CurrentMinute) * valve.Flow,
                        valve.Label,
                        Path + ",o" + valve.Label
                    );
                    result = Math.Max(result, childMachine.MoveNext());
                }

                var maxDepth = Valves.Count(v => v.Flow == 0) + unopened;//optimization
                if (MoveList.Count < maxDepth)
                {
                    // process moving next first
                    foreach (var tunnel in valve.Tunnels)
                    {
                        if (!this.MoveList.Contains(tunnel))
                        {
                            var childMachine = new Machine(
                                MaxMinutes,
                                CurrentMinute + 1,
                                Valves,
                                OpenValves,
                                TotalFlow,
                                tunnel,
                                Path + ",m" + tunnel
                            );
                            childMachine.MoveList = new List<string>(this.MoveList);
                            childMachine.MoveList.Add(tunnel);
                            var result2 = childMachine.MoveNext();
                            result = Math.Max(result, result2);
                        }
                    }
                }
            }
        }
        else if (CurrentMinute == MaxMinutes)
        {
            return result;
        }
        else
        {
            throw new NotSupportedException($"impossible situation: {CurrentMinute}");
        }
        // if (result > Problem.MaxPressure)
        // {
        //     Problem.MaxPressure = result;
        //     System.Console.WriteLine($"max: {result} path: {this.Path}");
        //     //max: 2087 path: mAA,mPE,mWW,mDY,mYI,oYI,mMZ,mUA,oUA,mKY,mAW,oAW,mYZ,mEL,oEL,mRD,mOY,oOY,mVO,mFL,oFL,mFH,mWZ,mEG,oEG,mZP,mMC,mXY,oXY
        // }
        return result;
    }
}

public class Valve
{
    public Valve(string label, string flow, string tunnels)
    {
        Label = label;
        Flow = int.Parse(flow);
        this.Tunnels = tunnels.Split(",", StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries).ToList();
    }

    public string Label { get; }
    public int Flow { get; }

    public List<string> Tunnels { get; }

    public override string ToString()
    {
        return $"valve: {Label} flow {Flow} tunnels {string.Join(',', Tunnels)}";
    }


    public Valve GetBestValveToOpen(Stack<Valve> openedValves, List<Valve> allvalves)
    {
        var candidates = this.Tunnels
            .Select(t => allvalves.Find(v => v.Label == t && !openedValves.Contains(v)))
            .Where(v => v != null && ((v.Flow > (2 * this.Flow)) || (this.Flow == 0 && v.Flow == 0)))
            .OrderByDescending(v => v.Flow).ToList();
        if (candidates.Count > 0)
        {
            return candidates.First();
        }
        return this;
    }
}
