using System.Text;

namespace InterviewPrepration.Questions;

/// <summary>Contains a routine for reversing the characters of each space-delimited word.</summary>
internal static class ReverseWordQuestion
{
    /// <summary>Writes the input with each word's characters reversed and word positions preserved.</summary>
    internal static void ReverseWord(string str)
    {
        ArgumentNullException.ThrowIfNull(str);

        int startIndex = 0;
        int lastIndex = 0;
        StringBuilder reverseWords = new StringBuilder(string.Empty);

        while (startIndex < str.Length)
        {
            if (str[startIndex] == ' ')
            {
                // A space closes the preceding word; copy that word backward, then keep the separator.
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
