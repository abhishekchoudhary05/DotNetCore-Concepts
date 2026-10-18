using System.Text;

namespace InterviewPrepration.Questions;

internal static class ReverseWordOrderQuestion
{
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
