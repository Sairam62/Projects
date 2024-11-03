
namespace DSA;

public class MergeIntervals : BaseQuestion
{
    // Leet Code : 56
    public override void Handle()
    {
        int[][] arr = [[1,3],[2,6],[8,10],[15,18]];
        int[][] res2 = Optimal(arr);
    }

    private int[][] Optimal(int[][] intervals)
    {
        // Sort intervals based on the starting value
        Array.Sort(intervals, (a, b) => a[0].CompareTo(b[0]));

        // Initialize start and end with the first interval's boundaries
        int start = intervals[0][0];
        int end = intervals[0][1];
        
        // Use List<int[]> for storing merged intervals directly to reduce conversions
        List<int[]> res = [];

        for (int i = 1; i < intervals.Length; i++) {
            // If there is overlap with the current interval
            if (intervals[i][0] <= end) {
                // Merge by extending the 'end' boundary
                end = Math.Max(end, intervals[i][1]);
            } else {
                // No overlap, add the previous interval and reset start and end
                res.Add([start, end]);
                start = intervals[i][0];
                end = intervals[i][1];
            }
        }

        // Add the last interval after the loop
        res.Add([start, end]);

        // Convert List<int[]> to int[][]
        return [.. res];
    }

}
