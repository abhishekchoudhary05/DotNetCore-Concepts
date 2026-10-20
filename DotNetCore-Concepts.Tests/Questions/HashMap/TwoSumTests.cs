using Xunit;
using DotNetCore_Concepts.Questions.HashMap;

namespace DotNetCore_Concepts.Tests.Questions.HashMap;

/// <summary>
/// Tests for TwoSum which finds indices of two numbers that sum to a target.
/// Algorithm:
/// - Uses a Dictionary<int, int> to store value → index mapping
/// - For each element, checks if complement (target - current) exists in dictionary
/// - Returns indices of complement and current element when found
/// - Returns [0, 0] when no solution exists
/// - Time complexity: O(n), Space complexity: O(n) for dictionary
/// </summary>
public class TwoSumTests
{
    /// <summary>
    /// Tests finding two elements that sum to target.
    /// Input: [2, 7, 11, 15], target: 9 → indices [0, 1] because 2 + 7 = 9
    /// </summary>
    [Fact]
    public void TwoSum_ValidInput_Test()
    {
        int[] input = [2, 7, 11, 15];
        int target = 9;
        int[] result = TwoSum.FindElements(input, target);
        Assert.Equal([0, 1], result);
    }

    /// <summary>
    /// Tests case where no two elements sum to target - returns [0, 0].
    /// Input: [1, 2, 3], target: 7 → no pair sums to 7
    /// </summary>
    [Fact]
    public void TwoSum_NoSolution_Test()
    {
        int[] input = [1, 2, 3];
        int target = 7;
        int[] result = TwoSum.FindElements(input, target);
        Assert.Equal([0, 0], result);
    }

    /// <summary>
    /// Tests that null input throws ArgumentNullException.
    /// </summary>
    [Fact]
    public void TwoSum_NullInput_Test()
    {
        Assert.Throws<ArgumentNullException>(() => TwoSum.FindElements(null, 5));
    }
}