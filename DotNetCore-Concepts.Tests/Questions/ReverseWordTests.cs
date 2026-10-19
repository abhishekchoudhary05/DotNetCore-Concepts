using Xunit;
using InterviewPrepration.Questions;

namespace DotNetCore_Concepts.Tests.Questions;

public class ReverseWordTests
{
    [Fact]
    public void ReverseWord_ValidInput_Test()
    {
        // Similar to above, this prints to Console
        ReverseWordQuestion.ReverseWord("Hello World");
    }
}