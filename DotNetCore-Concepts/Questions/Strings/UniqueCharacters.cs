namespace DotNetCore_Concepts.Questions.Strings
{
    internal static class UniqueCharacters
    {
        // Approach 1
        internal static bool IsStringContainsUniqueCharacters(string input)
        {
            ArgumentNullException.ThrowIfNull(input);

            if (input.Length == 0 || input.Length == 1)
                return true;

            for (int i = 0; i < input.Length - 1; i++)
            {
                for (int j = i + 1; j < input.Length; j++)
                {
                    if (input[i] == input[j])
                        return false;
                }
            }

            return true;
        }

        // Approach 2
        internal static bool IsStringContainsUniqueCharacters_2(string input)
        {
            ArgumentNullException.ThrowIfNull(input);

            if (input.Length == 0 || input.Length == 1)
                return true;

            HashSet<char> characters = new HashSet<char>();

            for (int i = 0; i < input.Length; i++)
            {
                if (characters.Contains(input[i]))
                    return false;
                else
                    characters.Add(input[i]);
            }

            return true;
        }
    }
}
