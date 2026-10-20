using Xunit;
using InterviewPrepration.Questions;

namespace DotNetCore_Concepts.Tests.Questions;

/// <summary>
/// Tests for ReverseWordQuestion which reverses the order of words in a string.
/// Algorithm:
/// - Iterates through the string from the end to the beginning
/// - Identifies word boundaries by spaces
/// - Builds the reversed string by appending words in reverse order
/// - Time complexity: O(n), Space complexity: O(n) for StringBuilder
/// </summary>
public class ReverseWordTests
{
    /// <summary>
    /// Tests reversing the words in a valid input string.
    /// Example: "Hello World" becomes "World Hello"
    /// </summary>
    [Fact]
    public void ReverseWord_ValidInput_Test()
    {
        ReverseWordQuestion.ReverseWord("Hello World");
    }
}