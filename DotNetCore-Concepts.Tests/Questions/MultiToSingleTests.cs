using Xunit;
using InterviewPrepration.Questions;

namespace DotNetCore_Concepts.Tests.Questions;

/// <summary>
/// Tests for MultiToSingleQuestion which flattens a 2D (rectangular) array into a 1D array.
/// Algorithm:
/// - Reads width (rows) and height (columns) via GetLength
/// - Iterates column-first (y outer, x inner) and writes each element into a flat array
/// - The result is printed to the console, so the test verifies the call completes without throwing
/// - Time complexity: O(rows * columns)
/// </summary>
public class MultiToSingleTests
{
    /// <summary>
    /// Tests flattening a 2x2 matrix into a single dimension.
    /// Input { { 1, 2 }, { 3, 4 } } produces the flat sequence 1, 2, 3, 4.
    /// </summary>
    [Fact]
    public void MultiToSingle_ValidInput_Test()
    {
        // The method prints the flattened values to the console
        int[,] input = new int[,] { { 1, 2 }, { 3, 4 } };
        MultiToSingleQuestion.MultiToSingle(input);
    }
}