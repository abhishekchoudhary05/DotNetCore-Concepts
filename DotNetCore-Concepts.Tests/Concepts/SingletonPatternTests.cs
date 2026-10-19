using Xunit;
using InterviewPrepration.Concepts;

namespace DotNetCore_Concepts.Tests.Concepts;

public class SingletonPatternTests
{
    [Fact]
    public void SingletonPattern_GetObject_Test()
    {
        var obj1 = SingletonPattern.GetObject();
        var obj2 = SingletonPattern.GetObject();
        Assert.Equal(obj1, obj2); // Should be the same instance
    }
}