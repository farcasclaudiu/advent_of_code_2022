namespace day07;

public static class GameExtensions
{
    public static bool IsCommand(this string line, out string cmd)
    {
        cmd = "";
        if (line.StartsWith("$"))
        {
            cmd = line.Substring(1).Trim();
        }
        return line.StartsWith("$");
    }
    public static bool IsCommand(this string line)
    {
        return line.StartsWith("$");
    }
    public static bool IsCdRoot(this string cmd)
    {
        var cmdparts = cmd.Split(" ");
        return cmdparts[0] == "cd" &&
            cmdparts[1] == "/";
    }

    public static bool IsCdIn(this string cmd, out string folder)
    {
        var cmdparts = cmd.Split(" ");
        folder = cmdparts[0] == "cd" ? cmdparts[1] : "";
        return cmdparts[0] == "cd" &&
            cmdparts[1] != "/" &&
            cmdparts[1] != "..";
    }

    public static bool IsCdOut(this string cmd)
    {
        var cmdparts = cmd.Split(" ");
        return cmdparts[0] == "cd" &&
            cmdparts[1] == "..";
    }

    public static bool IsLs(this string cmd, int i, ref string[] lines, out List<string> lsResult)
    {
        lsResult = new List<string>();
        while (++i < lines.Length && !lines[i].IsCommand())
        {
            lsResult.Add(lines[i]);
        }
        return cmd == "ls";
    }
}
