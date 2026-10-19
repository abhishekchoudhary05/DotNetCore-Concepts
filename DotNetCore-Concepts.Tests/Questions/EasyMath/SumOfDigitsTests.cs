using Xunit;
using DotNetCore_Concepts.Questions.EasyMath;

namespace DotNetCore_Concepts.Tests.Questions.EasyMath;

public class SumOfDigitsTests
{
    [Fact]
    public void SumOfDigits_123_Test()
    {
        // Sum of digits in 123 = 1 + 2 + 3 = 6
        SumOfDigitsQuestion.SumOfDigits(123);
    }

    [Fact]
    public void SumOfDigits_0_Test()
    {
        // Edge case: 0
        SumOfDigitsQuestion.SumOfDigits(0);
    }
}