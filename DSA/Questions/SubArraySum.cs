
namespace DSA;

public class SubArraySum : BaseQuestion
{
    // Leet Code 560
    public override void Handle()
    {
        int[] nums = [1,2,3];
        int k = 3;

        Optimal(nums,k);
    }

    private void Optimal(int[] nums, int k)
    {
        Dictionary<int, int> mpp = []; // Dictionary to store prefix sums
        int preSum = 0, cnt = 0;

        mpp[0] = 1; // Initialize with sum 0

        for (int i = 0; i < nums.Length; i++)
        {
            // Add current element to prefix sum
            preSum += nums[i];

            // Calculate the difference (preSum - k)
            int remove = preSum - k;

            // Check if this difference exists in the map
            if (mpp.ContainsKey(remove))
                cnt += mpp[remove];

            // Update the count of prefix sum in the dictionary
            if (mpp.ContainsKey(preSum))
                mpp[preSum]++;
            else
                mpp[preSum] = 1;
        }
    }
}
