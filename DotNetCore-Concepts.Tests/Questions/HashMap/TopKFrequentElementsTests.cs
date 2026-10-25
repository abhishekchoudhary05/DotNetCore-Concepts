using Xunit;
using DotNetCore_Concepts.Questions.HashMap;

namespace DotNetCore_Concepts.Tests.Questions.HashMap;

/// <summary>
/// Unit tests for <see cref="TopKFrequentElements"/> which finds the top k most frequent elements in an array.
/// When two elements have the same frequency, the larger number is preferred.
/// </summary>
public class TopKFrequentElementsTests
{
    /// <summary>
    /// Tests that passing a null array throws <see cref="ArgumentNullException"/>.
    /// </summary>
    [Fact]
    public void NullInput_ThrowsArgumentNullException()
    {
        var ex = Assert.Throws<ArgumentNullException>(() => TopKFrequentElements.FindElements(null!, 2));
        Assert.Equal("Input array is null", ex.ParamName);
    }

    /// <summary>
    /// Tests that an empty input array returns an empty array.
    /// </summary>
    [Fact]
    public void EmptyArray_ReturnsEmptyArray()
    {
        int[] input = [];

        int[] result = TopKFrequentElements.FindElements(input, 2);

        Assert.Empty(result);
    }

    /// <summary>
    /// Tests that k equal to or less than 0 returns an empty array.
    /// </summary>
    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(-5)]
    public void KZeroOrNegative_ReturnsEmptyArray(int k)
    {
        int[] input = [1, 2, 3];

        int[] result = TopKFrequentElements.FindElements(input, k);

        Assert.Empty(result);
    }

    /// <summary>
    /// Tests a typical scenario where elements have distinct frequencies.
    /// 1 appears 3 times, 2 appears 2 times, 3 appears 1 time. Top 2: [1, 2].
    /// </summary>
    [Fact]
    public void DistinctFrequencies_ReturnsTopKFrequentElements()
    {
        int[] input = [1, 1, 1, 2, 2, 3];

        int[] result = TopKFrequentElements.FindElements(input, 2);

        Assert.Equal([1, 2], result);
    }

    /// <summary>
    /// Tests tie-breaking when two elements share the same frequency.
    /// Frequencies: 1 (3 times), 4 (2 times), 2 (2 times), 3 (1 time).
    /// For k = 2, 1 is selected first; between 4 and 2 (both freq 2), 4 is chosen because 4 > 2.
    /// </summary>
    [Fact]
    public void SameFrequency_ReturnsLargerNumber()
    {
        int[] input = [1, 4, 1, 2, 1, 3, 2, 4];

        int[] result = TopKFrequentElements.FindElements(input, 2);

        Assert.Equal([1, 4], result);
    }

    /// <summary>
    /// Tests when all elements have the same frequency (frequency = 1).
    /// The top k largest numbers should be returned.
    /// </summary>
    [Fact]
    public void AllElementsSameFrequency_ReturnsLargestElements()
    {
        int[] input = [1, 2, 3, 4, 5];

        int[] result = TopKFrequentElements.FindElements(input, 2);

        Assert.Equal([5, 4], result);
    }

    /// <summary>
    /// Tests an array with a single element.
    /// </summary>
    [Fact]
    public void SingleElementArray_ReturnsElement()
    {
        int[] input = [42];

        int[] result = TopKFrequentElements.FindElements(input, 1);

        Assert.Equal([42], result);
    }

    /// <summary>
    /// Tests an array where all elements are identical.
    /// </summary>
    [Fact]
    public void AllElementsIdentical_ReturnsSingleElement()
    {
        int[] input = [7, 7, 7, 7];

        int[] result = TopKFrequentElements.FindElements(input, 1);

        Assert.Equal([7], result);
    }

    /// <summary>
    /// Tests tie-breaking with negative numbers.
    /// Frequencies: -5 (2 times), -2 (2 times).
    /// Since -2 > -5, -2 is larger and should be chosen for k = 1.
    /// </summary>
    [Fact]
    public void NegativeNumbers_SameFrequency_ReturnsLargerNumber()
    {
        int[] input = [-5, -5, -2, -2];

        int[] result = TopKFrequentElements.FindElements(input, 1);

        Assert.Equal([-2], result);
    }

    /// <summary>
    /// Tests tie-breaking with mixed positive and negative numbers.
    /// Frequencies: -10 (2 times), 0 (2 times), 10 (2 times).
    /// For k = 2, 10 and 0 should be returned because 10 > 0 > -10.
    /// </summary>
    [Fact]
    public void MixedPositiveAndNegative_SameFrequency_ReturnsLargerNumbers()
    {
        int[] input = [-10, -10, 0, 0, 10, 10];

        int[] result = TopKFrequentElements.FindElements(input, 2);

        Assert.Equal([10, 0], result);
    }

    /// <summary>
    /// Tests when k is greater than the total number of unique elements.
    /// Should return all unique elements ordered by frequency then value.
    /// </summary>
    [Fact]
    public void KGreaterThanUniqueElements_ReturnsAllUniqueElements()
    {
        int[] input = [1, 2];

        int[] result = TopKFrequentElements.FindElements(input, 5);

        Assert.Equal([2, 1], result);
    }

    /// <summary>
    /// Tests when k equals the total number of unique elements.
    /// </summary>
    [Fact]
    public void KEqualsUniqueElements_ReturnsAllOrderedByFrequencyThenValue()
    {
        int[] input = [3, 3, 2, 2, 1];

        int[] result = TopKFrequentElements.FindElements(input, 3);

        Assert.Equal([3, 2, 1], result);
    }
}
