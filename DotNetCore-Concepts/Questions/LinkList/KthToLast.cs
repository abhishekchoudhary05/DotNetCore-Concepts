using DotNetCore_Concepts.Models;

namespace DotNetCore_Concepts.Questions.LinkList
{
    /// <summary>
    /// Provides methods to find the kth to last node of a singly linked list.
    /// (1-based indexing: k = 1 returns the last node).
    /// </summary>
    internal static class KthToLast
    {
        /// <summary>
        /// Finds the kth to last node using a two-pass approach.
        /// First pass counts the total nodes; second pass advances to (total - k).
        /// </summary>
        /// <param name="head">The head node of the linked list.</param>
        /// <param name="k">1-based position from the end (k = 1 is the last element).</param>
        /// <returns>The kth to last node, or null if k is invalid or out of bounds.</returns>
        /// <exception cref="ArgumentNullException">Thrown when head is null.</exception>
        /// <remarks>
        /// Time Complexity: O(N) — two traversals through the list.
        /// Space Complexity: O(1) — constant auxiliary space.
        /// </remarks>
        internal static Node? GetNode(Node head, int k)
        {
            ArgumentNullException.ThrowIfNull(head);

            // Invalid index (0 or negative)
            if (k <= 0)
                return null;

            // Pass 1: Count total number of nodes
            Node? start = head;
            int totalNode = 0;
            while (start != null)
            {
                totalNode++;
                start = start.next;
            }

            // k is greater than the total number of nodes in the list
            if (k > totalNode)
                return null;

            // Pass 2: Traverse (totalNode - k) steps from head to reach the kth to last node
            start = head;
            int diff = totalNode - k;
            while (start != null && diff > 0)
            {
                start = start.next;
                diff--;
            }

            return start;
        }

        /// <summary>
        /// Finds the kth to last node using a single-pass two-pointer (runner) approach.
        /// Advances a 'fast' pointer k nodes ahead, then moves both 'fast' and 'slow' until 'fast' reaches null.
        /// </summary>
        /// <param name="head">The head node of the linked list.</param>
        /// <param name="k">1-based position from the end (k = 1 is the last element).</param>
        /// <returns>The kth to last node, or null if k is invalid or out of bounds.</returns>
        /// <exception cref="ArgumentNullException">Thrown when head is null.</exception>
        /// <remarks>
        /// Time Complexity: O(N) — single pass through the list.
        /// Space Complexity: O(1) — constant auxiliary space.
        /// </remarks>
        internal static Node? GetNodeOptimized(Node head, int k)
        {
            ArgumentNullException.ThrowIfNull(head);

            // Invalid index (0 or negative)
            if (k <= 0)
                return null;

            // Advance the fast pointer k steps ahead
            Node? fast = head;
            while (fast != null && k > 0)
            {
                fast = fast.next;
                k--;
            }

            // If fast became null before k steps were taken, k is out of bounds
            if (fast == null && k > 0)
                return null;

            // Move both pointers until fast reaches the end; slow will point to the kth to last node
            Node? slow = head;
            while (fast != null)
            {
                fast = fast.next;
                slow = slow!.next;
            }

            return slow;
        }
    }
}
