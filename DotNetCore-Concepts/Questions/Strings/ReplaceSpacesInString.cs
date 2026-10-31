namespace DotNetCore_Concepts.Questions.Strings
{
    internal static class ReplaceSpacesInString
    {
        // time complexicty O(n*m) where n is input length and m is replaceWith length
        // Approach 1
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

        // Approach 2 - In-Place algorithm on character array (Classic URLify two-pointer backwards approach)
        // Time Complexity: O(n * m) where n is trueLength and m is replaceWith length
        // Space Complexity: O(1) auxiliary space (modifies array in-place without allocating a second array)
        internal static int ReplaceSpacesInPlace(char[] characters, int trueLength, string replaceWith)
        {
            ArgumentNullException.ThrowIfNull(characters);
            ArgumentNullException.ThrowIfNull(replaceWith);

            if (trueLength < 0 || trueLength > characters.Length)
                throw new ArgumentOutOfRangeException(nameof(trueLength), "trueLength must be between 0 and characters.Length.");

            int spaceCount = 0;
            for (int i = 0; i < trueLength; i++)
            {
                if (characters[i] == ' ')
                    spaceCount++;
            }

            int newLength = trueLength + spaceCount * (replaceWith.Length - 1);

            if (newLength > characters.Length)
                throw new ArgumentException("The character array does not have sufficient capacity to hold the result.", nameof(characters));

            if (spaceCount == 0)
                return trueLength;

            // When replacing with empty string, shift characters forward
            if (replaceWith.Length == 0)
            {
                int writeIndex = 0;
                for (int readIndex = 0; readIndex < trueLength; readIndex++)
                {
                    if (characters[readIndex] != ' ')
                    {
                        characters[writeIndex++] = characters[readIndex];
                    }
                }
                return newLength;
            }

            // Two-pointer backward fill to prevent overwriting unread characters
            int j = newLength - 1;
            for (int i = trueLength - 1; i >= 0; i--)
            {
                if (characters[i] == ' ')
                {
                    for (int k = replaceWith.Length - 1; k >= 0; k--)
                    {
                        characters[j--] = replaceWith[k];
                    }
                }
                else
                {
                    characters[j--] = characters[i];
                }
            }

            return newLength;
        }

        // Approach 2 (String overload) - In-place using backward two-pointer algorithm on a single buffer
        // Time Complexity: O(n * m) where n is input length and m is replaceWith length
        // Space Complexity: O(n) for the output buffer, avoiding the duplicate intermediate array allocated in Approach 1
        internal static string ReplaceSpacesInStringWithAnother_InPlace(string input, string replaceWith)
        {
            ArgumentNullException.ThrowIfNull(input);
            ArgumentNullException.ThrowIfNull(replaceWith);

            if (input.Length == 0)
                return string.Empty;

            int spaceCount = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == ' ')
                    spaceCount++;
            }

            if (spaceCount == 0)
                return input;

            int newLength = input.Length + spaceCount * (replaceWith.Length - 1);
            char[] buffer = new char[Math.Max(newLength, input.Length)];
            input.CopyTo(0, buffer, 0, input.Length);

            int finalLength = ReplaceSpacesInPlace(buffer, input.Length, replaceWith);

            return new string(buffer, 0, finalLength);
        }
    }
}
