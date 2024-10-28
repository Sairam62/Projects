namespace DSA;

public class AllPermutations : BaseQuestion
{
    public override void Handle()
    {
        findPermutations();
    }

    private void findPermutations()
    {
        int index = 0;
        List<List<int>> res = [];
        int[] arr = [1,2,3];
        recursivePermutations(index,arr,res);
        Optimal(arr);
    }

    private void Optimal(int[] arr)
    {
        int breakPoint = -1;

        // Step 1: Find the rightmost element that is smaller than the element next to it.
        // This is known as the "breakpoint." We start from the second last element
        // and move towards the left.
        for (int i = arr.Length - 2; i >= 0; i--)
        {
            if (arr[i] < arr[i + 1])
            {
                breakPoint = i;
                break; // Found the breakpoint, exit the loop.
            }
        }

        // Step 2: If no breakpoint is found, then the array is in descending order,
        // which means we are at the last permutation.
        // To get the next permutation, reverse the array to get the smallest permutation.
        if (breakPoint == -1)
        {
            Array.Reverse(arr);
            return; // Exit after reversing, as no further steps are needed.
        }

        // Step 3: Find the rightmost element that is greater than the element at the breakpoint.
        // This will be the element to swap with the element at the breakpoint.
        for (int i = arr.Length - 1; i > breakPoint; i--)
        {
            if (arr[i] > arr[breakPoint])
            {
                // Swap the elements at the breakpoint and the found element.
                (arr[breakPoint], arr[i]) = (arr[i], arr[breakPoint]);
                break;
            }
        }

        // Step 4: Reverse the elements to the right of the breakpoint.
        // This ensures that we get the smallest lexicographical order for the new permutation.
        Array.Reverse(arr, breakPoint + 1, arr.Length - 1 - breakPoint);
    }


    private void recursivePermutations(int index, int[] arr,List<List<int>> res)
    {
        if(index == arr.Length)
        {
            List<int> data = [];
            for(int i=0;i<arr.Length;i++)
            {
                data.Add(arr[i]);
            }
            res.Add(data);
            return;
        }   
        for(int i=index;i<arr.Length;i++)
        {
            (arr[index],arr[i])=(arr[i],arr[index]); //Swap
            recursivePermutations(index+1,arr,res);
            (arr[index],arr[i])=(arr[i],arr[index]); //Undoing-Swap
        }
    }
}
