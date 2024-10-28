
namespace DSA;

//Leet Code : 128
public class LongestConsecutiveSequence : BaseQuestion
{
    public override void Handle()
    {
        int[] arr = [100,4,200,1,3,2];

        Better(arr);
        Optimal(arr);
    }

    private void Optimal(int[] nums)
    {
        if (nums.Length == 0) {
            Console.WriteLine(0);
        }

        // Step 1: Insert all numbers into a HashSet for O(1) lookups.
        HashSet<int> numSet = new(nums);
        int maxStreak = 0;

        // Step 2: Iterate through each number in the array.
        foreach (int num in nums) {
            // Check if it is the start of a sequence.
            if (!numSet.Contains(num - 1)) {
                // This means 'num' is the start of a sequence.
                int currentNum = num;
                int currentStreak = 1;

                // Count the length of the consecutive sequence.
                while (numSet.Contains(currentNum + 1)) {
                    currentNum++;
                    currentStreak++;
                }

                // Update the maximum streak length.
                maxStreak = Math.Max(maxStreak, currentStreak);
            }
        }

        Console.WriteLine(maxStreak);
    }

    private void Better(int[] nums)
    {
        //Using Sorting
        if(nums.Length == 0 || nums.Length == 1)
        {
            Console.WriteLine(nums.Length);
        }
        Array.Sort(nums);
        int streak = 1;
        int maxStreak = 1;
        for(int i=0;i<nums.Length-1;i++)
        {
            if((nums[i]<nums[i+1] && nums[i+1]==nums[i]+1))
                streak++;
            else if(nums[i]==nums[i+1])
                continue;
            else
                streak=1;

            maxStreak = Math.Max(maxStreak,streak);
        }
        Console.WriteLine(maxStreak);
    }
}
