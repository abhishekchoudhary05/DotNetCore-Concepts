using Xunit;
using DotNetCore_Concepts.Questions.EasyMath;

namespace DotNetCore_Concepts.Tests.Questions.EasyMath;

/// <summary>
/// Tests for IsPrimeQuestion which determines if a number is prime.
/// Algorithm:
/// - Numbers ≤ 1 are not prime (edge case)
/// - Checks divisibility from 2 up to sqrt(number)
/// - If any divisor is found, number is not prime
/// - Time complexity: O(sqrt(n)), Space complexity: O(1)
/// </summary>
public class IsPrimeTests
{
    /// <summary>
    /// Tests that 7 is correctly identified as prime.
    /// </summary>
    [Fact]
    public void IsPrime_7_Test()
    {
        IsPrimeQuestion.IsPrime(7);
    }

    /// <summary>
    /// Tests that 10 is correctly identified as not prime (divisible by 2 and 5).
    /// </summary>
    [Fact]
    public void IsPrime_10_Test()
    {
        IsPrimeQuestion.IsPrime(10);
    }

    /// <summary>
    /// Tests that 1 is correctly identified as not prime (edge case).
    /// </summary>
    [Fact]
    public void IsPrime_1_Test()
    {
        IsPrimeQuestion.IsPrime(1);
    }
}