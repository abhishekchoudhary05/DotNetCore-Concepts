using DotNetCore_Concepts.Questions.Array;

namespace DotNetCore_Concepts.Tests.Questions.Array;

public class ContainerWithMostWaterTests
{
    [Fact]
    public void NullInput_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => ContainerWithMostWater.FindMaximum(null!));
    }

    [Theory]
    [InlineData(new int[] { }, 0L)]
    [InlineData(new[] { 5 }, 0L)]
    [InlineData(new[] { 0, 0 }, 0L)]
    [InlineData(new[] { 3, 7 }, 3L)]
    [InlineData(new[] { 7, 3 }, 3L)]
    [InlineData(new[] { 5, 5 }, 5L)]
    public void SmallInputs_ReturnExpectedArea(int[] heights, long expected)
    {
        Assert.Equal(expected, ContainerWithMostWater.FindMaximum(heights));
    }

    [Theory]
    [InlineData(new[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 }, 49L)]
    [InlineData(new[] { 1, 2, 3, 4, 5 }, 6L)]
    [InlineData(new[] { 5, 4, 3, 2, 1 }, 6L)]
    [InlineData(new[] { 4, 4, 4, 4 }, 12L)]
    [InlineData(new[] { 0, 5, 0, 5 }, 10L)]
    [InlineData(new[] { 10, 1, 1, 1, 10 }, 40L)]
    [InlineData(new[] { 2, 3, 4, 5, 18, 17, 6 }, 17L)]
    public void MultipleHeights_ReturnsMaximumArea(int[] heights, long expected)
    {
        Assert.Equal(expected, ContainerWithMostWater.FindMaximum(heights));
    }

    [Fact]
    public void LargeHeights_ReturnsAreaWithoutIntOverflow()
    {
        int[] heights = [int.MaxValue, int.MaxValue, int.MaxValue];

        long result = ContainerWithMostWater.FindMaximum(heights);

        Assert.Equal(2L * int.MaxValue, result);
    }
}
