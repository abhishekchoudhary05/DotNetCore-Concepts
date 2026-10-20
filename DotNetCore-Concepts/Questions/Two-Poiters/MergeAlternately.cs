namespace DotNetCore_Concepts.Questions.Two_Poiters;

/// <summary>Combines two strings by alternating their characters.</summary>
internal static class MergeAlternately
{
    /// <summary>Appends one character from each input while either has characters left.</summary>
    public static string Merge(string word1, string word2)
    {
        char[] result = new char[word1.Length + word2.Length];
        int i = 0;
        int j = 0;
        int k = 0;
        // Each input advances independently, so the remaining suffix of a longer word is preserved.
        while (i < word1.Length || j < word2.Length)
        {
            if (i < word1.Length)
            {
                result[k] = word1[i];
                i++;
                k++;
            }
            if (j < word2.Length)
            {
                result[k] = word2[j];
                j++;
                k++;
            }
        }
        return new string(result);
    }
}
