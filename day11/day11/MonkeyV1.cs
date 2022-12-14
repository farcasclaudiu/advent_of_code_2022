namespace day11;

using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;


public class MonkeyV1
{
    public List<long> Items { get; set; } = new();

    public string NewFormula { get; set; }

    public long TestDivisor { get; set; }

    public int TeskMonkeyTrue { get; set; }
    public int TeskMonkeyFalse { get; set; }
    public long Inspections { get; set; }

    private Script<long> localScript;

    public void DoTurn(List<MonkeyV1> allMonkeys, long allDivisors)
    {
        foreach (var item in Items)
        {
            var globs = new Globals
            {
                old = item
            };
            if (localScript == null)
            {
                localScript = CSharpScript.Create<long>(NewFormula, globalsType: typeof(Globals));
                localScript.Compile();
            }

            var newWorry = localScript.RunAsync(globs).Result.ReturnValue;
            // System.Console.WriteLine($"newWorry: {newWorry}");
            // divide by 3
            newWorry = (int)Math.Ceiling((double)(newWorry / 3));
            // System.Console.WriteLine($"newWorry/3: {newWorry}");

            if (newWorry % TestDivisor == 0)
            {
                allMonkeys[TeskMonkeyTrue].Items.Add(newWorry);
            }
            else
            {
                allMonkeys[TeskMonkeyFalse].Items.Add(newWorry);
            }
        }
        Inspections += Items.Count;
        Items.Clear();
    }
}
