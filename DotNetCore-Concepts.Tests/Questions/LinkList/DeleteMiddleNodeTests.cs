using DotNetCore_Concepts.Models;
using DotNetCore_Concepts.Questions.LinkList;
using Xunit;

namespace DotNetCore_Concepts.Tests.Questions.LinkList;

/// <summary>
/// Unit tests for both implementations of DeleteMiddleNode:
/// 1. <see cref="DeleteMiddleNode.DeleteMiddleNodeFromLinkedList(Node)"/> — O(n) data-shifting approach.
/// 2. <see cref="DeleteMiddleNode.DeleteMiddleNodeFromLinkedListOptimized(Node)"/> — O(1) copy-and-bypass approach.
/// </summary>
public class DeleteMiddleNodeTests
{
    #region Data-Shifting Approach (DeleteMiddleNodeFromLinkedList) Tests

    [Fact]
    public void DataShifting_NullNode_DoesNotThrow()
    {
        // Should handle null gracefully without throwing
        DeleteMiddleNode.DeleteMiddleNodeFromLinkedList(null!);
    }

    [Fact]
    public void DataShifting_LastNode_ListUnchanged()
    {
        // Cannot delete the last node — list should remain intact
        var head = CreateList(1, 2, 3)!;
        var lastNode = head.next!.next!; // node with value 3

        DeleteMiddleNode.DeleteMiddleNodeFromLinkedList(lastNode);

        AssertListEquals([1, 2, 3], head);
    }

    [Fact]
    public void DataShifting_SingleNode_ListUnchanged()
    {
        // A single-node list is effectively the last node — no deletion possible
        var head = CreateList(10)!;

        DeleteMiddleNode.DeleteMiddleNodeFromLinkedList(head);

        Assert.Equal(10, head.Data);
    }

    [Fact]
    public void DataShifting_MiddleOfThreeNodes_DeletesCorrectly()
    {
        // 1 -> [2] -> 3  =>  1 -> 3
        var head = CreateList(1, 2, 3)!;
        var middleNode = head.next!; // node with value 2

        DeleteMiddleNode.DeleteMiddleNodeFromLinkedList(middleNode);

        AssertListEquals([1, 3], head);
    }

    [Fact]
    public void DataShifting_SecondNodeOfFour_DeletesCorrectly()
    {
        // 1 -> [2] -> 3 -> 4  =>  1 -> 3 -> 4
        var head = CreateList(1, 2, 3, 4)!;
        var secondNode = head.next!; // node with value 2

        DeleteMiddleNode.DeleteMiddleNodeFromLinkedList(secondNode);

        AssertListEquals([1, 3, 4], head);
    }

    [Fact]
    public void DataShifting_ThirdNodeOfSix_DeletesCorrectly()
    {
        // a(1) -> b(2) -> [c(3)] -> d(4) -> e(5) -> f(6)
        // => a(1) -> b(2) -> d(4) -> e(5) -> f(6)
        var head = CreateList(1, 2, 3, 4, 5, 6)!;
        var thirdNode = head.next!.next!; // node with value 3

        DeleteMiddleNode.DeleteMiddleNodeFromLinkedList(thirdNode);

        AssertListEquals([1, 2, 4, 5, 6], head);
    }

    [Fact]
    public void DataShifting_FirstOfTwoNodes_DeletesCorrectly()
    {
        // [1] -> 2  =>  2  (head node becomes 2, tail removed)
        var head = CreateList(1, 2)!;

        DeleteMiddleNode.DeleteMiddleNodeFromLinkedList(head);

        Assert.Equal(2, head.Data);
        Assert.Null(head.next);
    }

    [Fact]
    public void DataShifting_DuplicateValues_DeletesCorrectly()
    {
        // 5 -> [5] -> 5 -> 5  =>  5 -> 5 -> 5
        var head = CreateList(5, 5, 5, 5)!;
        var secondNode = head.next!;

        DeleteMiddleNode.DeleteMiddleNodeFromLinkedList(secondNode);

        AssertListEquals([5, 5, 5], head);
    }

    [Fact]
    public void DataShifting_PenultimateNode_DeletesCorrectly()
    {
        // 1 -> 2 -> [3] -> 4  =>  1 -> 2 -> 4
        var head = CreateList(1, 2, 3, 4)!;
        var penultimateNode = head.next!.next!; // node with value 3

        DeleteMiddleNode.DeleteMiddleNodeFromLinkedList(penultimateNode);

        AssertListEquals([1, 2, 4], head);
    }

    #endregion

    #region Optimized Copy-and-Bypass (DeleteMiddleNodeFromLinkedListOptimized) Tests

    [Fact]
    public void Optimized_NullNode_DoesNotThrow()
    {
        DeleteMiddleNode.DeleteMiddleNodeFromLinkedListOptimized(null!);
    }

    [Fact]
    public void Optimized_LastNode_ListUnchanged()
    {
        var head = CreateList(1, 2, 3)!;
        var lastNode = head.next!.next!;

        DeleteMiddleNode.DeleteMiddleNodeFromLinkedListOptimized(lastNode);

        AssertListEquals([1, 2, 3], head);
    }

    [Fact]
    public void Optimized_SingleNode_ListUnchanged()
    {
        var head = CreateList(10)!;

        DeleteMiddleNode.DeleteMiddleNodeFromLinkedListOptimized(head);

        Assert.Equal(10, head.Data);
    }

    [Fact]
    public void Optimized_MiddleOfThreeNodes_DeletesCorrectly()
    {
        var head = CreateList(1, 2, 3)!;
        var middleNode = head.next!;

        DeleteMiddleNode.DeleteMiddleNodeFromLinkedListOptimized(middleNode);

        AssertListEquals([1, 3], head);
    }

    [Fact]
    public void Optimized_SecondNodeOfFour_DeletesCorrectly()
    {
        var head = CreateList(1, 2, 3, 4)!;
        var secondNode = head.next!;

        DeleteMiddleNode.DeleteMiddleNodeFromLinkedListOptimized(secondNode);

        AssertListEquals([1, 3, 4], head);
    }

    [Fact]
    public void Optimized_ThirdNodeOfSix_DeletesCorrectly()
    {
        var head = CreateList(1, 2, 3, 4, 5, 6)!;
        var thirdNode = head.next!.next!;

        DeleteMiddleNode.DeleteMiddleNodeFromLinkedListOptimized(thirdNode);

        AssertListEquals([1, 2, 4, 5, 6], head);
    }

    [Fact]
    public void Optimized_FirstOfTwoNodes_DeletesCorrectly()
    {
        var head = CreateList(1, 2)!;

        DeleteMiddleNode.DeleteMiddleNodeFromLinkedListOptimized(head);

        Assert.Equal(2, head.Data);
        Assert.Null(head.next);
    }

    [Fact]
    public void Optimized_DuplicateValues_DeletesCorrectly()
    {
        var head = CreateList(5, 5, 5, 5)!;
        var secondNode = head.next!;

        DeleteMiddleNode.DeleteMiddleNodeFromLinkedListOptimized(secondNode);

        AssertListEquals([5, 5, 5], head);
    }

    [Fact]
    public void Optimized_PenultimateNode_DeletesCorrectly()
    {
        var head = CreateList(1, 2, 3, 4)!;
        var penultimateNode = head.next!.next!;

        DeleteMiddleNode.DeleteMiddleNodeFromLinkedListOptimized(penultimateNode);

        AssertListEquals([1, 2, 4], head);
    }

    #endregion

    #region Equivalence Tests — Both methods produce the same result

    [Theory]
    [InlineData(1)]  // delete 2nd node
    [InlineData(2)]  // delete 3rd node
    [InlineData(3)]  // delete 4th node
    public void BothMethods_ProduceSameResult_ForVariousPositions(int nodeIndex)
    {
        // Build two identical lists: 10 -> 20 -> 30 -> 40 -> 50
        var head1 = CreateList(10, 20, 30, 40, 50)!;
        var head2 = CreateList(10, 20, 30, 40, 50)!;

        // Navigate to the node at the given index in each list
        var node1 = GetNodeAt(head1, nodeIndex);
        var node2 = GetNodeAt(head2, nodeIndex);

        DeleteMiddleNode.DeleteMiddleNodeFromLinkedList(node1);
        DeleteMiddleNode.DeleteMiddleNodeFromLinkedListOptimized(node2);

        // Both lists should be identical after deletion
        AssertListEquals(ToList(head1), head2);
    }

    [Fact]
    public void BothMethods_NegativeValues_ProduceSameResult()
    {
        var head1 = CreateList(-3, -2, -1, 0, 1)!;
        var head2 = CreateList(-3, -2, -1, 0, 1)!;

        // Delete node with value -1 (index 2)
        DeleteMiddleNode.DeleteMiddleNodeFromLinkedList(head1.next!.next!);
        DeleteMiddleNode.DeleteMiddleNodeFromLinkedListOptimized(head2.next!.next!);

        AssertListEquals(ToList(head1), head2);
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
    /// Returns the node at the given zero-based index in the list.
    /// </summary>
    private static Node GetNodeAt(Node head, int index)
    {
        var current = head;
        for (int i = 0; i < index; i++)
            current = current.next!;
        return current;
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
