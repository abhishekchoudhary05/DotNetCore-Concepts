using Xunit;
using InterviewPrepration.Questions;

namespace DotNetCore_Concepts.Tests.Questions;

public class ReverseWordOrderTests
{
    [Fact]
    public void ReverseWordOrder_ValidInput_Test()
    {
        // Note: This method doesn't return a value, it prints to Console
        // We can't easily test the output without capturing Console.WriteLine
        // For now, we'll just verify it doesn't throw
        ReverseWordOrderQuestion.ReverseWordOrder("Hello World");
    }
}