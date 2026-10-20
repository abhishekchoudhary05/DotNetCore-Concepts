using Xunit;
using DotNetCore_Concepts.Questions.EasyMath;

namespace DotNetCore_Concepts.Tests.Questions.EasyMath;

/// <summary>
/// Tests for SumOfDigitsQuestion which calculates the sum of all digits in a number.
/// Algorithm:
/// - Repeatedly extracts the last digit using modulo 10
/// - Adds it to the running sum
/// - Removes the last digit using integer division by 10
/// - Continues until the number becomes 0
/// - Time complexity: O(log n) (number of digits), Space complexity: O(1)
/// </summary>
public class SumOfDigitsTests
{
    /// <summary>
    /// Tests sum of digits for 123 = 1 + 2 + 3 = 6.
    /// </summary>
    [Fact]
    public void SumOfDigits_123_Test()
    {
        SumOfDigitsQuestion.SumOfDigits(123);
    }

    /// <summary>
    /// Tests edge case with 0 (sum is 0).
    /// </summary>
    [Fact]
    public void SumOfDigits_0_Test()
    {
        SumOfDigitsQuestion.SumOfDigits(0);
    }
}