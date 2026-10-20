namespace InterviewPrepration.Questions;

/// <summary>Provides string reversal operations.</summary>
internal static class ReverseStringQuestion
{
    /// <summary>Returns a new string with the input characters in reverse order.</summary>
    internal static string ReverseString(string? str)
    {
        ArgumentNullException.ThrowIfNull(str);

        if (str == string.Empty)
            return string.Empty;

        char[] charArray = str.ToCharArray();
        // Swap matching positions from the outside toward the center.
        for (int i = 0, j = charArray.Length - 1; i < j; i++, j--)
        {
            char temp = charArray[i];
            charArray[i] = charArray[j];
            charArray[j] = temp;
        }

        return new string(charArray);
    }
}
