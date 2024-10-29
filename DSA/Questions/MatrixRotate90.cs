
namespace DSA;

public class MatrixRotate90 : BaseQuestion
{
    public override void Handle()
    {
        int[][] matrix1 = [[1,2,3],[4,5,6],[7,8,9]];
        int[][] matrix2 = [[1,2,3],[4,5,6],[7,8,9]];
        BruteForce(matrix1);
        Optimal(matrix2);
    }

    private void Optimal(int[][] matrix)
    {
        // Step 1: Transpose the Matrix
        // This step converts rows into columns and vice versa.
        for (int i = 0; i < matrix.Length; i++)
        {
            // Start j from i + 1 to avoid swapping elements back and forth.
            // By setting j = i + 1, we only swap elements above the main diagonal.
            for (int j = i + 1; j < matrix.Length; j++)
            {
                // Swap elements across the diagonal to transpose the matrix
                (matrix[j][i], matrix[i][j]) = (matrix[i][j], matrix[j][i]);
            }
        }

        // Step 2: Reverse Each Row
        // This step reverses each row in the transposed matrix to complete the 90-degree clockwise rotation.
        for (int i = 0; i < matrix.Length; i++)
        {
            // Reverse each row by swapping elements from the start to the midpoint of the row.
            // By iterating only to matrix.Length / 2, we swap the elements on the left with those on the right.
            for (int j = 0; j < matrix.Length / 2; j++)
            {
                // Swap elements in each row to reverse it
                (matrix[i][matrix.Length - 1 - j], matrix[i][j]) = (matrix[i][j], matrix[i][matrix.Length - 1 - j]);
            }
        }
    }

    private void BruteForce(int[][] matrix)
    {
        // Assuming 'matrix' is the original jagged array
        int[][] newMatrix = new int[matrix.Length][];

        // Step 1: Perform a deep copy of each row to create an independent 'newMatrix'
        for (int i = 0; i < matrix.Length; i++)
        {
            // Allocate a new array for each row in 'newMatrix' with the same length as the row in 'matrix'
            newMatrix[i] = new int[matrix[i].Length];
            
            // Copy each element from the original 'matrix' row to the 'newMatrix' row
            for (int j = 0; j < matrix[i].Length; j++)
            {
                newMatrix[i][j] = matrix[i][j];
            }
        }

        // Step 2: Rotate 'newMatrix' by 90 degrees clockwise into 'matrix'
        for (int i = 0; i < newMatrix.Length; i++)
        {
            for (int j = 0; j < newMatrix[i].Length; j++)
            {
                // Set each element in 'matrix' to the rotated position from 'newMatrix'
                // The element in position (i, j) in 'newMatrix' moves to (j, newMatrix.Length - 1 - i) in 'matrix'
                matrix[j][newMatrix.Length - 1 - i] = newMatrix[i][j];
            }
        }

    }
}
