
namespace DSA;

public class TwoSumArray : BaseQuestion
{
    public override void Handle()
    {
        int[] arr = [2,7,11,15];
        int req = 9;
        int[] result = TwoSum(arr,req);
    }

    private int[] TwoSum(int[] arr, int req)
    {
        // Idea is to create a dictionary with req-arr[i]
        // If any arr[i] present in dictionary then i and dictionary value is the required answer.
        int rem = 0;
        Dictionary<int,int> map = [];
        for(int i=0;i<arr.Length;i++)
        {
            rem = req - arr[i];

            if(map.TryGetValue(rem, out int value))
            {
                return [value, i];
            }
            else{
                map[arr[i]]=i;
            }
        }

        return [];
    }
}