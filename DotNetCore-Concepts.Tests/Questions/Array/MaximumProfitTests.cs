using Xunit;
using DotNetCore_Concepts.Questions.Array;

namespace DotNetCore_Concepts.Tests.Questions.Array;

/// <summary>
/// Unit tests for <see cref="MaximumProfit"/> which computes the maximum profit
/// from one buy followed by one sell.
/// </summary>
public class MaximumProfitTests
{
    /// <summary>
    /// Tests that passing null throws an <see cref="ArgumentNullException"/>.
    /// </summary>
    [Fact]
    public void NullInput_ThrowsArgumentNullException()
    {
        var ex = Assert.Throws<ArgumentNullException>(() => MaximumProfit.FindMaximumProfit(null!));
        Assert.Equal("Input array is null", ex.ParamName);
    }

    /// <summary>
    /// Tests a single element array containing a positive number.
    /// Max and Min are the same, resulting in 0 profit.
    /// </summary>
    [Fact]
    public void SingleElement_Positive_ReturnsZero()
    {
        int[] input = [42];

        long result = MaximumProfit.FindMaximumProfit(input);

        Assert.Equal(0, result);
    }

    /// <summary>
    /// Tests a single element array containing a negative number.
    /// Max and Min are the same, resulting in 0 profit.
    /// </summary>
    [Fact]
    public void SingleElement_Negative_ReturnsZero()
    {
        int[] input = [-15];

        long result = MaximumProfit.FindMaximumProfit(input);

        Assert.Equal(0, result);
    }

    /// <summary>
    /// Tests a single element array containing zero.
    /// Max and Min are the same, resulting in 0 profit.
    /// </summary>
    [Fact]
    public void SingleElement_Zero_ReturnsZero()
    {
        int[] input = [0];

        long result = MaximumProfit.FindMaximumProfit(input);

        Assert.Equal(0, result);
    }

    /// <summary>
    /// Tests an array where all elements have the same value.
    /// Max and Min are equal, so the difference is 0.
    /// </summary>
    [Fact]
    public void AllElementsEqual_ReturnsZero()
    {
        int[] input = [5, 5, 5, 5, 5];

        long result = MaximumProfit.FindMaximumProfit(input);

        Assert.Equal(0, result);
    }

    /// <summary>
    /// Tests a typical array of positive integers with varying values.
    /// Min: 1, Max: 7 -> Profit: 7 - 1 = 6.
    /// </summary>
    [Fact]
    public void TypicalArray_PositiveIntegers_ReturnsDifferenceBetweenMaxAndMin()
    {
        int[] input = [7, 1, 5, 3, 6, 4];

        long result = MaximumProfit.FindMaximumProfit(input);

        Assert.Equal(5L, result);
    }

    /// <summary>
    /// Tests a strictly increasing array.
    /// Min is the first element, Max is the last element.
    /// </summary>
    [Fact]
    public void SortedAscendingArray_ReturnsDifferenceBetweenLastAndFirst()
    {
        int[] input = [1, 2, 4, 8, 16];

        long result = MaximumProfit.FindMaximumProfit(input);

        Assert.Equal(15, result);
    }

    /// <summary>
    /// Tests a strictly decreasing array.
    /// Max is the first element, Min is the last element.
    /// </summary>
    [Fact]
    public void SortedDescendingArray_ReturnsDifferenceBetweenFirstAndLast()
    {
        int[] input = [20, 15, 10, 5, 2];

        long result = MaximumProfit.FindMaximumProfit(input);

        Assert.Equal(0L, result);
    }

    /// <summary>
    /// Tests an array containing only negative numbers.
    /// Min: -10, Max: -2 -> Profit: -2 - (-10) = 8.
    /// </summary>
    [Fact]
    public void NegativeNumbersOnly_ReturnsCorrectProfit()
    {
        int[] input = [-7, -3, -10, -2, -5];

        long result = MaximumProfit.FindMaximumProfit(input);

        Assert.Equal(8, result);
    }

    /// <summary>
    /// Tests an array with mixed positive, negative, and zero values.
    /// Min: -25, Max: 50 -> Profit: 50 - (-25) = 75.
    /// </summary>
    [Fact]
    public void MixedPositiveNegativeAndZero_ReturnsCorrectProfit()
    {
        int[] input = [-10, 0, 50, -25, 15];

        long result = MaximumProfit.FindMaximumProfit(input);

        Assert.Equal(40L, result);
    }

    /// <summary>
    /// Tests an array containing duplicate minimums and maximums.
    /// Min: 2, Max: 9 -> Profit: 9 - 2 = 7.
    /// </summary>
    [Fact]
    public void ArrayWithDuplicateMinAndMaxValues_ReturnsCorrectProfit()
    {
        int[] input = [2, 9, 5, 2, 9, 3];

        long result = MaximumProfit.FindMaximumProfit(input);

        Assert.Equal(7, result);
    }

    /// <summary>
    /// Tests two-element arrays in ascending, descending, and equal order.
    /// </summary>
    [Theory]
    [InlineData(new int[] { 3, 10 }, 7)]
    [InlineData(new int[] { 10, 3 }, 7)]
    [InlineData(new int[] { -5, 5 }, 10)]
    [InlineData(new int[] { 8, 8 }, 0)]
    public void TwoElementArrays_ReturnsExpectedProfit(int[] input, int expected)
    {
        long result = MaximumProfit.FindMaximumProfit(input);

        Assert.Equal(expected, result);
    }

    /// <summary>
    /// Tests arrays containing zeros only.
    /// </summary>
    [Fact]
    public void ArrayWithOnlyZeros_ReturnsZero()
    {
        int[] input = [0, 0, 0, 0];

        long result = MaximumProfit.FindMaximumProfit(input);

        Assert.Equal(0, result);
    }

    /// <summary>
    /// An empty array has no possible buy/sell transaction, so profit is zero.
    /// </summary>
    [Fact]
    public void EmptyArray_ReturnsZero()
    {
        int[] input = [];

        long result = MaximumProfit.FindMaximumProfit(input);

        Assert.Equal(0L, result);
    }

    /// <summary>
    /// Tests large numbers to verify correct handling without premature overflow.
    /// Min: 1_000_000, Max: 2_000_000_000 -> Profit: 1_999_000_000.
    /// </summary>
    [Fact]
    public void LargeValues_ReturnsCorrectDifference()
    {
        int[] input = [1_000_000, 500_000_000, 2_000_000_000];

        long result = MaximumProfit.FindMaximumProfit(input);

        Assert.Equal(1_999_000_000, result);
    }

    [Fact]
    public void FullIntRange_ReturnsProfitAsLong()
    {
        int[] input = [int.MinValue, int.MaxValue];

        long result = MaximumProfit.FindMaximumProfit(input);

        Assert.Equal(4_294_967_295L, result);
    }
}
