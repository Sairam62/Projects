
namespace DSA;

public class RearrangeArray : BaseQuestion
{
    public override void Handle()
    {
        // LeetCode 2149
        int[] arr = [3,1,-2,-5,2,-4];
        Varient1(arr);
        Varient2(arr);
    }

    private void Varient2(int[] arr)
    {
        int[] res = new int[arr.Length];
        int posI = 0;
        int negI = 1;
        for(int i=0;i<arr.Length;i++)
        {
            if(arr[i] < 0)
            {
                res[negI]=arr[i];
                negI+=2;
            }
            else
            {
                res[posI]=arr[i];
                posI+=2;
            }
        }

        //Checking array
        foreach(int x in res)
        {
            Console.WriteLine(x);
        }
    }

    private void Varient1(int[] arr)
    {
        //Diving to two parts
        int[] posArray=new int[arr.Length/2];
        int[] negArray=new int[arr.Length/2];
        int posI = 0;
        int negI = 0;
        for(int i=0;i<arr.Length;i++)
        {
            if(arr[i] < 0)
            {
                negArray[negI]=arr[i];
                negI++;
                //push to -ve array
            }
            else
            {
                posArray[posI]=arr[i];
                posI++;
                //push to +ve array
            }
        }
        for(int i=0;i<arr.Length;i+=2)
        {
            arr[i]=posArray[i/2];
            arr[i+1]=negArray[i/2];
        }

        //Checking Array
        for(int i=0;i<arr.Length;i++)
        {
            Console.WriteLine(arr[i]);
        }
    }
}
