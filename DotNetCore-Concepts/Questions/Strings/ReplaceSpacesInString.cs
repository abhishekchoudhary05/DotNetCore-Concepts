namespace DotNetCore_Concepts.Questions.Strings
{
    internal static class ReplaceSpacesInString
    {
        // time complexicty O(n*m) where n is input length and m is replaceWith length
        internal static string ReplaceSpacesInStringWithAnother(string input, string replaceWith)
        {
            ArgumentNullException.ThrowIfNull(input);
            ArgumentNullException.ThrowIfNull(replaceWith);

            char[] characters = input.ToCharArray();
            int spaceCount = 0;

            for (int i = 0; i < characters.Length; i++)
            {
                if (characters[i] == ' ')
                    spaceCount++;
            }

            char[] result = new char[characters.Length + spaceCount * (replaceWith.Length - 1)];

            int j = 0;
            for (int i = 0; i < characters.Length; i++)
            {
                if (characters[i] == ' ')
                {
                    for (int k = 0; k < replaceWith.Length; k++)
                    {
                        result[j] = replaceWith[k];
                        j++;
                    }
                }
                else
                {
                    result[j] = characters[i];
                    j++;
                }
            }

            return new string(result);
        }
    }
}
