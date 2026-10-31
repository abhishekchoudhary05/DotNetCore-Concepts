using DotNetCore_Concepts.Questions.Strings;

namespace DotNetCore_Concepts.Tests.Questions.Strings
{
    public class ReplaceSpacesInStringTests
    {
        #region Null & Empty Cases

        [Fact]
        public void NullInput_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => 
                ReplaceSpacesInString.ReplaceSpacesInStringWithAnother(null, "%20"));
        }

        [Fact]
        public void NullReplaceWith_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => 
                ReplaceSpacesInString.ReplaceSpacesInStringWithAnother("hello world", null));
        }

        [Fact]
        public void EmptyInput_ReturnsEmptyString()
        {
            string result = ReplaceSpacesInString.ReplaceSpacesInStringWithAnother("", "%20");
            Assert.Equal("", result);
        }

        [Fact]
        public void EmptyReplaceWith_RemovesAllSpaces()
        {
            string result = ReplaceSpacesInString.ReplaceSpacesInStringWithAnother("hello world test", "");
            Assert.Equal("helloworldtest", result);
        }

        #endregion

        #region No Spaces Cases

        [Fact]
        public void NoSpaces_ReturnsOriginalString()
        {
            string result = ReplaceSpacesInString.ReplaceSpacesInStringWithAnother("helloworld", "%20");
            Assert.Equal("helloworld", result);
        }

        [Fact]
        public void SingleCharacter_NoSpaces_ReturnsOriginalCharacter()
        {
            string result = ReplaceSpacesInString.ReplaceSpacesInStringWithAnother("a", "~");
            Assert.Equal("a", result);
        }

        #endregion

        #region Single Space Cases

        [Fact]
        public void SingleSpace_WithPercentTwenty_ReplacesCorrectly()
        {
            string result = ReplaceSpacesInString.ReplaceSpacesInStringWithAnother("hello world", "%20");
            Assert.Equal("hello%20world", result);
        }

        [Fact]
        public void SingleSpace_WithSingleChar_ReplacesCorrectly()
        {
            string result = ReplaceSpacesInString.ReplaceSpacesInStringWithAnother("a b", "~");
            Assert.Equal("a~b", result);
        }

        [Fact]
        public void SingleSpace_WithMultiChar_ReplacesCorrectly()
        {
            string result = ReplaceSpacesInString.ReplaceSpacesInStringWithAnother("a b", "~>");
            Assert.Equal("a~>b", result);
        }

        #endregion

        #region Multiple Spaces Cases

        [Fact]
        public void MultipleSpaces_Separated_ReplacesAllSpaces()
        {
            string result = ReplaceSpacesInString.ReplaceSpacesInStringWithAnother("a b c d", ".");
            Assert.Equal("a.b.c.d", result);
        }

        [Fact]
        public void MultipleSpaces_Consecutive_ReplacesAllSpaces()
        {
            string result = ReplaceSpacesInString.ReplaceSpacesInStringWithAnother("hello  world", "%20");
            Assert.Equal("hello%20%20world", result);
        }

        [Fact]
        public void LeadingSpace_ReplacesCorrectly()
        {
            string result = ReplaceSpacesInString.ReplaceSpacesInStringWithAnother(" hello world", "_");
            Assert.Equal("_hello_world", result);
        }

        [Fact]
        public void TrailingSpace_ReplacesCorrectly()
        {
            string result = ReplaceSpacesInString.ReplaceSpacesInStringWithAnother("hello world ", "_");
            Assert.Equal("hello_world_", result);
        }

        [Fact]
        public void LeadingAndTrailingSpaces_ReplacesCorrectly()
        {
            string result = ReplaceSpacesInString.ReplaceSpacesInStringWithAnother(" hello world ", "-");
            Assert.Equal("-hello-world-", result);
        }

        [Fact]
        public void OnlySpaces_ReplacesWith_ReturnsReplacement()
        {
            string result = ReplaceSpacesInString.ReplaceSpacesInStringWithAnother("   ", "X");
            Assert.Equal("XXX", result);
        }

        #endregion

        #region Replacement Length Cases

        [Fact]
        public void ReplaceWithLengthOne_Works()
        {
            string result = ReplaceSpacesInString.ReplaceSpacesInStringWithAnother("a b c", "~");
            Assert.Equal("a~b~c", result);
        }

        [Fact]
        public void ReplaceWithLengthTwo_Works()
        {
            string result = ReplaceSpacesInString.ReplaceSpacesInStringWithAnother("a b", ":-");
            Assert.Equal("a:-b", result);
        }

        [Fact]
        public void ReplaceWithLengthThree_Works()
        {
            string result = ReplaceSpacesInString.ReplaceSpacesInStringWithAnother("a b", "%20");
            Assert.Equal("a%20b", result);
        }

        [Fact]
        public void ReplaceWithLengthGreaterThanThree_Works()
        {
            string result = ReplaceSpacesInString.ReplaceSpacesInStringWithAnother("a b", "====>");
            Assert.Equal("a====>b", result);
        }

        #endregion

        #region Special Character Cases

        [Fact]
        public void WithSpecialCharacters_PreservesNonSpaceCharacters()
        {
            string result = ReplaceSpacesInString.ReplaceSpacesInStringWithAnother("hello! @# world$%", ".");
            Assert.Equal("hello!.@#.world$%", result);
        }

        [Fact]
        public void WithNumbers_PreservesNumbers()
        {
            string result = ReplaceSpacesInString.ReplaceSpacesInStringWithAnother("123 456 789", "-");
            Assert.Equal("123-456-789", result);
        }

        [Fact]
        public void WithTabs_DoesNotReplaceTabCharacters()
        {
            string result = ReplaceSpacesInString.ReplaceSpacesInStringWithAnother("hello\tworld test", "_");
            Assert.Equal("hello\tworld_test", result);
        }

        [Fact]
        public void ReplaceWithSpecialCharacters_Works()
        {
            string result = ReplaceSpacesInString.ReplaceSpacesInStringWithAnother("a b", "!@#");
            Assert.Equal("a!@#b", result);
        }

        #endregion

        #region Case Sensitivity Cases

        [Fact]
        public void WithMixedCase_PreservesCasing()
        {
            string result = ReplaceSpacesInString.ReplaceSpacesInStringWithAnother("Hello World Test", ".");
            Assert.Equal("Hello.World.Test", result);
        }

        [Fact]
        public void ReplaceWithMixedCase_PreservesCasing()
        {
            string result = ReplaceSpacesInString.ReplaceSpacesInStringWithAnother("a b", "MiXeD");
            Assert.Equal("aMiXeDb", result);
        }

        #endregion

        #region Complex Cases

        [Fact]
        public void LongString_WithManySpaces_Works()
        {
            string input = "The quick brown fox jumps over the lazy dog";
            string result = ReplaceSpacesInString.ReplaceSpacesInStringWithAnother(input, "%20");
            Assert.Equal("The%20quick%20brown%20fox%20jumps%20over%20the%20lazy%20dog", result);
        }

        [Fact]
        public void ComplexMixOfCharactersAndSpaces_Works()
        {
            string input = "C# is a powerful language 2024!";
            string result = ReplaceSpacesInString.ReplaceSpacesInStringWithAnother(input, "_");
            Assert.Equal("C#_is_a_powerful_language_2024!", result);
        }

        [Fact]
        public void AlternatingSpacesAndCharacters_Works()
        {
            string result = ReplaceSpacesInString.ReplaceSpacesInStringWithAnother("a b c d e f", ":");
            Assert.Equal("a:b:c:d:e:f", result);
        }

        #endregion

        #region Idempotent Cases

        [Fact]
        public void ReplaceContainsNoSpaces_PreservesOutput()
        {
            string input = "hello world";
            string result1 = ReplaceSpacesInString.ReplaceSpacesInStringWithAnother(input, "~");
            string result2 = ReplaceSpacesInString.ReplaceSpacesInStringWithAnother(result1, "~");
            Assert.Equal(result1, result2);
        }

        #endregion

        #region Approach 2 (In-Place) Tests

        [Fact]
        public void Approach2_String_NullInput_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() =>
                ReplaceSpacesInString.ReplaceSpacesInStringWithAnother_InPlace(null!, "%20"));
        }

        [Fact]
        public void Approach2_String_NullReplaceWith_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() =>
                ReplaceSpacesInString.ReplaceSpacesInStringWithAnother_InPlace("hello world", null!));
        }

        [Theory]
        [InlineData("", "%20")]
        [InlineData("hello", "%20")]
        [InlineData("a b", "~")]
        [InlineData("hello world", "%20")]
        [InlineData("hello  world", "%20")]
        [InlineData(" hello world ", "-")]
        [InlineData("   ", "X")]
        [InlineData("hello world test", "")]
        [InlineData("a b c d", ".")]
        [InlineData("The quick brown fox jumps over the lazy dog", "%20")]
        [InlineData("C# is a powerful language 2024!", "_")]
        public void Approach2_String_ProducesSameResultAsApproach1(string input, string replaceWith)
        {
            string result1 = ReplaceSpacesInString.ReplaceSpacesInStringWithAnother(input, replaceWith);
            string result2 = ReplaceSpacesInString.ReplaceSpacesInStringWithAnother_InPlace(input, replaceWith);
            Assert.Equal(result1, result2);
        }

        [Fact]
        public void Approach2_CharBuffer_NullCharacters_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() =>
                ReplaceSpacesInString.ReplaceSpacesInPlace(null!, 0, "%20"));
        }

        [Fact]
        public void Approach2_CharBuffer_NullReplaceWith_ThrowsArgumentNullException()
        {
            char[] buffer = new char[10];
            Assert.Throws<ArgumentNullException>(() =>
                ReplaceSpacesInString.ReplaceSpacesInPlace(buffer, 0, null!));
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(11)]
        public void Approach2_CharBuffer_InvalidTrueLength_ThrowsArgumentOutOfRangeException(int trueLength)
        {
            char[] buffer = new char[10];
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                ReplaceSpacesInString.ReplaceSpacesInPlace(buffer, trueLength, "%20"));
        }

        [Fact]
        public void Approach2_CharBuffer_InsufficientCapacity_ThrowsArgumentException()
        {
            char[] buffer = "hello world".ToCharArray(); // capacity 11, needs 13 for "%20"
            Assert.Throws<ArgumentException>(() =>
                ReplaceSpacesInString.ReplaceSpacesInPlace(buffer, 11, "%20"));
        }

        [Fact]
        public void Approach2_CharBuffer_ClassicURLifyInPlace()
        {
            char[] buffer = "hello world    ".ToCharArray();
            int newLength = ReplaceSpacesInString.ReplaceSpacesInPlace(buffer, 11, "%20");

            Assert.Equal(13, newLength);
            Assert.Equal("hello%20world", new string(buffer, 0, newLength));
        }

        [Fact]
        public void Approach2_CharBuffer_EmptyReplaceWith_RemovesSpacesInPlace()
        {
            char[] buffer = "hello world test".ToCharArray();
            int newLength = ReplaceSpacesInString.ReplaceSpacesInPlace(buffer, buffer.Length, "");

            Assert.Equal(14, newLength);
            Assert.Equal("helloworldtest", new string(buffer, 0, newLength));
        }

        [Fact]
        public void Approach2_CharBuffer_NoSpaces_LeavesBufferUnchanged()
        {
            char[] buffer = "hello".ToCharArray();
            int newLength = ReplaceSpacesInString.ReplaceSpacesInPlace(buffer, 5, "%20");

            Assert.Equal(5, newLength);
            Assert.Equal("hello", new string(buffer, 0, newLength));
        }

        [Fact]
        public void Approach2_CharBuffer_SingleCharacterReplacement_WorksInPlace()
        {
            char[] buffer = "a b c".ToCharArray();
            int newLength = ReplaceSpacesInString.ReplaceSpacesInPlace(buffer, 5, "_");

            Assert.Equal(5, newLength);
            Assert.Equal("a_b_c", new string(buffer, 0, newLength));
        }

        #endregion
    }
}
