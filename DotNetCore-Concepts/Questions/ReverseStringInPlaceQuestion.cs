namespace InterviewPrepration.Questions;

/// <summary>Provides an in-place reversal operation for character arrays.</summary>
internal static class ReverseStringInPlaceQuestion
{
    /// <summary>Reverses and returns the supplied array by swapping its outer pairs.</summary>
    internal static char[] ReverString_InPlace(char[] charArray)
    {
        if (charArray.Length <= 1)
            return charArray;

        // The two indices converge, so each pair is swapped exactly once.
        for (int i = 0, j = charArray.Length - 1; i < j; i++, j--)
        {
            char temp = charArray[i];
            charArray[i] = charArray[j];
            charArray[j] = temp;
        }
        return charArray;
    }
}
