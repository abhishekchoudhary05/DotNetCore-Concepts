using Xunit;
using InterviewPrepration.Concepts;

namespace DotNetCore_Concepts.Tests.Concepts;

public class MethodOverridingTests
{
    [Fact]
    public void MethodOverriding_ParentClassDisplay_Test()
    {
        var parent = new Parent();
        parent.Display(); // Should print "Parent class Display method"
    }

    [Fact]
    public void MethodOverriding_DerivedClassDisplay_Test()
    {
        var derived = new Derived();
        derived.Display(); // Should print "Derived class Display method"
    }
}