namespace DSA;

public class LongestSubArrayWithSumK:BaseQuestion
{
    public override void Handle()
    {
        int n = 18;
        int[] arr = [7,4,-17,-13,-15,1,16,7,16,-15,-7,-7,-18,19,11,-13,10,-16];
        int k = 30;

        Better(A:arr,N:n,K:k);
        Optimal(A:arr,N:n,K:k);
    }

    private void Optimal(int[] A, int N, int K)
    {
        //Two Pointer Approach
        int left = 0,right = 0;
        int curSum = 0;
        int maxLen = 0;
        while(right < N){
            curSum += A[right];
            while(curSum > K && left <= right){
                curSum -= A[left];
                left++;
            }
            if(curSum == K){
                maxLen = Math.Max(maxLen,right-left+1);
            }
            right++;
        }
        Console.WriteLine(maxLen);
    }

    private void Better(int[] A, int N, int K)
    {
        Dictionary<long,int> map = [];
        int maxLen = 0;
        int curSum = 0;

        for(int i=0;i<N;i++){
            curSum += A[i];
            if(curSum == K){
                maxLen = i+1;
            }
            if(map.ContainsKey(curSum-K)){
                maxLen = Math.Max(maxLen,i-map[curSum-K]);
            }
            if(!map.ContainsKey(curSum)){
                map[curSum]=i;
            }
        }

        Console.WriteLine(maxLen);
    }
}