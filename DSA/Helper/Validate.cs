namespace DSA;

public static class Validate
{
    private static readonly List<string> Questions = 
    [
        "LongestSubArrayWithSumK",
        "TwoSumArray",
        "SortColours",
        "MajorityElement",
        "MaxSubArray",
        "PairWithMaxSum",
        "StocksBuySell",
        "RearrangeArray",
        "AllPermutations",
        "FindLeader",
        "LongestConsecutiveSequence",
        "SetMatrixZeroes",
        "MatrixRotate90",
        "SpiralMatrix",
        "SubArraySum",
        "PascalTraingle",
        "MajorityElementII"
    ];
    public static bool IsQuestionExists(string question)
    {
        return Questions.Contains(question);
    }
}