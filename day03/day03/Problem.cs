namespace day03;
public class Problem
{
    public string Result1 { get; set; }
    public string Result2 { get; set; }

    public void ResolvePart1(string arg)
    {
        var lines = File.ReadAllLines(arg);

        var totalScore = 0;
        foreach (var line in lines)
        {
            var linecontent = line.Trim();
            // System.Console.WriteLine(linecontent);
            var h1 = linecontent.Substring(0, linecontent.Length / 2);
            var h2 = linecontent.Substring(linecontent.Length / 2, linecontent.Length / 2);
            var commonLetter = h1.Intersect(h2).First();
            // System.Console.WriteLine(commonLetter);
            var score = ConvertLetterToScore(commonLetter);
            // System.Console.WriteLine(score);
            totalScore += score;
        }

        // System.Console.WriteLine(totalScore);
        //8153
        Result1 = totalScore.ToString();
    }

    public void ResolvePart2(string arg)
    {
        var lines = File.ReadAllLines(arg);

        var totalScore = 0;
        var groupNo = lines.Length / 3;
        for (int i = 0; i < groupNo; i++)
        {
            var elf1 = lines[i * 3 + 0];
            var elf2 = lines[i * 3 + 1];
            var elf3 = lines[i * 3 + 2];
            var groupLetter = elf1.Intersect(elf2).Intersect(elf3).First();
            // System.Console.WriteLine(groupLetter);
            var score = ConvertLetterToScore(groupLetter);
            // System.Console.WriteLine(score);
            totalScore += score;
        }

        // System.Console.WriteLine(totalScore);
        //2342
        Result2 = totalScore.ToString();
    }

    public static int ConvertLetterToScore(char letter)
    {
        var score = 0;
        if (letter >= 'a' && letter <= 'z')
        {
            var baseLower = (int)'a';
            score = letter - baseLower + 1;
        }
        else if (letter >= 'A' && letter <= 'Z')
        {
            var baseLower = (int)'A';
            score = letter - baseLower + 27;
        }
        return score;
    }
}