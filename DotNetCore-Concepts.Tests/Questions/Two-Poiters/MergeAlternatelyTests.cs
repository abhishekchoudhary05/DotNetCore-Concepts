using Xunit;
using DotNetCore_Concepts.Questions.Two_Poiters;

namespace DotNetCore_Concepts.Tests.Questions.Two_Poiters;

/// <summary>
/// Tests for MergeAlternately which merges two strings by alternating characters.
/// Algorithm:
/// - Creates a result char array of length word1.Length + word2.Length
/// - Alternates characters from word1 and word2, starting with word1
/// - Handles different length strings gracefully
/// - Time complexity: O(n + m), Space complexity: O(n + m) for result
/// </summary>
public class MergeAlternatelyTests
{
    /// <summary>
    /// Tests merging two equal-length strings.
    /// Example: Merge("abc", "def") alternates characters: a-d-b-e-c-f = "adbecf"
    /// </summary>
    [Fact]
    public void MergeAlternately_ValidInput_Test()
    {
        string result = MergeAlternately.Merge("abc", "def");
        Assert.Equal("adbecf", result);
    }

    /// <summary>
    /// Tests merging with one empty string - returns the other string unchanged.
    /// Example: Merge("abc", "") returns "abc"
    /// </summary>
    [Fact]
    public void MergeAlternately_OneEmptyString_Test()
    {
        string result = MergeAlternately.Merge("abc", "");
        Assert.Equal("abc", result);
    }
}