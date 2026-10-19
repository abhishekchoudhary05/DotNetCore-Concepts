using DotNetCore_Concepts.Questions.Array;

namespace DotNetCore_Concepts.Tests.Array
{
    public class FindLeadersTests
    {
        [Fact]
        public void TypicalArray_ReturnsCorrectLeaders()
        {
            int[] input = [16, 17, 4, 3, 5, 2];
            int[] expected = [17, 5, 2];

            int[] result = FindLeaders.FindLeadersInArray(input);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void DecreasingArray_AllElementsAreLeaders()
        {
            int[] input = [5, 4, 3, 2, 1];
            int[] expected = [5, 4, 3, 2, 1];

            int[] result = FindLeaders.FindLeadersInArray(input);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void AllEqualElements_ReturnsLastElementOnly()
        {
            int[] input = [2, 2, 2];
            int[] expected = [2];

            int[] result = FindLeaders.FindLeadersInArray(input);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void SingleElement_ReturnsThatElement()
        {
            int[] input = [10];
            int[] expected = [10];

            int[] result = FindLeaders.FindLeadersInArray(input);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void EmptyArray_ReturnsEmpty()
        {
            int[] input = [];

            int[] result = FindLeaders.FindLeadersInArray(input);

            Assert.Empty(result);
        }

        [Fact]
        public void NullInput_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => FindLeaders.FindLeadersInArray(null));
        }
    }
}
