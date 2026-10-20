using Xunit;
using InterviewPrepration.Questions;

namespace DotNetCore_Concepts.Tests.Questions;

/// <summary>
/// Tests for OccurrenceOfCharactersQuestion which counts the frequency of each character in a string.
/// Algorithm:
/// - Uses a Dictionary<char, int> to track character counts
/// - Iterates through each character, incrementing its count in the dictionary
/// - Prints each character and its count to the console
/// - Time complexity: O(n), Space complexity: O(k) where k is number of unique characters
/// </summary>
public class OccurrenceOfCharactersTests
{
    /// <summary>
    /// Tests counting character occurrences in a valid string.
    /// Example: "Hello" outputs H:1, e:1, l:2, o:1
    /// </summary>
    [Fact]
    public void OccurrenceOfCharacters_ValidInput_Test()
    {
        OccurrenceOfCharactersQuestion.OccuranceOfCharacters("Hello");
    }
}