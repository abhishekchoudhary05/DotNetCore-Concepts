using Xunit;
using DotNetCore_Concepts.Questions.Array;

namespace DotNetCore_Concepts.Tests.Questions.Array;

/// <summary>
/// Tests for FindLeaders which finds all "leader" elements in an array.
/// A leader is an element greater than all elements to its right.
/// The last element is always a leader.
/// Algorithm:
/// - Iterates from right to left, tracking the current maximum (leader)
/// - When a new leader is found, adds it to the results list
/// - Reverses the results to maintain left-to-right order
/// - Time complexity: O(n), Space complexity: O(k) where k is number of leaders
/// </summary>
public class FindLeadersTests
{
    /// <summary>
    /// Tests a typical array with multiple leaders.
    /// Input: [16, 17, 4, 3, 5, 2]
    /// Leaders: 17 (greater than 4,3,5,2), 5 (greater than 2), 2 (last element)
    /// </summary>
    [Fact]
    public void TypicalArray_ReturnsCorrectLeaders()
    {
        int[] input = [16, 17, 4, 3, 5, 2];
        int[] expected = [17, 5, 2];

        int[] result = FindLeaders.FindLeadersInArray(input);

        Assert.Equal(expected, result);
    }

    /// <summary>
    /// Tests a strictly decreasing array where all elements are leaders.
    /// Input: [5, 4, 3, 2, 1] - each element is greater than all to its right
    /// </summary>
    [Fact]
    public void DecreasingArray_AllElementsAreLeaders()
    {
        int[] input = [5, 4, 3, 2, 1];
        int[] expected = [5, 4, 3, 2, 1];

        int[] result = FindLeaders.FindLeadersInArray(input);

        Assert.Equal(expected, result);
    }

    /// <summary>
    /// Tests an array with all equal elements - only the last is a leader.
    /// Input: [2, 2, 2] - no element is strictly greater than those to its right
    /// </summary>
    [Fact]
    public void AllEqualElements_ReturnsLastElementOnly()
    {
        int[] input = [2, 2, 2];
        int[] expected = [2];

        int[] result = FindLeaders.FindLeadersInArray(input);

        Assert.Equal(expected, result);
    }

    /// <summary>
    /// Tests a single-element array where the element is always a leader.
    /// </summary>
    [Fact]
    public void SingleElement_ReturnsThatElement()
    {
        int[] input = [10];
        int[] expected = [10];

        int[] result = FindLeaders.FindLeadersInArray(input);

        Assert.Equal(expected, result);
    }

    /// <summary>
    /// Tests that an empty array returns an empty result.
    /// </summary>
    [Fact]
    public void EmptyArray_ReturnsEmpty()
    {
        int[] input = [];

        int[] result = FindLeaders.FindLeadersInArray(input);

        Assert.Empty(result);
    }

    /// <summary>
    /// Tests that null input throws ArgumentNullException.
    /// </summary>
    [Fact]
    public void NullInput_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => FindLeaders.FindLeadersInArray(null));
    }
}
