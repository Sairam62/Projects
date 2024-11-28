namespace DSA
{
    public class CountReversePairs : BaseQuestion
    {
        public override void Handle()
        {
            // Test array for counting reverse pairs
            int[] nums = {1, 3, 2, 3, 1};

            // Brute force solution to count reverse pairs
            int res1 = BruteForce(nums);

            // Optimal solution using Merge Sort to count reverse pairs
            nums = new int[] {1, 3, 2, 3, 1};  // Reinitialize nums for optimal solution
            int res2 = Optimal(nums);

            // Check if both solutions give the same result
            if (res1 == res2)
                Console.WriteLine("TRUE");
            else
                Console.WriteLine("FALSE");
        }

        // Optimal solution using Merge Sort
        private int Optimal(int[] nums)
        {
            // Calling MergeSort to count reverse pairs in the array
            return MergeSort(nums, 0, nums.Length - 1);
        }

        // Merge Sort function to count reverse pairs
        private int MergeSort(int[] nums, int low, int high)
        {
            int cnt = 0;
            if (low >= high)
                return cnt;  // Base case: if low >= high, no reverse pairs to count

            // Find the middle index to divide the array into two halves
            int mid = (low + high) / 2;

            // Recursively sort the left half and count reverse pairs
            cnt += MergeSort(nums, low, mid);

            // Recursively sort the right half and count reverse pairs
            cnt += MergeSort(nums, mid + 1, high);

            // Count reverse pairs in the merged array and merge the two halves
            cnt += Merge(nums, low, mid, high);

            // Return the total count of reverse pairs
            return cnt;
        }

        // Merge function to merge two sorted halves and count reverse pairs
        private int Merge(int[] nums, int low, int mid, int high)
        {
            int cnt = 0;  // Initialize the count of reverse pairs during the merge process

            // Temporary array to store merged results
            int[] temp = new int[high - low + 1];
            int k = 0;

            // Count reverse pairs: (i, j) where i < j and nums[i] > 2 * nums[j]
            int left = low;       // Start of the left subarray
            int right = mid + 1;  // Start of the right subarray

            // This loop checks for reverse pairs where nums[left] > 2 * nums[right]
            // It is done before the actual merging of the two sorted halves
            for (left = low; left <= mid; left++)
            {
                // Move the 'right' pointer to the right position where nums[left] > 2 * nums[right]
                // We're trying to find all pairs (left, right) such that nums[left] > 2 * nums[right]
                while (right <= high && nums[left] > 2 * nums[right])
                {
                    right++;  // Move right pointer to the right while condition holds
                }

                // The number of valid reverse pairs for the current left element is the difference
                // between the current value of right and the start of the right subarray (mid + 1)
                // All elements from right to high are valid pairs with nums[left]
                cnt += right - (mid + 1);  // **Increment the count of reverse pairs**
            }

            // Reset left and right pointers to begin the actual merge process
            left = low;
            right = mid + 1;

            // Merge the two sorted subarrays into the temporary array
            while (left <= mid && right <= high)
            {
                if (nums[left] <= nums[right])
                {
                    temp[k++] = nums[left];  // Add smaller element from the left subarray to temp
                    left++;
                }
                else
                {
                    temp[k++] = nums[right];  // Add smaller element from the right subarray to temp
                    right++;
                }
            }

            // If there are remaining elements in the left subarray, add them to temp
            while (left <= mid)
            {
                temp[k++] = nums[left];
                left++;
            }

            // If there are remaining elements in the right subarray, add them to temp
            while (right <= high)
            {
                temp[k++] = nums[right];
                right++;
            }

            // Copy the merged results back into the original array
            for (int i = low; i <= high; i++)
            {
                nums[i] = temp[i - low];
            }

            // Return the count of reverse pairs found during the merge process
            return cnt;
        }

        // Brute force solution: Check every pair of elements and count valid reverse pairs
        private int BruteForce(int[] nums)
        {
            int cnt = 0;
            // Loop through every element
            for (int i = 0; i < nums.Length; i++)
            {
                // Compare with every subsequent element
                for (int j = i + 1; j < nums.Length; j++)
                {
                    // Check if the reverse pair condition holds: nums[i] > 2 * nums[j]
                    if (nums[i] > 2 * nums[j])
                    {
                        cnt++;  // **Increment count for valid reverse pair**
                    }
                }
            }
            return cnt;  // Return the total count of reverse pairs found
        }
    }
}