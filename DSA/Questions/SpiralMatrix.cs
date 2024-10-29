
namespace DSA;

//Leet Code : 54
public class SpiralMatrix : BaseQuestion
{
    public override void Handle()
    {
        int[][] mat = [[1,2,3],[4,5,6],[7,8,9]];
        List<int> res = Approach(mat);

        //TC : O(m x n)
        //SC : O(n)

        foreach(int val in res)
        {
            Console.WriteLine(val);
        }
    }

    private List<int> Approach(int[][] matrix)
    {
        List<int> res = []; // Initialize a list to store the spiral order result
        int left = 0; // Starting column index
        int top = 0;  // Starting row index
        int right = matrix[0].Length - 1; // Ending column index
        int bottom = matrix.Length - 1;    // Ending row index

        // Continue until all boundaries are crossed
        while (left <= right && top <= bottom)
        {
            // Traverse from Left to Right across the top row
            for (int i = left; i <= right; i++)
                res.Add(matrix[top][i]);
            top++; // Move the top boundary down

            // Traverse from Top to Bottom along the right column
            for (int i = top; i <= bottom; i++)
                res.Add(matrix[i][right]);
            right--; // Move the right boundary left

            // Traverse from Right to Left across the bottom row (if there are rows left)
            if (bottom >= top)
            {
                for (int i = right; i >= left; i--)
                    res.Add(matrix[bottom][i]);
                bottom--; // Move the bottom boundary up
            }

            // Traverse from Bottom to Top along the left column (if there are columns left)
            if (left <= right)
            {
                for (int i = bottom; i >= top; i--)
                    res.Add(matrix[i][left]);
                left++; // Move the left boundary right
            }
        }

        return res; // Return the list containing elements in spiral order

    }
}
