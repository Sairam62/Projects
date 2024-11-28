namespace DSA
{
    public class CountInversions : BaseQuestion
    {
        public override void Handle()
        {
            // Test case 1: Use brute force to count inversions
            int[] nums = [2, 4, 1, 3, 5];
            int res1 = BruteForce(nums);

            // Test case 2: Use optimal approach (Merge Sort) to count inversions
            nums = [2, 4, 1, 3, 5];
            int res2 = Optimal(nums);

            // Compare the results of brute force and optimal solution
            if (res1 == res2)
                Console.WriteLine("TRUE");  // Both methods gave the same result
            else
                Console.WriteLine("FALSE"); // The results don't match (this should not happen if both methods are correct)
        }

        // Brute force approach: Count inversions by checking each pair (O(n^2) time complexity)
        private int BruteForce(int[] nums)
        {
            int cnt = 0;
            // Compare each element with every other element to count inversions
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] > nums[j])  // If an element at i is greater than an element at j, it's an inversion
                        cnt++;
                }
            }
            return cnt;
        }

        // Optimal approach: Use Merge Sort to count inversions (O(n log n) time complexity)
        private int Optimal(int[] nums)
        {
            // Call the MergeSort method to count inversions
            return MergeSort(nums, 0, nums.Length - 1);
        }

        // MergeSort function: This is the recursive function that sorts the array and counts inversions
        private int MergeSort(int[] nums, int low, int high)
        {
            int cnt = 0;

            // Base case: If the subarray has one or no elements, no inversions
            if (low >= high) return cnt;

            // Find the middle point to divide the array into two halves
            int mid = (low + high) / 2;

            // Recursively sort and count inversions in the left half
            cnt += MergeSort(nums, low, mid);

            // Recursively sort and count inversions in the right half
            cnt += MergeSort(nums, mid + 1, high);

            // Merge the two sorted halves and count the cross inversions
            cnt += Merge(nums, low, mid, high);

            return cnt;
        }

        // Merge function: This function merges two sorted halves and counts inversions
        private int Merge(int[] nums, int low, int mid, int high)
        {
            List<int> temp = new List<int>();  // Temporary list to store the merged array
            int left = low;  // Pointer for the left half of the array
            int right = mid + 1;  // Pointer for the right half of the array
            int cnt = 0;  // Variable to count inversions during the merge

            // Merge the two sorted halves
            while (left <= mid && right <= high)
            {
                if (nums[left] <= nums[right])
                {
                    temp.Add(nums[left]);  // Add the smaller element from the left half
                    left++;
                }
                else
                {
                    // Count the inversions:
                    // If nums[left] > nums[right], then all elements from nums[left] to nums[mid] 
                    // are greater than nums[right] because both halves are sorted.
                    cnt += mid - left + 1;

                    // Add the element from the right half
                    temp.Add(nums[right]);
                    right++;
                }
            }

            // Add any remaining elements from the left half (if any)
            while (left <= mid)
            {
                temp.Add(nums[left]);
                left++;
            }

            // Add any remaining elements from the right half (if any)
            while (right <= high)
            {
                temp.Add(nums[right]);
                right++;
            }

            // Copy the merged elements back into the original array
            for (int i = low; i <= high; i++)
            {
                nums[i] = temp[i - low];
            }

            return cnt;  // Return the count of inversions found during the merge
        }
    }
}