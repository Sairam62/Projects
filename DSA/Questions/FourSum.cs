namespace DSA;

public class FourSum : BaseQuestion
{
    //Leet Code : 18
    public override void Handle()
    {
        int[] nums = {1, 0, -1, 0, -2, 2};
        int target = 0;
        var res1 = BruteForce(nums, target);
        var res2 = Better(nums, target);
        var res3 = Optimal(nums, target);
    }

    // Optimal approach using sorting and two-pointer technique to find unique quadruplets summing to the target.
    private IList<IList<int>> Optimal(int[] nums, int target)
    {
        IList<IList<int>> res = new List<IList<int>>();

        // Early exit if input length is insufficient to form a quadruplet
        if (nums.Length < 4)
        {
            return res;
        }

        // Sort the array for easier duplicate handling and two-pointer usage
        Array.Sort(nums);

        // Loop to fix the first two numbers of the quadruplet
        for (int i = 0; i < nums.Length; i++)
        {
            // Avoid duplicates for the first element
            if (i > 0 && nums[i] == nums[i - 1]) continue;

            for (int j = i + 1; j < nums.Length; j++)
            {
                // Avoid duplicates for the second element
                if (j > i + 1 && nums[j] == nums[j - 1]) continue;

                int k = j + 1;                  // Third pointer
                int l = nums.Length - 1;        // Fourth pointer

                // Use two-pointer technique to find pairs that add up to the target with nums[i] and nums[j]
                while (k < l)
                {
                    long sum = (long)nums[i] + (long)nums[j] + (long)nums[k] + (long)nums[l];

                    // Move the pointers based on the comparison with the target
                    if (sum > target)
                        l--;
                    else if (sum < target)
                        k++;
                    else
                    {
                        // Add the quadruplet if the sum matches the target
                        res.Add(new List<int> { nums[i], nums[j], nums[k], nums[l] });
                        k++;
                        l--;

                        // Skip duplicates for the third and fourth elements
                        while (k < l && nums[k] == nums[k - 1]) k++;
                        while (k < l && nums[l] == nums[l + 1]) l--;
                    }
                }
            }
        }

        return res;
    }

    // Improved approach using HashSet to track pairs that sum to a specific value,
    // avoiding duplicates by using unique strings for each quadruplet.
    private IList<IList<int>> Better(int[] nums, int target)
    {
        IList<IList<int>> res = new List<IList<int>>();

        // Early exit if input length is insufficient to form a quadruplet
        if (nums.Length < 4)
        {
            return res;
        }

        HashSet<string> map = new HashSet<string>();

        // Nested loops to fix the first three elements of the quadruplet
        for (int i = 0; i < nums.Length; i++)
        {
            for (int j = i + 1; j < nums.Length; j++)
            {
                HashSet<long> track = new HashSet<long>();

                // Loop to find the fourth element such that the sum equals the target
                for (int k = j + 1; k < nums.Length; k++)
                {
                    long Fourth = (long)target - (long)nums[i] - (long)nums[j] - (long)nums[k];

                    // Check if Fourth element is already in the HashSet (indicating a valid quadruplet)
                    if (track.Contains(Fourth))
                    {
                        // Store the quadruplet in sorted order to handle duplicates
                        List<int> row = new List<int> { nums[i], nums[j], nums[k], (int)Fourth };
                        row.Sort();

                        // Convert quadruplet to a unique string and add to map
                        string key = string.Join(",", row);
                        map.Add(key);
                    }
                    else
                    {
                        track.Add(nums[k]); // Track current element for future lookups
                    }
                }
            }
        }

        // Convert each unique quadruplet in the map back to list form and add to result
        foreach (string key in map)
        {
            res.Add(key.Split(',').Select(int.Parse).ToList());
        }

        return res;
    }

    // Brute-force approach using four nested loops to check all quadruplet combinations,
    // storing unique quadruplets as strings in a HashSet to avoid duplicates.
    private IList<IList<int>> BruteForce(int[] nums, int target)
    {
        IList<IList<int>> res = new List<IList<int>>();

        // Early exit if input length is insufficient to form a quadruplet
        if (nums.Length < 4)
        {
            return res;
        }

        HashSet<string> set = new HashSet<string>();

        // Nested loops to evaluate all possible quadruplet combinations
        for (int i = 0; i < nums.Length; i++)
        {
            for (int j = i + 1; j < nums.Length; j++)
            {
                for (int k = j + 1; k < nums.Length; k++)
                {
                    for (int l = k + 1; l < nums.Length; l++)
                    {
                        // Check if the quadruplet sums to the target
                        if (nums[i] + nums[j] + nums[k] + nums[l] == target)
                        {
                            // Store quadruplet in sorted order to handle duplicates
                            List<int> row = new List<int> { nums[i], nums[j], nums[k], nums[l] };
                            row.Sort();

                            // Convert quadruplet to a unique string and add to set
                            string key = string.Join(",", row);
                            set.Add(key);
                        }
                    }
                }
            }
        }

        // Convert each unique quadruplet in the set back to list form and add to result
        foreach (string key in set)
        {
            res.Add(key.Split(',').Select(int.Parse).ToList());
        }

        return res;
    }
}