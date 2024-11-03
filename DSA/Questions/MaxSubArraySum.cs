namespace DSA;

public class MaxSubArraySum : BaseQuestion
{
    //GFG : Largest subarray with 0 sum
    public override void Handle()
    {
        int[] arr = [15, -2, 2, -8, 1, 7, 10, 23];
        BruteForce(arr);
        Optimal(arr);
    }

    // BruteForce approach to find the maximum length of a subarray with a sum of zero.
    private void BruteForce(int[] arr)
    {
        int len = 0; // To store the maximum length of subarrays with sum zero

        // Outer loop to pick the starting point of each subarray
        for (int i = 0; i < arr.Length; i++)
        {
            int sum = arr[i]; // Initialize sum with the starting element

            // Inner loop to extend the subarray and calculate sum incrementally
            for (int j = i + 1; j < arr.Length; j++)
            {
                sum += arr[j]; // Add the current element to the sum

                // If a subarray with a sum of zero is found, update the maximum length
                if (sum == 0)
                    len = Math.Max(len, j - i + 1);
            }
        }

        Console.WriteLine(len); // Print the maximum length found
    }

    // Optimal approach to find the maximum length of a subarray with a sum of zero.
    // This approach uses a HashMap (Dictionary) to store cumulative sums and their indices for efficient lookup.
    private void Optimal(int[] arr)
    {
        Dictionary<int, int> map = new Dictionary<int, int>(); // To store cumulative sum and index
        int len = 0; // To store the maximum length of subarrays with sum zero
        int sum = 0; // To keep track of cumulative sum

        // Traverse each element of the array and maintain the cumulative sum
        for (int i = 0; i < arr.Length; i++)
        {
            sum += arr[i]; // Add the current element to cumulative sum

            // If cumulative sum is zero, update the maximum length as (i + 1)
            if (sum == 0)
                len = i + 1;
            // If cumulative sum is found in the map, calculate the subarray length and update maximum length
            else if (map.ContainsKey(sum))
                len = Math.Max(len, i - map[sum]);
            // Otherwise, add the cumulative sum and index to the map
            else
                map[sum] = i;
        }

        Console.WriteLine(len); // Print the maximum length found
    }
}
