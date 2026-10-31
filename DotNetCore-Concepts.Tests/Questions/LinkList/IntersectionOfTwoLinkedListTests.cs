using DotNetCore_Concepts.Models;
using DotNetCore_Concepts.Questions.LinkList;

namespace DotNetCore_Concepts.Tests.Questions.LinkList;

/// <summary>
/// Unit tests for <see cref="IntersectionOfTwoLinkedList.FindIntersection(Node, Node)"/>.
/// Covers:
/// - Null input validation (start1, start2, both)
/// - Disjoint lists of equal and unequal lengths (no intersection)
/// - Lists with identical data values but distinct node instances (reference equality verification)
/// - Identical lists (intersecting at head / same reference)
/// - Equal length lists intersecting at head, middle, and tail
/// - First list longer than second list intersecting at various points
/// - Second list longer than first list intersecting at various points
/// - Single node lists intersecting
/// </summary>
public class IntersectionOfTwoLinkedListTests
{
    #region Argument Validation Tests

    [Fact]
    public void FindIntersection_Start1IsNull_ThrowsArgumentNullException()
    {
        var node = new Node(1);
        var ex = Assert.Throws<ArgumentNullException>(() => IntersectionOfTwoLinkedList.FindIntersection(null!, node));
        Assert.Equal("start1", ex.ParamName);
    }

    [Fact]
    public void FindIntersection_Start2IsNull_ThrowsArgumentNullException()
    {
        var node = new Node(1);
        var ex = Assert.Throws<ArgumentNullException>(() => IntersectionOfTwoLinkedList.FindIntersection(node, null!));
        Assert.Equal("start2", ex.ParamName);
    }

    [Fact]
    public void FindIntersection_BothInputsAreNull_ThrowsArgumentNullExceptionForFirstParameter()
    {
        var ex = Assert.Throws<ArgumentNullException>(() => IntersectionOfTwoLinkedList.FindIntersection(null!, null!));
        Assert.Equal("start1", ex.ParamName);
    }

    #endregion

    #region No Intersection Tests

    [Fact]
    public void FindIntersection_SingleNodes_NoIntersection_ReturnsNull()
    {
        var list1 = new Node(1);
        var list2 = new Node(2);

        var result = IntersectionOfTwoLinkedList.FindIntersection(list1, list2);

        Assert.Null(result);
    }

    [Fact]
    public void FindIntersection_EqualLengthLists_NoIntersection_ReturnsNull()
    {
        // List1: 1 -> 2 -> 3
        // List2: 4 -> 5 -> 6
        var list1 = CreateList(1, 2, 3);
        var list2 = CreateList(4, 5, 6);

        var result = IntersectionOfTwoLinkedList.FindIntersection(list1, list2);

        Assert.Null(result);
    }

    [Fact]
    public void FindIntersection_FirstListLonger_NoIntersection_ReturnsNull()
    {
        // List1: 1 -> 2 -> 3 -> 4 -> 5
        // List2: 6 -> 7
        var list1 = CreateList(1, 2, 3, 4, 5);
        var list2 = CreateList(6, 7);

        var result = IntersectionOfTwoLinkedList.FindIntersection(list1, list2);

        Assert.Null(result);
    }

    [Fact]
    public void FindIntersection_SecondListLonger_NoIntersection_ReturnsNull()
    {
        // List1: 1 -> 2
        // List2: 3 -> 4 -> 5 -> 6 -> 7
        var list1 = CreateList(1, 2);
        var list2 = CreateList(3, 4, 5, 6, 7);

        var result = IntersectionOfTwoLinkedList.FindIntersection(list1, list2);

        Assert.Null(result);
    }

    [Fact]
    public void FindIntersection_IdenticalValues_DifferentNodeReferences_ReturnsNull()
    {
        // Verifies reference equality is tested, not value equality.
        // List1: 1 -> 2 -> 3
        // List2: 1 -> 2 -> 3 (distinct node objects)
        var list1 = CreateList(1, 2, 3);
        var list2 = CreateList(1, 2, 3);

        var result = IntersectionOfTwoLinkedList.FindIntersection(list1, list2);

        Assert.Null(result);
    }

    #endregion

    #region Same List / Head Intersection Tests

    [Fact]
    public void FindIntersection_SameSingleNode_ReturnsSameNode()
    {
        var node = new Node(10);

        var result = IntersectionOfTwoLinkedList.FindIntersection(node, node);

        Assert.NotNull(result);
        Assert.Same(node, result);
    }

    [Fact]
    public void FindIntersection_SameMultiNodeList_ReturnsHeadNode()
    {
        // Both pointers reference the same list head: 10 -> 20 -> 30
        var list = CreateList(10, 20, 30);

        var result = IntersectionOfTwoLinkedList.FindIntersection(list, list);

        Assert.NotNull(result);
        Assert.Same(list, result);
    }

    #endregion

    #region Equal Length Lists With Intersection

    [Fact]
    public void FindIntersection_EqualLength_IntersectionAtMiddle_ReturnsIntersectionNode()
    {
        // List1: 1 -> 2 -\
        //                 -> 100 -> 200
        // List2: 3 -> 4 -/
        var common = CreateList(100, 200);
        var list1 = CreateList(1, 2);
        var list2 = CreateList(3, 4);

        GetTail(list1).next = common;
        GetTail(list2).next = common;

        var result = IntersectionOfTwoLinkedList.FindIntersection(list1, list2);

        Assert.NotNull(result);
        Assert.Same(common, result);
    }

    [Fact]
    public void FindIntersection_EqualLength_IntersectionAtTail_ReturnsIntersectionNode()
    {
        // List1: 1 -> 2 -> 3 -\
        //                      -> 999
        // List2: 4 -> 5 -> 6 -/
        var commonTail = new Node(999);
        var list1 = CreateList(1, 2, 3);
        var list2 = CreateList(4, 5, 6);

        GetTail(list1).next = commonTail;
        GetTail(list2).next = commonTail;

        var result = IntersectionOfTwoLinkedList.FindIntersection(list1, list2);

        Assert.NotNull(result);
        Assert.Same(commonTail, result);
    }

    #endregion

    #region First List Longer Than Second List

    [Fact]
    public void FindIntersection_FirstListLonger_IntersectionInMiddle_ReturnsIntersectionNode()
    {
        // List1: 1 -> 2 -> 3 -> 4 -\
        //                           -> 50 -> 60
        // List2:           7 -> 8 -/
        // length1 = 6, length2 = 4 (diff = 2)
        var common = CreateList(50, 60);
        var list1 = CreateList(1, 2, 3, 4);
        var list2 = CreateList(7, 8);

        GetTail(list1).next = common;
        GetTail(list2).next = common;

        var result = IntersectionOfTwoLinkedList.FindIntersection(list1, list2);

        Assert.NotNull(result);
        Assert.Same(common, result);
    }

    [Fact]
    public void FindIntersection_FirstListLonger_IntersectionAtHeadOfSecondList_ReturnsIntersectionNode()
    {
        // List1: 1 -> 2 -> 3 -> 4 -> 5
        // List2:           3 -> 4 -> 5 (List2 starts at node 3 of List1)
        var list1 = CreateList(1, 2);
        var common = CreateList(3, 4, 5);
        GetTail(list1).next = common;

        var list2 = common; // Head of list2 is the intersection point

        var result = IntersectionOfTwoLinkedList.FindIntersection(list1, list2);

        Assert.NotNull(result);
        Assert.Same(common, result);
    }

    [Fact]
    public void FindIntersection_FirstListLonger_IntersectionAtTail_ReturnsIntersectionNode()
    {
        // List1: 1 -> 2 -> 3 -> 4 -\
        //                           -> 99
        // List2:                5 -/
        var commonTail = new Node(99);
        var list1 = CreateList(1, 2, 3, 4);
        var list2 = new Node(5);

        GetTail(list1).next = commonTail;
        list2.next = commonTail;

        var result = IntersectionOfTwoLinkedList.FindIntersection(list1, list2);

        Assert.NotNull(result);
        Assert.Same(commonTail, result);
    }

    [Fact]
    public void FindIntersection_FirstListLonger_SecondListIsSingleIntersectingNode_ReturnsIntersectionNode()
    {
        // List1: 1 -> 2 -> 3 (3 is single-node List2)
        // List2: 3
        var list1 = CreateList(1, 2);
        var singleSharedNode = new Node(3);
        GetTail(list1).next = singleSharedNode;

        var result = IntersectionOfTwoLinkedList.FindIntersection(list1, singleSharedNode);

        Assert.NotNull(result);
        Assert.Same(singleSharedNode, result);
    }

    #endregion

    #region Second List Longer Than First List

    [Fact]
    public void FindIntersection_SecondListLonger_IntersectionInMiddle_ReturnsIntersectionNode()
    {
        // List1:           7 -> 8 -\
        //                           -> 50 -> 60
        // List2: 1 -> 2 -> 3 -> 4 -/
        // length1 = 4, length2 = 6 (diff = 2)
        var common = CreateList(50, 60);
        var list1 = CreateList(7, 8);
        var list2 = CreateList(1, 2, 3, 4);

        GetTail(list1).next = common;
        GetTail(list2).next = common;

        var result = IntersectionOfTwoLinkedList.FindIntersection(list1, list2);

        Assert.NotNull(result);
        Assert.Same(common, result);
    }

    [Fact]
    public void FindIntersection_SecondListLonger_IntersectionAtHeadOfFirstList_ReturnsIntersectionNode()
    {
        // List1:           3 -> 4 -> 5
        // List2: 1 -> 2 -> 3 -> 4 -> 5 (List1 starts at node 3 of List2)
        var list2 = CreateList(1, 2);
        var common = CreateList(3, 4, 5);
        GetTail(list2).next = common;

        var list1 = common; // Head of list1 is the intersection point

        var result = IntersectionOfTwoLinkedList.FindIntersection(list1, list2);

        Assert.NotNull(result);
        Assert.Same(common, result);
    }

    [Fact]
    public void FindIntersection_SecondListLonger_IntersectionAtTail_ReturnsIntersectionNode()
    {
        // List1:                5 -\
        //                           -> 99
        // List2: 1 -> 2 -> 3 -> 4 -/
        var commonTail = new Node(99);
        var list1 = new Node(5);
        var list2 = CreateList(1, 2, 3, 4);

        list1.next = commonTail;
        GetTail(list2).next = commonTail;

        var result = IntersectionOfTwoLinkedList.FindIntersection(list1, list2);

        Assert.NotNull(result);
        Assert.Same(commonTail, result);
    }

    [Fact]
    public void FindIntersection_SecondListLonger_FirstListIsSingleIntersectingNode_ReturnsIntersectionNode()
    {
        // List1: 3
        // List2: 1 -> 2 -> 3 (3 is single-node List1)
        var list2 = CreateList(1, 2);
        var singleSharedNode = new Node(3);
        GetTail(list2).next = singleSharedNode;

        var result = IntersectionOfTwoLinkedList.FindIntersection(singleSharedNode, list2);

        Assert.NotNull(result);
        Assert.Same(singleSharedNode, result);
    }

    #endregion

    #region Helper Methods

    private static Node CreateList(params int[] values)
    {
        if (values.Length == 0)
        {
            throw new ArgumentException("Must supply at least one value to create a list.", nameof(values));
        }

        var head = new Node(values[0]);
        var current = head;
        for (int i = 1; i < values.Length; i++)
        {
            current.next = new Node(values[i]);
            current = current.next;
        }

        return head;
    }

    private static Node GetTail(Node head)
    {
        var current = head;
        while (current.next != null)
        {
            current = current.next;
        }

        return current;
    }

    #endregion
}
