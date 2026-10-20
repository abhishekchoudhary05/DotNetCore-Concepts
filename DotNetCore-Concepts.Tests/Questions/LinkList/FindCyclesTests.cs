using Xunit;
using DotNetCore_Concepts.Models;
using DotNetCore_Concepts.Questions.LinkList;

namespace DotNetCore_Concepts.Tests.Questions.LinkList;

/// <summary>
/// Tests for FindCycles which detects cycles in a linked list using Floyd's Tortoise and Hare algorithm.
/// Algorithm:
/// - Uses two pointers: slow (moves one step) and fast (moves two steps)
/// - If slow and fast pointers meet, a cycle exists
/// - If fast pointer reaches null, no cycle exists
/// - Time complexity: O(n) where n is list length
/// - Space complexity: O(1) (only two pointers)
/// </summary>
public class FindCyclesTests
{
    /// <summary>
    /// Tests that null input throws ArgumentNullException.
    /// </summary>
    [Fact]
    public void DetectCycles_NullStart_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => FindCycles.DetectCycles(null));
    }

    /// <summary>
    /// Tests single node without a cycle - returns false.
    /// </summary>
    [Fact]
    public void DetectCycles_SingleNode_NoCycle_ReturnsFalse()
    {
        var node = new Node(1);
        bool result = FindCycles.DetectCycles(node);
        Assert.False(result);
    }

    /// <summary>
    /// Tests single node with self-referencing cycle - returns true.
    /// </summary>
    [Fact]
    public void DetectCycles_SingleNode_SelfCycle_ReturnsTrue()
    {
        var node = new Node(1);
        node.next = node;
        bool result = FindCycles.DetectCycles(node);
        Assert.True(result);
    }

    /// <summary>
    /// Tests multi-node list without a cycle - returns false.
    /// </summary>
    [Fact]
    public void DetectCycles_MultiNode_NoCycle_ReturnsFalse()
    {
        var n1 = new Node(1);
        var n2 = new Node(2);
        var n3 = new Node(3);
        n1.next = n2;
        n2.next = n3;
        n3.next = null;

        bool result = FindCycles.DetectCycles(n1);
        Assert.False(result);
    }

    /// <summary>
    /// Tests multi-node list with a cycle (n4 points back to n2) - returns true.
    /// </summary>
    [Fact]
    public void DetectCycles_MultiNode_WithCycle_ReturnsTrue()
    {
        var n1 = new Node(1);
        var n2 = new Node(2);
        var n3 = new Node(3);
        var n4 = new Node(4);

        n1.next = n2;
        n2.next = n3;
        n3.next = n4;
        n4.next = n2; // cycle: n4 points back to n2

        bool result = FindCycles.DetectCycles(n1);
        Assert.True(result);
    }

    /// <summary>
    /// Tests two-node cycle (n1 → n2 → n1) - returns true.
    /// </summary>
    [Fact]
    public void DetectCycles_TwoNodeCycle_ReturnsTrue()
    {
        var n1 = new Node(1);
        var n2 = new Node(2);
        n1.next = n2;
        n2.next = n1; // cycle: n2 points back to n1

        bool result = FindCycles.DetectCycles(n1);
        Assert.True(result);
    }
}
