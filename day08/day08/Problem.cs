namespace day08;
public class Problem
{
    public string Result1 { get; set; }
    public string Result2 { get; set; }

    public void ResolvePart1(string arg)
    {
        var lines = File.ReadAllLines(arg);

        var nrLines = lines.Length;
        var nrColumns = lines[0].Length;
        var visibleTrees = 0;
        visibleTrees += 4;//corners
        HashSet<(int, int)> innerTrees = new();

        //scan lines
        for (int i = 1; i < nrLines - 1; i++)
        {
            visibleTrees += 2;
            var start = int.Parse(lines[i][0].ToString());
            var end = int.Parse(lines[i][nrColumns - 1].ToString());

            //start to end
            for (int j = 1; j < nrColumns - 1; j++)
            {
                var currentValue = int.Parse(lines[i][j].ToString());
                if (currentValue > start)
                {
                    innerTrees.Add(new(i, j));
                    start = currentValue;
                }
            }
            //end to start
            for (int j = nrColumns - 2; j > 0; j--)
            {
                var currentValue = int.Parse(lines[i][j].ToString());
                if (currentValue > end)
                {
                    innerTrees.Add(new(i, j));
                    end = currentValue;
                }
            }
        }

        //scan columns
        for (int i = 1; i < nrColumns - 1; i++)
        {
            visibleTrees += 2;
            var start = int.Parse(lines[0][i].ToString());
            var end = int.Parse(lines[nrLines - 1][i].ToString());

            //start to end
            for (int j = 1; j < nrLines - 1; j++)
            {
                var currentValue = int.Parse(lines[j][i].ToString());
                if (currentValue > start)
                {
                    innerTrees.Add(new(j, i));
                    start = currentValue;
                }
            }
            //end to start
            for (int j = nrLines - 2; j > 0; j--)
            {
                var currentValue = int.Parse(lines[j][i].ToString());
                if (currentValue > end)
                {
                    innerTrees.Add(new(j, i));
                    end = currentValue;
                }
            }
        }

        visibleTrees += innerTrees.Count;
        // System.Console.WriteLine(visibleTrees);


        Result1 = visibleTrees.ToString();
    }

    public void ResolvePart2(string arg)
    {
        var lines = File.ReadAllLines(arg);

        var nrLines = lines.Length;
        var nrColumns = lines[0].Length;

        // PART 2 - using matrix
        //populate
        var martrix = new int[nrLines, nrColumns];
        for (int i = 0; i < nrLines; i++)
        {
            for (int j = 0; j < nrColumns; j++)
            {
                martrix[i, j] = int.Parse(lines[i][j].ToString());
            }
        }
        //scan inner tree score
        var maxCellScore = 0;
        for (int i = 1; i < nrLines - 1; i++)
        {
            for (int j = 1; j < nrColumns - 1; j++)
            {
                if (i == 3 && j == 2)
                    System.Diagnostics.Debugger.Break();

                var currentValue = martrix[i, j];
                //scan up
                var scoreUp = 0;
                for (int up = i - 1; up >= 0; up--)
                {
                    var testValue = martrix[up, j];
                    scoreUp++;
                    if (testValue >= currentValue)
                    {
                        break;
                    }
                }
                //scan down
                var scoreDown = 0;
                for (int down = i + 1; down < nrLines; down++)
                {
                    var testValue = martrix[down, j];
                    scoreDown++;
                    if (testValue >= currentValue)
                    {
                        break;
                    }
                }
                //scan left
                var scoreLeft = 0;
                for (int left = j - 1; left >= 0; left--)
                {
                    var testValue = martrix[i, left];
                    scoreLeft++;
                    if (testValue >= currentValue)
                    {
                        break;
                    }
                }
                //scan right
                var scoreRight = 0;
                for (int right = j + 1; right < nrColumns; right++)
                {
                    var testValue = martrix[i, right];
                    scoreRight++;
                    if (testValue >= currentValue)
                    {
                        break;
                    }
                }

                var cellScore = scoreUp * scoreDown * scoreLeft * scoreRight;
                maxCellScore = Math.Max(cellScore, maxCellScore);
            }
        }
        // System.Console.WriteLine($"maxCellScore: {maxCellScore}");
        //8
        //327180 - PERFECT!

        Result2 = maxCellScore.ToString();
    }
}
