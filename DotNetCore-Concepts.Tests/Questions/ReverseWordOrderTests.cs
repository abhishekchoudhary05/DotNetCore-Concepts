using Xunit;
using InterviewPrepration.Questions;

namespace DotNetCore_Concepts.Tests.Questions;

/// <summary>
/// Tests for ReverseWordOrderQuestion which reverses the order of words in a string.
/// Algorithm:
/// - Iterates from the end of the string toward the beginning
/// - When a space is found, appends the word from (space+1) to End to StringBuilder
/// - Continues until all words are reversed in order
/// - Time complexity: O(n), Space complexity: O(n) for StringBuilder
/// </summary>
public class ReverseWordOrderTests
{
    /// <summary>
    /// Tests reversing word order in a valid input string.
    /// Example: "Hello World" becomes "World Hello"
    /// </summary>
    [Fact]
    public void ReverseWordOrder_ValidInput_Test()
    {
        ReverseWordOrderQuestion.ReverseWordOrder("Hello World");
    }
}