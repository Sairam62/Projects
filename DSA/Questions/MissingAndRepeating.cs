namespace DSA;

public class MissingAndRepeating : BaseQuestion
{
    public override void Handle()
    {
        int[] nums = [4,3,6,2,1,1];
        var res1 = BruteForce(nums);

        nums = [4,3,6,2,1,1];
        var res2 = Optimal(nums);
    }
    // Brute force approach to find the repeating and missing numbers
    private int[] BruteForce(int[] nums)
    {
        // Sort the input array to make it easier to find duplicates and the missing number
        Array.Sort(nums);

        int RNum = 0;  // Variable to store the repeating number
        int Dnum = 0;  // Variable to store the missing number

        // Check if the first number is 1, otherwise, 1 is the missing number
        if (nums[0] != 1)
            Dnum = 1;

        // Loop through the sorted array to find duplicates and gaps between numbers
        for (int i = 1; i < nums.Length; i++)
        {
            // If the current number is the same as the previous, we found a duplicate
            if (nums[i - 1] == nums[i])
                RNum = nums[i - 1];  // Store the repeating number

            // If the previous number and the current number differ by 1, continue
            else if (nums[i - 1] == nums[i] - 1)
                continue;

            // If the previous number and the current number have a gap, we found the missing number
            else
                Dnum = nums[i - 1];  // Store the missing number
        }

        // If no missing number was found in the loop (i.e., Dnum is still 0),
        // that means the missing number is the last one, which is nums.Length
        if (Dnum == 0)
            Dnum = nums.Length;

        // Return the repeating and missing numbers as an array
        return new int[] { RNum, Dnum };
    }

    // Optimal approach to find the repeating and missing numbers using index marking
    private int[] Optimal(int[] nums)
    {
        int repeating = -1;  // Variable to store the repeating number
        int missing = -1;    // Variable to store the missing number

        // First pass: mark the presence of numbers by negating the values at the corresponding indices
        for (int i = 0; i < nums.Length; i++)
        {
            int id = Math.Abs(nums[i]) - 1;  // Get the index corresponding to the absolute value of the current number

            // If the value at the index is positive, negate it to mark it as seen
            if (nums[id] > 0)
                nums[id] = -nums[id];
            else
                // If the value is already negative, it means this number has been encountered before
                // So, it is the repeating number
                repeating = Math.Abs(nums[i]);
        }

        // Second pass: find the missing number by checking for the index with a positive value
        for (int i = 0; i < nums.Length; i++)
        {
            // If the number at the index is still positive, that means the number (i+1) is missing
            if (nums[i] > 0)
            {
                missing = i + 1;  // Store the missing number (1-based index)
                break;  // Exit the loop after finding the missing number
            }
        }

        // Return the repeating and missing numbers as an array
        return new int[] { repeating, missing };
    }

}
