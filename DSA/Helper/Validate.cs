namespace DSA;

public static class Validate
{
    private static readonly List<string> Questions = 
    [
        "LongestSubArrayWithSumK",
        "TwoSumArray"
    ];
    public static bool IsQuestionExists(string question)
    {
        return Questions.Contains(question);
    }
}