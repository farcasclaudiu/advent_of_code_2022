namespace day02;

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

        // //A for Rock, B for Paper, and C for Scissors
        // //X for Rock, Y for Paper, and Z for Scissors

        // var lines = File.ReadAllLines("input01.txt");
        // int totalScore = 0;
        // foreach (var line in lines)
        // {
        //     var opMove = line[0].ToString();
        //     var myMove = line[2].ToString();
        //     totalScore += ComputeMatch(opMove.GetOpMoveSymbol(), myMove.GetMyMoveSymbol());
        // }
        // System.Console.WriteLine($"totalScore: {totalScore}");
        // //13565

        // //X means you need to lose, Y means you need to end the round in a draw, and Z means you need to win.
        // int totalScoreStrat = 0;
        // foreach (var line in lines)
        // {
        //     var opMoveLetter = line[0].ToString();
        //     var opMove = opMoveLetter.GetOpMoveSymbol();
        //     var matchScoreLetter = line[2].ToString();
        //     var matchScore = matchScoreLetter.GetGameScore();
        //     var myMove = matchScore.ComputeMyMove(opMove);
        //     totalScoreStrat += ComputeMatch(opMove, myMove);
        // }
        // System.Console.WriteLine($"totalScoreStrat: {totalScoreStrat}");
        // //12424
    }
}
