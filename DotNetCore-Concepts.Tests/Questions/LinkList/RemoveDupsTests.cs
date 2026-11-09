using DotNetCore_Concepts.Models;
using DotNetCore_Concepts.Questions.LinkList;
using Xunit;

namespace DotNetCore_Concepts.Tests.Questions.LinkList;

/// <summary>
/// Comprehensive unit tests for both implementations of RemoveDups:
/// 1. <see cref="RemoveDups.RemoveDupsFromUnsortedArray(Node?)"/> (O(N) Time, O(N) Space - with HashSet buffer)
/// 2. <see cref="RemoveDups.RemoveDupsWithoutBuffer(Node?)"/> (O(N^2) Time, O(1) Space - runner pointer technique)
/// </summary>
public class RemoveDupsTests
{
    #region With Buffer (HashSet) Tests

    [Fact]
    public void WithBuffer_NullHead_ReturnsNull()
    {
        var result = RemoveDups.RemoveDupsFromUnsortedArray(null);
        Assert.Null(result);
    }

    [Fact]
    public void WithBuffer_SingleNode_ReturnsSameList()
    {
        var head = CreateList(42);
        var result = RemoveDups.RemoveDupsFromUnsortedArray(head);
        AssertListEquals([42], result);
    }

    [Fact]
    public void WithBuffer_TwoDifferentNodes_ReturnsSameList()
    {
        var head = CreateList(1, 2);
        var result = RemoveDups.RemoveDupsFromUnsortedArray(head);
        AssertListEquals([1, 2], result);
    }

    [Fact]
    public void WithBuffer_TwoIdenticalNodes_RemovesDuplicate()
    {
        var head = CreateList(1, 1);
        var result = RemoveDups.RemoveDupsFromUnsortedArray(head);
        AssertListEquals([1], result);
    }

    [Fact]
    public void WithBuffer_NoDuplicates_ReturnsSameList()
    {
        var head = CreateList(1, 2, 3, 4, 5);
        var result = RemoveDups.RemoveDupsFromUnsortedArray(head);
        AssertListEquals([1, 2, 3, 4, 5], result);
    }

    [Fact]
    public void WithBuffer_AllDuplicateNodes_ReturnsSingleNode()
    {
        var head = CreateList(5, 5, 5, 5, 5);
        var result = RemoveDups.RemoveDupsFromUnsortedArray(head);
        AssertListEquals([5], result);
    }

    [Fact]
    public void WithBuffer_ConsecutiveDuplicates_RemovesDuplicates()
    {
        var head = CreateList(1, 1, 2, 2, 3, 3, 4);
        var result = RemoveDups.RemoveDupsFromUnsortedArray(head);
        AssertListEquals([1, 2, 3, 4], result);
    }

    [Fact]
    public void WithBuffer_NonConsecutiveDuplicates_PreservesFirstOccurrenceOrder()
    {
        var head = CreateList(3, 1, 2, 3, 1, 4, 2);
        var result = RemoveDups.RemoveDupsFromUnsortedArray(head);
        AssertListEquals([3, 1, 2, 4], result);
    }

    [Fact]
    public void WithBuffer_DuplicatesAtHead_RemovesCorrectly()
    {
        var head = CreateList(1, 1, 1, 2, 3);
        var result = RemoveDups.RemoveDupsFromUnsortedArray(head);
        AssertListEquals([1, 2, 3], result);
    }

    [Fact]
    public void WithBuffer_DuplicatesAtTail_RemovesCorrectly()
    {
        var head = CreateList(1, 2, 3, 3, 3);
        var result = RemoveDups.RemoveDupsFromUnsortedArray(head);
        AssertListEquals([1, 2, 3], result);
    }

    [Fact]
    public void WithBuffer_MultipleRepetitionsOfSameValue_RemovesAllSubsequent()
    {
        var head = CreateList(2, 1, 2, 2, 3, 2, 4, 2);
        var result = RemoveDups.RemoveDupsFromUnsortedArray(head);
        AssertListEquals([2, 1, 3, 4], result);
    }

    [Fact]
    public void WithBuffer_NegativeAndZeroValues_HandlesCorrectly()
    {
        var head = CreateList(-1, 0, 2, -1, 0, -5, 2);
        var result = RemoveDups.RemoveDupsFromUnsortedArray(head);
        AssertListEquals([-1, 0, 2, -5], result);
    }

    #endregion

    #region Without Buffer (Runner Pointer) Tests

    [Fact]
    public void WithoutBuffer_NullHead_ReturnsNull()
    {
        var result = RemoveDups.RemoveDupsWithoutBuffer(null);
        Assert.Null(result);
    }

    [Fact]
    public void WithoutBuffer_SingleNode_ReturnsSameList()
    {
        var head = CreateList(42);
        var result = RemoveDups.RemoveDupsWithoutBuffer(head);
        AssertListEquals([42], result);
    }

    [Fact]
    public void WithoutBuffer_TwoDifferentNodes_ReturnsSameList()
    {
        var head = CreateList(1, 2);
        var result = RemoveDups.RemoveDupsWithoutBuffer(head);
        AssertListEquals([1, 2], result);
    }

    [Fact]
    public void WithoutBuffer_TwoIdenticalNodes_RemovesDuplicate()
    {
        var head = CreateList(1, 1);
        var result = RemoveDups.RemoveDupsWithoutBuffer(head);
        AssertListEquals([1], result);
    }

    [Fact]
    public void WithoutBuffer_NoDuplicates_ReturnsSameList()
    {
        var head = CreateList(1, 2, 3, 4, 5);
        var result = RemoveDups.RemoveDupsWithoutBuffer(head);
        AssertListEquals([1, 2, 3, 4, 5], result);
    }

    [Fact]
    public void WithoutBuffer_AllDuplicateNodes_ReturnsSingleNode()
    {
        var head = CreateList(5, 5, 5, 5, 5);
        var result = RemoveDups.RemoveDupsWithoutBuffer(head);
        AssertListEquals([5], result);
    }

    [Fact]
    public void WithoutBuffer_ConsecutiveDuplicates_RemovesDuplicates()
    {
        var head = CreateList(1, 1, 2, 2, 3, 3, 4);
        var result = RemoveDups.RemoveDupsWithoutBuffer(head);
        AssertListEquals([1, 2, 3, 4], result);
    }

    [Fact]
    public void WithoutBuffer_NonConsecutiveDuplicates_PreservesFirstOccurrenceOrder()
    {
        var head = CreateList(3, 1, 2, 3, 1, 4, 2);
        var result = RemoveDups.RemoveDupsWithoutBuffer(head);
        AssertListEquals([3, 1, 2, 4], result);
    }

    [Fact]
    public void WithoutBuffer_DuplicatesAtHead_RemovesCorrectly()
    {
        var head = CreateList(1, 1, 1, 2, 3);
        var result = RemoveDups.RemoveDupsWithoutBuffer(head);
        AssertListEquals([1, 2, 3], result);
    }

    [Fact]
    public void WithoutBuffer_DuplicatesAtTail_RemovesCorrectly()
    {
        var head = CreateList(1, 2, 3, 3, 3);
        var result = RemoveDups.RemoveDupsWithoutBuffer(head);
        AssertListEquals([1, 2, 3], result);
    }

    [Fact]
    public void WithoutBuffer_MultipleRepetitionsOfSameValue_RemovesAllSubsequent()
    {
        var head = CreateList(2, 1, 2, 2, 3, 2, 4, 2);
        var result = RemoveDups.RemoveDupsWithoutBuffer(head);
        AssertListEquals([2, 1, 3, 4], result);
    }

    [Fact]
    public void WithoutBuffer_NegativeAndZeroValues_HandlesCorrectly()
    {
        var head = CreateList(-1, 0, 2, -1, 0, -5, 2);
        var result = RemoveDups.RemoveDupsWithoutBuffer(head);
        AssertListEquals([-1, 0, 2, -5], result);
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

    /// <summary>
    /// Traverses a linked list and converts its values to a list of integers.
    /// </summary>
    private static List<int> ToList(Node? head)
    {
        var list = new List<int>();
        var current = head;
        while (current != null)
        {
            list.Add(current.Data);
            current = current.next;
        }
        return list;
    }

    /// <summary>
    /// Asserts that the linked list contains exactly the expected sequence of values.
    /// </summary>
    private static void AssertListEquals(IEnumerable<int> expected, Node? actualHead)
    {
        var actualList = ToList(actualHead);
        Assert.Equal(expected, actualList);
    }

    #endregion
}
