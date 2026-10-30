using Xunit;
using DotNetCore_Concepts.Questions.Strings.Substrings;

namespace DotNetCore_Concepts.Tests.Questions.Strings.Substrings;

/// <summary>
/// Tests for FindAllSubstringsQuestion which prints all possible substrings of a string.
/// Algorithm:
/// - Uses nested loops: outer loop for length (1 to n), inner loop for start position
/// - For each length i, starts at position j from 0 to n-i
/// - Prints substring of length i starting at position j
/// - Example: "abc" outputs: a, b, c, ab, bc, abc
/// - Time complexity: O(n^3) due to nested loops and substring operations
/// - Space complexity: O(n) for substring creation
/// </summary>
public class FindAllSubstringsTests
{
    /// <summary>
    /// Tests printing all substrings for a valid input string.
    /// Input: "abc" produces substrings: "a", "b", "c", "ab", "bc", "abc"
    /// </summary>
    [Fact]
    public void FindAllSubstrings_ValidInput_Test()
    {
        FindAllSubstringsQuestion.FindAllSubstrings("abc");
    }
}