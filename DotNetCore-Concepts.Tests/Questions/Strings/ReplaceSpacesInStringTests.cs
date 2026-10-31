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
    }
}
