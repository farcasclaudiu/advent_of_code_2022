namespace day01;
class Program
{
    static void Main(string[] args)
    {
        var inputFile = "input.txt";
        var problem = new Problem();
        problem.ResolvePart2(inputFile);//solves also part 1

        System.Console.WriteLine($"Result1: Total calories of that elf: {problem.Result1}");
        System.Console.WriteLine($"Result2: Total calories of those elfs: {problem.Result2}");
    }
}
