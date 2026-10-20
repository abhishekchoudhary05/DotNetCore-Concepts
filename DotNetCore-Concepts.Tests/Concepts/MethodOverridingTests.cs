using Xunit;
using InterviewPrepration.Concepts;

namespace DotNetCore_Concepts.Tests.Concepts;

/// <summary>
/// Tests for method overriding in C# which demonstrates:
/// - Virtual method in base class (Parent) marked with 'virtual' keyword
/// - Override method in derived class (Derived) marked with 'override' keyword
/// - Polymorphism: overriding provides a new implementation of an inherited method
/// </summary>
public class MethodOverridingTests
{
    /// <summary>
    /// Tests that calling Display() on a Parent instance executes the Parent's implementation.
    /// The virtual keyword allows the method to be overridden in derived classes.
    /// </summary>
    [Fact]
    public void MethodOverriding_ParentClassDisplay_Test()
    {
        var parent = new Parent();
        parent.Display(); // Prints "Parent class Display method"
    }

    /// <summary>
    /// Tests that calling Display() on a Derived instance executes the Derived's overridden implementation.
    /// The override keyword replaces the virtual method from the base class with a new implementation.
    /// </summary>
    [Fact]
    public void MethodOverriding_DerivedClassDisplay_Test()
    {
        var derived = new Derived();
        derived.Display(); // Prints "Derived class Display method"
    }
}