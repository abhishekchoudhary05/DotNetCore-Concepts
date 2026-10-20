using Xunit;
using InterviewPrepration.Questions;

namespace DotNetCore_Concepts.Tests.Questions;

/// <summary>
/// Tests for ReverseStringInPlaceQuestion which reverses a char array in-place.
/// Algorithm:
/// - Uses two-pointer technique (left and right) to swap characters
/// - Operates directly on the input array without creating a copy
/// - Time complexity: O(n), Space complexity: O(1) (in-place)
/// </summary>
public class ReverseStringInPlaceTests
{
    /// <summary>
    /// Tests in-place reversal of a char array.
    /// Example: ['H','e','l','l','o'] becomes ['o','l','l','e','H']
    /// </summary>
    [Fact]
    public void ReverseStringInPlace_ValidInput_Test()
    {
        char[] input = ['H', 'e', 'l', 'l', 'o'];
        char[] result = ReverseStringInPlaceQuestion.ReverString_InPlace(input);
        Assert.Equal(new char[] { 'o', 'l', 'l', 'e', 'H' }, result);
    }

    /// <summary>
    /// Tests that empty char array returns empty array (edge case).
    /// </summary>
    [Fact]
    public void ReverseStringInPlace_EmptyInput_Test()
    {
        char[] input = [];
        char[] result = ReverseStringInPlaceQuestion.ReverString_InPlace(input);
        Assert.Empty(result);
    }
}