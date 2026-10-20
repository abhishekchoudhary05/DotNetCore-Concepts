using Xunit;
using InterviewPrepration.Questions;

namespace DotNetCore_Concepts.Tests.Questions;

/// <summary>
/// Tests for FindSecondHighestQuestion which finds the second highest distinct value in an array.
/// Algorithm:
/// - Single pass through the array tracking highest and second highest
/// - Handles duplicate values (skips if value equals highest)
/// - Throws exception if no distinct second highest value exists
/// - Time complexity: O(n), Space complexity: O(1)
/// </summary>
public class FindSecondHighestTests
{
    /// <summary>
    /// Tests finding the second highest value in a valid array.
    /// Example: [10, 20, 30, 20, 40] → second highest is 30 (40 is highest)
    /// </summary>
    [Fact]
    public void FindSecondHighest_ValidInput_Test()
    {
        int[] input = new int[] { 10, 20, 30, 20, 40 };
        int result = FindSecondHighestQuestion.FindSecondHighest(input);
        Assert.Equal(30, result);
    }

    /// <summary>
    /// Tests that an array without distinct values throws ArgumentException.
    /// Example: [10, 10, 10] has no distinct second highest value
    /// </summary>
    [Fact]
    public void FindSecondHighest_NoDistinctSecondHighest_Test()
    {
        int[] input = new int[] { 10, 10, 10 };
        Assert.Throws<ArgumentException>(() => FindSecondHighestQuestion.FindSecondHighest(input));
    }

    /// <summary>
    /// Tests that null input throws ArgumentNullException.
    /// Input validation prevents null reference errors.
    /// </summary>
    [Fact]
    public void FindSecondHighest_NullInput_Test()
    {
        Assert.Throws<ArgumentNullException>(() => FindSecondHighestQuestion.FindSecondHighest(null));
    }
}