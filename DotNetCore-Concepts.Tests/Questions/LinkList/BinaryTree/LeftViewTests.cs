using DotNetCore_Concepts.Models;
using DotNetCore_Concepts.Questions.LinkList.BinaryTree;
using Xunit;

namespace DotNetCore_Concepts.Tests.Questions.LinkList.BinaryTree;

/// <summary>
/// Unit tests for <see cref="LeftView.PrintLeftView(TreeNode?)"/>.
/// Covers:
/// - Null / empty tree
/// - Single node tree
/// - Left-skewed tree (only left children)
/// - Right-skewed tree (only right children)
/// - Perfect / full balanced binary tree
/// - Tree where right subtree is deeper than left subtree
/// - Zig-zag shaped trees
/// - Complex asymmetric tree structures
/// - Trees containing duplicate, negative, and zero values
/// </summary>
public class LeftViewTests
{
    [Fact]
    public void PrintLeftView_NullRoot_ReturnsEmptyList()
    {
        // Act
        var result = LeftView.PrintLeftView(null);

        // Assert
        Assert.NotNull(result);
        Assert.Empty(result);
    }

    [Fact]
    public void PrintLeftView_SingleNode_ReturnsSingleElement()
    {
        // Tree:
        //    42
        var root = CreateNode(42);

        var result = LeftView.PrintLeftView(root);

        Assert.Equal([42], result);
    }

    [Fact]
    public void PrintLeftView_LeftSkewedTree_ReturnsAllNodesInOrder()
    {
        // Tree:
        //       1
        //      /
        //     2
        //    /
        //   3
        //  /
        // 4
        var root = CreateNode(1,
            left: CreateNode(2,
                left: CreateNode(3,
                    left: CreateNode(4))));

        var result = LeftView.PrintLeftView(root);

        Assert.Equal([1, 2, 3, 4], result);
    }

    [Fact]
    public void PrintLeftView_RightSkewedTree_ReturnsAllNodesInOrder()
    {
        // Tree:
        // 1
        //  \
        //   2
        //    \
        //     3
        //      \
        //       4
        var root = CreateNode(1,
            right: CreateNode(2,
                right: CreateNode(3,
                    right: CreateNode(4))));

        var result = LeftView.PrintLeftView(root);

        Assert.Equal([1, 2, 3, 4], result);
    }

    [Fact]
    public void PrintLeftView_FullBalancedTree_ReturnsLeftmostBranch()
    {
        // Tree:
        //         1
        //       /   \
        //      2     3
        //     / \   / \
        //    4   5 6   7
        var root = CreateNode(1,
            left: CreateNode(2,
                left: CreateNode(4),
                right: CreateNode(5)),
            right: CreateNode(3,
                left: CreateNode(6),
                right: CreateNode(7)));

        var result = LeftView.PrintLeftView(root);

        Assert.Equal([1, 2, 4], result);
    }

    [Fact]
    public void PrintLeftView_RightSubtreeDeeperThanLeftSubtree_ReturnsVisibleNodesFromRightSubtree()
    {
        // Tree:
        //         1
        //       /   \
        //      2     3
        //           / \
        //          4   5
        //             /
        //            6
        // Level 1: 1
        // Level 2: 2
        // Level 3: 4 (left child of 3, visible because 2 has no children)
        // Level 4: 6 (left child of 5, visible because it's the only node at depth 4)
        var root = CreateNode(1,
            left: CreateNode(2),
            right: CreateNode(3,
                left: CreateNode(4),
                right: CreateNode(5,
                    left: CreateNode(6))));

        var result = LeftView.PrintLeftView(root);

        Assert.Equal([1, 2, 4, 6], result);
    }

    [Fact]
    public void PrintLeftView_ZigZagStartingLeft_ReturnsAllNodes()
    {
        // Tree:
        //       1
        //      /
        //     2
        //      \
        //       3
        //      /
        //     4
        var root = CreateNode(1,
            left: CreateNode(2,
                right: CreateNode(3,
                    left: CreateNode(4))));

        var result = LeftView.PrintLeftView(root);

        Assert.Equal([1, 2, 3, 4], result);
    }

    [Fact]
    public void PrintLeftView_ZigZagStartingRight_ReturnsAllNodes()
    {
        // Tree:
        //   1
        //    \
        //     2
        //    /
        //   3
        //    \
        //     4
        var root = CreateNode(1,
            right: CreateNode(2,
                left: CreateNode(3,
                    right: CreateNode(4))));

        var result = LeftView.PrintLeftView(root);

        Assert.Equal([1, 2, 3, 4], result);
    }

    [Fact]
    public void PrintLeftView_AsymmetricTreeWithMissingLeftNodes_ReturnsFirstNodeAtEachLevel()
    {
        // Tree:
        //          10
        //        /    \
        //       20     30
        //        \       \
        //         40      50
        //        /
        //       60
        // Level 1: 10
        // Level 2: 20
        // Level 3: 40
        // Level 4: 60
        var root = CreateNode(10,
            left: CreateNode(20,
                right: CreateNode(40,
                    left: CreateNode(60))),
            right: CreateNode(30,
                right: CreateNode(50)));

        var result = LeftView.PrintLeftView(root);

        Assert.Equal([10, 20, 40, 60], result);
    }

    [Fact]
    public void PrintLeftView_TreeWithDuplicateValues_CorrectlyCapturesValues()
    {
        // Tree:
        //         5
        //       /   \
        //      5     5
        //     /       \
        //    5         5
        var root = CreateNode(5,
            left: CreateNode(5,
                left: CreateNode(5)),
            right: CreateNode(5,
                right: CreateNode(5)));

        var result = LeftView.PrintLeftView(root);

        Assert.Equal([5, 5, 5], result);
    }

    [Fact]
    public void PrintLeftView_TreeWithNegativeAndZeroValues_CorrectlyReturnsValues()
    {
        // Tree:
        //        -10
        //       /    \
        //      0      20
        //     / \    /  \
        //   -5   8  15  -30
        var root = CreateNode(-10,
            left: CreateNode(0,
                left: CreateNode(-5),
                right: CreateNode(8)),
            right: CreateNode(20,
                left: CreateNode(15),
                right: CreateNode(-30)));

        var result = LeftView.PrintLeftView(root);

        Assert.Equal([-10, 0, -5], result);
    }

    #region Helper Methods

    private static TreeNode CreateNode(int data, TreeNode? left = null, TreeNode? right = null)
    {
        return new TreeNode
        {
            data = data,
            left = left,
            right = right
        };
    }

    #endregion
}
