namespace day13;

using System.Text.Json;

public class Message
{
    protected Message() { }
    public List<Message> Values { get; set; } = new List<Message>();
    public int Value { get; set; }
    public bool IsList { get; set; }
    public string StringValue { get; private set; }

    public static Message CreateFromJsonElement(JsonElement jsonEl)
    {
        var result = new Message();
        if (jsonEl.ValueKind == JsonValueKind.Array)
        {
            result.IsList = true;
            var arr = jsonEl.EnumerateArray().ToArray();
            foreach (var item in arr)
            {
                result.Values.Add(CreateFromJsonElement(item));
            }
        }
        else if (jsonEl.ValueKind == JsonValueKind.Number)
        {
            result.IsList = false;
            result.Value = jsonEl.GetInt32();
        }
        return result;
    }
    public static Message Create(string msg)
    {
        var jsonElement = (JsonElement)JsonSerializer.Deserialize<object>(msg);

        var result = CreateFromJsonElement(jsonElement);
        result.StringValue = msg;
        return result;
    }

    public int Compare(Message other)
    {
        if (!this.IsList && !other.IsList)
        {
            //numeric comparison
            return this.Value.CompareTo(other.Value);
        }
        else if (this.IsList && !other.IsList)
        {
            //first is list
            var secList = new Message
            {
                IsList = true
            };
            secList.Values.Add(other);
            return this.Compare(secList);
        }
        else if (!this.IsList && other.IsList)
        {
            //second is list
            var firstList = new Message
            {
                IsList = true
            };
            firstList.Values.Add(this);
            return firstList.Compare(other);
        }
        else if (this.IsList && other.IsList)
        {
            //both are list
            var thisCount = this.Values.Count;
            var otherCount = other.Values.Count;
            for (int i = 0; i < Math.Min(thisCount, otherCount); i++)
            {
                var localComp = this.Values[i].Compare(other.Values[i]);
                if (localComp != 0)
                {
                    return localComp;
                }
            }
            return thisCount.CompareTo(otherCount);
        }
        throw new NotSupportedException("situation impossible");
    }

    public override string ToString()
    {
        return StringValue;
    }
}