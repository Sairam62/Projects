
using System.Buffers;

namespace DSA;

public class SortColours : BaseQuestion
{
    public override void Handle()
    {
        int[] arr = [0,2,1,2,1,0,2];

        BetterUsingExtensionMethod(arr);
        Better(arr);
        Optimal(arr);
    }

    private void Optimal(int[] arr)
    {
        int low=0;
        int mid=0;
        int high=arr.Length-1;
        while(mid<=high)
        {
            if(arr[mid]==0)
            {
                (arr[low], arr[mid]) = (arr[mid], arr[low]);
                low++;
                mid++;
            }
            else if(arr[mid]==1)
            {
                mid++;
            }
            else
            {
                (arr[mid],arr[high]) = (arr[high],arr[mid]);
                high--;
            }
        }
    }

    private void Better(int[] arr)
    {
        int count_0 = 0;
        int count_1 = 0;
        for(int i=0;i<arr.Length;i++)
        {
            if(arr[i] == 0)
            {
                count_0++;
            }
            else if(arr[i] == 1)
            {
                count_1++;
            }
        }
        for(int i=0;i<arr.Length;i++)
        {
            if(i < count_0)
            {
                arr[i]=0;
            }
            else if(i < count_0 + count_1)
            {
                arr[i]=1;
            }
            else
            {
                arr[i]=2;
            }
        }
    }

    private void BetterUsingExtensionMethod(int[] arr)
    {
        Array.Sort(arr);
    }
}
