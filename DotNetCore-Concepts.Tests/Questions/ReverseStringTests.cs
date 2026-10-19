using Xunit;
using InterviewPrepration.Questions;

namespace DotNetCore_Concepts.Tests.Questions;

public class ReverseStringTests
{
    [Fact]
    public void ReverseString_ValidString_Test()
    {
        string input = "Hello";
        string result = ReverseStringQuestion.ReverseString(input);
        Assert.Equal("olleH", result);
    }

    [Fact]
    public void ReverseString_EmptyString_Test()
    {
        string result = ReverseStringQuestion.ReverseString("");
        Assert.Equal("", result);
    }

    [Fact]
    public void ReverseString_NullInput_Test()
    {
        Assert.Throws<ArgumentNullException>(() => ReverseStringQuestion.ReverseString(null));
    }
}