using Xunit;
using DotNetCore_Concepts.Questions.HashMap;

namespace DotNetCore_Concepts.Tests.Questions.HashMap;

public class TwoSumTests
{
    [Fact]
    public void TwoSum_ValidInput_Test()
    {
        int[] input = [2, 7, 11, 15];
        int target = 9;
        int[] result = TwoSum.FindElements(input, target);
        Assert.Equal([0, 1], result);
    }

    [Fact]
    public void TwoSum_NoSolution_Test()
    {
        int[] input = [1, 2, 3];
        int target = 7;
        int[] result = TwoSum.FindElements(input, target);
        Assert.Equal([0, 0], result); // Returns [0, 0] when no solution
    }

    [Fact]
    public void TwoSum_NullInput_Test()
    {
        Assert.Throws<ArgumentNullException>(() => TwoSum.FindElements(null, 5));
    }
}