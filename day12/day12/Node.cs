namespace day12;

using FastGraph;
using FastGraph.Algorithms;

public class Node
{
    private Node() { }

    public static AdjacencyGraph<Node, TaggedEdge<Node, string>>
        graph = new FastGraph.AdjacencyGraph<Node, TaggedEdge<Node, string>>();

    public static void InitGraph()
    {
        graph = new FastGraph.AdjacencyGraph<Node, TaggedEdge<Node, string>>();
        AllNodes.Clear();
    }

    public static List<Node> AllNodes = new();
    public static Node Create(int x, int y, string value)
    {
        var node = new Node
        {
            X = x,
            Y = y,
            Value = value
        };
        AllNodes.Add(node);

        //add vertex to graph
        graph.AddVertex(node);

        return node;
    }
    public int X { get; set; }
    public int Y { get; set; }
    public string Value { get; set; }
    public List<Node> Vertices { get; set; } = new List<Node>();

    private bool IsFilled = false;

    public void AddVertices(string[] lines)
    {
        if (IsFilled)
            return;
        // System.Console.WriteLine($"node: {X} - {Y}");
        TryAddVertice(lines, Value, X - 1, Y);
        TryAddVertice(lines, Value, X + 1, Y);
        TryAddVertice(lines, Value, X, Y - 1);
        TryAddVertice(lines, Value, X, Y + 1);
        IsFilled = true;
        foreach (var vertice in Vertices)
        {
            vertice.AddVertices(lines);
        }
    }

    private void TryAddVertice(string[] lines, string currentValue, int chkX, int chkY)
    {
        if (chkX < 0 || chkY < 0 || chkY > lines.Length - 1 || chkX > lines[0].Length - 1)
            return;

        if (
            (lines[chkY][chkX] >= 'a' && //Value[0] - 1 &&
            lines[chkY][chkX] <= (Value[0] + 1)) ||
            (lines[chkY][chkX] == 'E' && 'z' >= Value[0] - 1 && 'z' <= Value[0] + 1))
        {
            var existNode = AllNodes.FirstOrDefault(n => n.X == chkX && n.Y == chkY);
            if (existNode == null)
            {
                //create node
                var chkNode = Node.Create(chkX, chkY, lines[chkY][chkX].ToString());
                Vertices.Add(chkNode);
                // System.Console.WriteLine($"add vertice {chkX} - {chkY} : {lines[chkY][chkX].ToString()}");
                // add edge to graph
                var edge1 = new TaggedEdge<Node, string>(this, chkNode, "create hello");
                graph.AddEdge(edge1);
            }
            else
            {
                //reuse node - link
                if (!Vertices.Contains(existNode))
                {
                    Vertices.Add(existNode);
                    //link
                    // System.Console.WriteLine($"link vertice {chkX} - {chkY} : {lines[chkY][chkX].ToString()}");
                    // add edge to graph
                    var edge1 = new TaggedEdge<Node, string>(this, existNode, "link hello");
                    graph.AddEdge(edge1);
                }
            }
        }
    }

    public override string ToString()
    {
        return $"N:{X}-{Y}:{Value}";
    }
}
