using Xunit;
using InterviewPrepration.Questions;

namespace DotNetCore_Concepts.Tests.Questions;

public class LeftCirculationTests
{
    [Fact]
    public void LeftCirculation_ValidInput_Test()
    {
        int[] input = new int[] { 1, 2, 3, 4 };
        LeftCirculationQuestion.LeftCirculation(input);
        Assert.Equal(new int[] { 2, 3, 4, 1 }, input);
    }

    [Fact]
    public void LeftCirculation_NullInput_Test()
    {
        Assert.Throws<ArgumentNullException>(() => LeftCirculationQuestion.LeftCirculation<int>(null));
    }
}