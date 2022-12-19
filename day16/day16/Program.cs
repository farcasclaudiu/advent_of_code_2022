namespace day16;
class Program
{
    static void Main(string[] args)
    {
        var inputFile = "testdata.txt";
        // var inputFile = "input.txt";

        var problem = new Problem();

        problem.ResolvePart1(inputFile);
        System.Console.WriteLine($"Result1: {problem.Result1}");
        // test 1651
        // input 2087

        // problem.ResolvePart2(inputFile);
        // System.Console.WriteLine($"Result2: {problem.Result2}");
        // test 1707
        // input ????

        //TODO - improve by applying Floyd Warshall algorithm
        // inspire from https://github.com/Bpendragon/AdventOfCodeCSharp/blob/9fd66/AdventOfCode/Solutions/Year2022/Day16-Solution.cs
    }
}
