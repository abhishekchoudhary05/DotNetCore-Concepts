namespace DotNetCore_Concepts.Questions.Strings
{
    /// <summary>
    /// Permutation class generates all possible permutations of a given string.
    /// 
    /// Problem: Generate all permutations of characters in a string.
    /// Example: "ABC" → ["ABC", "ACB", "BAC", "BCA", "CAB", "CBA"]
    /// 
    /// Algorithm: Backtracking
    /// - Fix a character at each position
    /// - Recursively generate permutations for remaining positions
    /// - Backtrack by restoring the original state
    /// 
    /// Time Complexity: O(n! * n) where n is the length of the string
    ///   - n! permutations to generate
    ///   - O(n) to create each permutation string
    /// 
    /// Space Complexity: O(n! * n) for storing all permutations
    /// Recursion Depth: O(n)
    /// </summary>
    internal static class Permutation
    {
        /// <summary>
        /// Generates all permutations of the given input string.
        /// Uses backtracking approach to systematically explore all possible arrangements.
        /// </summary>
        /// <param name="input">The input string to permute. Can contain duplicates.</param>
        /// <returns>List of all permutations. Empty list if input is null or empty.</returns>
        /// <example>
        /// FindAllPermutation("AB") returns ["AB", "BA"]
        /// FindAllPermutation("ABC") returns ["ABC", "ACB", "BAC", "BCA", "CAB", "CBA"]
        /// </example>
        internal static List<string> FindAllPermutation(string input)
        {
            // Handle null or empty input
            if (string.IsNullOrEmpty(input))
                return [];

            List<string> result = new List<string>();
            char[] charArr = input.ToCharArray();

            // Start backtracking from index 0
            BackTrack(charArr, result, 0);
            return result;
        }

        /// <summary>
        /// Recursive backtracking helper function to generate permutations.
        /// 
        /// Strategy:
        /// 1. Fix a character at the current index
        /// 2. Recursively permute the remaining characters
        /// 3. Backtrack by undoing the swap to explore other possibilities
        /// 
        /// For position 0 with "ABC":
        ///   - Swap(0,0) → "ABC..." → Recurse on position 1
        ///   - Swap(0,1) → "BAC..." → Recurse on position 1
        ///   - Swap(0,2) → "CBA..." → Recurse on position 1
        /// </summary>
        /// <param name="charArr">Character array being permuted (modified in-place)</param>
        /// <param name="result">List to store all generated permutations</param>
        /// <param name="index">Current position being fixed (0 to length-1)</param>
        private static void BackTrack(char[] charArr, List<string> result, int index)
        {
            // Base case: All characters are fixed, we have a complete permutation
            if (index == charArr.Length)
            {
                result.Add(new string(charArr));
                return;
            }

            // Try each character at the current index position
            for (int i = index; i < charArr.Length; i++)
            {
                // Step 1: Swap - Place character at position 'i' into position 'index'
                (charArr[i], charArr[index]) = (charArr[index], charArr[i]);

                // Step 2: Recurse - Fix the next position (index + 1)
                BackTrack(charArr, result, index + 1);

                // Step 3: Backtrack - Restore original state for next iteration
                // This undoes the swap so we can try the next character
                (charArr[i], charArr[index]) = (charArr[index], charArr[i]);
            }
        }
    }
}
