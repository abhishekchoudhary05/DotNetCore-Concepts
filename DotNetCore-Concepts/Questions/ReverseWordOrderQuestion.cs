using System.Text;

namespace InterviewPrepration.Questions;

/// <summary>Contains a routine for reversing the order of space-delimited words.</summary>
internal static class ReverseWordOrderQuestion
{
    /// <summary>Writes the words from right to left while preserving their character order.</summary>
    internal static void ReverseWordOrder(string str)
    {
        int i;
        StringBuilder reverseSentence = new StringBuilder();

        int Start = str.Length - 1;
        int End = str.Length - 1;

        while (Start > 0)
        {
            if (str[Start] == ' ')
            {
                // Copy the word after this separator before moving the end boundary left.
                i = Start + 1;
                while (i <= End)
                {
                    reverseSentence.Append(str[i]);
                    i++;
                }
                reverseSentence.Append(' ');
                End = Start - 1;
            }
            Start--;
        }

        for (i = 0; i <= End; i++)
        {
            reverseSentence.Append(str[i]);
        }
        Console.WriteLine(reverseSentence.ToString());
    }
}
