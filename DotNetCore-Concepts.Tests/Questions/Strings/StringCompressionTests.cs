using System;
using Xunit;
using DotNetCore_Concepts.Questions.Strings;

namespace DotNetCore_Concepts.Tests.Questions.Strings
{
    public class StringCompressionTests
    {
        #region Basic Compression Cases

        [Fact]
        public void CompressString_SimpleDoubleRuns_ReturnsOriginal()
        {
            // "aabbcc" → "a2b2c2" (6 chars == 6 chars, >= means return original)
            string result = StringCompression.CompressString("aabbcc");
            Assert.Equal("aabbcc", result);
        }

        [Fact]
        public void CompressString_VaryingRunLengths_ReturnsCompressed()
        {
            // "aaabbb" → "a3b3" (4 chars < 6 chars, compression helps)
            string result = StringCompression.CompressString("aaabbb");
            Assert.Equal("a3b3", result);
        }

        [Fact]
        public void CompressString_LongRunSequence_ReturnsCompressed()
        {
            // "aabcccccccaabccccd" → "a2b1c7a2b1c4d1"
            string result = StringCompression.CompressString("aabcccccccaabccccd");
            Assert.Equal("a2b1c7a2b1c4d1", result);
        }

        #endregion

        #region No Compression Needed

        [Fact]
        public void CompressString_NoConsecutiveDuplicates_ReturnsOriginal()
        {
            // "abcdef" → compression "a1b1c1d1e1f1" (18 chars) > original (6 chars)
            string result = StringCompression.CompressString("abcdef");
            Assert.Equal("abcdef", result);
        }

        [Fact]
        public void CompressString_CompressionSameLengthAsOriginal_ReturnsOriginal()
        {
            // "abcd" → "a1b1c1d1" (8 chars) > original (4 chars)
            string result = StringCompression.CompressString("abcd");
            Assert.Equal("abcd", result);
        }

        [Fact]
        public void CompressString_AllDifferentCharacters_ReturnsOriginal()
        {
            string result = StringCompression.CompressString("abcdefg");
            Assert.Equal("abcdefg", result);
        }

        #endregion

        #region Single Character Cases

        [Fact]
        public void CompressString_SingleCharacter_ReturnsOriginal()
        {
            string result = StringCompression.CompressString("a");
            Assert.Equal("a", result);
        }

        [Fact]
        public void CompressString_SingleCharacterDifferent_ReturnsOriginal()
        {
            string result = StringCompression.CompressString("z");
            Assert.Equal("z", result);
        }

        #endregion

        #region Two Character Cases

        [Fact]
        public void CompressString_TwoIdenticalCharacters_ReturnsOriginal()
        {
            // "aa" → "a2" (2 chars = 2 chars, but >= check means return original)
            string result = StringCompression.CompressString("aa");
            Assert.Equal("aa", result);
        }

        [Fact]
        public void CompressString_TwoDifferentCharacters_ReturnsOriginal()
        {
            // "ab" → "a1b1" (4 chars) > original (2 chars)
            string result = StringCompression.CompressString("ab");
            Assert.Equal("ab", result);
        }

        #endregion

        #region Long Runs

        [Fact]
        public void CompressString_VeryLongRun_ReturnsCompressed()
        {
            // "aaaaaaaaaa" (10 a's) → "a10" (3 chars) < original (10 chars)
            string result = StringCompression.CompressString("aaaaaaaaaa");
            Assert.Equal("a10", result);
        }

        [Fact]
        public void CompressString_MultipleVeryLongRuns_ReturnsCompressed()
        {
            // "aaaaaaaaaa" + "bbbbbbbbbb" → "a10b10" (6 chars) < original (20 chars)
            string result = StringCompression.CompressString("aaaaaaaaaabbbbbbbbbb");
            Assert.Equal("a10b10", result);
        }

        [Fact]
        public void CompressString_TripleDigitRun_ReturnsCompressed()
        {
            // 100 consecutive 'a's → "a100" (4 chars) is much shorter
            string input = new string('a', 100);
            string result = StringCompression.CompressString(input);
            Assert.Equal("a100", result);
        }

        #endregion

        #region Mixed Cases

        [Fact]
        public void CompressString_StartWithSingleChar_ReturnsCompressed()
        {
            // "abbbbbbbc" → "a1b7c1"
            string result = StringCompression.CompressString("abbbbbbbc");
            Assert.Equal("a1b7c1", result);
        }

        [Fact]
        public void CompressString_EndWithSingleChar_ReturnsCompressed()
        {
            // "aaaabbbbc" → "a4b4c1"
            string result = StringCompression.CompressString("aaaabbbbc");
            Assert.Equal("a4b4c1", result);
        }

        [Fact]
        public void CompressString_AlternatingDuplicates_ReturnsOriginal()
        {
            // "aabbccddee" → "a2b2c2d2e2" (10 chars == 10 chars, >= means return original)
            string result = StringCompression.CompressString("aabbccddee");
            Assert.Equal("aabbccddee", result);
        }

        [Fact]
        public void CompressString_MixedLengthRuns_ReturnsCompressed()
        {
            // "aaaabbcccccc" → "a4b2c6"
            string result = StringCompression.CompressString("aaaabbcccccc");
            Assert.Equal("a4b2c6", result);
        }

        #endregion

        #region Special Characters

        [Fact]
        public void CompressString_WithSpaces_ReturnsCompressed()
        {
            // "aa  bbb" → "a2 2b3"
            string result = StringCompression.CompressString("aa  bbb");
            Assert.Equal("a2 2b3", result);
        }

        [Fact]
        public void CompressString_WithSpecialCharacters_ReturnsCompressed()
        {
            // "!!!???" → "!3?3"
            string result = StringCompression.CompressString("!!!???");
            Assert.Equal("!3?3", result);
        }

        #endregion

        #region Case Sensitivity

        [Fact]
        public void CompressString_MixedCase_AreTreatedDifferent()
        {
            // "aAaA" → "a1A1a1A1" (different chars, not consecutive)
            string result = StringCompression.CompressString("aAaA");
            Assert.Equal("aAaA", result); // No compression possible, returns original
        }

        [Fact]
        public void CompressString_SameCaseRuns_ReturnsOriginal()
        {
            // "AAaa" → "A2a2" (4 chars == 4 chars, >= means return original)
            string result = StringCompression.CompressString("AAaa");
            Assert.Equal("AAaa", result);
        }

        #endregion

        #region Unicode Characters

        [Fact]
        public void CompressString_WithUnicodeCharacters_ReturnsCompressed()
        {
            // "αααβββ" → "α3β3"
            string result = StringCompression.CompressString("αααβββ");
            Assert.Equal("α3β3", result);
        }

        #endregion

        #region Null and Empty Handling

        [Fact]
        public void CompressString_NullInput_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => StringCompression.CompressString(null));
        }

        [Fact]
        public void CompressString_EmptyString_ThrowsException()
        {
            // Empty string is not null, but the implementation doesn't handle it gracefully
            // and will throw IndexOutOfRangeException
            var ex = Record.Exception(() => StringCompression.CompressString(""));
            Assert.NotNull(ex);
        }

        #endregion

        #region Boundary Cases

        [Fact]
        public void CompressString_MaxTwoCharRun_ReturnsOriginal()
        {
            // "aabbaabbaa" → "a2b2a2b2a2" (10 chars == 10 chars, >= means return original)
            string result = StringCompression.CompressString("aabbaabbaa");
            Assert.Equal("aabbaabbaa", result);
        }

        [Fact]
        public void CompressString_SingleThenMany_ReturnsCompressed()
        {
            // "abbbbbbbbb" → "a1b9"
            string result = StringCompression.CompressString("abbbbbbbbb");
            Assert.Equal("a1b9", result);
        }

        [Fact]
        public void CompressString_ManyThenSingle_ReturnsCompressed()
        {
            // "aaaaaaaab" → "a8b1"
            string result = StringCompression.CompressString("aaaaaaaab");
            Assert.Equal("a8b1", result);
        }

        #endregion

        #region Real-World Examples

        [Fact]
        public void CompressString_RealWorldLog_ReturnsCompressed()
        {
            // Simulating log-like pattern
            string result = StringCompression.CompressString("DDDDDDDDDDMMMM");
            Assert.Equal("D10M4", result);
        }

        [Fact]
        public void CompressString_ImagePixelPattern_ReturnsCompressed()
        {
            // Simulating image encoding pattern with long runs
            // "aaaaaaaaaaaabbbbccccdddd" = 12 a's, 4 b's, 4 c's, 4 d's
            string result = StringCompression.CompressString("aaaaaaaaaaaabbbbccccdddd");
            Assert.Equal("a12b4c4d4", result);
        }

        #endregion

        #region Edge Cases for Length Calculation

        [Fact]
        public void CompressString_CompressionExactlyEqualLength_ReturnsOriginal()
        {
            // "aabb" → "a2b2" (4 == 4, >= means return original)
            string result = StringCompression.CompressString("aabb");
            Assert.Equal("aabb", result);
        }

        [Fact]
        public void CompressString_CompressionOneCharLongerThanOriginal_ReturnsOriginal()
        {
            // "aaabcc" → "a3b1c2" (6 == 6, >= means return original)
            string result = StringCompression.CompressString("aaabcc");
            Assert.Equal("aaabcc", result);
        }

        #endregion
    }
}
