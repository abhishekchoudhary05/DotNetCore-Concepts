using Xunit;
using DotNetCore_Concepts.Questions.EasyMath;

namespace DotNetCore_Concepts.Tests.Questions.EasyMath;

public class IsPrimeTests
{
    [Fact]
    public void IsPrime_7_Test()
    {
        // 7 is prime
        IsPrimeQuestion.IsPrime(7);
    }

    [Fact]
    public void IsPrime_10_Test()
    {
        // 10 is not prime
        IsPrimeQuestion.IsPrime(10);
    }

    [Fact]
    public void IsPrime_1_Test()
    {
        // 1 is not prime (edge case)
        IsPrimeQuestion.IsPrime(1);
    }
}