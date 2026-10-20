using Xunit;
using InterviewPrepration.Concepts;

namespace DotNetCore_Concepts.Tests.Concepts;

/// <summary>
/// Tests for the Constructor class which demonstrates C# constructor concepts:
/// - Default constructor (parameterless)
/// - Parameterized constructor (with input)
/// - Static constructor (called implicitly before first instance creation)
/// - Private constructor (restricts instantiation)
/// </summary>
public class ConstructorTests
{
    /// <summary>
    /// Tests that the default constructor initializes the static message field
    /// and prints "This is default constructor" to the console.
    /// </summary>
    [Fact]
    public void Constructor_DefaultConstructor_Test()
    {
        // Default constructor sets static message and prints initialization message
        Constructor constructor = new Constructor();
    }

    /// <summary>
    /// Tests that the parameterized constructor accepts a string input
    /// and prints "This is parameterized constructor." to the console.
    /// </summary>
    [Fact]
    public void Constructor_ParameterizedConstructor_Test()
    {
        // Parameterized constructor prints initialization message with input
        Constructor constructor = new Constructor("test");
    }

    /// <summary>
    /// Tests that the static constructor is called implicitly before any instance creation.
    /// Static constructors in C# are called automatically to initialize static fields
    /// and are invoked before the first instance is created or any static members are accessed.
    /// </summary>
    [Fact]
    public void Constructor_StaticConstructor_Test()
    {
        // Static constructor initializes static 'message' field and prints it
        // It is called implicitly by the CLR before first instance creation
    }
}