using Xunit;
using DotNetCore_Concepts.Questions.Array;

namespace DotNetCore_Concepts.Tests.Questions.Array;

/// <summary>
/// Unit tests for <see cref="MoveZeros"/> which moves all zero elements in an array to the end
/// while maintaining the relative order of the non-zero elements in-place.
/// </summary>
public class MoveZerosTests
{
    /// <summary>
    /// Tests a typical array with multiple zeros interspersed among non-zero numbers.
    /// Input: [0, 1, 0, 3, 12] -> Output: [1, 3, 12, 0, 0]
    /// </summary>
    [Fact]
    public void TypicalArray_MovesZerosToEnd_PreservingOrder()
    {
        int[] input = [0, 1, 0, 3, 12];
        int[] expected = [1, 3, 12, 0, 0];

        int[] result = MoveZeros.MoveZerosTtEnd(input);

        Assert.Equal(expected, result);
    }

    /// <summary>
    /// Tests an empty array.
    /// Input: [] -> Output: []
    /// </summary>
    [Fact]
    public void EmptyArray_ReturnsEmptyArray()
    {
        int[] input = [];
        int[] expected = [];

        int[] result = MoveZeros.MoveZerosTtEnd(input);

        Assert.Equal(expected, result);
        Assert.Empty(result);
    }

    /// <summary>
    /// Tests a single element array containing zero.
    /// Input: [0] -> Output: [0]
    /// </summary>
    [Fact]
    public void SingleZeroElement_ReturnsSameElement()
    {
        int[] input = [0];
        int[] expected = [0];

        int[] result = MoveZeros.MoveZerosTtEnd(input);

        Assert.Equal(expected, result);
    }

    /// <summary>
    /// Tests a single element array containing a non-zero number.
    /// Input: [5] -> Output: [5]
    /// </summary>
    [Fact]
    public void SingleNonZeroElement_ReturnsSameElement()
    {
        int[] input = [5];
        int[] expected = [5];

        int[] result = MoveZeros.MoveZerosTtEnd(input);

        Assert.Equal(expected, result);
    }

    /// <summary>
    /// Tests two-element arrays with various combinations of zero and non-zero elements.
    /// </summary>
    [Theory]
    [InlineData(new int[] { 0, 1 }, new int[] { 1, 0 })]
    [InlineData(new int[] { 1, 0 }, new int[] { 1, 0 })]
    [InlineData(new int[] { 0, 0 }, new int[] { 0, 0 })]
    [InlineData(new int[] { 4, 7 }, new int[] { 4, 7 })]
    public void TwoElementArray_ReturnsExpectedResult(int[] input, int[] expected)
    {
        int[] result = MoveZeros.MoveZerosTtEnd(input);

        Assert.Equal(expected, result);
    }

    /// <summary>
    /// Tests an array containing no zeros; elements should remain untouched.
    /// </summary>
    [Fact]
    public void ArrayWithNoZeros_RemainsUnchanged()
    {
        int[] input = [1, 2, 3, 4, 5];
        int[] expected = [1, 2, 3, 4, 5];

        int[] result = MoveZeros.MoveZerosTtEnd(input);

        Assert.Equal(expected, result);
    }

    /// <summary>
    /// Tests an array containing only zeros; elements should remain untouched.
    /// </summary>
    [Fact]
    public void ArrayWithAllZeros_RemainsUnchanged()
    {
        int[] input = [0, 0, 0, 0, 0];
        int[] expected = [0, 0, 0, 0, 0];

        int[] result = MoveZeros.MoveZerosTtEnd(input);

        Assert.Equal(expected, result);
    }

    /// <summary>
    /// Tests an array where zeros are already at the end; order should be preserved.
    /// </summary>
    [Fact]
    public void ArrayWithZerosAlreadyAtEnd_RemainsUnchanged()
    {
        int[] input = [1, 2, 3, 0, 0];
        int[] expected = [1, 2, 3, 0, 0];

        int[] result = MoveZeros.MoveZerosTtEnd(input);

        Assert.Equal(expected, result);
    }

    /// <summary>
    /// Tests an array where all leading elements are zeros followed by non-zeros.
    /// </summary>
    [Fact]
    public void LeadingZeros_MovesZerosToEnd()
    {
        int[] input = [0, 0, 0, 1, 2];
        int[] expected = [1, 2, 0, 0, 0];

        int[] result = MoveZeros.MoveZerosTtEnd(input);

        Assert.Equal(expected, result);
    }

    /// <summary>
    /// Tests an alternating pattern of zeros and non-zeros.
    /// </summary>
    [Theory]
    [InlineData(new int[] { 0, 1, 0, 2, 0, 3 }, new int[] { 1, 2, 3, 0, 0, 0 })]
    [InlineData(new int[] { 1, 0, 2, 0, 3, 0 }, new int[] { 1, 2, 3, 0, 0, 0 })]
    public void AlternatingZerosAndNonZeros_MovesZerosToEnd(int[] input, int[] expected)
    {
        int[] result = MoveZeros.MoveZerosTtEnd(input);

        Assert.Equal(expected, result);
    }

    /// <summary>
    /// Tests an array with multiple consecutive zeros between non-zero elements.
    /// </summary>
    [Fact]
    public void ConsecutiveZerosBetweenNonZeros_PreservesRelativeOrder()
    {
        int[] input = [4, 0, 0, 0, 1, 0, 5];
        int[] expected = [4, 1, 5, 0, 0, 0, 0];

        int[] result = MoveZeros.MoveZerosTtEnd(input);

        Assert.Equal(expected, result);
    }

    /// <summary>
    /// Tests array with negative numbers and mixed values.
    /// </summary>
    [Fact]
    public void NegativeAndPositiveNumbers_PreservesRelativeOrder()
    {
        int[] input = [-1, 0, 3, -5, 0, 0, 2];
        int[] expected = [-1, 3, -5, 2, 0, 0, 0];

        int[] result = MoveZeros.MoveZerosTtEnd(input);

        Assert.Equal(expected, result);
    }

    /// <summary>
    /// Tests that the method modifies the array in-place and returns the same array reference.
    /// </summary>
    [Fact]
    public void InPlaceModification_ReturnsSameInstanceAndMutatesInput()
    {
        int[] input = [0, 1, 0, 3, 12];

        int[] result = MoveZeros.MoveZerosTtEnd(input);

        Assert.Same(input, result);
        Assert.Equal(new int[] { 1, 3, 12, 0, 0 }, input);
    }

    /// <summary>
    /// Tests that passing null throws an <see cref="ArgumentNullException"/>.
    /// </summary>
    [Fact]
    public void NullInput_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => MoveZeros.MoveZerosTtEnd(null!));
    }
}
