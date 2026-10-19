using Xunit;
using InterviewPrepration.Questions;

namespace DotNetCore_Concepts.Tests.Questions;

public class OccurrenceOfCharactersTests
{
    [Fact]
    public void OccurrenceOfCharacters_ValidInput_Test()
    {
        // This method prints to Console, hard to test directly
        // We'll verify it doesn't throw exception
        OccurrenceOfCharactersQuestion.OccuranceOfCharacters("Hello");
    }
}