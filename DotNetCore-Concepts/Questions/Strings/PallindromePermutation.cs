namespace DotNetCore_Concepts.Questions.Strings
{
    /// <summary>
    /// PallindromePermutation class finds all permutations of a string that form palindromes.
    /// 
    /// Problem: Given a string, find all permutations that are palindromes.
    /// Example: "aab" → ["aba"]
    /// Example: "aabb" → ["abba", "baab"]
    /// 
    /// Key Insight: A string can form a palindrome if and only if:
    ///   - At most ONE character has an odd frequency
    ///   - All other characters have even frequencies
    /// 
    /// Time Complexity:
    ///   Approach 1 (Brute Force): O(n! * n) - generate all permutations then filter
    ///   Approach 2 (Optimized): O(n) validation + O(n! * n) generation (only if valid)
    /// 
    /// Space Complexity: O(n) for character frequency map, O(n! * n) for results
    /// </summary>
    internal static class PallindromePermutation
    {
        /// <summary>
        /// APPROACH 1 (Brute Force): Generate all permutations then filter palindromes.
        /// 
        /// Algorithm:
        /// 1. Generate all permutations of the input string
        /// 2. Check each permutation if it's a palindrome
        /// 3. Collect only the palindromic permutations
        /// 
        /// Note: Inefficient for longer strings as it generates unnecessary permutations.
        /// </summary>
        /// <param name="input">The input string</param>
        /// <returns>List of all permutations that are palindromes</returns>
        internal static List<string> FindPallindromePermutation(string input)
        {
            if (string.IsNullOrEmpty(input))
                return [];

            // Generate all permutations
            List<string> allPermutations = Permutation.FindAllPermutation(input);
            List<string> result = new List<string>();

            // Filter only palindromic permutations
            foreach (var permutation in allPermutations)
            {
                if (IsPalindrome.IsStringPalindrome_2(permutation))
                    result.Add(permutation);
            }

            return result;
        }

        /// <summary>
        /// APPROACH 2 (Optimized): Check if palindrome is possible FIRST, then generate.
        /// 
        /// Algorithm:
        /// 1. Count character frequencies
        /// 2. Check if a palindrome permutation is possible:
        ///    - At most 1 character can have odd frequency
        /// 3. If yes, generate permutations and filter (all will be palindromes)
        /// 4. If no, return empty list immediately
        /// 
        /// This avoids generating permutations for strings that cannot form palindromes.
        /// Much more efficient for large strings.
        /// </summary>
        /// <param name="input">The input string</param>
        /// <returns>List of all permutations that are palindromes</returns>
        internal static List<string> FindPallindromePermutationOptimized(string input)
        {
            if (string.IsNullOrEmpty(input))
                return [];

            // Step 1: Count character frequencies
            Dictionary<char, int> charFreq = new Dictionary<char, int>();
            foreach (char c in input)
            {
                if (charFreq.ContainsKey(c))
                    charFreq[c]++;
                else
                    charFreq[c] = 1;
            }

            // Step 2: Check if palindrome permutation is possible
            // A valid palindrome permutation has at most 1 character with odd frequency
            int oddCount = 0;
            foreach (var freq in charFreq.Values)
            {
                if (freq % 2 == 1)
                    oddCount++;
            }

            // Cannot form palindrome if more than 1 character has odd frequency
            if (oddCount > 1)
                return [];

            // Step 3: If valid, generate all permutations and collect palindromes
            List<string> allPermutations = Permutation.FindAllPermutation(input);
            List<string> result = new List<string>();

            foreach (var permutation in allPermutations)
            {
                if (IsPalindrome.IsStringPalindrome_2(permutation))
                    result.Add(permutation);
            }

            return result;
        }

        /// <summary>
        /// Helper method to check if a string can form a palindrome permutation.
        /// 
        /// Algorithm: Count characters with odd frequencies.
        /// A palindrome permutation is possible iff at most 1 character has odd frequency.
        /// </summary>
        /// <param name="input">The input string</param>
        /// <returns>True if a palindrome permutation can be formed, false otherwise</returns>
        /// <example>
        /// CanFormPalindromePermutation("aab") → true (only 'a' has odd count=2? No, both even)
        /// CanFormPalindromePermutation("aabbcc") → true (all even frequencies)
        /// CanFormPalindromePermutation("abc") → false (all 3 have odd count=1)
        /// CanFormPalindromePermutation("aabbc") → true (only 'c' has odd count=1)
        /// </example>
        internal static bool CanFormPalindromePermutation(string input)
        {
            if (string.IsNullOrEmpty(input))
                return true; // Empty string is technically a palindrome

            // Count character frequencies
            Dictionary<char, int> charFreq = new Dictionary<char, int>();
            foreach (char c in input)
            {
                if (charFreq.ContainsKey(c))
                    charFreq[c]++;
                else
                    charFreq[c] = 1;
            }

            // Count how many characters have odd frequencies
            int oddCount = 0;
            foreach (var freq in charFreq.Values)
            {
                if (freq % 2 == 1)
                    oddCount++;
            }

            // Valid only if at most 1 character has odd frequency
            return oddCount <= 1;
        }
    }
}
