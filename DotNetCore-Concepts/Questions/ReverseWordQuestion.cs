using System.Text;

namespace InterviewPrepration.Questions;

internal static class ReverseWordQuestion
{
    internal static void ReverseWord(string str)
    {
        // "Welcome to Csharp corner",  "Welcome", "     "

        ArgumentNullException.ThrowIfNull(str);

        int startIndex = 0;
        int lastIndex = 0;
        StringBuilder reverseWords = new StringBuilder(string.Empty);

        while (startIndex < str.Length)
        {
            if (str[startIndex] == ' ')
            {
                int j = startIndex - 1;
                while (j >= lastIndex)
                {
                    reverseWords.Append(str[j]);
                    j--;
                }
                reverseWords.Append(' ');
                lastIndex = startIndex + 1;
            }
            startIndex++;
        }
        while (lastIndex < startIndex)
        {
            reverseWords.Append(str[lastIndex]);
            lastIndex++;
        }

        Console.WriteLine(reverseWords.ToString());
    }
}
