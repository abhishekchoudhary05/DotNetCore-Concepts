using System;
using Xunit;
using DotNetCore_Concepts.Questions.Array;

namespace DotNetCore_Concepts.Tests.Questions.Array
{
    public class MaximumSubarrayTests
    {
        #region BruteForce Tests - FindMaximumSumFromSubarray

        [Fact]
        public void BruteForce_SimplePositiveArray_ReturnsMaxSum()
        {
            // [5, -4, -1, -3, 7, -1, 2] → max is [7, -1, 2] = 8 (or [5, -4, -1, -3, 7] = 4, or just [7, -1, 2] = 8)
            // Actually: 5 by itself=5, 5-4=1, 5-4-1=0, 5-4-1-3=−3, 5-4-1-3+7=4, 5-4-1-3+7-1=3, 5-4-1-3+7-1+2=5
            // Also: -4=−4, -4-1=−5, -4-1-3=−8, -4-1-3+7=0, so 7 by itself = 7, 7-1=6, 7-1+2=8
            // Max is 8 ([7, -1, 2])
            int[] arr = { 5, -4, -1, -3, 7, -1, 2 };
            int result = MaximumSubAarray.FindMaximumSumFromSubarray(arr);
            Assert.Equal(8, result);
        }

        [Fact]
        public void BruteForce_MixedWithMultiElementMax_ReturnsCorrectSum()
        {
            // [-2, 1, -3, 4, -1, 2, 1, -5, 4] → max is [4, -1, 2, 1] = 6
            int[] arr = { -2, 1, -3, 4, -1, 2, 1, -5, 4 };
            int result = MaximumSubAarray.FindMaximumSumFromSubarray(arr);
            Assert.Equal(6, result);
        }

        [Fact]
        public void BruteForce_AllNegativeNumbers_ReturnsLargestNegative()
        {
            // [-5, -3, -8] → max is [-3] = -3
            int[] arr = { -5, -3, -8 };
            int result = MaximumSubAarray.FindMaximumSumFromSubarray(arr);
            Assert.Equal(-3, result);
        }

        [Fact]
        public void BruteForce_SingleElement_ReturnsThatElement()
        {
            // [7] → [7] = 7
            int[] arr = { 7 };
            int result = MaximumSubAarray.FindMaximumSumFromSubarray(arr);
            Assert.Equal(7, result);
        }

        [Fact]
        public void BruteForce_SingleNegativeElement_ReturnsThatElement()
        {
            // [-5] → [-5] = -5
            int[] arr = { -5 };
            int result = MaximumSubAarray.FindMaximumSumFromSubarray(arr);
            Assert.Equal(-5, result);
        }

        [Fact]
        public void BruteForce_TwoPositiveElements_ReturnsBoth()
        {
            // [3, 5] → [3, 5] = 8
            int[] arr = { 3, 5 };
            int result = MaximumSubAarray.FindMaximumSumFromSubarray(arr);
            Assert.Equal(8, result);
        }

        [Fact]
        public void BruteForce_TwoNegativeElements_ReturnsLargerNegative()
        {
            // [-3, -5] → [-3] = -3
            int[] arr = { -3, -5 };
            int result = MaximumSubAarray.FindMaximumSumFromSubarray(arr);
            Assert.Equal(-3, result);
        }

        [Fact]
        public void BruteForce_PositiveThenNegative_ReturnsPositive()
        {
            // [5, -10] → [5] = 5
            int[] arr = { 5, -10 };
            int result = MaximumSubAarray.FindMaximumSumFromSubarray(arr);
            Assert.Equal(5, result);
        }

        [Fact]
        public void BruteForce_NegativeThenPositive_ReturnsPositive()
        {
            // [-5, 10] → [10] = 10
            int[] arr = { -5, 10 };
            int result = MaximumSubAarray.FindMaximumSumFromSubarray(arr);
            Assert.Equal(10, result);
        }

        [Fact]
        public void BruteForce_AllPositives_ReturnSum()
        {
            // [1, 2, 3, 4, 5] → [1, 2, 3, 4, 5] = 15
            int[] arr = { 1, 2, 3, 4, 5 };
            int result = MaximumSubAarray.FindMaximumSumFromSubarray(arr);
            Assert.Equal(15, result);
        }

        [Fact]
        public void BruteForce_ZeroInArray_HandlesCorrectly()
        {
            // [0, -2, 3, 0, -1] → [3] = 3
            int[] arr = { 0, -2, 3, 0, -1 };
            int result = MaximumSubAarray.FindMaximumSumFromSubarray(arr);
            Assert.Equal(3, result);
        }

        [Fact]
        public void BruteForce_MultipleZeros_ReturnsZero()
        {
            // [0, 0, 0] → [0] = 0
            int[] arr = { 0, 0, 0 };
            int result = MaximumSubAarray.FindMaximumSumFromSubarray(arr);
            Assert.Equal(0, result);
        }

        [Fact]
        public void BruteForce_LargePositiveNumbers_ReturnsCorrectly()
        {
            // [1000000, -999999, 500000] → [1000000] = 1000000
            int[] arr = { 1000000, -999999, 500000 };
            int result = MaximumSubAarray.FindMaximumSumFromSubarray(arr);
            Assert.Equal(1000000, result);
        }

        [Fact]
        public void BruteForce_EmptyArray_ReturnsZero()
        {
            int[] arr = { };
            int result = MaximumSubAarray.FindMaximumSumFromSubarray(arr);
            Assert.Equal(0, result);
        }

        [Fact]
        public void BruteForce_NullArray_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => 
                MaximumSubAarray.FindMaximumSumFromSubarray(null));
        }

        #endregion

        #region Optimized Tests - FindMaximumSumFromSubarrayOptimized (Kadane's Algorithm)

        [Fact]
        public void Optimized_SimplePositiveArray_ReturnsMaxSum()
        {
            // [5, -4, -1, -3, 7, -1, 2] → max is [7, -1, 2] = 8
            int[] arr = { 5, -4, -1, -3, 7, -1, 2 };
            int result = MaximumSubAarray.FindMaximumSumFromSubarrayOptimized(arr);
            Assert.Equal(8, result);
        }

        [Fact]
        public void Optimized_MixedWithMultiElementMax_ReturnsCorrectSum()
        {
            // [-2, 1, -3, 4, -1, 2, 1, -5, 4] → max is [4, -1, 2, 1] = 6
            int[] arr = { -2, 1, -3, 4, -1, 2, 1, -5, 4 };
            int result = MaximumSubAarray.FindMaximumSumFromSubarrayOptimized(arr);
            Assert.Equal(6, result);
        }

        [Fact]
        public void Optimized_AllNegativeNumbers_ReturnsLargestNegative()
        {
            // [-5, -3, -8] → max is [-3] = -3
            int[] arr = { -5, -3, -8 };
            int result = MaximumSubAarray.FindMaximumSumFromSubarrayOptimized(arr);
            Assert.Equal(-3, result);
        }

        [Fact]
        public void Optimized_SingleElement_ReturnsThatElement()
        {
            // [7] → [7] = 7
            int[] arr = { 7 };
            int result = MaximumSubAarray.FindMaximumSumFromSubarrayOptimized(arr);
            Assert.Equal(7, result);
        }

        [Fact]
        public void Optimized_SingleNegativeElement_ReturnsThatElement()
        {
            // [-5] → [-5] = -5
            int[] arr = { -5 };
            int result = MaximumSubAarray.FindMaximumSumFromSubarrayOptimized(arr);
            Assert.Equal(-5, result);
        }

        [Fact]
        public void Optimized_TwoPositiveElements_ReturnsBoth()
        {
            // [3, 5] → [3, 5] = 8
            int[] arr = { 3, 5 };
            int result = MaximumSubAarray.FindMaximumSumFromSubarrayOptimized(arr);
            Assert.Equal(8, result);
        }

        [Fact]
        public void Optimized_TwoNegativeElements_ReturnsLargerNegative()
        {
            // [-3, -5] → [-3] = -3
            int[] arr = { -3, -5 };
            int result = MaximumSubAarray.FindMaximumSumFromSubarrayOptimized(arr);
            Assert.Equal(-3, result);
        }

        [Fact]
        public void Optimized_PositiveThenNegative_ReturnsPositive()
        {
            // [5, -10] → [5] = 5
            int[] arr = { 5, -10 };
            int result = MaximumSubAarray.FindMaximumSumFromSubarrayOptimized(arr);
            Assert.Equal(5, result);
        }

        [Fact]
        public void Optimized_NegativeThenPositive_ReturnsPositive()
        {
            // [-5, 10] → [10] = 10
            int[] arr = { -5, 10 };
            int result = MaximumSubAarray.FindMaximumSumFromSubarrayOptimized(arr);
            Assert.Equal(10, result);
        }

        [Fact]
        public void Optimized_AllPositives_ReturnSum()
        {
            // [1, 2, 3, 4, 5] → [1, 2, 3, 4, 5] = 15
            int[] arr = { 1, 2, 3, 4, 5 };
            int result = MaximumSubAarray.FindMaximumSumFromSubarrayOptimized(arr);
            Assert.Equal(15, result);
        }

        [Fact]
        public void Optimized_ZeroInArray_HandlesCorrectly()
        {
            // [0, -2, 3, 0, -1] → [3] = 3
            int[] arr = { 0, -2, 3, 0, -1 };
            int result = MaximumSubAarray.FindMaximumSumFromSubarrayOptimized(arr);
            Assert.Equal(3, result);
        }

        [Fact]
        public void Optimized_MultipleZeros_ReturnsZero()
        {
            // [0, 0, 0] → [0] = 0
            int[] arr = { 0, 0, 0 };
            int result = MaximumSubAarray.FindMaximumSumFromSubarrayOptimized(arr);
            Assert.Equal(0, result);
        }

        [Fact]
        public void Optimized_LargePositiveNumbers_ReturnsCorrectly()
        {
            // [1000000, -999999, 500000] → [1000000] = 1000000
            int[] arr = { 1000000, -999999, 500000 };
            int result = MaximumSubAarray.FindMaximumSumFromSubarrayOptimized(arr);
            Assert.Equal(1000000, result);
        }

        [Fact]
        public void Optimized_EmptyArray_ReturnsZero()
        {
            int[] arr = { };
            int result = MaximumSubAarray.FindMaximumSumFromSubarrayOptimized(arr);
            Assert.Equal(0, result);
        }

        [Fact]
        public void Optimized_NullArray_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => 
                MaximumSubAarray.FindMaximumSumFromSubarrayOptimized(null));
        }

        #endregion

        #region Comparison Tests - Both algorithms should return same result

        [Fact]
        public void BothAlgorithms_ComplexArray_ReturnSameResult()
        {
            int[] arr = { -2, 1, -3, 4, -1, 2, 1, -5, 4 };
            int bruteForce = MaximumSubAarray.FindMaximumSumFromSubarray(arr);
            int optimized = MaximumSubAarray.FindMaximumSumFromSubarrayOptimized(arr);
            Assert.Equal(bruteForce, optimized);
        }

        [Fact]
        public void BothAlgorithms_AllNegative_ReturnSameResult()
        {
            int[] arr = { -5, -3, -8, -1, -9 };
            int bruteForce = MaximumSubAarray.FindMaximumSumFromSubarray(arr);
            int optimized = MaximumSubAarray.FindMaximumSumFromSubarrayOptimized(arr);
            Assert.Equal(bruteForce, optimized);
        }

        [Fact]
        public void BothAlgorithms_SingleElement_ReturnSameResult()
        {
            int[] arr = { 42 };
            int bruteForce = MaximumSubAarray.FindMaximumSumFromSubarray(arr);
            int optimized = MaximumSubAarray.FindMaximumSumFromSubarrayOptimized(arr);
            Assert.Equal(bruteForce, optimized);
        }

        [Fact]
        public void BothAlgorithms_LargeArray_ReturnSameResult()
        {
            int[] arr = { 5, -4, -1, -3, 7, -1, 2, 6, -5, 3, 2, -1, 4 };
            int bruteForce = MaximumSubAarray.FindMaximumSumFromSubarray(arr);
            int optimized = MaximumSubAarray.FindMaximumSumFromSubarrayOptimized(arr);
            Assert.Equal(bruteForce, optimized);
        }

        #endregion

        #region Edge Cases

        [Fact]
        public void BruteForce_ArrayWithMax_ReturnsCorrectly()
        {
            // [-1, -2, -3, -4, 5, -6] → [5] = 5
            int[] arr = { -1, -2, -3, -4, 5, -6 };
            int result = MaximumSubAarray.FindMaximumSumFromSubarray(arr);
            Assert.Equal(5, result);
        }

        [Fact]
        public void Optimized_ArrayWithMax_ReturnsCorrectly()
        {
            // [-1, -2, -3, -4, 5, -6] → [5] = 5
            int[] arr = { -1, -2, -3, -4, 5, -6 };
            int result = MaximumSubAarray.FindMaximumSumFromSubarrayOptimized(arr);
            Assert.Equal(5, result);
        }

        [Fact]
        public void BruteForce_DecreasingThenIncreasing_ReturnsCorrectly()
        {
            // [5, 4, 3, 2, 1, -10, 10, 9, 8]
            // [5,4,3,2,1] = 15
            // [5,4,3,2,1,-10] = 5
            // [-10,10] = 0
            // [10,9,8] = 27
            // [10] = 10
            // Max is [5,4,3,2,1] = 15 or [10,9,8] = 27?
            // Let's compute: continuing from 5: 5,4,3,2,1,-10,10,9,8 checking all:
            // Actually [5,4,3,2,1] = 15, but continuing: [5,4,3,2,1,-10,10,9,8] = 5+4+3+2+1-10+10+9+8 = 32
            // So max is 32 ([5,4,3,2,1,-10,10,9,8])
            int[] arr = { 5, 4, 3, 2, 1, -10, 10, 9, 8 };
            int result = MaximumSubAarray.FindMaximumSumFromSubarray(arr);
            Assert.Equal(32, result);
        }

        [Fact]
        public void Optimized_DecreasingThenIncreasing_ReturnsCorrectly()
        {
            // [5, 4, 3, 2, 1, -10, 10, 9, 8] → [5,4,3,2,1,-10,10,9,8] = 32
            int[] arr = { 5, 4, 3, 2, 1, -10, 10, 9, 8 };
            int result = MaximumSubAarray.FindMaximumSumFromSubarrayOptimized(arr);
            Assert.Equal(32, result);
        }

        #endregion
    }
}
