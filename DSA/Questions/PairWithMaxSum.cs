
namespace DSA;

public class PairWithMaxSum : BaseQuestion
{
    public override void Handle()
    {
        int[] nums = [4, 3, 1, 5, 6];
        BruteForce(nums);
    }

    private void BruteForce(int[] nums)
    {
        int maxScore = 0;
        for(int i=0;i<nums.Length;i++)
        {
            for(int j=i+1;j<nums.Length;j++)
            {
                int firstMin = int.MaxValue;
                int secondMin = int.MaxValue;
                for(int k=i;k<=j;k++)
                {
                    if(nums[k] < firstMin)
                    {
                        secondMin=firstMin;
                        firstMin=nums[k];
                    }
                    else if(nums[k] < secondMin)
                    {
                        secondMin = nums[k];
                    }
                }
                int currentScore = firstMin+secondMin;
                maxScore = Math.Max(maxScore,currentScore);
            }
        }
        Console.WriteLine(maxScore);
    }
}
