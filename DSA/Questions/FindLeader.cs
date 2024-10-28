namespace DSA;

public class FindLeader : BaseQuestion
{
    //GFG : Array Leaders
    public override void Handle()
    {
        int[] arr = [16, 17, 4, 3, 5, 2];

        List<int> res1 = BruteForce(arr);
        List<int> res2 = Optimal(arr);
    }

    private List<int> Optimal(int[] arr)
    {
        // Initialize a list to store the leaders in the array.
        List<int> res = new List<int>();

        // Set the current leader to the last element of the array.
        // In a right-to-left traversal, the last element is always considered a leader.
        int curLeader = arr[^1];
        
        // Add the last element to the result list as the first leader.
        res.Add(curLeader);

        // Traverse the array from the second last element to the beginning.
        for (int i = arr.Length - 2; i >= 0; i--)
        {
            // If the current element is greater than or equal to the current leader,
            // it becomes the new leader.
            if (arr[i] >= curLeader)
            {
                curLeader = arr[i];
                res.Add(curLeader); // Add the new leader to the result list.
            }
        }

        // Reverse the result list to maintain the original order of leaders as they
        // appear from left to right in the input array.
        res.Reverse();

        // Return the list of leaders.
        return res;
    }


    private List<int> BruteForce(int[] arr)
    {
        List<int> res = [];
        for(int i=0;i<arr.Length-1;i++)
        {
            bool isLeader = true;

            for(int j=i+1;j<arr.Length;j++)
            {
                if(arr[i] < arr[j])
                {
                    isLeader = false;
                }
            }

            if(isLeader)
            {
                res.Add(arr[i]);
            }
        }
        res.Add(arr[^1]);
        return res;
    }
}
