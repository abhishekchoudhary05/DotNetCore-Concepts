using DotNetCore_Concepts.Models;
using DotNetCore_Concepts.Questions.LinkList.BinaryTree;

namespace DotNetCore_Concepts.Tests.Questions.LinkList.BinaryTree;

/// <summary>Tests the visible rightmost node at each level of a binary tree.</summary>
public class RightViewTests
{
    [Fact]
    public void PrintRightView_NullRoot_ReturnsEmptyList()
    {
        var result = RightView.PrintRightView(null);

        Assert.NotNull(result);
        Assert.Empty(result);
    }

    [Fact]
    public void PrintRightView_SingleNode_ReturnsRoot()
    {
        var result = RightView.PrintRightView(CreateNode(42));

        Assert.Equal([42], result);
    }

    [Fact]
    public void PrintRightView_LeftSkewedTree_ReturnsOnlyNodeAtEachLevel()
    {
        var root = CreateNode(1,
            left: CreateNode(2,
                left: CreateNode(3,
                    left: CreateNode(4))));

        var result = RightView.PrintRightView(root);

        Assert.Equal([1, 2, 3, 4], result);
    }

    [Fact]
    public void PrintRightView_RightSkewedTree_ReturnsOnlyNodeAtEachLevel()
    {
        var root = CreateNode(1,
            right: CreateNode(2,
                right: CreateNode(3,
                    right: CreateNode(4))));

        var result = RightView.PrintRightView(root);

        Assert.Equal([1, 2, 3, 4], result);
    }

    [Fact]
    public void PrintRightView_FullBalancedTree_ReturnsRightmostNodeAtEachLevel()
    {
        var root = CreateNode(1,
            left: CreateNode(2, CreateNode(4), CreateNode(5)),
            right: CreateNode(3, CreateNode(6), CreateNode(7)));

        var result = RightView.PrintRightView(root);

        Assert.Equal([1, 3, 7], result);
    }

    [Fact]
    public void PrintRightView_LeftSubtreeDeeperThanRight_ReturnsVisibleNodesFromLeftSubtree()
    {
        var root = CreateNode(1,
            left: CreateNode(2,
                left: CreateNode(4),
                right: CreateNode(5,
                    right: CreateNode(6))),
            right: CreateNode(3));

        var result = RightView.PrintRightView(root);

        Assert.Equal([1, 3, 5, 6], result);
    }

    [Fact]
    public void PrintRightView_ZigZagTree_ReturnsNodeAtEachLevel()
    {
        var root = CreateNode(1,
            right: CreateNode(2,
                left: CreateNode(3,
                    right: CreateNode(4))));

        var result = RightView.PrintRightView(root);

        Assert.Equal([1, 2, 3, 4], result);
    }

    [Fact]
    public void PrintRightView_AsymmetricTree_ReturnsRightmostNodeAtEachLevel()
    {
        // At depth 3, node 60 is visible because the rightmost branch ends at depth 2.
        var root = CreateNode(10,
            left: CreateNode(20,
                left: CreateNode(40,
                    left: CreateNode(60))),
            right: CreateNode(30,
                right: CreateNode(50)));

        var result = RightView.PrintRightView(root);

        Assert.Equal([10, 30, 50, 60], result);
    }

    [Fact]
    public void PrintRightView_DuplicateValues_ReturnsOneValuePerLevel()
    {
        var root = CreateNode(5,
            left: CreateNode(5, left: CreateNode(5)),
            right: CreateNode(5, right: CreateNode(5)));

        var result = RightView.PrintRightView(root);

        Assert.Equal([5, 5, 5], result);
    }

    [Fact]
    public void PrintRightView_NegativeAndZeroValues_PreservesNodeValues()
    {
        var root = CreateNode(-10,
            left: CreateNode(0, CreateNode(-5), CreateNode(8)),
            right: CreateNode(20, CreateNode(15), CreateNode(-30)));

        var result = RightView.PrintRightView(root);

        Assert.Equal([-10, 20, -30], result);
    }

    private static TreeNode CreateNode(int data, TreeNode? left = null, TreeNode? right = null)
    {
        return new TreeNode { data = data, left = left, right = right };
    }
}
