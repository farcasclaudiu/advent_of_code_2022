namespace day15;
class Program
{
    static void Main(string[] args)
    {
        // var inputFile = "testdata.txt";
        var inputFile = "input.txt";

        var problem = new Problem();

        // problem.ResolvePart1(inputFile, 10);//testdata.txt
        problem.ResolvePart1(inputFile, 2000000);//for input.txt
        System.Console.WriteLine($"Result1: {problem.Result1}");
        //4748135

        // problem.ResolvePart2(inputFile, 20);//testdata.txt
        problem.ResolvePart2(inputFile, 4000000);//for input.txt
        System.Console.WriteLine($"Result2: {problem.Result2}");
        //13743542639657
    }
}
