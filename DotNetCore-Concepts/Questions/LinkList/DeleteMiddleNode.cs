using DotNetCore_Concepts.Models;

namespace DotNetCore_Concepts.Questions.LinkList
{
    /// <summary>
    /// CTCI 2.3 — Delete Middle Node:
    /// Given only access to a node in the middle of a singly linked list
    /// (i.e. not the head or the tail), delete that node from the list.
    ///
    /// Example:
    ///   Input:  a -> b -> [c] -> d -> e -> f   (given node c)
    ///   Output: a -> b -> d -> e -> f
    ///
    /// Constraint: You are NOT given access to the head of the list.
    /// </summary>
    internal static class DeleteMiddleNode
    {
        /// <summary>
        /// Deletes the given middle node by shifting all subsequent node data
        /// one position forward and removing the tail.
        ///
        /// Algorithm:
        ///   1. Walk from the given node to the tail, copying each successor's
        ///      data into the current node.
        ///   2. Remove the (now-duplicate) tail by setting the previous node's
        ///      next pointer to null.
        ///
        /// Time Complexity:  O(n) — traverses all nodes after the given node.
        /// Space Complexity: O(1) — uses only two pointer variables.
        /// </summary>
        /// <param name="middleNode">
        /// A node in the middle of the list (must not be null or the last node).
        /// </param>
        internal static void DeleteMiddleNodeFromLinkedList(Node middleNode)
        {
            if (middleNode == null || middleNode.next == null)
                return;

            Node? previousNode = null;
            while (middleNode.next != null)
            {
                middleNode.Data = middleNode.next.Data;
                previousNode = middleNode;
                middleNode = middleNode.next;
            }

            previousNode?.next = null;
        }

        /// <summary>
        /// Deletes the given middle node using the copy-and-bypass trick.
        ///
        /// Algorithm:
        ///   1. Copy the data from the next node into the given node.
        ///   2. Point the given node's next to the next node's next,
        ///      effectively removing the next node from the list.
        ///
        /// Time Complexity:  O(1) — only touches the given node and its successor.
        /// Space Complexity: O(1) — no extra memory used.
        /// </summary>
        /// <param name="middleNode">
        /// A node in the middle of the list (must not be null or the last node).
        /// </param>
        internal static void DeleteMiddleNodeFromLinkedListOptimized(Node middleNode)
        {
            // Cannot delete if node is null or is the last node
            if (middleNode == null || middleNode.next == null)
                return;

            // Copy data from the next node and bypass it
            middleNode.Data = middleNode.next.Data;
            middleNode.next = middleNode.next.next;
        }
    }
}
