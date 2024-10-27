namespace DSA;

public static class Validate
{
    private static readonly List<string> Questions = 
    [
        "LongestSubArrayWithSumK",
        "TwoSumArray",
        "SortColours",
        "MajorityElement",
        "MaxSubArray"
    ];
    public static bool IsQuestionExists(string question)
    {
        return Questions.Contains(question);
    }
}