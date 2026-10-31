using System;
using Xunit;
using DotNetCore_Concepts.Questions.Array;

namespace DotNetCore_Concepts.Tests.Array
{
    public class RotateArrayTests
    {
        [Fact]
        public void RotateArrayByKTimes_NullInput_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => RotateAraay.RotateArrayByKTimes(null, 2));
        }

        [Fact]
        public void RotateArrayByKTimes_EmptyArray_ReturnsEmpty()
        {
            int[] input = System.Array.Empty<int>();
            int[] result = RotateAraay.RotateArrayByKTimes(input, 2);
            Assert.Empty(result);
        }

        [Fact]
        public void RotateArrayByKTimes_SingleElement_ReturnsSame()
        {
            int[] input = new int[] { 5 };
            int[] result = RotateAraay.RotateArrayByKTimes(input, 2);
            Assert.Equal(new int[] { 5 }, result);
        }

        [Fact]
        public void RotateArrayByKTimes_KEqualsZero_ReturnsUnchanged()
        {
            int[] input = new int[] { 1, 2, 3, 4, 5 };
            int[] result = RotateAraay.RotateArrayByKTimes(input, 0);
            Assert.Equal(new int[] { 1, 2, 3, 4, 5 }, result);
        }

        [Fact]
        public void RotateArrayByKTimes_RotateByOne_ReturnsCorrectly()
        {
            int[] input = new int[] { 1, 2, 3, 4, 5 };
            int[] result = RotateAraay.RotateArrayByKTimes(input, 1);
            Assert.Equal(new int[] { 5, 1, 2, 3, 4 }, result);
        }

        [Fact]
        public void RotateArrayByKTimes_RotateByTwo_ReturnsCorrectly()
        {
            int[] input = new int[] { 1, 2, 3, 4, 5 };
            int[] result = RotateAraay.RotateArrayByKTimes(input, 2);
            Assert.Equal(new int[] { 4, 5, 1, 2, 3 }, result);
        }

        [Fact]
        public void RotateArrayByKTimes_RotateByThree_ReturnsCorrectly()
        {
            int[] input = new int[] { 1, 2, 3, 4, 5 };
            int[] result = RotateAraay.RotateArrayByKTimes(input, 3);
            Assert.Equal(new int[] { 3, 4, 5, 1, 2 }, result);
        }

        [Fact]
        public void RotateArrayByKTimes_KEqualsArrayLength_ReturnsUnchanged()
        {
            int[] input = new int[] { 1, 2, 3, 4, 5 };
            int[] result = RotateAraay.RotateArrayByKTimes(input, 5);
            Assert.Equal(new int[] { 1, 2, 3, 4, 5 }, result);
        }

        [Fact]
        public void RotateArrayByKTimes_KGreaterThanLength_RotatesCorrectly()
        {
            int[] input = new int[] { 1, 2, 3, 4, 5 };
            // k = 7, 7 % 5 = 2, so should rotate by 2
            int[] result = RotateAraay.RotateArrayByKTimes(input, 7);
            Assert.Equal(new int[] { 4, 5, 1, 2, 3 }, result);
        }

        [Fact]
        public void RotateArrayByKTimes_KMuchGreaterThanLength_RotatesCorrectly()
        {
            int[] input = new int[] { 1, 2, 3, 4, 5 };
            // k = 12, 12 % 5 = 2, so should rotate by 2
            int[] result = RotateAraay.RotateArrayByKTimes(input, 12);
            Assert.Equal(new int[] { 4, 5, 1, 2, 3 }, result);
        }

        [Fact]
        public void RotateArrayByKTimes_TwoElements_RotateByOne()
        {
            int[] input = new int[] { 1, 2 };
            int[] result = RotateAraay.RotateArrayByKTimes(input, 1);
            Assert.Equal(new int[] { 2, 1 }, result);
        }

        [Fact]
        public void RotateArrayByKTimes_WithNegativeNumbers()
        {
            int[] input = new int[] { -5, -3, -1, 0, 2 };
            int[] result = RotateAraay.RotateArrayByKTimes(input, 2);
            Assert.Equal(new int[] { 0, 2, -5, -3, -1 }, result);
        }

        [Fact]
        public void RotateArrayByKTimes_WithDuplicates()
        {
            int[] input = new int[] { 1, 1, 2, 2, 3 };
            int[] result = RotateAraay.RotateArrayByKTimes(input, 2);
            Assert.Equal(new int[] { 2, 3, 1, 1, 2 }, result);
        }

        [Fact]
        public void RotateArrayByKTimes_LargeArray()
        {
            int[] input = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int[] result = RotateAraay.RotateArrayByKTimes(input, 3);
            Assert.Equal(new int[] { 8, 9, 10, 1, 2, 3, 4, 5, 6, 7 }, result);
        }
    }

    public class RotateArrayOptimizedTests
    {
        [Fact]
        public void RotateArrayByKTimesOptimized_NullInput_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => RotateAraay.RotateArrayByKTimesOptimized(null, 2));
        }

        [Fact]
        public void RotateArrayByKTimesOptimized_EmptyArray_ReturnsEmpty()
        {
            int[] input = System.Array.Empty<int>();
            int[] result = RotateAraay.RotateArrayByKTimesOptimized(input, 2);
            Assert.Empty(result);
        }

        [Fact]
        public void RotateArrayByKTimesOptimized_SingleElement_ReturnsSame()
        {
            int[] input = new int[] { 5 };
            int[] result = RotateAraay.RotateArrayByKTimesOptimized(input, 2);
            Assert.Equal(new int[] { 5 }, result);
        }

        [Fact]
        public void RotateArrayByKTimesOptimized_KEqualsZero_ReturnsUnchanged()
        {
            int[] input = new int[] { 1, 2, 3, 4, 5 };
            int[] result = RotateAraay.RotateArrayByKTimesOptimized(input, 0);
            Assert.Equal(new int[] { 1, 2, 3, 4, 5 }, result);
        }

        [Fact]
        public void RotateArrayByKTimesOptimized_RotateByOne_ReturnsCorrectly()
        {
            int[] input = new int[] { 1, 2, 3, 4, 5 };
            int[] result = RotateAraay.RotateArrayByKTimesOptimized(input, 1);
            Assert.Equal(new int[] { 5, 1, 2, 3, 4 }, result);
        }

        [Fact]
        public void RotateArrayByKTimesOptimized_RotateByTwo_ReturnsCorrectly()
        {
            int[] input = new int[] { 1, 2, 3, 4, 5 };
            int[] result = RotateAraay.RotateArrayByKTimesOptimized(input, 2);
            Assert.Equal(new int[] { 4, 5, 1, 2, 3 }, result);
        }

        [Fact]
        public void RotateArrayByKTimesOptimized_RotateByThree_ReturnsCorrectly()
        {
            int[] input = new int[] { 1, 2, 3, 4, 5 };
            int[] result = RotateAraay.RotateArrayByKTimesOptimized(input, 3);
            Assert.Equal(new int[] { 3, 4, 5, 1, 2 }, result);
        }

        [Fact]
        public void RotateArrayByKTimesOptimized_KEqualsArrayLength_ReturnsUnchanged()
        {
            int[] input = new int[] { 1, 2, 3, 4, 5 };
            int[] result = RotateAraay.RotateArrayByKTimesOptimized(input, 5);
            Assert.Equal(new int[] { 1, 2, 3, 4, 5 }, result);
        }

        [Fact]
        public void RotateArrayByKTimesOptimized_KGreaterThanLength_RotatesCorrectly()
        {
            int[] input = new int[] { 1, 2, 3, 4, 5 };
            // k = 7, 7 % 5 = 2, so should rotate by 2
            int[] result = RotateAraay.RotateArrayByKTimesOptimized(input, 7);
            Assert.Equal(new int[] { 4, 5, 1, 2, 3 }, result);
        }

        [Fact]
        public void RotateArrayByKTimesOptimized_KMuchGreaterThanLength_RotatesCorrectly()
        {
            int[] input = new int[] { 1, 2, 3, 4, 5 };
            // k = 12, 12 % 5 = 2, so should rotate by 2
            int[] result = RotateAraay.RotateArrayByKTimesOptimized(input, 12);
            Assert.Equal(new int[] { 4, 5, 1, 2, 3 }, result);
        }

        [Fact]
        public void RotateArrayByKTimesOptimized_TwoElements_RotateByOne()
        {
            int[] input = new int[] { 1, 2 };
            int[] result = RotateAraay.RotateArrayByKTimesOptimized(input, 1);
            Assert.Equal(new int[] { 2, 1 }, result);
        }

        [Fact]
        public void RotateArrayByKTimesOptimized_WithNegativeNumbers()
        {
            int[] input = new int[] { -5, -3, -1, 0, 2 };
            int[] result = RotateAraay.RotateArrayByKTimesOptimized(input, 2);
            Assert.Equal(new int[] { 0, 2, -5, -3, -1 }, result);
        }

        [Fact]
        public void RotateArrayByKTimesOptimized_WithDuplicates()
        {
            int[] input = new int[] { 1, 1, 2, 2, 3 };
            int[] result = RotateAraay.RotateArrayByKTimesOptimized(input, 2);
            Assert.Equal(new int[] { 2, 3, 1, 1, 2 }, result);
        }

        [Fact]
        public void RotateArrayByKTimesOptimized_LargeArray()
        {
            int[] input = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int[] result = RotateAraay.RotateArrayByKTimesOptimized(input, 3);
            Assert.Equal(new int[] { 8, 9, 10, 1, 2, 3, 4, 5, 6, 7 }, result);
        }

        [Fact]
        public void RotateArrayByKTimesOptimized_CompareWithOriginal_ProducesSameResult()
        {
            int[] input1 = new int[] { 1, 2, 3, 4, 5 };
            int[] input2 = new int[] { 1, 2, 3, 4, 5 };

            int[] result1 = RotateAraay.RotateArrayByKTimes(input1, 3);
            int[] result2 = RotateAraay.RotateArrayByKTimesOptimized(input2, 3);

            Assert.Equal(result1, result2);
        }
    }
}
