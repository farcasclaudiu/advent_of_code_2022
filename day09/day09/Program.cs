namespace day09;
class Program
{
    static void Main(string[] args)
    {
        var inputFile = "input.txt";

        var problem = new Problem();

        problem.ResolvePart1(inputFile);
        System.Console.WriteLine($"Result1: {problem.Result1}");

        problem.ResolvePart2(inputFile);
        System.Console.WriteLine($"Result2: {problem.Result2}");
    }
}
