using Xunit;
using InterviewPrepration.Questions;

namespace DotNetCore_Concepts.Tests.Questions;

public class MultiToSingleTests
{
    [Fact]
    public void MultiToSingle_ValidInput_Test()
    {
        // This method prints to Console
        int[,] input = new int[,] { { 1, 2 }, { 3, 4 } };
        MultiToSingleQuestion.MultiToSingle(input);
    }
}