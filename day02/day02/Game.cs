namespace day02;

public static class Game
{
    public static GameSymbols GetOpMoveSymbol(this string opMoveLetter)
    {
        return opMoveLetter switch
        {
            "A" => GameSymbols.Rock,
            "B" => GameSymbols.Paper,
            "C" => GameSymbols.Scissor,
            _ => throw new ArgumentOutOfRangeException(nameof(opMoveLetter), $"Not expected opMoveLetter value: {opMoveLetter}")
        };
    }

    public static GameSymbols GetMyMoveSymbol(this string myMoveLetter)
    {
        return myMoveLetter switch
        {
            "X" => GameSymbols.Rock,
            "Y" => GameSymbols.Paper,
            "Z" => GameSymbols.Scissor,
            _ => throw new ArgumentOutOfRangeException(nameof(myMoveLetter), $"Not expected myMoveLetter value: {myMoveLetter}")
        };
    }

    public static GameScore GetGameScore(this string gameScoreLetter)
    {
        //X means you need to lose, Y means you need to end the round in a draw, and Z means you need to win.
        return gameScoreLetter switch
        {
            "X" => GameScore.Loss,
            "Y" => GameScore.Draw,
            "Z" => GameScore.Win,
            _ => throw new ArgumentOutOfRangeException(nameof(gameScoreLetter), $"Not expected gameScoreLetter value: {gameScoreLetter}")
        };
    }

    public static GameScore GetMatchScore(this GameSymbols myMove, GameSymbols opMove)
    {
        if (myMove == opMove)
        {
            return GameScore.Draw;
        }
        if ((myMove == GameSymbols.Rock && opMove == GameSymbols.Scissor) ||
            (myMove == GameSymbols.Paper && opMove == GameSymbols.Rock) ||
            (myMove == GameSymbols.Scissor && opMove == GameSymbols.Paper))
        {
            return GameScore.Win;
        }
        return GameScore.Loss;
    }

    public static GameSymbols ComputeMyMove(this GameScore gameScore, GameSymbols opMove)
    {
        return gameScore switch
        {
            GameScore.Win => opMove.GetWinSymbol(),
            GameScore.Draw => opMove,
            GameScore.Loss => opMove.GetLossSymbol(),
        };
    }

    public static GameSymbols GetWinSymbol(this GameSymbols opMove)
    {
        return opMove switch
        {
            GameSymbols.Rock => GameSymbols.Paper,
            GameSymbols.Scissor => GameSymbols.Rock,
            GameSymbols.Paper => GameSymbols.Scissor
        };
    }
    public static GameSymbols GetLossSymbol(this GameSymbols opMove)
    {
        return opMove switch
        {
            GameSymbols.Rock => GameSymbols.Scissor,
            GameSymbols.Scissor => GameSymbols.Paper,
            GameSymbols.Paper => GameSymbols.Rock
        };
    }
}