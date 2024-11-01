


namespace DSA;

public class PascalTraingle : BaseQuestion
{
    // Leet Code : 118
    public override void Handle()
    {
        int numOfRows = 5;
        var result1 = BruteForceApproach(numOfRows);
        var result2 = Optimal(numOfRows);
    }

    private List<List<int>> Optimal(int numOfRows)
    {
        List<List<int>> res = [];

        for(int i=1;i<=numOfRows;i++)
        {
            res.Add(generateRow(i));
        }

        return res;
    }

    private List<int> generateRow(int i)
    {
        List<int> row = [];
        row.Add(1);
        int ans = 1;
        for(int j=1;j<=i;j++)
        {
            ans *= (i-j);
            ans /= j;
            row.Add(ans);
        }

        return row;
    }

    private List<List<int>> BruteForceApproach(int numOfRows)
    {
        List<List<int>> res = [];
        List<int> prevRow = [];
        for(int i=0;i<numOfRows;i++)
        {
            List<int> row = [];
            for(int j=0;j<=i;j++)
            {
                if(j==0 || j==i)
                {
                    row.Add(1);
                }
                else
                {
                    row.Add(prevRow[j]+prevRow[j-1]);
                }
            }
            prevRow = row;
            res.Add(row);
        }
        return res;
    }
}
