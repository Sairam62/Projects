namespace DSA;

/*
Given an integer array of size n, find all elements that appear more than ⌊ n/3 ⌋ times.

Example 1:
    Input: nums = [3,2,3]
    Output: [3]
Example 2:
    Input: nums = [1]
    Output: [1]
Example 3:
    Input: nums = [1,2]
    Output: [1,2]
*/
public class MajorityElementII : BaseQuestion
{
    //Leet Code 229
    public override void Handle()
    {
        int[] array = [3,2,3];
        List<int> res1 = BruteForce(array);
        array = [3,2,3];
        List<int> res2 = Better(array);
        array = [1,2];
        List<int> res3 = Optimal(array);
    }

    private List<int> Optimal(int[] array)
    {
        int cnt1 = 0;
        int cnt2 = 0;
        List<int> res = [];
        int element1 = int.MinValue;
        int element2 = int.MinValue;
        for(int i=0;i<array.Length;i++)
        {
            if(cnt1 == 0 && element2 != array[i])
            {
                cnt1 = 1;
                element1 = array[i];
            }
            else if(cnt2 == 0 && element1 != array[i])
            {
                cnt2 = 1;
                element2 = array[i];
            }
            else if(element1 == array[i])
                cnt1++;
            else if(element2 == array[i])
                cnt2++;
            else
            {
                cnt1--;
                cnt2--;
            }
        }
        cnt1 = 0;cnt2 = 0;
        for(int i=0;i<array.Length;i++)
        {
            if(array[i] == element1)
                cnt1++;
            if(array[i] == element2)
                cnt2++;
        }

        if(cnt1 > array.Length/3)
            res.Add(element1);
        
        if(cnt2 > array.Length/3)
            res.Add(element2);
        
        return res;
    }

    private List<int> Better(int[] nums)
    {
        Array.Sort(nums);
        HashSet<int> map = new HashSet<int>();
        int count = 0;
        int element = 0;
        for(int i=0;i<nums.Length;i++)
        {   
            if(element == nums[i])
                count++;
            else
            {
                count = 1;
                element = nums[i];
            }
            
            if(count > nums.Length/3)
            {
                map.Add(nums[i]);
            }
        }
        return [..map];
    }

    private List<int> BruteForce(int[] nums)
    {
        // Using Dictionary keep track of no times each element is getting repeated.
        Dictionary<int,int> map = new Dictionary<int,int>();

        for(int i=0;i<nums.Length;i++)
        {
            if(map.ContainsKey(nums[i]))
            {
                map[nums[i]]++;
            }
            else
            {
                map[nums[i]]=1;
            }
        }
        List<int> res = new List<int>();
        foreach(var val in map)
        {
            if(val.Value > (nums.Length / 3))
            {
                res.Add(val.Key);
            }
        }
        return res;
    }
}
