using DotNetCore_Concepts.Questions.Array;

namespace DotNetCore_Concepts.Tests.Questions.Array
{
    public class MissingNumberTests
    {
        [Fact]
        public void NullInput_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => MissingNumber.FindNumber(null));
        }

        [Fact]
        public void TypicalCase_ReturnsMissingNumber()
        {
            int[] input = new int[] { 2, 1, 4, 0, 5, 6 };
            int result = MissingNumber.FindNumber(input);
            Assert.Equal(3, result);
        }

        [Fact]
        public void MissingIsLastIndex_ReturnsLastIndexValue()
        {
            // array length 4, elements 0,1,2 and a value equal to length (4) which is ignored
            int[] input = new int[] { 0, 1, 2, 4 };
            int result = MissingNumber.FindNumber(input);
            Assert.Equal(3, result);
        }

        [Fact]
        public void NoMissing_ReturnsMinusOne()
        {
            int[] input = new int[] { 2, 0, 1 };
            int result = MissingNumber.FindNumber(input);
            Assert.Equal(-1, result);
        }

        [Fact]
        public void Duplicates_ReturnsMissingCorrectly()
        {
            int[] input = new int[] { 1, 1, 2 };
            int result = MissingNumber.FindNumber(input);
            Assert.Equal(0, result);
        }

        [Fact]
        public void ValuesGreaterThanLength_AreIgnored()
        {
            int[] input = new int[] { 0, 1, 10 };
            int result = MissingNumber.FindNumber(input);
            Assert.Equal(2, result);
        }

        [Fact]
        public void NegativeValue_ThrowsIndexOutOfRangeException()
        {
            int[] input = new int[] { -1, 0, 1 };
            Assert.Throws<IndexOutOfRangeException>(() => MissingNumber.FindNumber(input));
        }
    }
}
