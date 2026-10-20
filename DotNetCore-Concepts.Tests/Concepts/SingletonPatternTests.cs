using Xunit;
using InterviewPrepration.Concepts;

namespace DotNetCore_Concepts.Tests.Concepts;

/// <summary>
/// Tests for the Singleton design pattern which ensures:
/// - A class has only one instance in the application domain
/// - Provides global access to that instance
/// - Uses private constructor to prevent external instantiation
/// - Uses lazy initialization (instance created on first request)
/// </summary>
public class SingletonPatternTests
{
    /// <summary>
    /// Tests that GetObject() returns the same instance on multiple calls.
    /// This verifies the singleton behavior - only one instance exists per application domain.
    /// </summary>
    [Fact]
    public void SingletonPattern_GetObject_Test()
    {
        var obj1 = SingletonPattern.GetObject();
        var obj2 = SingletonPattern.GetObject();
        Assert.Equal(obj1, obj2); // Both references point to the same instance
    }
}