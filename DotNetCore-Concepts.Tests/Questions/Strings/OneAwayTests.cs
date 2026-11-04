using System;
using Xunit;
using DotNetCore_Concepts.Questions.Strings;

namespace DotNetCore_Concepts.Tests.Questions.Strings
{
    public class OneAwayTests
    {
        #region Null & Empty Cases

        [Fact]
        public void BothEmpty_ReturnsFalse()
        {
            Assert.False(OneAway.IsEditDistanceIsOne("", ""));
        }

        [Fact]
        public void FirstEmpty_SecondSingleChar_ReturnsTrue()
        {
            Assert.True(OneAway.IsEditDistanceIsOne("", "a"));
        }

        [Fact]
        public void FirstSingleChar_SecondEmpty_ReturnsTrue()
        {
            Assert.True(OneAway.IsEditDistanceIsOne("a", ""));
        }

        [Fact]
        public void FirstEmpty_SecondMultiChar_ReturnsFalse()
        {
            Assert.False(OneAway.IsEditDistanceIsOne("", "ab"));
        }

        [Fact]
        public void FirstMultiChar_SecondEmpty_ReturnsFalse()
        {
            Assert.False(OneAway.IsEditDistanceIsOne("ab", ""));
        }

        [Fact]
        public void NullFirstString_SingleCharSecond_ReturnsTrue()
        {
            // null is treated as empty string by IsNullOrEmpty, so it's like "" vs "a"
            Assert.True(OneAway.IsEditDistanceIsOne(null, "a"));
        }

        [Fact]
        public void NullSecondString_SingleCharFirst_ReturnsTrue()
        {
            // null is treated as empty string by IsNullOrEmpty, so it's like "a" vs ""
            Assert.True(OneAway.IsEditDistanceIsOne("a", null));
        }

        [Fact]
        public void BothNull_ReturnsFalse()
        {
            // Both null are treated as empty, so "" vs "" = no edit
            Assert.False(OneAway.IsEditDistanceIsOne(null, null));
        }

        #endregion

        #region Length Difference > 1 (Impossible)

        [Fact]
        public void LengthDifference_TwoChars_ReturnsFalse()
        {
            Assert.False(OneAway.IsEditDistanceIsOne("a", "abc"));
        }

        [Fact]
        public void LengthDifference_ThreeChars_ReturnsFalse()
        {
            Assert.False(OneAway.IsEditDistanceIsOne("abc", "abcdef"));
        }

        #endregion

        #region Same Length - Replacement Cases

        [Fact]
        public void SameLength_TheSame_ReturnsFalse()
        {
            Assert.False(OneAway.IsEditDistanceIsOne("pale", "pale"));
        }

        [Fact]
        public void SameLength_OneCharDifference_FirstPos_ReturnsTrue()
        {
            Assert.True(OneAway.IsEditDistanceIsOne("pale", "bale"));
        }

        [Fact]
        public void SameLength_OneCharDifference_MiddlePos_ReturnsTrue()
        {
            Assert.True(OneAway.IsEditDistanceIsOne("pale", "pble"));
        }

        [Fact]
        public void SameLength_OneCharDifference_LastPos_ReturnsTrue()
        {
            Assert.True(OneAway.IsEditDistanceIsOne("pale", "pals"));
        }

        [Fact]
        public void SameLength_TwoCharDifference_ReturnsFalse()
        {
            Assert.False(OneAway.IsEditDistanceIsOne("pale", "bble"));
        }

        [Fact]
        public void SameLength_AllCharDifference_ReturnsFalse()
        {
            Assert.False(OneAway.IsEditDistanceIsOne("abc", "def"));
        }

        [Fact]
        public void SameLength_SingleCharString_OneReplacement_ReturnsTrue()
        {
            Assert.True(OneAway.IsEditDistanceIsOne("a", "b"));
        }

        #endregion

        #region Length Difference by 1 - Insertion/Deletion Cases

        [Fact]
        public void LengthDiffOne_Deletion_RemoveFromEnd_ReturnsTrue()
        {
            Assert.True(OneAway.IsEditDistanceIsOne("pales", "pale"));
        }

        [Fact]
        public void LengthDiffOne_Deletion_RemoveFromStart_ReturnsTrue()
        {
            Assert.True(OneAway.IsEditDistanceIsOne("pale", "ple"));
        }

        [Fact]
        public void LengthDiffOne_Deletion_RemoveFromMiddle_ReturnsTrue()
        {
            Assert.True(OneAway.IsEditDistanceIsOne("pale", "pae"));
        }

        [Fact]
        public void LengthDiffOne_Insertion_InsertAtEnd_ReturnsTrue()
        {
            Assert.True(OneAway.IsEditDistanceIsOne("pale", "pales"));
        }

        [Fact]
        public void LengthDiffOne_Insertion_InsertAtStart_ReturnsTrue()
        {
            Assert.True(OneAway.IsEditDistanceIsOne("ale", "pale"));
        }

        [Fact]
        public void LengthDiffOne_Insertion_InsertAtMiddle_ReturnsTrue()
        {
            Assert.True(OneAway.IsEditDistanceIsOne("ple", "pale"));
        }

        [Fact]
        public void LengthDiffOne_NoValidEdit_ReturnsFalse()
        {
            // "pales" vs "pble" - length diff 1 but more than 1 char differs
            Assert.False(OneAway.IsEditDistanceIsOne("pales", "pble"));
        }

        #endregion

        #region Single Character Strings

        [Fact]
        public void SingleChar_Same_ReturnsFalse()
        {
            Assert.False(OneAway.IsEditDistanceIsOne("a", "a"));
        }

        [Fact]
        public void SingleChar_Different_ReturnsTrue()
        {
            Assert.True(OneAway.IsEditDistanceIsOne("a", "b"));
        }

        [Fact]
        public void SingleChar_ToEmpty_ReturnsTrue()
        {
            Assert.True(OneAway.IsEditDistanceIsOne("a", ""));
        }

        [Fact]
        public void Empty_ToSingleChar_ReturnsTrue()
        {
            Assert.True(OneAway.IsEditDistanceIsOne("", "a"));
        }

        #endregion

        #region Special Cases

        [Fact]
        public void LongStrings_OneCharDifference_ReturnsTrue()
        {
            Assert.True(OneAway.IsEditDistanceIsOne("abcdefghij", "abcdefghik"));
        }

        [Fact]
        public void LongStrings_OneCharInsertion_ReturnsTrue()
        {
            Assert.True(OneAway.IsEditDistanceIsOne("abcdefghij", "abcdefghijk"));
        }

        [Fact]
        public void LongStrings_OneCharDeletion_ReturnsTrue()
        {
            Assert.True(OneAway.IsEditDistanceIsOne("abcdefghijk", "abcdefghij"));
        }

        [Fact]
        public void LongStrings_MultipleCharDifference_ReturnsFalse()
        {
            Assert.False(OneAway.IsEditDistanceIsOne("abcdefghij", "abcxyzghij"));
        }

        #endregion

        #region Case Sensitivity

        [Fact]
        public void CaseDifference_ReturnsTrue()
        {
            Assert.True(OneAway.IsEditDistanceIsOne("pale", "Pale"));
        }

        #endregion

        #region Real-World Examples

        [Fact]
        public void Example1_Replacement()
        {
            Assert.True(OneAway.IsEditDistanceIsOne("cat", "bat"));
        }

        [Fact]
        public void Example2_Insertion()
        {
            Assert.True(OneAway.IsEditDistanceIsOne("cat", "cats"));
        }

        [Fact]
        public void Example3_Deletion()
        {
            Assert.True(OneAway.IsEditDistanceIsOne("cats", "cat"));
        }

        [Fact]
        public void Example4_NoEdit()
        {
            Assert.False(OneAway.IsEditDistanceIsOne("cat", "cat"));
        }

        [Fact]
        public void Example5_TwoEdits()
        {
            Assert.False(OneAway.IsEditDistanceIsOne("cat", "dog"));
        }

        #endregion

        #region Symmetry

        [Fact]
        public void Symmetry_Replacement()
        {
            bool result1 = OneAway.IsEditDistanceIsOne("pale", "bale");
            bool result2 = OneAway.IsEditDistanceIsOne("bale", "pale");
            Assert.Equal(result1, result2);
        }

        [Fact]
        public void Symmetry_InsertionDeletion()
        {
            bool result1 = OneAway.IsEditDistanceIsOne("pale", "pales");
            bool result2 = OneAway.IsEditDistanceIsOne("pales", "pale");
            Assert.Equal(result1, result2);
        }

        #endregion
    }
}
