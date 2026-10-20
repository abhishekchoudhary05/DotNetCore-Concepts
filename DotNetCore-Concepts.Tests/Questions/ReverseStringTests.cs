using Xunit;
using InterviewPrepration.Questions;

namespace DotNetCore_Concepts.Tests.Questions;

/// <summary>
/// Tests for ReverseStringQuestion which reverses a string using character array manipulation.
/// Algorithm:
/// - Convert string to char array
/// - Use two-pointer technique (left and right) to swap characters from ends toward center
/// - Time complexity: O(n), Space complexity: O(n) for char array
/// </summary>
public class ReverseStringTests
{
    /// <summary>
    /// Tests reversing a valid non-empty string using two-pointer swapping.
    /// Example: "Hello" becomes "olleH"
    /// </summary>
    [Fact]
    public void ReverseString_ValidString_Test()
    {
        string input = "Hello";
        string result = ReverseStringQuestion.ReverseString(input);
        Assert.Equal("olleH", result);
    }

    /// <summary>
    /// Tests that empty string returns empty string (edge case).
    /// </summary>
    [Fact]
    public void ReverseString_EmptyString_Test()
    {
        string result = ReverseStringQuestion.ReverseString("");
        Assert.Equal("", result);
    }

    /// <summary>
    /// Tests that null input throws ArgumentNullException.
    /// Input validation ensures the method fails fast with null inputs.
    /// </summary>
    [Fact]
    public void ReverseString_NullInput_Test()
    {
        Assert.Throws<ArgumentNullException>(() => ReverseStringQuestion.ReverseString(null));
    }
}