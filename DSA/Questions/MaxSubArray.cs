
namespace DSA;

public class MaxSubArray : BaseQuestion
{
    public override void Handle()
    {
        int[] arr = [-2,1,-3,4,-1,2,1,-5,4];

        BruteForce(arr);
        Optimal(arr);
        OptimalWithIndices(arr);
    }

    private void OptimalWithIndices(int[] arr)
    {
        //Sliding Window
        int maxSum = arr[0];
        int curSum = 0;
        int left = 0;
        int right = 0;
        for(int i=0;i<arr.Length;i++)
        {
            if(curSum < 0)
            {
                curSum = 0;
                left = i;
            }
            curSum += arr[i];
            if(maxSum < curSum)
            {
                maxSum = curSum;
                right = i;
            }
        }
        Console.WriteLine("left : "+left+", right : "+right);
    }

    private void Optimal(int[] arr)
    {
        //Kadane's Algorithm
        int maxSum = arr[0];
        int curSum = 0;
        for(int i=0;i<arr.Length;i++)
        {
            curSum = Math.Max(0,curSum);
            curSum += arr[i];
            maxSum = Math.Max(maxSum,curSum);
        }
        Console.WriteLine(maxSum);
    }

    private void BruteForce(int[] arr)
    {
        int maxSum = arr[0];
        int curSum;
        for(int i=0;i<arr.Length;i++)
        {
            curSum=0;
            for(int j=i;j<arr.Length;j++)
            {
                curSum += arr[j];
                maxSum = Math.Max(maxSum,curSum);
            }
        }
        Console.WriteLine(maxSum);
    }
}
