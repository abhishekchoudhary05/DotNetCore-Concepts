using Xunit;
using InterviewPrepration.Concepts;

namespace DotNetCore_Concepts.Tests.Concepts;

public class MethodHidingTests
{
    [Fact]
    public void MethodHiding_BaseClassDisplay_Test()
    {
        var baseClass = new BaseClass();
        baseClass.Display(); // Should print "Base class Display method"
    }

    [Fact]
    public void MethodHiding_DerivedClassDisplay_Test()
    {
        var derivedClass = new DerivedClass();
        derivedClass.Display(); // Should print "Derived class Display method"
    }
}