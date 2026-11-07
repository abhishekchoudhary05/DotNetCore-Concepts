using System;
using Xunit;
using DotNetCore_Concepts.Questions.Array;

namespace DotNetCore_Concepts.Tests.Questions.Array
{
    /// <summary>
    /// Comprehensive test suite for <see cref="PivotIndex"/> covering:
    /// - <see cref="PivotIndex.FindPivotIndex(int[])"/> (Brute-Force O(n²))
    /// - <see cref="PivotIndex.FindPivotIndexOptimal(int[])"/> (Optimal O(n))
    /// </summary>
    public class PivotIndexTests
    {
        #region BruteForce Tests - FindPivotIndex

        [Fact]
        public void FindPivotIndex_NullArray_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => PivotIndex.FindPivotIndex(null!));
        }

        [Fact]
        public void FindPivotIndex_EmptyArray_ReturnsNegativeOne()
        {
            int[] arr = [];
            int result = PivotIndex.FindPivotIndex(arr);
            Assert.Equal(-1, result);
        }

        [Theory]
        [InlineData(new int[] { 10 }, 0)]
        [InlineData(new int[] { -5 }, 0)]
        [InlineData(new int[] { 0 }, 0)]
        public void FindPivotIndex_SingleElement_ReturnsZero(int[] arr, int expected)
        {
            int result = PivotIndex.FindPivotIndex(arr);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(new int[] { 0, 5 }, 1)]
        [InlineData(new int[] { 5, 0 }, 0)]
        [InlineData(new int[] { 1, 2 }, -1)]
        [InlineData(new int[] { 0, 0 }, 0)]
        public void FindPivotIndex_TwoElements_ReturnsExpected(int[] arr, int expected)
        {
            int result = PivotIndex.FindPivotIndex(arr);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void FindPivotIndex_PivotInMiddle_ReturnsCorrectIndex()
        {
            // Left sum = 1 + 7 + 3 = 11, Right sum = 5 + 6 = 11 -> Index 3
            int[] arr = [1, 7, 3, 6, 5, 6];
            int result = PivotIndex.FindPivotIndex(arr);
            Assert.Equal(3, result);
        }

        [Fact]
        public void FindPivotIndex_PivotAtStart_ReturnsZero()
        {
            // Left sum = 0, Right sum = 1 + (-1) = 0 -> Index 0
            int[] arr = [2, 1, -1];
            int result = PivotIndex.FindPivotIndex(arr);
            Assert.Equal(0, result);
        }

        [Fact]
        public void FindPivotIndex_PivotAtEnd_ReturnsLastIndex()
        {
            // Left sum = -1 + 1 = 0, Right sum = 0 -> Index 2
            int[] arr = [-1, 1, 2];
            int result = PivotIndex.FindPivotIndex(arr);
            Assert.Equal(2, result);
        }

        [Fact]
        public void FindPivotIndex_NoPivotExists_ReturnsNegativeOne()
        {
            int[] arr = [1, 2, 3];
            int result = PivotIndex.FindPivotIndex(arr);
            Assert.Equal(-1, result);
        }

        [Theory]
        [InlineData(new int[] { -1, -1, -1, -1, -1, 0 }, 2)]
        [InlineData(new int[] { -1, -1, 0, 1, 1, 0 }, 5)]
        [InlineData(new int[] { -1, -1, 1, 1, 0, 0 }, 4)]
        public void FindPivotIndex_NegativeAndMixedNumbers_ReturnsCorrectIndex(int[] arr, int expected)
        {
            int result = PivotIndex.FindPivotIndex(arr);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void FindPivotIndex_AllZeros_ReturnsFirstIndex()
        {
            // Any index is a valid pivot; must return the leftmost (index 0)
            int[] arr = [0, 0, 0];
            int result = PivotIndex.FindPivotIndex(arr);
            Assert.Equal(0, result);
        }

        [Fact]
        public void FindPivotIndex_MultipleValidPivots_ReturnsLeftmostPivot()
        {
            // For [0, 0, 0, 0], index 0 is valid (0 == 0), index 1 is valid (0 == 0), etc.
            int[] arr = [0, 0, 0, 0];
            int result = PivotIndex.FindPivotIndex(arr);
            Assert.Equal(0, result);
        }

        [Fact]
        public void FindPivotIndex_LargeValues_HandlesCorrectly()
        {
            int[] arr = [1000, 2000, 3000, 99999, 4000, 2000];
            // Left: 1000 + 2000 + 3000 = 6000
            // Right: 4000 + 2000 = 6000
            // Pivot index = 3
            int result = PivotIndex.FindPivotIndex(arr);
            Assert.Equal(3, result);
        }

        #endregion

        #region Optimal Tests - FindPivotIndexOptimal

        [Fact]
        public void FindPivotIndexOptimal_NullArray_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => PivotIndex.FindPivotIndexOptimal(null!));
        }

        [Fact]
        public void FindPivotIndexOptimal_EmptyArray_ReturnsNegativeOne()
        {
            int[] arr = [];
            int result = PivotIndex.FindPivotIndexOptimal(arr);
            Assert.Equal(-1, result);
        }

        [Theory]
        [InlineData(new int[] { 10 }, 0)]
        [InlineData(new int[] { -5 }, 0)]
        [InlineData(new int[] { 0 }, 0)]
        public void FindPivotIndexOptimal_SingleElement_ReturnsZero(int[] arr, int expected)
        {
            int result = PivotIndex.FindPivotIndexOptimal(arr);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(new int[] { 0, 5 }, 1)]
        [InlineData(new int[] { 5, 0 }, 0)]
        [InlineData(new int[] { 1, 2 }, -1)]
        [InlineData(new int[] { 0, 0 }, 0)]
        public void FindPivotIndexOptimal_TwoElements_ReturnsExpected(int[] arr, int expected)
        {
            int result = PivotIndex.FindPivotIndexOptimal(arr);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void FindPivotIndexOptimal_PivotInMiddle_ReturnsCorrectIndex()
        {
            int[] arr = [1, 7, 3, 6, 5, 6];
            int result = PivotIndex.FindPivotIndexOptimal(arr);
            Assert.Equal(3, result);
        }

        [Fact]
        public void FindPivotIndexOptimal_PivotAtStart_ReturnsZero()
        {
            int[] arr = [2, 1, -1];
            int result = PivotIndex.FindPivotIndexOptimal(arr);
            Assert.Equal(0, result);
        }

        [Fact]
        public void FindPivotIndexOptimal_PivotAtEnd_ReturnsLastIndex()
        {
            int[] arr = [-1, 1, 2];
            int result = PivotIndex.FindPivotIndexOptimal(arr);
            Assert.Equal(2, result);
        }

        [Fact]
        public void FindPivotIndexOptimal_NoPivotExists_ReturnsNegativeOne()
        {
            int[] arr = [1, 2, 3];
            int result = PivotIndex.FindPivotIndexOptimal(arr);
            Assert.Equal(-1, result);
        }

        [Theory]
        [InlineData(new int[] { -1, -1, -1, -1, -1, 0 }, 2)]
        [InlineData(new int[] { -1, -1, 0, 1, 1, 0 }, 5)]
        [InlineData(new int[] { -1, -1, 1, 1, 0, 0 }, 4)]
        public void FindPivotIndexOptimal_NegativeAndMixedNumbers_ReturnsCorrectIndex(int[] arr, int expected)
        {
            int result = PivotIndex.FindPivotIndexOptimal(arr);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void FindPivotIndexOptimal_AllZeros_ReturnsFirstIndex()
        {
            int[] arr = [0, 0, 0];
            int result = PivotIndex.FindPivotIndexOptimal(arr);
            Assert.Equal(0, result);
        }

        [Fact]
        public void FindPivotIndexOptimal_MultipleValidPivots_ReturnsLeftmostPivot()
        {
            int[] arr = [0, 0, 0, 0];
            int result = PivotIndex.FindPivotIndexOptimal(arr);
            Assert.Equal(0, result);
        }

        [Fact]
        public void FindPivotIndexOptimal_LargeValues_HandlesCorrectly()
        {
            int[] arr = [1000, 2000, 3000, 99999, 4000, 2000];
            int result = PivotIndex.FindPivotIndexOptimal(arr);
            Assert.Equal(3, result);
        }

        #endregion

        #region Consistency Tests

        [Theory]
        [InlineData(new int[] { 1, 7, 3, 6, 5, 6 })]
        [InlineData(new int[] { 1, 2, 3 })]
        [InlineData(new int[] { 2, 1, -1 })]
        [InlineData(new int[] { -1, 1, 2 })]
        [InlineData(new int[] { 0, 0, 0 })]
        [InlineData(new int[] { 0, 5 })]
        [InlineData(new int[] { 5, 0 })]
        [InlineData(new int[] { 42 })]
        [InlineData(new int[] { -1, -1, -1, -1, -1, 0 })]
        public void BothImplementations_ProduceIdenticalResults(int[] arr)
        {
            int bruteForce = PivotIndex.FindPivotIndex(arr);
            int optimal = PivotIndex.FindPivotIndexOptimal(arr);

            Assert.Equal(bruteForce, optimal);
        }

        #endregion
    }
}
