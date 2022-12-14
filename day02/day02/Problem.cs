namespace day02;
public class Problem
{
    public string Result1 { get; set; }
    public string Result2 { get; set; }

    public void ResolvePart1(string arg)
    {
        var lines = File.ReadAllLines(arg);

        //A for Rock, B for Paper, and C for Scissors
        //X for Rock, Y for Paper, and Z for Scissors

        int totalScore = 0;
        foreach (var line in lines)
        {
            var opMove = line[0].ToString();
            var myMove = line[2].ToString();
            totalScore += ComputeMatch(opMove.GetOpMoveSymbol(), myMove.GetMyMoveSymbol());
        }
        // System.Console.WriteLine($"totalScore: {totalScore}");
        //13565

        Result1 = totalScore.ToString();
    }

    public void ResolvePart2(string arg)
    {
        var lines = File.ReadAllLines(arg);

        //X means you need to lose, Y means you need to end the round in a draw, and Z means you need to win.
        int totalScoreStrat = 0;
        foreach (var line in lines)
        {
            var opMoveLetter = line[0].ToString();
            var opMove = opMoveLetter.GetOpMoveSymbol();
            var matchScoreLetter = line[2].ToString();
            var matchScore = matchScoreLetter.GetGameScore();
            var myMove = matchScore.ComputeMyMove(opMove);
            totalScoreStrat += ComputeMatch(opMove, myMove);
        }
        // System.Console.WriteLine($"totalScoreStrat: {totalScoreStrat}");
        //12424

        Result2 = totalScoreStrat.ToString();
    }

    static int ComputeMatch(GameSymbols opMove, GameSymbols myMove)
    {
        var localScore = 0;
        switch (myMove.GetMatchScore(opMove))
        {
            case GameScore.Win:
                localScore += 6;
                break;
            case GameScore.Draw:
                localScore += 3;
                break;
        }
        localScore += (int)myMove;
        return localScore;
    }
}