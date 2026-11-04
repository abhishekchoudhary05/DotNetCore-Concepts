namespace DotNetCore_Concepts.Questions.Strings
{
    /// <summary>
    /// OneAway class determines if two strings are one edit away from each other.
    /// 
    /// Problem: Given two strings, determine if they are exactly one edit away.
    /// An edit consists of one of three operations:
    /// 1. Insert a character
    /// 2. Remove a character
    /// 3. Replace a character
    /// 
    /// Examples:
    /// - "pale" vs "ple"   → true (one removal: 'a')
    /// - "pales" vs "pale" → true (one removal: 's')
    /// - "pale" vs "bale"  → true (one replacement: 'p' → 'b')
    /// - "pale" vs "pales" → true (one insertion: 's')
    /// - "pale" vs "pale"  → false (zero edits, not one)
    /// - "pale" vs "babe"  → false (two edits needed)
    /// 
    /// Key Insight:
    /// - If length difference > 1 → impossible with single edit
    /// - If same length → check if exactly 1 character differs
    /// - If length differs by 1 → check if removing/inserting one char makes them equal
    /// 
    /// Time Complexity: O(min(n, m)) where n and m are string lengths
    /// Space Complexity: O(1)
    /// </summary>
    internal static class OneAway
    {
        /// <summary>
        /// Determines if two strings are exactly one edit away.
        /// An edit is: Insert, Remove, or Replace one character.
        /// 
        /// Algorithm:
        /// 1. Check if length difference is more than 1 → return false
        /// 2. Use two pointers to compare characters
        /// 3. Count the number of differences
        /// 4. Return true if difference count <= 1
        /// </summary>
        /// <param name="input1">First string</param>
        /// <param name="input2">Second string</param>
        /// <returns>True if exactly one edit away, false otherwise</returns>
        internal static bool IsEditDistanceIsOne(string input1, string input2)
        {
            // Handle null/empty cases
            // One string empty and other has 1 char → one insertion needed
            if (string.IsNullOrEmpty(input1) && string.IsNullOrEmpty(input2))
                return false; // Both empty, zero edits

            if (string.IsNullOrEmpty(input1))
                return input2.Length == 1; // One insertion adds 1 char

            if (string.IsNullOrEmpty(input2))
                return input1.Length == 1; // One deletion removes 1 char

            // If length difference is more than 1, can't be done in one edit
            int lengthDiff = Math.Abs(input1.Length - input2.Length);
            if (lengthDiff > 1)
                return false;

            // Case 1: Same length → exactly one replacement
            if (input1.Length == input2.Length)
                return IsOneReplacement(input1, input2);

            // Case 2: Length differs by 1 → one insertion or deletion
            // Make sure input1 is the shorter string
            if (input1.Length > input2.Length)
            {
                string temp = input1;
                input1 = input2;
                input2 = temp;
            }

            return IsOneInsertionOrDeletion(input1, input2);
        }

        /// <summary>
        /// Checks if two strings of equal length differ by exactly one replacement.
        /// 
        /// Algorithm:
        /// - Count characters that don't match
        /// - Return true if exactly 1 mismatch
        /// 
        /// Examples:
        /// - "pale" vs "bale" → 1 difference at position 0 → true
        /// - "pale" vs "pale" → 0 differences → false
        /// - "abc" vs "def"   → 3 differences → false
        /// </summary>
        private static bool IsOneReplacement(string str1, string str2)
        {
            // Both strings must be same length
            if (str1.Length != str2.Length)
                return false;

            int differenceCount = 0;
            for (int i = 0; i < str1.Length; i++)
            {
                if (str1[i] != str2[i])
                {
                    differenceCount++;
                    // Early exit: more than 1 difference means not one edit
                    if (differenceCount > 1)
                        return false;
                }
            }

            return differenceCount == 1; // Exactly one replacement
        }

        /// <summary>
        /// Checks if two strings differ by exactly one insertion/deletion.
        /// The longer string should have exactly one extra character.
        /// 
        /// Algorithm:
        /// - Use two pointers, one for each string
        /// - When characters don't match, skip one character in longer string
        /// - After skipping, all remaining characters must match
        /// 
        /// Examples:
        /// - "pale" (short) vs "pales" (long) → skip 's' at end → true
        /// - "ple" (short) vs "pale" (long) → skip 'a' at middle → true
        /// - "ab" (short) vs "adb" (long) → skip 'd' and all match → true
        /// - "ab" (short) vs "dab" (long) → skip 'd' and all match → true
        /// 
        /// Precondition: str1.Length == str2.Length - 1
        /// </summary>
        private static bool IsOneInsertionOrDeletion(string str1, string str2)
        {
            // str1 is shorter, str2 is longer
            // str2 should have exactly 1 more character
            if (str2.Length != str1.Length + 1)
                return false;

            int i = 0, j = 0;
            bool foundDifference = false;

            while (i < str1.Length && j < str2.Length)
            {
                if (str1[i] != str2[j])
                {
                    // We found a mismatch, skip one character in the longer string
                    if (foundDifference)
                        return false; // More than one difference

                    foundDifference = true;
                    j++; // Skip this character in longer string
                }
                else
                {
                    i++;
                    j++;
                }
            }

            return true; // Found at most one difference
        }
    }
}
