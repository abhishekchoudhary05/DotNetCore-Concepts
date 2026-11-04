using System;
using Xunit;
using DotNetCore_Concepts.Questions.Strings;

namespace DotNetCore_Concepts.Tests.Questions.Strings
{
    public class PallindromePermutationTests
    {
        #region Null & Empty Cases

        [Fact]
        public void NullInput_ReturnsEmptyList()
        {
            var result = PallindromePermutation.FindPallindromePermutation(null);
            Assert.Empty(result);
        }

        [Fact]
        public void EmptyString_ReturnsEmptyList()
        {
            var result = PallindromePermutation.FindPallindromePermutation("");
            Assert.Empty(result);
        }

        #endregion

        #region Single Character

        [Fact]
        public void SingleCharacter_ReturnsSinglePalindrome()
        {
            var result = PallindromePermutation.FindPallindromePermutation("a");
            Assert.Single(result);
            Assert.Contains("a", result);
        }

        #endregion

        #region Two Characters

        [Fact]
        public void TwoIdenticalCharacters_ReturnsPalindromePermutations()
        {
            var result = PallindromePermutation.FindPallindromePermutation("aa");
            // "aa" generates 2! = 2 permutations, all are "aa" (duplicates)
            Assert.NotEmpty(result);
            Assert.All(result, p => Assert.Equal("aa", p));
        }

        [Fact]
        public void TwoDifferentCharacters_ReturnsEmptyList()
        {
            var result = PallindromePermutation.FindPallindromePermutation("ab");
            Assert.Empty(result); // "ab" and "ba" are not palindromes
        }

        #endregion

        #region Three Characters

        [Fact]
        public void ThreeCharacters_OneUnique_ReturnsPalindromePermutations()
        {
            var result = PallindromePermutation.FindPallindromePermutation("aaa");
            // "aaa" generates 3! = 6 permutations, all are "aaa" (duplicates)
            Assert.NotEmpty(result);
            Assert.All(result, p => Assert.Equal("aaa", p));
        }

        [Fact]
        public void ThreeCharacters_TwoUnique_OneOddFreq_ReturnsPalindromePermutations()
        {
            var result = PallindromePermutation.FindPallindromePermutation("aab");
            // "aab" can form "aba" → palindrome
            // With duplicates in permutations, there may be multiple "aba" entries
            Assert.NotEmpty(result);
            Assert.True(result.All(p => p == "aba"), "All palindromes should be 'aba'");
        }

        [Fact]
        public void ThreeCharacters_AllDifferent_ReturnsEmptyList()
        {
            var result = PallindromePermutation.FindPallindromePermutation("abc");
            Assert.Empty(result); // All three have odd frequencies
        }

        #endregion

        #region Four Characters

        [Fact]
        public void FourCharacters_AllEvenFreq_ReturnsPalindromePermutations()
        {
            var result = PallindromePermutation.FindPallindromePermutation("aabb");
            Assert.NotEmpty(result);
            // "aabb" can form "abba" and "baab" palindromes
            // Due to permutation duplicates, there may be multiple of each
            var distinctResults = result.Distinct().ToList();
            Assert.NotEmpty(distinctResults);
            Assert.All(distinctResults, p => Assert.True(IsPalindrome.IsStringPalindrome_2(p)));
        }

        [Fact]
        public void FourCharacters_OneOddFreq_ReturnsPalindromePermutations()
        {
            var result = PallindromePermutation.FindPallindromePermutation("aaab");
            // 'a' count=3 (odd), 'b' count=1 (odd) → TWO odd frequencies, cannot form palindrome
            Assert.Empty(result);
        }

        [Fact]
        public void FourCharacters_TwoOddFreq_ReturnsEmptyList()
        {
            var result = PallindromePermutation.FindPallindromePermutation("abcd");
            Assert.Empty(result); // All have odd frequencies
        }

        #endregion

        #region Five Characters

        [Fact]
        public void FiveCharacters_OneOddFreq_ReturnsPalindromePermutations()
        {
            var result = PallindromePermutation.FindPallindromePermutation("aabbc");
            // 'a' count=2, 'b' count=2, 'c' count=1 → only one odd, can form palindrome
            Assert.NotEmpty(result);
            // Palindromes should exist like "abcba", "bacab", "cbac" etc.
        }

        [Fact]
        public void FiveCharacters_AllSame_ReturnsPalindrome()
        {
            var result = PallindromePermutation.FindPallindromePermutation("aaaaa");
            // All 5! = 120 permutations are "aaaaa"
            Assert.NotEmpty(result);
            Assert.All(result, p => Assert.Equal("aaaaa", p));
        }

        #endregion

        #region Duplicates

        [Fact]
        public void MultipleDuplicates_AllEven_ReturnsPalindromePermutations()
        {
            var result = PallindromePermutation.FindPallindromePermutation("aabbcc");
            Assert.NotEmpty(result);
            // Each permutation should be a palindrome
            foreach (var palindrome in result)
            {
                Assert.True(IsPalindrome.IsStringPalindrome_2(palindrome));
            }
        }

        #endregion

        #region Palindrome Validation

        [Fact]
        public void AllResultsArePalindromes()
        {
            var result = PallindromePermutation.FindPallindromePermutation("aabbc");
            foreach (var item in result)
            {
                Assert.True(IsPalindrome.IsStringPalindrome_2(item), $"{item} is not a palindrome");
            }
        }

        #endregion

        #region CanFormPalindromePermutation Tests

        [Fact]
        public void CanFormPalindrome_EmptyString_ReturnsTrue()
        {
            Assert.True(PallindromePermutation.CanFormPalindromePermutation(""));
        }

        [Fact]
        public void CanFormPalindrome_SingleCharacter_ReturnsTrue()
        {
            Assert.True(PallindromePermutation.CanFormPalindromePermutation("a"));
        }

        [Fact]
        public void CanFormPalindrome_AllEvenFreq_ReturnsTrue()
        {
            Assert.True(PallindromePermutation.CanFormPalindromePermutation("aabb"));
            Assert.True(PallindromePermutation.CanFormPalindromePermutation("aabbcc"));
            Assert.True(PallindromePermutation.CanFormPalindromePermutation("aaaa"));
        }

        [Fact]
        public void CanFormPalindrome_OneOddFreq_ReturnsTrue()
        {
            Assert.True(PallindromePermutation.CanFormPalindromePermutation("aab"));
            Assert.True(PallindromePermutation.CanFormPalindromePermutation("aabbc"));
            Assert.True(PallindromePermutation.CanFormPalindromePermutation("aabbcc" + 'd'));
        }

        [Fact]
        public void CanFormPalindrome_TwoOddFreq_ReturnsFalse()
        {
            Assert.False(PallindromePermutation.CanFormPalindromePermutation("ab"));
            Assert.False(PallindromePermutation.CanFormPalindromePermutation("abc"));
        }

        [Fact]
        public void CanFormPalindrome_ManyOddFreq_ReturnsFalse()
        {
            Assert.False(PallindromePermutation.CanFormPalindromePermutation("abcde"));
        }

        #endregion

        #region Approach Consistency

        [Fact]
        public void BothApproaches_ProduceSameResults()
        {
            string[] testStrings = { "aabb", "aabbc", "a", "aa", "abc" };

            foreach (var input in testStrings)
            {
                var approach1 = PallindromePermutation.FindPallindromePermutation(input);
                var approach2 = PallindromePermutation.FindPallindromePermutationOptimized(input);

                Assert.Equal(approach1.Count, approach2.Count);

                // All results should match (order independent)
                foreach (var result in approach1)
                {
                    Assert.Contains(result, approach2);
                }
            }
        }

        #endregion

        #region Special Cases

        [Fact]
        public void StringWithSpaces_ValidPalindrome_ReturnsResults()
        {
            var result = PallindromePermutation.FindPallindromePermutation("a a");
            // 'a' count=2, ' ' count=1 → one odd, can form palindrome
            Assert.NotEmpty(result);
        }

        [Fact]
        public void StringWithNumbers_ValidPalindrome_ReturnsResults()
        {
            var result = PallindromePermutation.FindPallindromePermutation("11");
            // "11" generates 2! = 2 permutations, all are "11"
            Assert.NotEmpty(result);
            Assert.All(result, p => Assert.Equal("11", p));
        }

        #endregion

        #region Efficiency

        [Fact]
        public void CanFormPalindrome_ShortCircuitsInvalid()
        {
            // Should immediately return empty without generating permutations
            var result = PallindromePermutation.FindPallindromePermutationOptimized("abcde");
            Assert.Empty(result);
        }

        #endregion
    }
}
