using System;
using Xunit;
using DotNetCore_Concepts.Questions.Strings;

namespace DotNetCore_Concepts.Tests.Questions.Strings
{
    public class PermutationTests
    {
        #region Null & Empty Cases

        [Fact]
        public void NullInput_ReturnsEmptyList()
        {
            var result = Permutation.FindAllPermutation(null);
            Assert.Empty(result);
        }

        [Fact]
        public void EmptyString_ReturnsEmptyList()
        {
            var result = Permutation.FindAllPermutation("");
            Assert.Empty(result);
        }

        #endregion

        #region Single Character

        [Fact]
        public void SingleCharacter_ReturnsSinglePermutation()
        {
            var result = Permutation.FindAllPermutation("A");
            Assert.Single(result);
            Assert.Contains("A", result);
        }

        #endregion

        #region Two Characters

        [Fact]
        public void TwoCharacters_ReturnsTwoPermutations()
        {
            var result = Permutation.FindAllPermutation("AB");
            Assert.Equal(2, result.Count);
            Assert.Contains("AB", result);
            Assert.Contains("BA", result);
        }

        [Fact]
        public void TwoIdenticalCharacters_ReturnsTwoPermutations()
        {
            var result = Permutation.FindAllPermutation("AA");
            Assert.Equal(2, result.Count);
            Assert.Contains("AA", result);
        }

        #endregion

        #region Three Characters

        [Fact]
        public void ThreeCharacters_ReturnsSixPermutations()
        {
            var result = Permutation.FindAllPermutation("ABC");
            Assert.Equal(6, result.Count); // 3! = 6

            Assert.Contains("ABC", result);
            Assert.Contains("ACB", result);
            Assert.Contains("BAC", result);
            Assert.Contains("BCA", result);
            Assert.Contains("CAB", result);
            Assert.Contains("CBA", result);
        }

        #endregion

        #region Duplicate Characters

        [Fact]
        public void DuplicateCharacters_ReturnsCorrectPermutationCount()
        {
            var result = Permutation.FindAllPermutation("AAB");
            // With duplicates, we still get all permutations (including duplicates)
            // Total would be 3! = 6 arrangements, but some are identical
            Assert.NotEmpty(result);
            Assert.Contains("AAB", result);
            Assert.Contains("ABA", result);
            Assert.Contains("BAA", result);
        }

        #endregion

        #region Four Characters

        [Fact]
        public void FourCharacters_ReturnsTwentyFourPermutations()
        {
            var result = Permutation.FindAllPermutation("ABCD");
            Assert.Equal(24, result.Count); // 4! = 24
        }

        #endregion

        #region Character Preservation

        [Fact]
        public void AllPermutationsSameCharacters_OriginalCharactersPreserved()
        {
            const string input = "ABC";
            var result = Permutation.FindAllPermutation(input);

            foreach (var permutation in result)
            {
                // Each permutation should contain exactly the same characters
                var sortedInput = string.Concat(input.OrderBy(c => c));
                var sortedPermutation = string.Concat(permutation.OrderBy(c => c));
                Assert.Equal(sortedInput, sortedPermutation);
            }
        }

        #endregion

        #region Length Preservation

        [Fact]
        public void AllPermutationsSameLength_InputLength()
        {
            const string input = "ABCD";
            var result = Permutation.FindAllPermutation(input);

            foreach (var permutation in result)
            {
                Assert.Equal(input.Length, permutation.Length);
            }
        }

        #endregion

        #region Special Characters

        [Fact]
        public void SpecialCharacters_ReturnsCorrectPermutations()
        {
            var result = Permutation.FindAllPermutation("1@");
            Assert.Equal(2, result.Count);
            Assert.Contains("1@", result);
            Assert.Contains("@1", result);
        }

        #endregion

        #region Numbers as String

        [Fact]
        public void NumbersAsString_ReturnsCorrectPermutations()
        {
            var result = Permutation.FindAllPermutation("123");
            Assert.Equal(6, result.Count);
            Assert.Contains("123", result);
            Assert.Contains("132", result);
            Assert.Contains("213", result);
            Assert.Contains("231", result);
            Assert.Contains("312", result);
            Assert.Contains("321", result);
        }

        #endregion

        #region Case Sensitivity

        [Fact]
        public void MixedCaseCharacters_TreatsAsDifferent()
        {
            var result = Permutation.FindAllPermutation("aA");
            Assert.Equal(2, result.Count);
            Assert.Contains("aA", result);
            Assert.Contains("Aa", result);
        }

        #endregion

        #region Count Verification

        [Fact]
        public void PermutationCountFollowsFactorial()
        {
            // 1! = 1
            Assert.Equal(1, Permutation.FindAllPermutation("A").Count);

            // 2! = 2
            Assert.Equal(2, Permutation.FindAllPermutation("AB").Count);

            // 3! = 6
            Assert.Equal(6, Permutation.FindAllPermutation("ABC").Count);

            // 4! = 24
            Assert.Equal(24, Permutation.FindAllPermutation("ABCD").Count);

            // 5! = 120
            Assert.Equal(120, Permutation.FindAllPermutation("ABCDE").Count);
        }

        #endregion

        #region No Duplicates in Results

        [Fact]
        public void NoWildlyDuplicatePermutations_UniqueStrings()
        {
            var result = Permutation.FindAllPermutation("ABC");
            var distinctResults = result.Distinct().ToList();
            // For unique input characters, all permutations should be distinct
            Assert.Equal(result.Count, distinctResults.Count);
        }

        #endregion

        #region Whitespace Characters

        [Fact]
        public void WithSpaceCharacter_IncludesInPermutations()
        {
            var result = Permutation.FindAllPermutation("A ");
            Assert.Equal(2, result.Count);
            Assert.Contains("A ", result);
            Assert.Contains(" A", result);
        }

        #endregion
    }
}
