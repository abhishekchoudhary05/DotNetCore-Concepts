namespace DotNetCore_Concepts.Questions.Strings
{
    internal static class IsPalindrome
    {
        // Note: This implementation is case-sensitive
        internal static bool IsStringPalindrome(string input)
        {
            ArgumentNullException.ThrowIfNull(input);

            if (input.Length == 0 || input.Length == 1)
                return true;

            int left = 0, right = input.Length - 1;
            while (left < right)
            {
                if (input[left] != input[right])
                    return false;

                left++;
                right--;
            }

            return true;
        }

        // Approach 2 - Case-insensitive (optimized, no temp string)
        // Note: This implementation is case-insensitive
        internal static bool IsStringPalindrome_2(string input)
        {
            ArgumentNullException.ThrowIfNull(input);

            if (input.Length == 0 || input.Length == 1)
                return true;

            int left = 0, right = input.Length - 1;
            while (left < right)
            {
                if (char.ToLower(input[left]) != char.ToLower(input[right]))
                    return false;

                left++;
                right--;
            }

            return true;
        }
    }
}
