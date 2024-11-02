
namespace DSA;

public class ThreeSum:BaseQuestion
{
    //Leet Code : 15
    public override void Handle()
    {
        int[] nums = [-1,0,1,2,-1,-4];
        var res1 = BruteForce(nums);
        var res2 = Better(nums);
        var res3 = Optimal(nums);
    }
    // Optimal approach using sorting and two-pointer technique for finding unique triplets that sum to zero.
    private IList<IList<int>> Optimal(int[] nums)
    {
        // Sort the array to enable two-pointer approach and easy duplicate handling
        Array.Sort(nums);
        IList<IList<int>> res = new List<IList<int>>();

        // Iterate through each element, treating it as the first element in the triplet
        for (int i = 0; i < nums.Length; i++)
        {
            // Skip duplicate elements to avoid duplicate triplets in the result
            if (i != 0 && nums[i] == nums[i - 1]) continue;

            // Initialize two pointers: one at the next element and one at the end
            int j = i + 1;
            int k = nums.Length - 1;

            // Use two-pointer technique to find pairs that sum with nums[i] to zero
            while (j < k)
            {
                int sum = nums[i] + nums[j] + nums[k];

                // If the sum is greater than zero, move the end pointer leftward to reduce the sum
                if (sum > 0)
                    k--;
                // If the sum is less than zero, move the start pointer rightward to increase the sum
                else if (sum < 0)
                    j++;
                // If a zero-sum triplet is found, add it to the result
                else
                {
                    List<int> row = new List<int> { nums[i], nums[j], nums[k] };
                    res.Add(row);

                    // Move both pointers to find the next possible triplet
                    j++;
                    k--;

                    // Skip duplicate elements to avoid duplicate triplets in the result
                    while (j < k && nums[j] == nums[j - 1]) j++;
                    while (j < k && nums[k] == nums[k + 1]) k--;
                }
            }
        }

        return res;
    }

    // Better approach using HashSet to check for existing third element in O(1) time, avoiding triplets duplication.
    private IList<IList<int>> Better(int[] nums)
    {
        IList<IList<int>> res = new List<IList<int>>();
        HashSet<string> map = new HashSet<string>(); // To store unique triplets as strings

        // Iterate through each element as the first element in a triplet
        for (int i = 0; i < nums.Length; i++)
        {
            // HashSet to keep track of elements we've seen in the inner loop
            HashSet<int> track = new HashSet<int>();

            // Inner loop to find pairs that sum with nums[i] to zero
            for (int j = i + 1; j < nums.Length; j++)
            {
                // Calculate the third element needed to form a zero-sum triplet
                int third = -(nums[i] + nums[j]);

                // Check if the third element exists in the set (indicating a valid triplet)
                if (track.Contains(third))
                {
                    // Sort the triplet to ensure consistency and add to the result
                    List<int> row = new List<int> { nums[i], nums[j], third };
                    row.Sort();

                    // Convert triplet to string to store uniquely in the map
                    string key = string.Join(",", row);
                    map.Add(key);
                }
                else
                    track.Add(nums[j]); // Add current element to set for future lookups
            }
        }

        // Convert each unique triplet in map back to list form and add to result
        foreach (string key in map)
        {
            List<int> triplet = key.Split(',').Select(int.Parse).ToList();
            res.Add(triplet);
        }

        return res;
    }

    // Brute-force approach with three nested loops to find all possible triplets that sum to zero, 
    // checking each combination.
    private IList<IList<int>> BruteForce(int[] nums)
    {
        IList<IList<int>> res = new List<IList<int>>();
        HashSet<string> map = new HashSet<string>(); // To store unique triplets as strings

        // Triple nested loop to evaluate every possible combination of triplets
        for (int i = 0; i < nums.Length; i++)
        {
            for (int j = i + 1; j < nums.Length; j++)
            {
                for (int k = j + 1; k < nums.Length; k++)
                {
                    // Check if the current triplet sums to zero
                    if (nums[i] + nums[j] + nums[k] == 0)
                    {
                        // Sort the triplet to ensure consistency and add to the result
                        List<int> row = new List<int> { nums[i], nums[j], nums[k] };
                        row.Sort();

                        // Convert triplet to string to store uniquely in the map
                        string key = string.Join(",", row);
                        map.Add(key);
                    }
                }
            }
        }

        // Convert each unique triplet in map back to list form and add to result
        foreach (string key in map)
        {
            List<int> triplet = key.Split(',').Select(int.Parse).ToList();
            res.Add(triplet);
        }

        return res;
    }

}