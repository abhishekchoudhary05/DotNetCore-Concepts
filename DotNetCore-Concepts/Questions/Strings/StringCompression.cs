using System.Text;

namespace DotNetCore_Concepts.Questions.Strings
{
    /// <summary>
    /// StringCompression class provides functionality to compress strings using run-length encoding.
    /// 
    /// Problem: Given a string, compress it by counting consecutive duplicate characters.
    /// Format: character followed by its count.
    /// If compressed string is longer than original, return the original string.
    /// 
    /// Examples:
    /// - "aabbcc"   → "a2b2c2" (compression helps, return compressed)
    /// - "aaabbb"   → "a3b3" (compression helps, return compressed)
    /// - "abcdef"   → "a1b1c1d1e1f1" (18 chars > 6 chars, return original "abcdef")
    /// - "aabcccccccaabccccd" → "a2b1c6a2b1c4d1" (compression helps, return compressed)
    /// 
    /// Time Complexity: O(n) where n is the length of the input string (single pass)
    /// Space Complexity: O(n) for the StringBuilder in worst case where no compression occurs
    /// </summary>
    internal static class StringCompression
    {
        /// <summary>
        /// Compresses a string using run-length encoding (consecutive character counts).
        /// Returns the original string if compression doesn't reduce its length.
        /// 
        /// Algorithm:
        /// 1. Handle single character edge case
        /// 2. Iterate through the string with a pointer and counter
        /// 3. Count consecutive identical characters
        /// 4. When a different character is encountered, append character and count to result
        /// 5. Don't forget to append the last run (after loop completes)
        /// 6. Return compressed string only if it's shorter than the original
        /// </summary>
        /// <param name="str">The input string to compress (cannot be null)</param>
        /// <returns>
        /// Compressed string if shorter than original; otherwise returns the original string.
        /// Format: character followed by count (e.g., "a2b3c1")
        /// </returns>
        /// <exception cref="ArgumentNullException">Thrown if input string is null</exception>
        internal static string CompressString(string str)
        {
            // Validate input
            ArgumentNullException.ThrowIfNull(str);

            // Single character: already minimal, return as-is
            if (str.Length == 1)
                return str;

            StringBuilder stringBuilder = new StringBuilder();
            int i = 0, length = 1;

            // Count consecutive identical characters
            while (i < str.Length - 1)
            {
                // Check if current character matches next character
                if (str[i] == str[i + 1])
                {
                    // Increment count for consecutive matching characters
                    length++;
                }
                else
                {
                    // Different character found: append current character and its count
                    stringBuilder.Append(str[i]);
                    stringBuilder.Append(length);

                    // Reset counter for the new character run
                    length = 1;
                }
                i++;
            }

            // Process the last character run (loop exits before processing the final character)
            stringBuilder.Append(str[i]);
            stringBuilder.Append(length);

            // Return compressed string only if it's actually shorter than the original
            if (stringBuilder.Length >= str.Length)
            {
                return str;
            }
            else
                return stringBuilder.ToString();
        }
    }
}
