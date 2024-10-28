

namespace DSA;

public class SetMatrixZeroes : BaseQuestion
{
    //LeetCode : 73
    public override void Handle()
    {
        int[][] matrix1 = [[1,1,1],[1,0,1],[1,1,1]];
        int[][] matrix2 = [[1,1,1],[1,0,1],[1,1,1]];
        Approach1(matrix1);
        Approach2(matrix2);
    }
    // Approach 2: Using Constant Space
    private void Approach2(int[][] matrix)
    {
        // Flag to indicate if the first column should be set to zero.
        bool col0 = false;

        // Step 1: Traverse the matrix to mark rows and columns that need to be set to zero.
        for (int i = 0; i < matrix.Length; i++)
        {
            for (int j = 0; j < matrix[0].Length; j++)
            {
                // If a cell is zero, mark the corresponding row and column.
                if (matrix[i][j] == 0)
                {
                    matrix[i][0] = 0; // Mark the start of the row.

                    if (j != 0)
                        matrix[0][j] = 0; // Mark the start of the column (only if it's not the first column).
                    else
                        col0 = true; // If the zero is in the first column, set col0 flag.
                }
            }
        }

        // Step 2: Set matrix elements to zero based on marks in the first row and column.
        for (int i = 1; i < matrix.Length; i++)
        {
            for (int j = 1; j < matrix[0].Length; j++)
            {
                // If the row or column is marked with zero, set the cell to zero.
                if (matrix[i][0] == 0 || matrix[0][j] == 0)
                {
                    matrix[i][j] = 0;
                }
            }
        }

        // Step 3: If the first row was marked, set the entire first row to zero.
        if (matrix[0][0] == 0)
        {
            for (int j = 0; j < matrix[0].Length; j++)
            {
                matrix[0][j] = 0;
            }
        }

        // Step 4: If col0 was marked, set the entire first column to zero.
        if (col0)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i][0] = 0;
            }
        }
    }
    // Approach 1: Using Extra Space
    private void Approach1(int[][] matrix)
    {
        // Lists to store rows and columns that need to be zeroed.
        List<int> row = new List<int>();
        List<int> column = new List<int>();

        // Step 1: Identify the rows and columns to be zeroed.
        for (int i = 0; i < matrix.Length; i++)
        {
            for (int j = 0; j < matrix[0].Length; j++)
            {
                // If a zero is found, add the row and column indices to the lists.
                if (matrix[i][j] == 0)
                {
                    row.Add(i);
                    column.Add(j);
                }
            }
        }

        // Step 2: Set the identified rows and columns to zero.
        for (int i = 0; i < matrix.Length; i++)
        {
            for (int j = 0; j < matrix[0].Length; j++)
            {
                // If the current row or column is in the list, set the cell to zero.
                if (row.Contains(i) || column.Contains(j))
                {
                    matrix[i][j] = 0;
                }
            }
        }
    }
}
