namespace day07;
public class Problem
{
    public string Result1 { get; set; }
    public string Result2 { get; set; }

    private List<Node> allFolders = new List<Node>();

    public void ResolvePart1(string arg)
    {
        var lines = File.ReadAllLines(arg);

        var currentPath = "";

        Node root = null;
        Node currentNode = null;


        for (int i = 0; i < lines.Length; i++)
        {
            var line = lines[i];
            string cmd;
            List<string> lsResult;
            if (line.IsCommand(out cmd))
            {
                string folderIn = "";
                if (cmd.IsCdRoot())
                {
                    currentPath = "/";
                    if (root == null)
                    {
                        root = new Node()
                        {
                            Name = "/",
                            NodeType = NodeType.Directory
                        };
                    }
                    currentNode = root;
                    if (!allFolders.Contains(root))
                    {
                        allFolders.Add(root);
                    }
                }
                else if (cmd.IsCdIn(out folderIn))
                {
                    currentNode = currentNode.Childs.Find(x => x.Name == folderIn);
                }
                else if (cmd.IsCdOut())
                {
                    currentNode = currentNode.Parent;
                }
                else if (cmd.IsLs(i, ref lines, out lsResult))
                {
                    i += lsResult.Count;
                    foreach (var result in lsResult)
                    {
                        var entryParts = result.Split(" ");
                        var nodeEntry = new Node
                        {
                            NodeType = entryParts[0] == "dir" ? NodeType.Directory : NodeType.File,
                            Name = entryParts[1],
                            Parent = currentNode
                        };
                        currentNode.Childs.Add(nodeEntry);
                        nodeEntry.Size = entryParts[0] != "dir" ? long.Parse(entryParts[0]) : 0;
                        //
                        if (nodeEntry.NodeType == NodeType.Directory)
                        {
                            if (!allFolders.Contains(nodeEntry))
                            {
                                allFolders.Add(nodeEntry);
                            }
                        }
                    }
                    i--;
                }
            }
        }

        //
        var sum1 = allFolders.Where(x => (x.Size <= 100000))
            .Sum(x => x.Size);
        // System.Console.WriteLine(sum1);
        //95437
        //1206825

        Result1 = sum1.ToString();
    }

    public void ResolvePart2(string arg)
    {
        ResolvePart1(arg);

        var theroot = allFolders.Find(x => x.Parent == null);
        var diskSize = 70000000;
        var neededSpace = 30000000;
        var currentSpace = diskSize - theroot.Size;
        // System.Console.WriteLine(currentSpace);
        var extraNeededSpace = neededSpace - currentSpace;
        // System.Console.WriteLine(extraNeededSpace);
        var pickedDirectoryForDelete = allFolders
            .Where(x => x.Size >= extraNeededSpace)
            .OrderBy(x => x.Size)
            .First();
        // System.Console.WriteLine(pickedDirectoryForDelete);
        //24933642
        //9608311


        Result2 = pickedDirectoryForDelete.Size.ToString();
    }
}
