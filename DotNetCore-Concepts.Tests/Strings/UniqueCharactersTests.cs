using DotNetCore_Concepts.Questions.Strings;

namespace DotNetCore_Concepts.Tests.Strings
{
    public class UniqueCharactersTests
    {
        [Fact]
        public void NullInput_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => UniqueCharacters.IsStringContainsUniqueCharacters(null));
        }

        [Fact]
        public void EmptyString_ReturnsTrue()
        {
            string input = "";
            bool result = UniqueCharacters.IsStringContainsUniqueCharacters(input);
            Assert.True(result);
        }

        [Fact]
        public void SingleCharacter_ReturnsTrue()
        {
            string input = "a";
            bool result = UniqueCharacters.IsStringContainsUniqueCharacters(input);
            Assert.True(result);
        }

        [Fact]
        public void AllUniqueCharacters_ReturnsTrue()
        {
            string input = "abcdef";
            bool result = UniqueCharacters.IsStringContainsUniqueCharacters(input);
            Assert.True(result);
        }

        [Fact]
        public void AllUniqueCharacters_MixedCase_ReturnsTrue()
        {
            string input = "AaBbCc";
            bool result = UniqueCharacters.IsStringContainsUniqueCharacters(input);
            Assert.True(result);
        }

        [Fact]
        public void AllUniqueCharacters_WithSpecialChars_ReturnsTrue()
        {
            string input = "a@b#c$";
            bool result = UniqueCharacters.IsStringContainsUniqueCharacters(input);
            Assert.True(result);
        }

        [Fact]
        public void AllUniqueCharacters_WithSpaces_ReturnsTrue()
        {
            string input = "a b@c";
            bool result = UniqueCharacters.IsStringContainsUniqueCharacters(input);
            Assert.True(result);
        }

        [Fact]
        public void DuplicateCharacters_FirstAndLast_ReturnsFalse()
        {
            string input = "abcda";
            bool result = UniqueCharacters.IsStringContainsUniqueCharacters(input);
            Assert.False(result);
        }

        [Fact]
        public void DuplicateCharacters_Adjacent_ReturnsFalse()
        {
            string input = "abccdef";
            bool result = UniqueCharacters.IsStringContainsUniqueCharacters(input);
            Assert.False(result);
        }

        [Fact]
        public void DuplicateCharacters_MultipleOccurrences_ReturnsFalse()
        {
            string input = "aabbcc";
            bool result = UniqueCharacters.IsStringContainsUniqueCharacters(input);
            Assert.False(result);
        }

        [Fact]
        public void DuplicateCharacters_AllSame_ReturnsFalse()
        {
            string input = "aaaa";
            bool result = UniqueCharacters.IsStringContainsUniqueCharacters(input);
            Assert.False(result);
        }

        [Fact]
        public void TwoCharacters_Unique_ReturnsTrue()
        {
            string input = "ab";
            bool result = UniqueCharacters.IsStringContainsUniqueCharacters(input);
            Assert.True(result);
        }

        [Fact]
        public void TwoCharacters_Duplicate_ReturnsFalse()
        {
            string input = "aa";
            bool result = UniqueCharacters.IsStringContainsUniqueCharacters(input);
            Assert.False(result);
        }

        [Fact]
        public void LongString_AllUnique_ReturnsTrue()
        {
            string input = "abcdefghijklmnopqrstuvwxyz";
            bool result = UniqueCharacters.IsStringContainsUniqueCharacters(input);
            Assert.True(result);
        }

        [Fact]
        public void LongString_WithDuplicate_ReturnsFalse()
        {
            string input = "abcdefghijklmnopqrstuvwxyza";
            bool result = UniqueCharacters.IsStringContainsUniqueCharacters(input);
            Assert.False(result);
        }

        [Fact]
        public void NumbersAsString_AllUnique_ReturnsTrue()
        {
            string input = "123456789";
            bool result = UniqueCharacters.IsStringContainsUniqueCharacters(input);
            Assert.True(result);
        }

        [Fact]
        public void NumbersAsString_WithDuplicate_ReturnsFalse()
        {
            string input = "1234567899";
            bool result = UniqueCharacters.IsStringContainsUniqueCharacters(input);
            Assert.False(result);
        }
    }

    public class UniqueCharactersHashSetTests
    {
        [Fact]
        public void NullInput_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => UniqueCharacters.IsStringContainsUniqueCharacters_2(null));
        }

        [Fact]
        public void EmptyString_ReturnsTrue()
        {
            string input = "";
            bool result = UniqueCharacters.IsStringContainsUniqueCharacters_2(input);
            Assert.True(result);
        }

        [Fact]
        public void SingleCharacter_ReturnsTrue()
        {
            string input = "a";
            bool result = UniqueCharacters.IsStringContainsUniqueCharacters_2(input);
            Assert.True(result);
        }

        [Fact]
        public void AllUniqueCharacters_ReturnsTrue()
        {
            string input = "abcdef";
            bool result = UniqueCharacters.IsStringContainsUniqueCharacters_2(input);
            Assert.True(result);
        }

        [Fact]
        public void AllUniqueCharacters_MixedCase_ReturnsTrue()
        {
            string input = "AaBbCc";
            bool result = UniqueCharacters.IsStringContainsUniqueCharacters_2(input);
            Assert.True(result);
        }

        [Fact]
        public void AllUniqueCharacters_WithSpecialChars_ReturnsTrue()
        {
            string input = "a@b#c$";
            bool result = UniqueCharacters.IsStringContainsUniqueCharacters_2(input);
            Assert.True(result);
        }

        [Fact]
        public void AllUniqueCharacters_WithSpaces_ReturnsTrue()
        {
            string input = "a b@c";
            bool result = UniqueCharacters.IsStringContainsUniqueCharacters_2(input);
            Assert.True(result);
        }

        [Fact]
        public void DuplicateCharacters_FirstAndLast_ReturnsFalse()
        {
            string input = "abcda";
            bool result = UniqueCharacters.IsStringContainsUniqueCharacters_2(input);
            Assert.False(result);
        }

        [Fact]
        public void DuplicateCharacters_Adjacent_ReturnsFalse()
        {
            string input = "abccdef";
            bool result = UniqueCharacters.IsStringContainsUniqueCharacters_2(input);
            Assert.False(result);
        }

        [Fact]
        public void DuplicateCharacters_MultipleOccurrences_ReturnsFalse()
        {
            string input = "aabbcc";
            bool result = UniqueCharacters.IsStringContainsUniqueCharacters_2(input);
            Assert.False(result);
        }

        [Fact]
        public void DuplicateCharacters_AllSame_ReturnsFalse()
        {
            string input = "aaaa";
            bool result = UniqueCharacters.IsStringContainsUniqueCharacters_2(input);
            Assert.False(result);
        }

        [Fact]
        public void TwoCharacters_Unique_ReturnsTrue()
        {
            string input = "ab";
            bool result = UniqueCharacters.IsStringContainsUniqueCharacters_2(input);
            Assert.True(result);
        }

        [Fact]
        public void TwoCharacters_Duplicate_ReturnsFalse()
        {
            string input = "aa";
            bool result = UniqueCharacters.IsStringContainsUniqueCharacters_2(input);
            Assert.False(result);
        }

        [Fact]
        public void LongString_AllUnique_ReturnsTrue()
        {
            string input = "abcdefghijklmnopqrstuvwxyz";
            bool result = UniqueCharacters.IsStringContainsUniqueCharacters_2(input);
            Assert.True(result);
        }

        [Fact]
        public void LongString_WithDuplicate_ReturnsFalse()
        {
            string input = "abcdefghijklmnopqrstuvwxyza";
            bool result = UniqueCharacters.IsStringContainsUniqueCharacters_2(input);
            Assert.False(result);
        }

        [Fact]
        public void NumbersAsString_AllUnique_ReturnsTrue()
        {
            string input = "123456789";
            bool result = UniqueCharacters.IsStringContainsUniqueCharacters_2(input);
            Assert.True(result);
        }

        [Fact]
        public void NumbersAsString_WithDuplicate_ReturnsFalse()
        {
            string input = "1234567899";
            bool result = UniqueCharacters.IsStringContainsUniqueCharacters_2(input);
            Assert.False(result);
        }
    }
}
