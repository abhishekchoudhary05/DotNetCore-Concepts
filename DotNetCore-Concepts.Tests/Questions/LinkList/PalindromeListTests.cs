using DotNetCore_Concepts.Models;
using DotNetCore_Concepts.Questions.LinkList;
using Xunit;

namespace DotNetCore_Concepts.Tests.Questions.LinkList;

/// <summary>
/// Unit tests for both implementations of PalindromeList:
/// 1. <see cref="PalindromeList.IsListPalindrome(Node)"/> — O(n) space, list-copy approach.
/// 2. <see cref="PalindromeList.IsListPalindromeOptimized(Node)"/> — O(1) space, reverse-second-half approach.
/// </summary>
public class PalindromeListTests
{
    #region List-Copy Approach (IsListPalindrome) Tests

    [Fact]
    public void ListCopy_NullHead_ReturnsFalse()
    {
        Assert.False(PalindromeList.IsListPalindrome(null!));
    }

    [Fact]
    public void ListCopy_SingleNode_ReturnsTrue()
    {
        var head = CreateList(1)!;
        Assert.True(PalindromeList.IsListPalindrome(head));
    }

    [Fact]
    public void ListCopy_TwoNodes_Palindrome_ReturnsTrue()
    {
        // 1 -> 1
        var head = CreateList(1, 1)!;
        Assert.True(PalindromeList.IsListPalindrome(head));
    }

    [Fact]
    public void ListCopy_TwoNodes_NotPalindrome_ReturnsFalse()
    {
        // 1 -> 2
        var head = CreateList(1, 2)!;
        Assert.False(PalindromeList.IsListPalindrome(head));
    }

    [Fact]
    public void ListCopy_OddLength_Palindrome_ReturnsTrue()
    {
        // 1 -> 2 -> 3 -> 2 -> 1
        var head = CreateList(1, 2, 3, 2, 1)!;
        Assert.True(PalindromeList.IsListPalindrome(head));
    }

    [Fact]
    public void ListCopy_OddLength_NotPalindrome_ReturnsFalse()
    {
        // 1 -> 2 -> 3 -> 4 -> 5
        var head = CreateList(1, 2, 3, 4, 5)!;
        Assert.False(PalindromeList.IsListPalindrome(head));
    }

    [Fact]
    public void ListCopy_EvenLength_Palindrome_ReturnsTrue()
    {
        // 1 -> 2 -> 2 -> 1
        var head = CreateList(1, 2, 2, 1)!;
        Assert.True(PalindromeList.IsListPalindrome(head));
    }

    [Fact]
    public void ListCopy_EvenLength_NotPalindrome_ReturnsFalse()
    {
        // 1 -> 2 -> 3 -> 4
        var head = CreateList(1, 2, 3, 4)!;
        Assert.False(PalindromeList.IsListPalindrome(head));
    }

    [Fact]
    public void ListCopy_AllSameValues_ReturnsTrue()
    {
        // 7 -> 7 -> 7 -> 7 -> 7
        var head = CreateList(7, 7, 7, 7, 7)!;
        Assert.True(PalindromeList.IsListPalindrome(head));
    }

    [Fact]
    public void ListCopy_ThreeNodes_Palindrome_ReturnsTrue()
    {
        // 1 -> 2 -> 1
        var head = CreateList(1, 2, 1)!;
        Assert.True(PalindromeList.IsListPalindrome(head));
    }

    [Fact]
    public void ListCopy_ThreeNodes_NotPalindrome_ReturnsFalse()
    {
        // 1 -> 2 -> 3
        var head = CreateList(1, 2, 3)!;
        Assert.False(PalindromeList.IsListPalindrome(head));
    }

    [Fact]
    public void ListCopy_MismatchOnlyAtEnds_ReturnsFalse()
    {
        // 1 -> 2 -> 3 -> 2 -> 9
        var head = CreateList(1, 2, 3, 2, 9)!;
        Assert.False(PalindromeList.IsListPalindrome(head));
    }

    [Fact]
    public void ListCopy_NegativeValues_Palindrome_ReturnsTrue()
    {
        // -1 -> 0 -> -1
        var head = CreateList(-1, 0, -1)!;
        Assert.True(PalindromeList.IsListPalindrome(head));
    }

    [Fact]
    public void ListCopy_NegativeValues_NotPalindrome_ReturnsFalse()
    {
        // -1 -> -2 -> -3
        var head = CreateList(-1, -2, -3)!;
        Assert.False(PalindromeList.IsListPalindrome(head));
    }

    [Fact]
    public void ListCopy_LongerEvenPalindrome_ReturnsTrue()
    {
        // 1 -> 2 -> 3 -> 3 -> 2 -> 1
        var head = CreateList(1, 2, 3, 3, 2, 1)!;
        Assert.True(PalindromeList.IsListPalindrome(head));
    }

    #endregion

    #region Reverse-Second-Half Approach (IsListPalindromeOptimized) Tests

    [Fact]
    public void Optimized_NullHead_ReturnsFalse()
    {
        Assert.False(PalindromeList.IsListPalindromeOptimized(null!));
    }

    [Fact]
    public void Optimized_SingleNode_ReturnsTrue()
    {
        var head = CreateList(1)!;
        Assert.True(PalindromeList.IsListPalindromeOptimized(head));
    }

    [Fact]
    public void Optimized_TwoNodes_Palindrome_ReturnsTrue()
    {
        var head = CreateList(1, 1)!;
        Assert.True(PalindromeList.IsListPalindromeOptimized(head));
    }

    [Fact]
    public void Optimized_TwoNodes_NotPalindrome_ReturnsFalse()
    {
        var head = CreateList(1, 2)!;
        Assert.False(PalindromeList.IsListPalindromeOptimized(head));
    }

    [Fact]
    public void Optimized_OddLength_Palindrome_ReturnsTrue()
    {
        var head = CreateList(1, 2, 3, 2, 1)!;
        Assert.True(PalindromeList.IsListPalindromeOptimized(head));
    }

    [Fact]
    public void Optimized_OddLength_NotPalindrome_ReturnsFalse()
    {
        var head = CreateList(1, 2, 3, 4, 5)!;
        Assert.False(PalindromeList.IsListPalindromeOptimized(head));
    }

    [Fact]
    public void Optimized_EvenLength_Palindrome_ReturnsTrue()
    {
        var head = CreateList(1, 2, 2, 1)!;
        Assert.True(PalindromeList.IsListPalindromeOptimized(head));
    }

    [Fact]
    public void Optimized_EvenLength_NotPalindrome_ReturnsFalse()
    {
        var head = CreateList(1, 2, 3, 4)!;
        Assert.False(PalindromeList.IsListPalindromeOptimized(head));
    }

    [Fact]
    public void Optimized_AllSameValues_ReturnsTrue()
    {
        var head = CreateList(7, 7, 7, 7, 7)!;
        Assert.True(PalindromeList.IsListPalindromeOptimized(head));
    }

    [Fact]
    public void Optimized_ThreeNodes_Palindrome_ReturnsTrue()
    {
        var head = CreateList(1, 2, 1)!;
        Assert.True(PalindromeList.IsListPalindromeOptimized(head));
    }

    [Fact]
    public void Optimized_ThreeNodes_NotPalindrome_ReturnsFalse()
    {
        var head = CreateList(1, 2, 3)!;
        Assert.False(PalindromeList.IsListPalindromeOptimized(head));
    }

    [Fact]
    public void Optimized_MismatchOnlyAtEnds_ReturnsFalse()
    {
        var head = CreateList(1, 2, 3, 2, 9)!;
        Assert.False(PalindromeList.IsListPalindromeOptimized(head));
    }

    [Fact]
    public void Optimized_NegativeValues_Palindrome_ReturnsTrue()
    {
        var head = CreateList(-1, 0, -1)!;
        Assert.True(PalindromeList.IsListPalindromeOptimized(head));
    }

    [Fact]
    public void Optimized_NegativeValues_NotPalindrome_ReturnsFalse()
    {
        var head = CreateList(-1, -2, -3)!;
        Assert.False(PalindromeList.IsListPalindromeOptimized(head));
    }

    [Fact]
    public void Optimized_LongerEvenPalindrome_ReturnsTrue()
    {
        var head = CreateList(1, 2, 3, 3, 2, 1)!;
        Assert.True(PalindromeList.IsListPalindromeOptimized(head));
    }

    #endregion

    #region Equivalence Tests — Both methods return the same result

    [Theory]
    [InlineData(new[] { 1 }, true)]
    [InlineData(new[] { 1, 1 }, true)]
    [InlineData(new[] { 1, 2 }, false)]
    [InlineData(new[] { 1, 2, 1 }, true)]
    [InlineData(new[] { 1, 2, 3 }, false)]
    [InlineData(new[] { 1, 2, 2, 1 }, true)]
    [InlineData(new[] { 1, 2, 3, 4 }, false)]
    [InlineData(new[] { 1, 2, 3, 2, 1 }, true)]
    [InlineData(new[] { 1, 2, 3, 4, 5 }, false)]
    [InlineData(new[] { 1, 2, 3, 3, 2, 1 }, true)]
    [InlineData(new[] { 1, 2, 3, 4, 5, 6 }, false)]
    [InlineData(new[] { 5, 5, 5, 5, 5 }, true)]
    [InlineData(new[] { 1, 2, 3, 2, 9 }, false)]
    [InlineData(new[] { -1, 0, -1 }, true)]
    [InlineData(new[] { -1, -2, -3 }, false)]
    public void BothMethods_ReturnSameResult(int[] values, bool expected)
    {
        var head1 = CreateList(values)!;
        var head2 = CreateList(values)!;

        var result1 = PalindromeList.IsListPalindrome(head1);
        var result2 = PalindromeList.IsListPalindromeOptimized(head2);

        Assert.Equal(expected, result1);
        Assert.Equal(expected, result2);
    }

    #endregion

    #region Helper Methods

    /// <summary>
    /// Constructs a singly linked list from the given sequence of integer values.
    /// </summary>
    private static Node? CreateList(params int[] values)
    {
        if (values == null || values.Length == 0)
            return null;

        var head = new Node(values[0]);
        var current = head;
        for (int i = 1; i < values.Length; i++)
        {
            current.next = new Node(values[i]);
            current = current.next;
        }

        return head;
    }

    #endregion
}
