using Xunit;
using InterviewPrepration.Concepts;

namespace DotNetCore_Concepts.Tests.Concepts;

/// <summary>
/// Tests for method hiding in C# which demonstrates:
/// - New keyword used in derived class to hide base class method
/// - Difference from method overriding (which uses override keyword)
/// - With hiding, the base method is completely replaced, not called polymorphically
/// - Static binding determines which method is called based on reference type
/// </summary>
public class MethodHidingTests
{
    /// <summary>
    /// Tests that calling Display() on a BaseClass instance executes the BaseClass implementation.
    /// </summary>
    [Fact]
    public void MethodHiding_BaseClassDisplay_Test()
    {
        var baseClass = new BaseClass();
        baseClass.Display(); // Prints "Base class Display method"
    }

    /// <summary>
    /// Tests that calling Display() on a DerivedClass instance executes the hidden DerivedClass implementation.
    /// The 'new' keyword hides the base method rather than overriding it.
    /// </summary>
    [Fact]
    public void MethodHiding_DerivedClassDisplay_Test()
    {
        var derivedClass = new DerivedClass();
        derivedClass.Display(); // Prints "Derived class Display method"
    }
}