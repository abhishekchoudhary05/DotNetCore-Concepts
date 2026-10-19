using Xunit;
using InterviewPrepration.Questions;

namespace DotNetCore_Concepts.Tests.Questions;

public class ReverseStringInPlaceTests
{
    [Fact]
    public void ReverseStringInPlace_ValidInput_Test()
    {
        char[] input = new char[] { 'H', 'e', 'l', 'l', 'o' };
        char[] result = ReverseStringInPlaceQuestion.ReverString_InPlace(input);
        Assert.Equal(new char[] { 'o', 'l', 'l', 'e', 'H' }, result);
    }

    [Fact]
    public void ReverseStringInPlace_EmptyInput_Test()
    {
        char[] input = Array.Empty<char>();
        char[] result = ReverseStringInPlaceQuestion.ReverString_InPlace(input);
        Assert.Empty(result);
    }
}