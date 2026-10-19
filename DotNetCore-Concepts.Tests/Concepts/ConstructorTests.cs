using Xunit;
using InterviewPrepration.Concepts;

namespace DotNetCore_Concepts.Tests.Concepts;

public class ConstructorTests
{
    [Fact]
    public void Constructor_DefaultConstructor_Test()
    {
        // Test that default constructor works
        Constructor constructor = new Constructor();
        // Constructor should not throw exception
    }

    [Fact]
    public void Constructor_ParameterizedConstructor_Test()
    {
        // Test parameterized constructor
        Constructor constructor = new Constructor("test");
    }

    [Fact]
    public void Constructor_StaticConstructor_Test()
    {
        // Static constructor is called automatically, just verify it exists
        // Static constructor in C# is called implicitly
    }
}