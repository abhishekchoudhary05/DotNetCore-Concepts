using Xunit;
using InterviewPrepration.Questions;

namespace DotNetCore_Concepts.Tests.Questions;

/// <summary>
/// Tests for RemoveDuplicateCharactersQuestion which removes duplicate characters from a string.
/// Algorithm:
/// - Iterates through each character in the input string
/// - Uses string.Contains() to check if character is already in the result
/// - Appends only unique characters to the result string
/// - Time complexity: O(n^2) due to Contains() being O(n) per character
/// - Space complexity: O(n) for result string
/// </summary>
public class RemoveDuplicateCharactersTests
{
    /// <summary>
    /// Tests removing duplicate characters from a valid string.
    /// Example: "Hello" becomes "Helo" (second 'l' removed)
    /// </summary>
    [Fact]
    public void RemoveDuplicateCharacters_ValidInput_Test()
    {
        RemoveDuplicateCharactersQuestion.RemoveDuplicateCharacters("Hello");
    }
}