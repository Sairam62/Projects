
namespace DSA;

public class MergeSortedArrays : BaseQuestion
{
    // Leet Code : 88
    public override void Handle()
    {
        int[] arr1 = [1,2,3,0,0,0];
        int m = 3; //Length of non zero elements in num 1
        int[] arr2 = [2,5,6];
        int n = 3; //Length of non zero elements in num 2
        BruteForce(arr1,m,arr2,n);
        arr1 = [1,2,3,0,0,0];
        Optimal(arr1,m,arr2,n);
    }

    private void Optimal(int[] nums1, int m, int[] nums2, int n)
    {
        // Start filling from the last index of nums1
        int p1 = m - 1; // Last index of the valid elements in nums1
        int p2 = n - 1; // Last index of nums2
        int p = m + n - 1; // Last index of nums1

        // Merge nums1 and nums2 from the back
        while (p1 >= 0 && p2 >= 0) {
            if (nums1[p1] > nums2[p2]) {
                nums1[p] = nums1[p1];
                p1--;
            } else {
                nums1[p] = nums2[p2];
                p2--;
            }
            p--;
        }

        // If there are remaining elements in nums2, copy them
        while (p2 >= 0) {
            nums1[p] = nums2[p2];
            p2--;
            p--;
        }
    }

    private void BruteForce(int[] nums1,int m, int[] nums2,int n)
    {
        int i = 0;
        int j = 0;
        List<int> res = [];
        while(i<nums1.Length && j<nums2.Length)
        {
            if(nums1[i] == 0)
                i++;
            else if(nums1[i] <= nums2[j])
            {
                res.Add(nums1[i]);
                i++;
            }
            else
            {
                res.Add(nums2[j]);
                j++;
            }
        }

        while(i<nums1.Length && nums1[i] != 0)
        {
            res.Add(nums1[i]);
            i++;
        }

        while(j<nums2.Length)
        {
            res.Add(nums2[j]);
            j++;
        }
        nums1 = [.. res];
    }
}
