namespace day10;
class Program
{
    static void Main(string[] args)
    {
        var inputFile = "input.txt";

        var problem = new Problem();

        problem.ResolvePart1(inputFile);
        System.Console.WriteLine($"Result1: {problem.Result1}");
        //11720

        problem.ResolvePart2(inputFile);
        System.Console.WriteLine($"Result2: {problem.Result2}");
        // ERCREPCJ
    }
}
