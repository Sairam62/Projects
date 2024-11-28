using System.Text;

namespace DSA;

public class EncodeDecodeString : BaseQuestion
{
    public override void Handle()
    {
        List<string> strs = ["neet","code","love","you"];

        string key = Encode(strs);
        List<string> values = Decode(key);
    }

    private string Encode(List<string> strs)
    {
        StringBuilder sb = new();

        sb.Append(strs[0]);
        for(int i=1;i<strs.Count;i++)
        {
            sb.Append(':');
            sb.Append(strs[i]);
        }
        return sb.ToString();
    }

    private List<string> Decode(string key)
    {
        return [.. key.Split(':')];
    }
}