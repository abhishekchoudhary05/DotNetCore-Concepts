namespace InterviewPrepration.Questions;

internal static class ReverseStringQuestion
{
    internal static string ReverseString(string? str)
    {
        ArgumentNullException.ThrowIfNull(str);

        if (str == string.Empty)
            return string.Empty;

        char[] charArray = str.ToCharArray();
        for (int i = 0, j = charArray.Length - 1; i < j; i++, j--)
        {
            char temp = charArray[i];
            charArray[i] = charArray[j];
            charArray[j] = temp;
        }

        return new string(charArray);
    }
}
