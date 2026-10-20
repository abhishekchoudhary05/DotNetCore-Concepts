using Xunit;
using InterviewPrepration.Questions;

namespace DotNetCore_Concepts.Tests.Questions;

/// <summary>
/// Tests for LeftCirculationQuestion which rotates an array to the left by one position.
/// Algorithm:
/// - Stores the first element
/// - Shifts all elements one position to the left
/// - Places the stored first element at the end
/// - Time complexity: O(n), Space complexity: O(1) (in-place modification)
/// - Generic implementation works with any type T
/// </summary>
public class LeftCirculationTests
{
    /// <summary>
    /// Tests left rotation of a valid integer array.
    /// Example: [1, 2, 3, 4] becomes [2, 3, 4, 1]
    /// </summary>
    [Fact]
    public void LeftCirculation_ValidInput_Test()
    {
        int[] input = new int[] { 1, 2, 3, 4 };
        LeftCirculationQuestion.LeftCirculation(input);
        Assert.Equal(new int[] { 2, 3, 4, 1 }, input);
    }

    /// <summary>
    /// Tests that null input throws ArgumentNullException.
    /// </summary>
    [Fact]
    public void LeftCirculation_NullInput_Test()
    {
        Assert.Throws<ArgumentNullException>(() => LeftCirculationQuestion.LeftCirculation<int>(null));
    }
}