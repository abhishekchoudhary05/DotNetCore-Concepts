using Xunit;
using InterviewPrepration.Questions;

namespace DotNetCore_Concepts.Tests.Questions;

public class FindSecondHighestTests
{
    [Fact]
    public void FindSecondHighest_ValidInput_Test()
    {
        int[] input = new int[] { 10, 20, 30, 20, 40 };
        int result = FindSecondHighestQuestion.FindSecondHighest(input);
        Assert.Equal(30, result);
    }

    [Fact]
    public void FindSecondHighest_NoDistinctSecondHighest_Test()
    {
        int[] input = new int[] { 10, 10, 10 };
        Assert.Throws<ArgumentException>(() => FindSecondHighestQuestion.FindSecondHighest(input));
    }

    [Fact]
    public void FindSecondHighest_NullInput_Test()
    {
        Assert.Throws<ArgumentNullException>(() => FindSecondHighestQuestion.FindSecondHighest(null));
    }
}