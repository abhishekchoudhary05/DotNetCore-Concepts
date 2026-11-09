using DotNetCore_Concepts.Models;
using DotNetCore_Concepts.Questions.LinkList;
using Xunit;

namespace DotNetCore_Concepts.Tests.Questions.LinkList;

/// <summary>
/// Unit tests for <see cref="KthToLast"/> implementations:
/// 1. <see cref="KthToLast.GetNode(Node, int)"/> — Two-Pass length-counting approach.
/// 2. <see cref="KthToLast.GetNodeOptimized(Node, int)"/> — Single-Pass runner pointer approach.
/// </summary>
public class KthToLastTests
{
    #region Two-Pass (GetNode) Tests

    [Fact]
    public void GetNode_NullHead_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => KthToLast.GetNode(null!, 1));
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(-10)]
    public void GetNode_InvalidK_ReturnsNull(int k)
    {
        var head = CreateList(1, 2, 3)!;
        var result = KthToLast.GetNode(head, k);
        Assert.Null(result);
    }

    [Fact]
    public void GetNode_SingleNode_KIsOne_ReturnsHead()
    {
        var head = CreateList(42)!;
        var result = KthToLast.GetNode(head, 1);

        Assert.NotNull(result);
        Assert.Same(head, result);
        Assert.Equal(42, result.Data);
    }

    [Fact]
    public void GetNode_SingleNode_KGreaterThanLength_ReturnsNull()
    {
        var head = CreateList(42)!;
        var result = KthToLast.GetNode(head, 2);

        Assert.Null(result);
    }

    [Fact]
    public void GetNode_MultipleNodes_ReturnsLastNodeWhenKIsOne()
    {
        var head = CreateList(10, 20, 30, 40, 50)!;
        var result = KthToLast.GetNode(head, 1);

        Assert.NotNull(result);
        Assert.Equal(50, result.Data);
        Assert.Null(result.next);
    }

    [Fact]
    public void GetNode_MultipleNodes_ReturnsHeadWhenKEqualsTotalLength()
    {
        var head = CreateList(10, 20, 30, 40, 50)!;
        var result = KthToLast.GetNode(head, 5);

        Assert.NotNull(result);
        Assert.Same(head, result);
        Assert.Equal(10, result.Data);
    }

    [Fact]
    public void GetNode_MultipleNodes_ReturnsCorrectMiddleNode()
    {
        var head = CreateList(10, 20, 30, 40, 50)!;
        var result = KthToLast.GetNode(head, 3);

        Assert.NotNull(result);
        Assert.Equal(30, result.Data);
    }

    [Fact]
    public void GetNode_MultipleNodes_KGreaterThanTotalLength_ReturnsNull()
    {
        var head = CreateList(10, 20, 30, 40, 50)!;
        var result = KthToLast.GetNode(head, 6);

        Assert.Null(result);
    }

    #endregion

    #region Optimized Single-Pass (GetNodeOptimized) Tests

    [Fact]
    public void GetNodeOptimized_NullHead_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => KthToLast.GetNodeOptimized(null!, 1));
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(-10)]
    public void GetNodeOptimized_InvalidK_ReturnsNull(int k)
    {
        var head = CreateList(1, 2, 3)!;
        var result = KthToLast.GetNodeOptimized(head, k);
        Assert.Null(result);
    }

    [Fact]
    public void GetNodeOptimized_SingleNode_KIsOne_ReturnsHead()
    {
        var head = CreateList(42)!;
        var result = KthToLast.GetNodeOptimized(head, 1);

        Assert.NotNull(result);
        Assert.Same(head, result);
        Assert.Equal(42, result.Data);
    }

    [Fact]
    public void GetNodeOptimized_SingleNode_KGreaterThanLength_ReturnsNull()
    {
        var head = CreateList(42)!;
        var result = KthToLast.GetNodeOptimized(head, 2);

        Assert.Null(result);
    }

    [Fact]
    public void GetNodeOptimized_MultipleNodes_ReturnsLastNodeWhenKIsOne()
    {
        var head = CreateList(10, 20, 30, 40, 50)!;
        var result = KthToLast.GetNodeOptimized(head, 1);

        Assert.NotNull(result);
        Assert.Equal(50, result.Data);
        Assert.Null(result.next);
    }

    [Fact]
    public void GetNodeOptimized_MultipleNodes_ReturnsHeadWhenKEqualsTotalLength()
    {
        var head = CreateList(10, 20, 30, 40, 50)!;
        var result = KthToLast.GetNodeOptimized(head, 5);

        Assert.NotNull(result);
        Assert.Same(head, result);
        Assert.Equal(10, result.Data);
    }

    [Fact]
    public void GetNodeOptimized_MultipleNodes_ReturnsCorrectMiddleNode()
    {
        var head = CreateList(10, 20, 30, 40, 50)!;
        var result = KthToLast.GetNodeOptimized(head, 3);

        Assert.NotNull(result);
        Assert.Equal(30, result.Data);
    }

    [Fact]
    public void GetNodeOptimized_MultipleNodes_KGreaterThanTotalLength_ReturnsNull()
    {
        var head = CreateList(10, 20, 30, 40, 50)!;
        var result = KthToLast.GetNodeOptimized(head, 6);

        Assert.Null(result);
    }

    #endregion

    #region Equivalence and Edge Cases

    [Theory]
    [InlineData(1, 5)]  // last node
    [InlineData(2, 4)]  // 2nd to last
    [InlineData(3, 3)]  // 3rd to last
    [InlineData(4, 2)]  // 4th to last
    [InlineData(5, 1)]  // 5th to last (head)
    public void BothMethods_ReturnSameExpectedValue_ForEveryK(int k, int expectedData)
    {
        var list1 = CreateList(1, 2, 3, 4, 5)!;
        var list2 = CreateList(1, 2, 3, 4, 5)!;

        var result1 = KthToLast.GetNode(list1, k);
        var result2 = KthToLast.GetNodeOptimized(list2, k);

        Assert.NotNull(result1);
        Assert.NotNull(result2);
        Assert.Equal(expectedData, result1.Data);
        Assert.Equal(expectedData, result2.Data);
    }

    [Fact]
    public void BothMethods_ListWithDuplicateValues_ReturnsExpectedNode()
    {
        var list1 = CreateList(7, 7, 7, 7)!;
        var list2 = CreateList(7, 7, 7, 7)!;

        var result1 = KthToLast.GetNode(list1, 2);
        var result2 = KthToLast.GetNodeOptimized(list2, 2);

        Assert.NotNull(result1);
        Assert.NotNull(result2);
        Assert.Equal(7, result1.Data);
        Assert.Equal(7, result2.Data);
    }

    [Fact]
    public void BothMethods_TwoNodeList_HandlesBothPositions()
    {
        var head1 = CreateList(100, 200)!;
        var head2 = CreateList(100, 200)!;

        // k = 1 -> 200
        Assert.Equal(200, KthToLast.GetNode(head1, 1)?.Data);
        Assert.Equal(200, KthToLast.GetNodeOptimized(head2, 1)?.Data);

        // k = 2 -> 100
        Assert.Equal(100, KthToLast.GetNode(head1, 2)?.Data);
        Assert.Equal(100, KthToLast.GetNodeOptimized(head2, 2)?.Data);

        // k = 3 -> null
        Assert.Null(KthToLast.GetNode(head1, 3));
        Assert.Null(KthToLast.GetNodeOptimized(head2, 3));
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
