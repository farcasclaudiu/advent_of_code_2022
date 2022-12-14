namespace day07;

public class Node
{
    private long size = 0;

    public long Size
    {
        get { return size; }
        set
        {
            if (this.Parent != null)
                this.Parent.Size -= size;
            size = value;
            if (this.Parent != null)
                this.Parent.Size += size;
        }
    }
    public Node Parent { get; set; }
    public List<Node> Childs { get; private set; } = new();
    public NodeType NodeType { get; set; }
    public string Name { get; set; }

    public override string ToString()
    {
        return $"{Enum.GetName(NodeType)} - {FullPath} - {Size}";
    }

    public string FullPath
    {
        get
        {
            if (Parent == null)
            {
                return "/";
            }
            else
            {
                return $"{Parent.FullPath}{Name}/";
            }
        }
    }

}
