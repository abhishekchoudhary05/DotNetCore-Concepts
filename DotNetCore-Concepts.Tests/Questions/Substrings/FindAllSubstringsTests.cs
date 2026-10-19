using Xunit;
using DotNetCore_Concepts.Questions.Substrings;

namespace DotNetCore_Concepts.Tests.Questions.Substrings;

public class FindAllSubstringsTests
{
    [Fact]
    public void FindAllSubstrings_ValidInput_Test()
    {
        // This method prints to Console
        FindAllSubstringsQuestion.FindAllSubstrings("abc");
    }
}