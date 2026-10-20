using Xunit;
using DotNetCore_Concepts.Questions.Array;

namespace DotNetCore_Concepts.Tests.Questions.Array;

/// <summary>
/// Tests for MissingNumber which finds the smallest missing non-negative integer in an array.
/// Algorithm:
/// - Creates a boolean array (using int array as marker) of size equal to input length
/// - Marks indices corresponding to values in the input array (if value < array length)
/// - Scans for the first unmarked index, which is the missing number
/// - If all indices are marked, returns -1 (no missing number in range [0, n-1])
/// - Time complexity: O(n), Space complexity: O(n)
/// </summary>
public class MissingNumberTests
{
    /// <summary>
    /// Tests that null input throws ArgumentNullException.
    /// </summary>
    [Fact]
    public void NullInput_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => MissingNumber.FindNumber(null));
    }

    /// <summary>
    /// Tests a typical case with a missing number in the middle.
    /// Input: [2, 1, 4, 0, 5, 6] - numbers 0,1,2,4,5,6 present; missing 3
    /// </summary>
    [Fact]
    public void TypicalCase_ReturnsMissingNumber()
    {
        int[] input = new int[] { 2, 1, 4, 0, 5, 6 };
        int result = MissingNumber.FindNumber(input);
        Assert.Equal(3, result);
    }

    /// <summary>
    /// Tests case where the missing number is at the last valid index.
    /// Input: [0, 1, 2, 4] - length 4, missing index 3 (value 4 is ignored as it equals length)
    /// </summary>
    [Fact]
    public void MissingIsLastIndex_ReturnsLastIndexValue()
    {
        // array length 4, elements 0,1,2 and a value equal to length (4) which is ignored
        int[] input = new int[] { 0, 1, 2, 4 };
        int result = MissingNumber.FindNumber(input);
        Assert.Equal(3, result);
    }

    /// <summary>
    /// Tests case with no missing numbers in range [0, n-1].
    /// Input: [2, 0, 1] - all indices 0,1,2 are present; returns -1
    /// </summary>
    [Fact]
    public void NoMissing_ReturnsMinusOne()
    {
        int[] input = new int[] { 2, 0, 1 };
        int result = MissingNumber.FindNumber(input);
        Assert.Equal(-1, result);
    }

    /// <summary>
    /// Tests handling of duplicate values - first missing is still returned correctly.
    /// Input: [1, 1, 2] - 0 is missing; returns 0
    /// </summary>
    [Fact]
    public void Duplicates_ReturnsMissingCorrectly()
    {
        int[] input = new int[] { 1, 1, 2 };
        int result = MissingNumber.FindNumber(input);
        Assert.Equal(0, result);
    }

    /// <summary>
    /// Tests that values greater than array length are ignored.
    /// Input: [0, 1, 10] - 10 >= length(3), ignored; missing is 2
    /// </summary>
    [Fact]
    public void ValuesGreaterThanLength_AreIgnored()
    {
        int[] input = new int[] { 0, 1, 10 };
        int result = MissingNumber.FindNumber(input);
        Assert.Equal(2, result);
    }

    /// <summary>
    /// Tests that negative values cause IndexOutOfRangeException.
    /// Input: [-1, 0, 1] - negative index -1 used to access array
    /// </summary>
    [Fact]
    public void NegativeValue_ThrowsIndexOutOfRangeException()
    {
        int[] input = new int[] { -1, 0, 1 };
        Assert.Throws<IndexOutOfRangeException>(() => MissingNumber.FindNumber(input));
    }
}
