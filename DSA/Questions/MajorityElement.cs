
namespace DSA;

public class MajorityElement : BaseQuestion
{
    public override void Handle()
    {
        int[] arr = [2,2,1,1,1,2,2];

        int btr = Better(arr);
        int opt = Optimal(arr);
    }

    private int Optimal(int[] arr)
    {
        int count=0;
        int element = 0;
        for(int i=0;i<arr.Length;i++)
        {
            if(count==0)
                element = arr[i];
            else if(element == arr[i])
                count++;
            else
                count--;
        }
        count=0;
        for(int i=0;i<arr.Length;i++)
        {
            if(arr[i]==element)
                count++;
        }
        if(count > arr.Length/2)
            return element;
        return -1;
    }

    private int Better(int[] arr)
    {
        // Using Dictionary

        Dictionary<int,int> dict = [];

        for(int i=0;i<arr.Length;i++)
        {
            if(dict.TryGetValue(arr[i], out int value))
            {
                dict[arr[i]] = ++value;
            }
            else
            {
                dict[arr[i]]=1;
            }
        }

        foreach(var item in dict)
        {
            if(item.Value > arr.Length/2)
            {
                return item.Key;
            }
        }
        return 0;
    }
}
