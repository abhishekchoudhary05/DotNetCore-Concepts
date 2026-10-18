namespace InterviewPrepration.Questions;

internal static class ReverseStringInPlaceQuestion
{
    internal static char[] ReverString_InPlace(char[] charArray)
    {
        if (charArray.Length <= 1)
            return charArray;

        for (int i = 0, j = charArray.Length - 1; i < j; i++, j--)
        {
            char temp = charArray[i];
            charArray[i] = charArray[j];
            charArray[j] = temp;
        }
        return charArray;
    }
}
