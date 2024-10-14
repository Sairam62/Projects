namespace DSA;

public static class Validate
{
    private static List<string> Questions = ["LongestSubArrayWithSumK"];
    public static bool IsQuestionExists(string question)
    {
        return Questions.Contains(question);
    }
}